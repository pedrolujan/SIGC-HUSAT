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
            this.pnImporteEnCaja = new Guna.UI.WinForms.GunaPanel();
            this.lblMostraCierreAnterior = new Guna.UI.WinForms.GunaLabel();
            this.btnRegistrar = new Guna.UI.WinForms.GunaButton();
            this.btnAtras = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            this.pnImporteEnCaja.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptsReturn = true;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(103, 125);
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
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.AcceptsReturn = true;
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(103, 74);
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
            this.txtMonto.Location = new System.Drawing.Point(103, 175);
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
            this.label3.Location = new System.Drawing.Point(9, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Monto";
            // 
            // epUsuario
            // 
            this.epUsuario.ContainerControl = this;
            // 
            // pnImporteEnCaja
            // 
            this.pnImporteEnCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.pnImporteEnCaja.Controls.Add(this.lblMostraCierreAnterior);
            this.pnImporteEnCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnImporteEnCaja.Location = new System.Drawing.Point(0, 0);
            this.pnImporteEnCaja.Name = "pnImporteEnCaja";
            this.pnImporteEnCaja.Size = new System.Drawing.Size(365, 46);
            this.pnImporteEnCaja.TabIndex = 284;
            // 
            // lblMostraCierreAnterior
            // 
            this.lblMostraCierreAnterior.BackColor = System.Drawing.Color.Transparent;
            this.lblMostraCierreAnterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMostraCierreAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMostraCierreAnterior.ForeColor = System.Drawing.Color.White;
            this.lblMostraCierreAnterior.Location = new System.Drawing.Point(0, 0);
            this.lblMostraCierreAnterior.Name = "lblMostraCierreAnterior";
            this.lblMostraCierreAnterior.Size = new System.Drawing.Size(365, 46);
            this.lblMostraCierreAnterior.TabIndex = 285;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.AnimationHoverSpeed = 0.07F;
            this.btnRegistrar.AnimationSpeed = 0.03F;
            this.btnRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistrar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnRegistrar.BorderColor = System.Drawing.Color.Black;
            this.btnRegistrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegistrar.FocusedColor = System.Drawing.Color.Empty;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Image = global::wfaIntegradoCom.Properties.Resources.guardar_hover;
            this.btnRegistrar.ImageOffsetX = 10;
            this.btnRegistrar.ImageSize = new System.Drawing.Size(22, 22);
            this.btnRegistrar.Location = new System.Drawing.Point(16, 261);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnRegistrar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRegistrar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRegistrar.OnHoverImage = null;
            this.btnRegistrar.OnPressedColor = System.Drawing.Color.Black;
            this.btnRegistrar.Radius = 5;
            this.btnRegistrar.Size = new System.Drawing.Size(143, 42);
            this.btnRegistrar.TabIndex = 285;
            this.btnRegistrar.Text = "Aperturar";
            this.btnRegistrar.TextOffsetX = 5;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.AnimationHoverSpeed = 0.07F;
            this.btnAtras.AnimationSpeed = 0.03F;
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnAtras.BorderColor = System.Drawing.Color.Black;
            this.btnAtras.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAtras.FocusedColor = System.Drawing.Color.Empty;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Image = global::wfaIntegradoCom.Properties.Resources.salir_hover;
            this.btnAtras.ImageOffsetX = 10;
            this.btnAtras.ImageSize = new System.Drawing.Size(22, 22);
            this.btnAtras.Location = new System.Drawing.Point(195, 261);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(31)))));
            this.btnAtras.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAtras.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAtras.OnHoverImage = null;
            this.btnAtras.OnPressedColor = System.Drawing.Color.Black;
            this.btnAtras.Radius = 5;
            this.btnAtras.Size = new System.Drawing.Size(143, 42);
            this.btnAtras.TabIndex = 286;
            this.btnAtras.Text = "Cerrar";
            this.btnAtras.TextOffsetX = 5;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 328);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.pnImporteEnCaja);
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
        private Guna.UI.WinForms.GunaPanel pnImporteEnCaja;
        private Guna.UI.WinForms.GunaLabel lblMostraCierreAnterior;
        private Guna.UI.WinForms.GunaButton btnRegistrar;
        private Guna.UI.WinForms.GunaButton btnAtras;
    }
}