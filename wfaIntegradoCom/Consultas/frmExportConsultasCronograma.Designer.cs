namespace wfaIntegradoCom.Consultas
{
    partial class frmExportConsultasCronograma
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
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.siticonePanel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel1.BorderColor = System.Drawing.Color.Black;
            this.siticonePanel1.BorderThickness = 1;
            this.siticonePanel1.Controls.Add(this.reportViewer1);
            this.siticonePanel1.Controls.Add(this.gunaPanel1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(786, 515);
            this.siticonePanel1.TabIndex = 165;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 8;
            this.reportViewer1.Location = new System.Drawing.Point(3, 32);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(779, 480);
            this.reportViewer1.TabIndex = 163;
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Controls.Add(this.gunaControlBox1);
            this.gunaPanel1.Controls.Add(this.gunaControlBox2);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(786, 29);
            this.gunaPanel1.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 21);
            this.label1.TabIndex = 76;
            this.label1.Text = "Exportar busquedas";
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(667, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 75;
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(737, 0);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 74;
            // 
            // frmExportConsultasCronograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 515);
            this.Controls.Add(this.siticonePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExportConsultasCronograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmExportConsultasCronograma";
            this.Load += new System.EventHandler(this.frmExportConsultasCronograma_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}