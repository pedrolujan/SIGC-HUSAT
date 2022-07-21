
namespace wfaIntegradoCom.Procesos
{
    partial class frmLoad
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
            this.components = new System.ComponentModel.Container();
            this.ProgressBar1 = new Siticone.UI.WinForms.SiticoneProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneWinProgressIndicator1 = new Siticone.UI.WinForms.SiticoneWinProgressIndicator();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.BorderColor = System.Drawing.Color.Transparent;
            this.ProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ProgressBar1.Location = new System.Drawing.Point(-287, 239);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ProgressBar1.ShadowDecoration.Parent = this.ProgressBar1;
            this.ProgressBar1.Size = new System.Drawing.Size(10, 24);
            this.ProgressBar1.TabIndex = 1;
            this.ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ProgressBar1.Visible = false;
            this.ProgressBar1.Click += new System.EventHandler(this.CLICK);
            // 
            // timer1
            // 
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.lblStatus.Location = new System.Drawing.Point(497, 380);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 26);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "0%";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.label1.Location = new System.Drawing.Point(467, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cargando";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // siticoneWinProgressIndicator1
            // 
            this.siticoneWinProgressIndicator1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.siticoneWinProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneWinProgressIndicator1.CircleSize = 1F;
            this.siticoneWinProgressIndicator1.Location = new System.Drawing.Point(432, 189);
            this.siticoneWinProgressIndicator1.Name = "siticoneWinProgressIndicator1";
            this.siticoneWinProgressIndicator1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneWinProgressIndicator1.Size = new System.Drawing.Size(177, 177);
            this.siticoneWinProgressIndicator1.TabIndex = 6;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Controls.Add(this.lblStatus);
            this.siticonePanel1.Controls.Add(this.siticoneWinProgressIndicator1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(1042, 602);
            this.siticonePanel1.TabIndex = 7;
            // 
            // frmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1042, 602);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.ProgressBar1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoad";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmLoad_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.UI.WinForms.SiticoneProgressBar ProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private Siticone.UI.WinForms.SiticoneWinProgressIndicator siticoneWinProgressIndicator1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
    }
}