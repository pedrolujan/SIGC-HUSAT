namespace wfaIntegradoCom.Procesos
{
    partial class frmAperturaCaja
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRegistrar = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.btnAtras = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.pnImporteEnCaja = new Siticone.Desktop.UI.WinForms.SiticoneGradientPanel();
            this.lblMostraCierreAnterior = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            this.pnImporteEnCaja.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptsReturn = true;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(106, 100);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.MinimumSize = new System.Drawing.Size(124, 40);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(241, 40);
            this.txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.AcceptsReturn = true;
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(106, 49);
            this.txtFecha.MaxLength = 20;
            this.txtFecha.MinimumSize = new System.Drawing.Size(124, 40);
            this.txtFecha.Multiline = true;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(241, 40);
            this.txtFecha.TabIndex = 1;
            // 
            // txtMonto
            // 
            this.txtMonto.AcceptsReturn = true;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(106, 155);
            this.txtMonto.MaxLength = 20;
            this.txtMonto.MinimumSize = new System.Drawing.Size(124, 40);
            this.txtMonto.Multiline = true;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(241, 40);
            this.txtMonto.TabIndex = 3;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Monto";
            // 
            // epUsuario
            // 
            this.epUsuario.ContainerControl = this;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BorderRadius = 5;
            this.btnRegistrar.CheckedState.Parent = this.btnRegistrar;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.CustomImages.Parent = this.btnRegistrar;
            this.btnRegistrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnRegistrar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.HoverState.Parent = this.btnRegistrar;
            this.btnRegistrar.Image = global::wfaIntegradoCom.Properties.Resources.guardar_hover;
            this.btnRegistrar.ImageSize = new System.Drawing.Size(22, 22);
            this.btnRegistrar.Location = new System.Drawing.Point(16, 254);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.ShadowDecoration.Parent = this.btnRegistrar;
            this.btnRegistrar.Size = new System.Drawing.Size(143, 44);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Aperturar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            this.btnRegistrar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRegistrar_KeyDown);
            // 
            // btnAtras
            // 
            this.btnAtras.BorderRadius = 5;
            this.btnAtras.CheckedState.Parent = this.btnAtras;
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.CustomImages.Parent = this.btnAtras;
            this.btnAtras.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnAtras.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.HoverState.Parent = this.btnAtras;
            this.btnAtras.Image = global::wfaIntegradoCom.Properties.Resources.salir_hover;
            this.btnAtras.ImageSize = new System.Drawing.Size(22, 22);
            this.btnAtras.Location = new System.Drawing.Point(204, 254);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.ShadowDecoration.Parent = this.btnAtras;
            this.btnAtras.Size = new System.Drawing.Size(143, 44);
            this.btnAtras.TabIndex = 283;
            this.btnAtras.Text = "    Cerrar";
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // pnImporteEnCaja
            // 
            this.pnImporteEnCaja.Controls.Add(this.lblMostraCierreAnterior);
            this.pnImporteEnCaja.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.pnImporteEnCaja.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnImporteEnCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnImporteEnCaja.Location = new System.Drawing.Point(6, 0);
            this.pnImporteEnCaja.Name = "pnImporteEnCaja";
            this.pnImporteEnCaja.ShadowDecoration.Parent = this.pnImporteEnCaja;
            this.pnImporteEnCaja.Size = new System.Drawing.Size(359, 34);
            this.pnImporteEnCaja.TabIndex = 284;
            // 
            // lblMostraCierreAnterior
            // 
            this.lblMostraCierreAnterior.AutoSize = false;
            this.lblMostraCierreAnterior.BackColor = System.Drawing.Color.Transparent;
            this.lblMostraCierreAnterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMostraCierreAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostraCierreAnterior.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMostraCierreAnterior.Location = new System.Drawing.Point(0, 0);
            this.lblMostraCierreAnterior.Name = "lblMostraCierreAnterior";
            this.lblMostraCierreAnterior.Size = new System.Drawing.Size(359, 34);
            this.lblMostraCierreAnterior.TabIndex = 0;
            this.lblMostraCierreAnterior.Text = null;
            this.lblMostraCierreAnterior.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 328);
            this.Controls.Add(this.pnImporteEnCaja);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Apertura";
            this.Load += new System.EventHandler(this.frmAperturaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            this.pnImporteEnCaja.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton btnAtras;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton btnRegistrar;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientPanel pnImporteEnCaja;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel lblMostraCierreAnterior;
    }
}