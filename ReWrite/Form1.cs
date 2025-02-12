using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ReWrite
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private HttpClient client = new HttpClient();
        private string currentLanguage = "ja";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentLanguage = LoadLanguageSelection();
            if (string.IsNullOrEmpty(currentLanguage))
                currentLanguage = "ja";

            TextBox1.Text = ConfigurationManager.AppSettings["FolderPath"];

            LoadDataGridView();
            LoadLanguage();
            updateUIForLanguage();
        }

        private void LoadLanguage()
        {
            ComboBoxLanguage.Items.Clear();

            ComboBoxLanguage.Items.Add(GetLocalizedString("Language_Japanese"));
            ComboBoxLanguage.Items.Add(GetLocalizedString("Language_English"));
            ComboBoxLanguage.Items.Add(GetLocalizedString("Language_Korean"));
            ComboBoxLanguage.Items.Add(GetLocalizedString("Language_Chinese"));

            switch (currentLanguage)
            {
                case "ja":
                    ComboBoxLanguage.SelectedIndex = 0;
                    break;
                case "en":
                    ComboBoxLanguage.SelectedIndex = 1;
                    break;
                case "ko":
                    ComboBoxLanguage.SelectedIndex = 2;
                    break;
                case "zh":
                    ComboBoxLanguage.SelectedIndex = 3;
                    break;
                default:
                    ComboBoxLanguage.SelectedIndex = 0;
                    break;
            }
        }
        private string GetLocalizedString(string key)
        {
            string localizedString;
            switch (currentLanguage)
            {
                case "ja":
                    localizedString = Resources.ResourceManager.GetString(key, new System.Globalization.CultureInfo("ja"));
                    break;
                case "en":
                    localizedString = Resources.ResourceManager.GetString(key, new System.Globalization.CultureInfo("en"));
                    break;
                case "ko":
                    localizedString = Resources.ResourceManager.GetString(key, new System.Globalization.CultureInfo("ko"));
                    break;
                case "zh":
                    localizedString = Resources.ResourceManager.GetString(key, new System.Globalization.CultureInfo("zh"));
                    break;
                default:
                    localizedString = Resources.ResourceManager.GetString(key, new System.Globalization.CultureInfo("ja"));
                    break;
            }

            if (localizedString == null)
            {
                localizedString = "ÉäÉ\Å[ÉXÇ™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩ: " + key;
            }

            return localizedString;
        }
        private void SaveSettings(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void SaveLanguageSelection(string language)
        {
            SaveSettings("language", language);
        }

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxLanguage.SelectedIndex)
            {
                case 0:
                    currentLanguage = "ja";
                    break;
                case 1:
                    currentLanguage = "en";
                    break;
                case 2:
                    currentLanguage = "ko";
                    break;
                case 3:
                    currentLanguage = "zh";
                    break;
                default:
                    currentLanguage = "ja";
                    break;
            }

            SaveLanguageSelection(currentLanguage);
            updateUIForLanguage();
            DataGridView1.Columns["onoff"].HeaderText = GetLocalizedString("onoff");
            DataGridView1.Columns["servername"].HeaderText = GetLocalizedString("servername");
        }
        private void updateUIForLanguage()
        {
            Label1.Text = GetLocalizedString("Language");
            Label2.Text = GetLocalizedString("Label2");
            Button1.Text = GetLocalizedString("start");
            UpdateLinkButton.Text = GetLocalizedString("UpdateDownloadButtonText");
            TabControl1.TabPages[0].Text = GetLocalizedString("Page1");
            TabControl1.TabPages[1].Text = GetLocalizedString("Page2");
        }
        private string LoadLanguageSelection()
        {
            return ConfigurationManager.AppSettings["language"];
        }

        private void LoadDataGridView()
        {
            string filepath = Path.Combine(Application.StartupPath, "DataGridViewData.json");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("onoff", typeof(bool));
            dataTable.Columns.Add("servername", typeof(string));
            dataTable.Columns.Add("WebHookURL", typeof(string));

            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
                foreach (var row in data)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow["onoff"] = Convert.ToBoolean(row["onoff"]);
                    dataRow["servername"] = Convert.ToString(row["servername"]);
                    dataRow["WebHookURL"] = Convert.ToString(row["WebHookURL"]);
                    dataTable.Rows.Add(dataRow);
                }
            }

            DataGridView1.DataSource = dataTable;

            DataGridView1.Columns["onoff"].HeaderText = GetLocalizedString("onoff");
            DataGridView1.Columns["servername"].HeaderText = GetLocalizedString("servername");
            DataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void SaveDataGridView()
        {
            string filepath = Path.Combine(Application.StartupPath, "DataGridViewData.json");
            var dataTable = new DataTable();
            dataTable.Columns.Add("onoff", typeof(Boolean));
            dataTable.Columns.Add("servername", typeof(String));
            dataTable.Columns.Add("WebHookURL", typeof(String));

            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var datarow = dataTable.NewRow();
                    datarow["onoff"] = row.Cells["onoff"].Value;
                    datarow["servername"] = row.Cells["servername"].Value;
                    datarow["WebHookURL"] = row.Cells["WebHookURL"].Value;
                    dataTable.Rows.Add(datarow);
                }
            }

            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

        private void InvokeIfRequired(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private async void OnNewImageCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                string baseLogFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).Replace("Local", "LocalLow"), "VRChat", "VRChat");
                if (!Directory.Exists(baseLogFolder))
                    InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("LogFolderNotFoundMessage") + ": " + baseLogFolder));
                var logFiles = Directory.GetFiles(baseLogFolder, "output_log_*.txt", SearchOption.AllDirectories);
                if (logFiles.Length == 0)
                    InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("LogFilesNotFoundMessage")));
                var latestLog = logFiles.OrderByDescending(f => File.GetLastWriteTime(f)).FirstOrDefault();

                if (latestLog is not null)
                {
                    string worldName = ExtractWorldNameFromLog(latestLog);
                    if (!string.IsNullOrEmpty(worldName))
                    {
                        foreach (DataGridViewRow row in DataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["onoff"].Value))
                            {
                                if (!row.IsNewRow && (bool)row.Cells["onoff"].Value)
                                {
                                    string serverName = row.Cells["servername"].Value.ToString();
                                    string webhookUrl = row.Cells["WebHookURL"].Value.ToString();
                                    await (SendToDiscord(webhookUrl, worldName, e.FullPath, serverName));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("ErrorOccuredMessage") + ": " + ex.Message));
            }
        }

        private string ExtractWorldNameFromLog(string logPath)
        {
            try
            {
                using (var fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        string[] lines = reader.ReadToEnd().Split(Environment.NewLine);
                        foreach (var line in lines.Reverse())
                        {
                            if (line.Contains("Entering Room:"))
                            {
                                var match = Regex.Match(line, "Entering Room: (.+)");
                                if (match.Success)
                                {
                                    var worldName = match.Groups[1].Value;
                                    InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("WorldNameDetectedMessage") + ": " + worldName));
                                    return worldName;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("ErrorOccuredMessage") + ": " + ex.Message));
            }
            return string.Empty;
        }

        private async Task SendToDiscord(string webhookUrl, string worldName, string imagePath, string serverName)
        {
            try
            {
                string captureTime = File.GetCreationTime(imagePath).ToString("yyyy-MM-dd HH:mm:ss");
                var jsonpayload = new
                {
                    content = GetLocalizedString("NewImageUploadedMessage"),
                    embeds = new[]
                    {
                        new
                        {
                            title =GetLocalizedString("ImageInformationTitle"),
                            fields = new[]
                            {
                                new
                                {
                                    name = GetLocalizedString("WorldNameLabel"),
                                    value = worldName,
                                    inline = true
                                },
                                new
                                {
                                    name = GetLocalizedString("CaptureTimeLabel"),
                                    value = captureTime,
                                    inline = true
                                }
                            },
                        }
                    }
                };

                string json = JsonConvert.SerializeObject(jsonpayload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var boundary = "----WebKitFormBoundary" + DateTime.Now.Ticks.ToString("x");
                var multipartContent = new MultipartFormDataContent(boundary);
                multipartContent.Add(content, "payload_json");
                multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "file", Path.GetFileName(imagePath));

                var response = await client.PostAsync(webhookUrl, multipartContent);
                if (response.IsSuccessStatusCode)
                {
                    InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("MessageSentSuccessfully") + ": " + serverName));
                }
                else
                {
                    InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("MessageSendingFailed") + ": " + serverName));
                }
            }
            catch (Exception ex)
            {
                InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("DiscordSendErrorMessage") + ": " + serverName + " - " + ex.Message));
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string folderPath = TextBox1.Text;
            var webhookUrls = new List<string>();

            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (!row.IsNewRow && (bool)row.Cells["onoff"].Value)
                {
                    webhookUrls.Add(row.Cells["WebHookURL"].Value.ToString());
                }
            }

            if (string.IsNullOrWhiteSpace(folderPath) || webhookUrls.Count == 0)
            {
                MessageBox.Show(GetLocalizedString("FolderPathInputMessage"));
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show(GetLocalizedString("FolderNotExistMessage"));
                return;
            }

            SaveSettings("FolderPath", folderPath);

            watcher = new FileSystemWatcher();
            watcher.Path = folderPath;
            watcher.Filter = "*.png";
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            watcher.Created += OnNewImageCreated;
            watcher.EnableRaisingEvents = true;

            InvokeIfRequired(() => ListBox1.Items.Add(GetLocalizedString("StartWatchingMessage") + ": " + folderPath));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (watcher != null)
            {
                watcher.Dispose();
            }
            if (client != null)
            {
                client.Dispose();
            }
            SaveDataGridView();
        }

    }
}
