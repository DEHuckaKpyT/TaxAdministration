
namespace TaxAdministration.form
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonProfile = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonUsers = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonProfile,
            this.toolStripDropDownButtonUsers});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1217, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonProfile
            // 
            this.toolStripDropDownButtonProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemShow,
            this.ToolStripMenuItemExit});
            this.toolStripDropDownButtonProfile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonProfile.Image")));
            this.toolStripDropDownButtonProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonProfile.Name = "toolStripDropDownButtonProfile";
            this.toolStripDropDownButtonProfile.Size = new System.Drawing.Size(106, 22);
            this.toolStripDropDownButtonProfile.Text = "Мой профиль";
            // 
            // ToolStripMenuItemShow
            // 
            this.ToolStripMenuItemShow.Name = "ToolStripMenuItemShow";
            this.ToolStripMenuItemShow.Size = new System.Drawing.Size(191, 24);
            this.ToolStripMenuItemShow.Text = "Посмотреть";
            this.ToolStripMenuItemShow.Click += new System.EventHandler(this.ToolStripMenuItemShow_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(191, 24);
            this.ToolStripMenuItemExit.Text = "Выйти из профиля";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // toolStripDropDownButtonUsers
            // 
            this.toolStripDropDownButtonUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemUserList});
            this.toolStripDropDownButtonUsers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonUsers.Image")));
            this.toolStripDropDownButtonUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonUsers.Name = "toolStripDropDownButtonUsers";
            this.toolStripDropDownButtonUsers.Size = new System.Drawing.Size(107, 22);
            this.toolStripDropDownButtonUsers.Text = "Пользователи";
            // 
            // ToolStripMenuItemUserList
            // 
            this.ToolStripMenuItemUserList.Name = "ToolStripMenuItemUserList";
            this.ToolStripMenuItemUserList.Size = new System.Drawing.Size(218, 24);
            this.ToolStripMenuItemUserList.Text = "Список пользователей";
            this.ToolStripMenuItemUserList.Click += new System.EventHandler(this.ToolStripMenuItemUserList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 775);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonProfile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonUsers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUserList;
    }
}