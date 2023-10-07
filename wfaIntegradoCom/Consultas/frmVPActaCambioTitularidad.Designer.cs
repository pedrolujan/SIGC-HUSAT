namespace wfaIntegradoCom.Consultas
{
    partial class frmVPActaCambioTitularidad
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
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaControlBox3 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox4 = new Guna.UI.WinForms.GunaControlBox();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.btnGenerarVenta = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnVolver = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.gunaPanel2.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(4, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(548, 482);
            this.reportViewer1.TabIndex = 0;
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.gunaPanel2.Controls.Add(this.label4);
            this.gunaPanel2.Controls.Add(this.gunaControlBox3);
            this.gunaPanel2.Controls.Add(this.gunaControlBox4);
            this.gunaPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel2.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(554, 29);
            this.gunaPanel2.TabIndex = 163;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 21);
            this.label4.TabIndex = 76;
            this.label4.Text = "Acta de cambio de titularidad";
            // 
            // gunaControlBox3
            // 
            this.gunaControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox3.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox3.AnimationSpeed = 0.03F;
            this.gunaControlBox3.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox3.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox3.IconSize = 15F;
            this.gunaControlBox3.Location = new System.Drawing.Point(435, 0);
            this.gunaControlBox3.Name = "gunaControlBox3";
            this.gunaControlBox3.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox3.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox3.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox3.TabIndex = 75;
            // 
            // gunaControlBox4
            // 
            this.gunaControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox4.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox4.AnimationSpeed = 0.03F;
            this.gunaControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox4.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox4.IconSize = 15F;
            this.gunaControlBox4.Location = new System.Drawing.Point(505, 0);
            this.gunaControlBox4.Name = "gunaControlBox4";
            this.gunaControlBox4.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox4.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox4.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox4.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox4.TabIndex = 74;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel1.BorderThickness = 2;
            this.siticonePanel1.Controls.Add(this.btnVolver);
            this.siticonePanel1.Controls.Add(this.btnGenerarVenta);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(554, 586);
            this.siticonePanel1.TabIndex = 165;
            this.siticonePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.siticonePanel1_Paint);
            // 
            // btnGenerarVenta
            // 
            this.btnGenerarVenta.BorderRadius = 3;
            this.btnGenerarVenta.BorderThickness = 1;
            this.btnGenerarVenta.CheckedState.Parent = this.btnGenerarVenta;
            this.btnGenerarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarVenta.CustomImages.Parent = this.btnGenerarVenta;
            this.btnGenerarVenta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenerarVenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerarVenta.ForeColor = System.Drawing.Color.White;
            this.btnGenerarVenta.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerarVenta.HoverState.Parent = this.btnGenerarVenta;
            this.btnGenerarVenta.Location = new System.Drawing.Point(118, 529);
            this.btnGenerarVenta.Name = "btnGenerarVenta";
            this.btnGenerarVenta.PressedColor = System.Drawing.Color.White;
            this.btnGenerarVenta.ShadowDecoration.Parent = this.btnGenerarVenta;
            this.btnGenerarVenta.Size = new System.Drawing.Size(130, 42);
            this.btnGenerarVenta.TabIndex = 98;
            this.btnGenerarVenta.Text = "Generar Venta";
            this.btnGenerarVenta.Click += new System.EventHandler(this.btnGenerarVenta_Click);
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
            this.btnVolver.HoverState.Parent = this.btnVolver;
            this.btnVolver.Location = new System.Drawing.Point(312, 529);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.ShadowDecoration.Parent = this.btnVolver;
            this.btnVolver.Size = new System.Drawing.Size(130, 42);
            this.btnVolver.TabIndex = 99;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmVPActaCambioTitularidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 586);
            this.Controls.Add(this.gunaPanel2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.siticonePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVPActaCambioTitularidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmVPActaCambioTitularidad";
            this.Load += new System.EventHandler(this.frmVPActaCambioTitularidad_Load);
            this.gunaPanel2.ResumeLayout(false);
            this.gunaPanel2.PerformLayout();
            this.siticonePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox3;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox4;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnVolver;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnGenerarVenta;
    }
}