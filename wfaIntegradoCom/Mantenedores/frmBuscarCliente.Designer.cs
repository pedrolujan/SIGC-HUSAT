namespace wfaIntegradoCom.Mantenedores
{
    partial class frmBuscarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarCliente));
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.rbDoc = new System.Windows.Forms.RadioButton();
            this.rbRazon = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCliente = new System.Windows.Forms.ListView();
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBuscar
            // 
            this.gbBuscar.Controls.Add(this.rbDoc);
            this.gbBuscar.Controls.Add(this.rbRazon);
            this.gbBuscar.Controls.Add(this.rbCodigo);
            this.gbBuscar.Location = new System.Drawing.Point(12, 12);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(216, 41);
            this.gbBuscar.TabIndex = 26;
            this.gbBuscar.TabStop = false;
            this.gbBuscar.Text = "Buscar por:";
            // 
            // rbDoc
            // 
            this.rbDoc.AutoSize = true;
            this.rbDoc.Location = new System.Drawing.Point(132, 18);
            this.rbDoc.Name = "rbDoc";
            this.rbDoc.Size = new System.Drawing.Size(80, 17);
            this.rbDoc.TabIndex = 3;
            this.rbDoc.Text = "Documento";
            this.rbDoc.UseVisualStyleBackColor = true;
            this.rbDoc.CheckedChanged += new System.EventHandler(this.rbDoc_CheckedChanged);
            // 
            // rbRazon
            // 
            this.rbRazon.AutoSize = true;
            this.rbRazon.Checked = true;
            this.rbRazon.Location = new System.Drawing.Point(6, 18);
            this.rbRazon.Name = "rbRazon";
            this.rbRazon.Size = new System.Drawing.Size(62, 17);
            this.rbRazon.TabIndex = 1;
            this.rbRazon.TabStop = true;
            this.rbRazon.Text = "Nombre";
            this.rbRazon.UseVisualStyleBackColor = true;
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(71, 18);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbCodigo.TabIndex = 2;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(251, 27);
            this.txtBuscarCliente.MaxLength = 100;
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(397, 20);
            this.txtBuscarCliente.TabIndex = 23;
            this.txtBuscarCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCliente_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre Cliente";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Documento";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tipo Documento";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Telefono Celular";
            this.columnHeader5.Width = 200;
            // 
            // lvCliente
            // 
            this.lvCliente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvCliente.FullRowSelect = true;
            this.lvCliente.GridLines = true;
            this.lvCliente.HideSelection = false;
            this.lvCliente.Location = new System.Drawing.Point(4, 53);
            this.lvCliente.MultiSelect = false;
            this.lvCliente.Name = "lvCliente";
            this.lvCliente.Size = new System.Drawing.Size(644, 372);
            this.lvCliente.TabIndex = 24;
            this.lvCliente.UseCompatibleStateImageBehavior = false;
            this.lvCliente.View = System.Windows.Forms.View.Details;
            this.lvCliente.Visible = false;
            this.lvCliente.DoubleClick += new System.EventHandler(this.lvCliente_DoubleClick);
            this.lvCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvCliente_KeyPress);
            // 
            // epUsuario
            // 
            this.epUsuario.ContainerControl = this;
            // 
            // epControlOk
            // 
            this.epControlOk.BlinkRate = 0;
            this.epControlOk.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epControlOk.ContainerControl = this;
            this.epControlOk.Icon = ((System.Drawing.Icon)(resources.GetObject("epControlOk.Icon")));
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Estado";
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 430);
            this.Controls.Add(this.lvCliente);
            this.Controls.Add(this.gbBuscar);
            this.Controls.Add(this.txtBuscarCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Cliente";
            this.Load += new System.EventHandler(this.frmRegistrarCliente_Load);
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.RadioButton rbDoc;
        private System.Windows.Forms.RadioButton rbRazon;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.ListView lvCliente;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}