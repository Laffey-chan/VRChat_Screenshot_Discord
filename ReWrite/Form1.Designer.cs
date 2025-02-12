namespace ReWrite
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabControl1 = new TabControl();
            TabPage1 = new TabPage();
            ListBox1 = new ListBox();
            Button1 = new Button();
            Label2 = new Label();
            UpdateLinkButton = new Button();
            ComboBoxLanguage = new ComboBox();
            TextBox1 = new TextBox();
            Label1 = new Label();
            TabPage2 = new TabPage();
            DataGridView1 = new DataGridView();
            TabControl1.SuspendLayout();
            TabPage1.SuspendLayout();
            TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // TabControl1
            // 
            TabControl1.Controls.Add(TabPage1);
            TabControl1.Controls.Add(TabPage2);
            TabControl1.Dock = DockStyle.Fill;
            TabControl1.Location = new Point(0, 0);
            TabControl1.Name = "TabControl1";
            TabControl1.SelectedIndex = 0;
            TabControl1.Size = new Size(668, 321);
            TabControl1.TabIndex = 10;
            // 
            // TabPage1
            // 
            TabPage1.BackColor = Color.Transparent;
            TabPage1.Controls.Add(ListBox1);
            TabPage1.Controls.Add(Button1);
            TabPage1.Controls.Add(Label2);
            TabPage1.Controls.Add(UpdateLinkButton);
            TabPage1.Controls.Add(ComboBoxLanguage);
            TabPage1.Controls.Add(TextBox1);
            TabPage1.Controls.Add(Label1);
            TabPage1.Location = new Point(4, 24);
            TabPage1.Name = "TabPage1";
            TabPage1.Padding = new Padding(3);
            TabPage1.Size = new Size(660, 293);
            TabPage1.TabIndex = 0;
            TabPage1.Text = "TabPage1";
            // 
            // ListBox1
            // 
            ListBox1.FormattingEnabled = true;
            ListBox1.ItemHeight = 15;
            ListBox1.Location = new Point(3, 94);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(657, 199);
            ListBox1.TabIndex = 6;
            // 
            // Button1
            // 
            Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button1.AutoSize = true;
            Button1.Location = new Point(550, 60);
            Button1.Name = "Button1";
            Button1.Size = new Size(104, 25);
            Button1.TabIndex = 3;
            Button1.Text = "監視開始";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(11, 45);
            Label2.Name = "Label2";
            Label2.Size = new Size(124, 15);
            Label2.TabIndex = 7;
            Label2.Text = "VRChat画像フォルダパス";
            // 
            // UpdateLinkButton
            // 
            UpdateLinkButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateLinkButton.AutoSize = true;
            UpdateLinkButton.Location = new Point(549, 6);
            UpdateLinkButton.Name = "UpdateLinkButton";
            UpdateLinkButton.Size = new Size(105, 25);
            UpdateLinkButton.TabIndex = 2;
            UpdateLinkButton.Text = "更新をダウンロード";
            UpdateLinkButton.UseVisualStyleBackColor = true;
            // 
            // ComboBoxLanguage
            // 
            ComboBoxLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComboBoxLanguage.FormattingEnabled = true;
            ComboBoxLanguage.Location = new Point(353, 7);
            ComboBoxLanguage.Name = "ComboBoxLanguage";
            ComboBoxLanguage.Size = new Size(150, 23);
            ComboBoxLanguage.TabIndex = 1;
            ComboBoxLanguage.SelectedIndexChanged += ComboBoxLanguage_SelectedIndexChanged;
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(3, 60);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(534, 23);
            TextBox1.TabIndex = 5;
            // 
            // Label1
            // 
            Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label1.Location = new Point(195, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(152, 19);
            Label1.TabIndex = 8;
            Label1.Text = "言語/Language/语言/언어";
            Label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TabPage2
            // 
            TabPage2.Controls.Add(DataGridView1);
            TabPage2.Location = new Point(4, 24);
            TabPage2.Name = "TabPage2";
            TabPage2.Padding = new Padding(3);
            TabPage2.Size = new Size(660, 293);
            TabPage2.TabIndex = 1;
            TabPage2.Text = "TabPage2";
            TabPage2.UseVisualStyleBackColor = true;
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToOrderColumns = true;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Dock = DockStyle.Fill;
            DataGridView1.Location = new Point(3, 3);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.Size = new Size(654, 287);
            DataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 321);
            Controls.Add(TabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            TabControl1.ResumeLayout(false);
            TabPage1.ResumeLayout(false);
            TabPage1.PerformLayout();
            TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public TabControl TabControl1;
        internal TabPage TabPage1;
        internal ListBox ListBox1;
        internal Button Button1;
        internal Label Label2;
        internal Button UpdateLinkButton;
        internal ComboBox ComboBoxLanguage;
        internal TextBox TextBox1;
        internal Label Label1;
        internal TabPage TabPage2;
        internal DataGridView DataGridView1;
    }
}
