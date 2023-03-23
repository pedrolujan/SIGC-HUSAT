namespace wfaIntegradoCom.Consultas
{
    partial class frmRptActa
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
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnVolver = new Siticone.UI.WinForms.SiticoneButton();
            this.btnFinalizarInstalacion = new Siticone.UI.WinForms.SiticoneButton();
            this.label1 = new System.Windows.Forms.Label();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.gunaPanel1.Controls.Add(this.label3);
            this.gunaPanel1.Controls.Add(this.gunaControlBox2);
            this.gunaPanel1.Controls.Add(this.gunaControlBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(592, 29);
            this.gunaPanel1.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 21);
            this.label3.TabIndex = 76;
            this.label3.Text = "Acta de instalacion";
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(473, 0);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 75;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(543, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 74;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer1.Location = new System.Drawing.Point(6, 27);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(582, 528);
            this.reportViewer1.TabIndex = 164;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // btnVolver
            // 
            this.btnVolver.BorderRadius = 3;
            this.btnVolver.BorderThickness = 1;
            this.btnVolver.CheckedState.Parent = this.btnVolver;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.CustomImages.Parent = this.btnVolver;
            this.btnVolver.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.HoveredState.Parent = this.btnVolver;
            this.btnVolver.Location = new System.Drawing.Point(321, 564);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.ShadowDecoration.Parent = this.btnVolver;
            this.btnVolver.Size = new System.Drawing.Size(179, 42);
            this.btnVolver.TabIndex = 166;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnFinalizarInstalacion
            // 
            this.btnFinalizarInstalacion.BorderRadius = 3;
            this.btnFinalizarInstalacion.BorderThickness = 1;
            this.btnFinalizarInstalacion.CheckedState.Parent = this.btnFinalizarInstalacion;
            this.btnFinalizarInstalacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizarInstalacion.CustomImages.Parent = this.btnFinalizarInstalacion;
            this.btnFinalizarInstalacion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFinalizarInstalacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFinalizarInstalacion.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarInstalacion.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFinalizarInstalacion.HoveredState.Parent = this.btnFinalizarInstalacion;
            this.btnFinalizarInstalacion.Location = new System.Drawing.Point(88, 564);
            this.btnFinalizarInstalacion.Name = "btnFinalizarInstalacion";
            this.btnFinalizarInstalacion.PressedColor = System.Drawing.Color.White;
            this.btnFinalizarInstalacion.ShadowDecoration.Parent = this.btnFinalizarInstalacion;
            this.btnFinalizarInstalacion.Size = new System.Drawing.Size(179, 42);
            this.btnFinalizarInstalacion.TabIndex = 165;
            this.btnFinalizarInstalacion.Text = "Finalizar Instalacion";
            this.btnFinalizarInstalacion.Click += new System.EventHandler(this.btnFinalizarInstalacion_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(104, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 37);
            this.label1.TabIndex = 167;
            this.label1.Text = "¿ Imprimir Acta de Instalacion ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel1.BorderRadius = 3;
            this.siticonePanel1.BorderThickness = 2;
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(592, 619);
            this.siticonePanel1.TabIndex = 168;
            // 
            // frmRptActa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 619);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnFinalizarInstalacion);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRptActa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRptActa";
            this.Load += new System.EventHandler(this.frmRptActa_Load);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Siticone.UI.WinForms.SiticoneButton btnVolver;
        private Siticone.UI.WinForms.SiticoneButton btnFinalizarInstalacion;
        private System.Windows.Forms.Label label1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
    }
}