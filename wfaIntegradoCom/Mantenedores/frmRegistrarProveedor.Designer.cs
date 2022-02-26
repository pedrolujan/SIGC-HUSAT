namespace wfaIntegradoCom.Mantenedores
{
    partial class frmRegistrarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarProveedor));
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFijo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtIdProov = new System.Windows.Forms.TextBox();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.txtBuscaProov = new System.Windows.Forms.TextBox();
            this.gbUbigeo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.lvProveedor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Direccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbBuscarDepa = new System.Windows.Forms.GroupBox();
            this.rbDoc = new System.Windows.Forms.RadioButton();
            this.rbRazon = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tsBotonera.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.gbUbigeo.SuspendLayout();
            this.gbBuscarDepa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.toolStripSeparator2,
            this.tsSalir});
            this.tsBotonera.Location = new System.Drawing.Point(272, 300);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(147, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 16;
            this.tsBotonera.TabStop = true;
            this.tsBotonera.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(46, 35);
            this.newToolStripButton.Text = "&Nuevo";
            this.newToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(53, 35);
            this.saveToolStripButton.Text = "&Guardar";
            this.saveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsSalir
            // 
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(33, 35);
            this.tsSalir.Text = "Salir";
            this.tsSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSalir.ToolTipText = "Salir de Formulario";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.label7);
            this.gbProveedor.Controls.Add(this.dateTimePicker1);
            this.gbProveedor.Controls.Add(this.txtCelular);
            this.gbProveedor.Controls.Add(this.label6);
            this.gbProveedor.Controls.Add(this.txtFijo);
            this.gbProveedor.Controls.Add(this.label5);
            this.gbProveedor.Controls.Add(this.txtReferencia);
            this.gbProveedor.Controls.Add(this.label4);
            this.gbProveedor.Controls.Add(this.txtDireccion);
            this.gbProveedor.Controls.Add(this.label2);
            this.gbProveedor.Controls.Add(this.chkEstado);
            this.gbProveedor.Controls.Add(this.label1);
            this.gbProveedor.Controls.Add(this.txtRuc);
            this.gbProveedor.Controls.Add(this.lblClave);
            this.gbProveedor.Controls.Add(this.txtRazon);
            this.gbProveedor.Controls.Add(this.lblUsuario);
            this.gbProveedor.Controls.Add(this.txtIdProov);
            this.gbProveedor.Controls.Add(this.lblIdUsuario);
            this.gbProveedor.Location = new System.Drawing.Point(16, 45);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(686, 169);
            this.gbProveedor.TabIndex = 4;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Datos Principales";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fecha de Creación:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(385, 131);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(279, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(180, 131);
            this.txtCelular.MaxLength = 20;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(171, 20);
            this.txtCelular.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Telefono Celular:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFijo
            // 
            this.txtFijo.Location = new System.Drawing.Point(16, 131);
            this.txtFijo.MaxLength = 20;
            this.txtFijo.Name = "txtFijo";
            this.txtFijo.Size = new System.Drawing.Size(142, 20);
            this.txtFijo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telefono Fijo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtReferencia
            // 
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencia.Location = new System.Drawing.Point(385, 84);
            this.txtReferencia.MaxLength = 100;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(279, 20);
            this.txtReferencia.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Referencia";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(385, 38);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(279, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dirección";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(16, 87);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 8;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(112, 84);
            this.txtRuc.MaxLength = 15;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(239, 20);
            this.txtRuc.TabIndex = 9;
            this.txtRuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuc_KeyPress);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(109, 68);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(30, 13);
            this.lblClave.TabIndex = 4;
            this.lblClave.Text = "Ruc:";
            this.lblClave.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRazon
            // 
            this.txtRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazon.Location = new System.Drawing.Point(112, 38);
            this.txtRazon.MaxLength = 200;
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(239, 20);
            this.txtRazon.TabIndex = 6;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(109, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(73, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Razon Social:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIdProov
            // 
            this.txtIdProov.Location = new System.Drawing.Point(16, 38);
            this.txtIdProov.Name = "txtIdProov";
            this.txtIdProov.ReadOnly = true;
            this.txtIdProov.Size = new System.Drawing.Size(58, 20);
            this.txtIdProov.TabIndex = 1;
            this.txtIdProov.Text = "0";
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(13, 22);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblIdUsuario.TabIndex = 0;
            this.lblIdUsuario.Text = "Codigo:";
            this.lblIdUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBuscaProov
            // 
            this.txtBuscaProov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscaProov.Location = new System.Drawing.Point(244, 10);
            this.txtBuscaProov.MaxLength = 20;
            this.txtBuscaProov.Name = "txtBuscaProov";
            this.txtBuscaProov.Size = new System.Drawing.Size(458, 20);
            this.txtBuscaProov.TabIndex = 4;
            this.txtBuscaProov.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaProov_KeyPress);
            // 
            // gbUbigeo
            // 
            this.gbUbigeo.Controls.Add(this.label3);
            this.gbUbigeo.Controls.Add(this.cboPais);
            this.gbUbigeo.Controls.Add(this.label10);
            this.gbUbigeo.Controls.Add(this.cboDistrito);
            this.gbUbigeo.Controls.Add(this.label9);
            this.gbUbigeo.Controls.Add(this.cboProvincia);
            this.gbUbigeo.Controls.Add(this.label8);
            this.gbUbigeo.Controls.Add(this.cboDepartamento);
            this.gbUbigeo.Location = new System.Drawing.Point(16, 220);
            this.gbUbigeo.Name = "gbUbigeo";
            this.gbUbigeo.Size = new System.Drawing.Size(686, 77);
            this.gbUbigeo.TabIndex = 9;
            this.gbUbigeo.TabStop = false;
            this.gbUbigeo.Text = "Seleccionar Ubigeo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(501, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Elegir Distrito";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboDistrito
            // 
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(504, 41);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(176, 21);
            this.cboDistrito.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Elegir Provincia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboProvincia
            // 
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(308, 41);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(174, 21);
            this.cboProvincia.TabIndex = 14;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Elegir Departamento:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(124, 41);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(169, 21);
            this.cboDepartamento.TabIndex = 13;
            this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
            // 
            // lvProveedor
            // 
            this.lvProveedor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.Direccion});
            this.lvProveedor.FullRowSelect = true;
            this.lvProveedor.GridLines = true;
            this.lvProveedor.HideSelection = false;
            this.lvProveedor.Location = new System.Drawing.Point(244, 30);
            this.lvProveedor.MultiSelect = false;
            this.lvProveedor.Name = "lvProveedor";
            this.lvProveedor.Size = new System.Drawing.Size(458, 192);
            this.lvProveedor.TabIndex = 5;
            this.lvProveedor.UseCompatibleStateImageBehavior = false;
            this.lvProveedor.View = System.Windows.Forms.View.Details;
            this.lvProveedor.Visible = false;
            this.lvProveedor.DoubleClick += new System.EventHandler(this.lvProveedor_DoubleClick);
            this.lvProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvProveedor_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Razon Social";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ruc";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // Direccion
            // 
            this.Direccion.Text = "Dirección";
            // 
            // gbBuscarDepa
            // 
            this.gbBuscarDepa.Controls.Add(this.rbDoc);
            this.gbBuscarDepa.Controls.Add(this.rbRazon);
            this.gbBuscarDepa.Controls.Add(this.rbCodigo);
            this.gbBuscarDepa.Location = new System.Drawing.Point(16, 2);
            this.gbBuscarDepa.Name = "gbBuscarDepa";
            this.gbBuscarDepa.Size = new System.Drawing.Size(216, 41);
            this.gbBuscarDepa.TabIndex = 19;
            this.gbBuscarDepa.TabStop = false;
            this.gbBuscarDepa.Text = "Buscar por:";
            // 
            // rbDoc
            // 
            this.rbDoc.AutoSize = true;
            this.rbDoc.Location = new System.Drawing.Point(158, 18);
            this.rbDoc.Name = "rbDoc";
            this.rbDoc.Size = new System.Drawing.Size(45, 17);
            this.rbDoc.TabIndex = 3;
            this.rbDoc.Text = "Ruc";
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
            this.rbRazon.CheckedChanged += new System.EventHandler(this.rbRazon_CheckedChanged);
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(81, 18);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbCodigo.TabIndex = 2;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
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
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(6, 41);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(112, 21);
            this.cboPais.TabIndex = 23;
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Elegir Pais:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmRegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 350);
            this.Controls.Add(this.gbBuscarDepa);
            this.Controls.Add(this.lvProveedor);
            this.Controls.Add(this.gbUbigeo);
            this.Controls.Add(this.txtBuscaProov);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.gbProveedor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Proveedor";
            this.Load += new System.EventHandler(this.frmRegistrarProveedor_Load);
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.gbProveedor.ResumeLayout(false);
            this.gbProveedor.PerformLayout();
            this.gbUbigeo.ResumeLayout(false);
            this.gbUbigeo.PerformLayout();
            this.gbBuscarDepa.ResumeLayout(false);
            this.gbBuscarDepa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.GroupBox gbProveedor;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtIdProov;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.TextBox txtBuscaProov;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFijo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbUbigeo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.ListView lvProveedor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox gbBuscarDepa;
        private System.Windows.Forms.RadioButton rbDoc;
        private System.Windows.Forms.RadioButton rbRazon;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.ColumnHeader Direccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPais;
    }
}