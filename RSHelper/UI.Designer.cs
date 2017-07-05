namespace RSHelperUI
{
    partial class UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.cLvScripts = new System.Windows.Forms.ListView();
            this.cId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cLvScripts
            // 
            this.cLvScripts.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.cLvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cId,
            this.cAuthor,
            this.cName,
            this.cVersion});
            this.cLvScripts.FullRowSelect = true;
            this.cLvScripts.HideSelection = false;
            this.cLvScripts.Location = new System.Drawing.Point(12, 12);
            this.cLvScripts.Name = "cLvScripts";
            this.cLvScripts.Size = new System.Drawing.Size(360, 237);
            this.cLvScripts.TabIndex = 2;
            this.cLvScripts.UseCompatibleStateImageBehavior = false;
            this.cLvScripts.View = System.Windows.Forms.View.Details;
            this.cLvScripts.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.cLvScripts_ItemSelectionChanged);
            // 
            // cId
            // 
            this.cId.DisplayIndex = 3;
            this.cId.Text = "ID";
            this.cId.Width = 0;
            // 
            // cAuthor
            // 
            this.cAuthor.DisplayIndex = 0;
            this.cAuthor.Text = "Author";
            this.cAuthor.Width = 125;
            // 
            // cName
            // 
            this.cName.DisplayIndex = 1;
            this.cName.Text = "Name";
            this.cName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cName.Width = 175;
            // 
            // cVersion
            // 
            this.cVersion.DisplayIndex = 2;
            this.cVersion.Text = "Version";
            this.cVersion.Width = 56;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.cLvScripts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UI";
            this.Text = "RSHelper";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView cLvScripts;
        private System.Windows.Forms.ColumnHeader cAuthor;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cVersion;
        private System.Windows.Forms.ColumnHeader cId;
    }
}