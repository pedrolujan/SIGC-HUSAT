namespace wfaIntegradoCom.Consultas
{
    partial class frmActaCierreCaja
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnRegresar = new Siticone.UI.WinForms.SiticoneGradientButton();
            this.btnCerrarGuardarCierre = new Siticone.UI.WinForms.SiticoneGradientButton();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(2, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(683, 430);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BorderRadius = 5;
            this.btnRegresar.CheckedState.Parent = this.btnRegresar;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.CustomImages.Parent = this.btnRegresar;
            this.btnRegresar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRegresar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.HoveredState.Parent = this.btnRegresar;
            this.btnRegresar.Image = global::wfaIntegradoCom.Properties.Resources.salir_hover;
            this.btnRegresar.Location = new System.Drawing.Point(107, 450);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.ShadowDecoration.Parent = this.btnRegresar;
            this.btnRegresar.Size = new System.Drawing.Size(213, 55);
            this.btnRegresar.TabIndex = 283;
            this.btnRegresar.Text = "Atras";
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnCerrarGuardarCierre
            // 
            this.btnCerrarGuardarCierre.BorderRadius = 5;
            this.btnCerrarGuardarCierre.CheckedState.Parent = this.btnCerrarGuardarCierre;
            this.btnCerrarGuardarCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarGuardarCierre.CustomImages.Parent = this.btnCerrarGuardarCierre;
            this.btnCerrarGuardarCierre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnCerrarGuardarCierre.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCerrarGuardarCierre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCerrarGuardarCierre.ForeColor = System.Drawing.Color.White;
            this.btnCerrarGuardarCierre.HoveredState.Parent = this.btnCerrarGuardarCierre;
            this.btnCerrarGuardarCierre.Image = global::wfaIntegradoCom.Properties.Resources.guardar_hover;
            this.btnCerrarGuardarCierre.ImageSize = new System.Drawing.Size(22, 22);
            this.btnCerrarGuardarCierre.Location = new System.Drawing.Point(353, 450);
            this.btnCerrarGuardarCierre.Name = "btnCerrarGuardarCierre";
            this.btnCerrarGuardarCierre.ShadowDecoration.Parent = this.btnCerrarGuardarCierre;
            this.btnCerrarGuardarCierre.Size = new System.Drawing.Size(213, 55);
            this.btnCerrarGuardarCierre.TabIndex = 284;
            this.btnCerrarGuardarCierre.Text = "Guardar Cierre Caja";
            this.btnCerrarGuardarCierre.Click += new System.EventHandler(this.btnCerrarGuardarCierre_Click);
            // 
            // frmActaCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 516);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnCerrarGuardarCierre);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmActaCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmActaCierreCaja";
            this.Load += new System.EventHandler(this.frmActaCierreCaja_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Siticone.UI.WinForms.SiticoneGradientButton btnRegresar;
        private Siticone.UI.WinForms.SiticoneGradientButton btnCerrarGuardarCierre;
    }
}