namespace BasicFormVersion
{
    partial class SICA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SICA));
            this.CreateImage = new System.Windows.Forms.Button();
            this.AddAgent = new System.Windows.Forms.Button();
            this.SetOutput = new System.Windows.Forms.Button();
            this.AgentViewList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OutputList = new System.Windows.Forms.ListView();
            this.SlackCheck = new System.Windows.Forms.CheckBox();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.PasswordFocus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateImage
            // 
            this.CreateImage.AccessibleName = "cmdCombine";
            this.CreateImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateImage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CreateImage.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.CreateImage.FlatAppearance.BorderSize = 6;
            this.CreateImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.CreateImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateImage.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateImage.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CreateImage.Location = new System.Drawing.Point(848, 456);
            this.CreateImage.Margin = new System.Windows.Forms.Padding(0);
            this.CreateImage.Name = "CreateImage";
            this.CreateImage.Size = new System.Drawing.Size(384, 80);
            this.CreateImage.TabIndex = 0;
            this.CreateImage.Text = "CREATE SUPER IMAGE";
            this.CreateImage.UseVisualStyleBackColor = false;
            this.CreateImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddAgent
            // 
            this.AddAgent.AccessibleName = "addDirectory";
            this.AddAgent.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AddAgent.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.AddAgent.FlatAppearance.BorderSize = 6;
            this.AddAgent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.AddAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAgent.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAgent.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.AddAgent.Location = new System.Drawing.Point(32, 32);
            this.AddAgent.Margin = new System.Windows.Forms.Padding(0);
            this.AddAgent.Name = "AddAgent";
            this.AddAgent.Size = new System.Drawing.Size(384, 80);
            this.AddAgent.TabIndex = 1;
            this.AddAgent.Text = "ADD INPUT DIRECTORY";
            this.AddAgent.UseVisualStyleBackColor = false;
            this.AddAgent.Click += new System.EventHandler(this.button2_Click);
            // 
            // SetOutput
            // 
            this.SetOutput.AccessibleName = "SetOuput";
            this.SetOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SetOutput.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SetOutput.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.SetOutput.FlatAppearance.BorderSize = 6;
            this.SetOutput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.SetOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetOutput.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetOutput.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SetOutput.Location = new System.Drawing.Point(848, 32);
            this.SetOutput.Margin = new System.Windows.Forms.Padding(0);
            this.SetOutput.Name = "SetOutput";
            this.SetOutput.Size = new System.Drawing.Size(384, 80);
            this.SetOutput.TabIndex = 2;
            this.SetOutput.Text = "SET OUTPUT DIRECTORY";
            this.SetOutput.UseVisualStyleBackColor = false;
            this.SetOutput.Click += new System.EventHandler(this.SetOutput_Click);
            // 
            // AgentViewList
            // 
            this.AgentViewList.AccessibleName = "AgentView";
            this.AgentViewList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.AgentViewList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AgentViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.AgentViewList.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgentViewList.ForeColor = System.Drawing.Color.White;
            this.AgentViewList.FullRowSelect = true;
            this.AgentViewList.GridLines = true;
            this.AgentViewList.HideSelection = false;
            this.AgentViewList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.AgentViewList.Location = new System.Drawing.Point(32, 136);
            this.AgentViewList.Margin = new System.Windows.Forms.Padding(0);
            this.AgentViewList.Name = "AgentViewList";
            this.AgentViewList.Size = new System.Drawing.Size(384, 400);
            this.AgentViewList.TabIndex = 3;
            this.AgentViewList.UseCompatibleStateImageBehavior = false;
            this.AgentViewList.View = System.Windows.Forms.View.List;
            this.AgentViewList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 256;
            // 
            // OutputList
            // 
            this.OutputList.AccessibleName = "OutputView";
            this.OutputList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OutputList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputList.Font = new System.Drawing.Font("Helvetica LT Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputList.ForeColor = System.Drawing.Color.White;
            this.OutputList.HideSelection = false;
            this.OutputList.Location = new System.Drawing.Point(848, 136);
            this.OutputList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OutputList.Name = "OutputList";
            this.OutputList.Size = new System.Drawing.Size(384, 80);
            this.OutputList.TabIndex = 4;
            this.OutputList.UseCompatibleStateImageBehavior = false;
            this.OutputList.View = System.Windows.Forms.View.List;
            // 
            // SlackCheck
            // 
            this.SlackCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.SlackCheck.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.SlackCheck.FlatAppearance.BorderSize = 6;
            this.SlackCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SlackCheck.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlackCheck.ForeColor = System.Drawing.Color.White;
            this.SlackCheck.Location = new System.Drawing.Point(717, 456);
            this.SlackCheck.Name = "SlackCheck";
            this.SlackCheck.Size = new System.Drawing.Size(128, 80);
            this.SlackCheck.TabIndex = 5;
            this.SlackCheck.Text = "Notify Slack";
            this.SlackCheck.UseVisualStyleBackColor = true;
            this.SlackCheck.CheckedChanged += new System.EventHandler(this.SlackCheck_CheckedChanged);
            // 
            // PasswordField
            // 
            this.PasswordField.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PasswordField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordField.ForeColor = System.Drawing.Color.White;
            this.PasswordField.Location = new System.Drawing.Point(864, 373);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(16);
            this.PasswordField.MaximumSize = new System.Drawing.Size(364, 80);
            this.PasswordField.MaxLength = 32;
            this.PasswordField.MinimumSize = new System.Drawing.Size(364, 0);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '*';
            this.PasswordField.Size = new System.Drawing.Size(364, 22);
            this.PasswordField.TabIndex = 6;
            this.PasswordField.TextChanged += new System.EventHandler(this.PasswordField_TextChanged);
            // 
            // PasswordFocus
            // 
            this.PasswordFocus.AccessibleName = "SetOuput";
            this.PasswordFocus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordFocus.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PasswordFocus.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.PasswordFocus.FlatAppearance.BorderSize = 6;
            this.PasswordFocus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.PasswordFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordFocus.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordFocus.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PasswordFocus.Location = new System.Drawing.Point(848, 240);
            this.PasswordFocus.Margin = new System.Windows.Forms.Padding(0);
            this.PasswordFocus.Name = "PasswordFocus";
            this.PasswordFocus.Size = new System.Drawing.Size(384, 80);
            this.PasswordFocus.TabIndex = 7;
            this.PasswordFocus.Text = "INPUT PASSWORD";
            this.PasswordFocus.UseVisualStyleBackColor = false;
            this.PasswordFocus.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.AccessibleName = "SetOuput";
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.button1.FlatAppearance.BorderSize = 6;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(428, 456);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 80);
            this.button1.TabIndex = 8;
            this.button1.Text = "CLEAR INPUTS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // SICA
            // 
            this.AccessibleName = "SICA";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 641);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordFocus);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.SlackCheck);
            this.Controls.Add(this.OutputList);
            this.Controls.Add(this.AgentViewList);
            this.Controls.Add(this.SetOutput);
            this.Controls.Add(this.AddAgent);
            this.Controls.Add(this.CreateImage);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Coral;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SICA";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SICA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateImage;
        private System.Windows.Forms.Button AddAgent;
        private System.Windows.Forms.Button SetOutput;
        private System.Windows.Forms.ListView AgentViewList;
        private System.Windows.Forms.ListView OutputList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox SlackCheck;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Button PasswordFocus;
        private System.Windows.Forms.Button button1;
    }
}

