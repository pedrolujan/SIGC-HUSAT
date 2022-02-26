namespace wfaIntegradoCom.Mantenedores
{
    partial class frmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.txtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.rbDoc = new System.Windows.Forms.RadioButton();
            this.rbRazon = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.gbUbigeo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.txtIdPersonal = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtApePat = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtApeMat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrimerNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSegundoNom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.gbEmpleado = new System.Windows.Forms.GroupBox();
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.lvempleado = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.siticoneButton1 = new Siticone.UI.WinForms.SiticoneButton();
            this.tsBotonera.SuspendLayout();
            this.gbBuscar.SuspendLayout();
            this.gbUbigeo.SuspendLayout();
            this.gbEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(259, 23);
            this.txtBuscarEmpleado.MaxLength = 20;
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(397, 20);
            this.txtBuscarEmpleado.TabIndex = 4;
            this.txtBuscarEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarEmpleado_KeyPress);
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
            this.tsBotonera.Location = new System.Drawing.Point(248, 347);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(147, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 21;
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
            // gbBuscar
            // 
            this.gbBuscar.Controls.Add(this.rbDoc);
            this.gbBuscar.Controls.Add(this.rbRazon);
            this.gbBuscar.Controls.Add(this.rbCodigo);
            this.gbBuscar.Location = new System.Drawing.Point(20, 8);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(216, 41);
            this.gbBuscar.TabIndex = 20;
            this.gbBuscar.TabStop = false;
            this.gbBuscar.Text = "Buscar por:";
            // 
            // rbDoc
            // 
            this.rbDoc.AutoSize = true;
            this.rbDoc.Location = new System.Drawing.Point(158, 18);
            this.rbDoc.Name = "rbDoc";
            this.rbDoc.Size = new System.Drawing.Size(44, 17);
            this.rbDoc.TabIndex = 3;
            this.rbDoc.Text = "DNI";
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
            // gbUbigeo
            // 
            this.gbUbigeo.Controls.Add(this.label10);
            this.gbUbigeo.Controls.Add(this.cboDistrito);
            this.gbUbigeo.Controls.Add(this.label9);
            this.gbUbigeo.Controls.Add(this.cboProvincia);
            this.gbUbigeo.Controls.Add(this.label8);
            this.gbUbigeo.Controls.Add(this.cboDepartamento);
            this.gbUbigeo.Location = new System.Drawing.Point(20, 269);
            this.gbUbigeo.Name = "gbUbigeo";
            this.gbUbigeo.Size = new System.Drawing.Size(636, 67);
            this.gbUbigeo.TabIndex = 22;
            this.gbUbigeo.TabStop = false;
            this.gbUbigeo.Text = "Seleccionar Ubigeo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(432, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Elegir Distrito";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboDistrito
            // 
            this.cboDistrito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDistrito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(436, 34);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(179, 21);
            this.cboDistrito.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(222, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Elegir Provincia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboProvincia
            // 
            this.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(226, 34);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(188, 21);
            this.cboProvincia.TabIndex = 19;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Elegir Departamento:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(16, 34);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(188, 21);
            this.cboDepartamento.TabIndex = 18;
            this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(25, 22);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblIdUsuario.TabIndex = 0;
            this.lblIdUsuario.Text = "Codigo:";
            this.lblIdUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIdPersonal
            // 
            this.txtIdPersonal.Location = new System.Drawing.Point(28, 38);
            this.txtIdPersonal.Name = "txtIdPersonal";
            this.txtIdPersonal.ReadOnly = true;
            this.txtIdPersonal.Size = new System.Drawing.Size(58, 20);
            this.txtIdPersonal.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(109, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(87, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Apellido Paterno:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtApePat
            // 
            this.txtApePat.Location = new System.Drawing.Point(112, 38);
            this.txtApePat.MaxLength = 50;
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.Size = new System.Drawing.Size(229, 20);
            this.txtApePat.TabIndex = 6;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(366, 22);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(89, 13);
            this.lblClave.TabIndex = 4;
            this.lblClave.Text = "Apellido Materno:";
            this.lblClave.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtApeMat
            // 
            this.txtApeMat.Location = new System.Drawing.Point(367, 38);
            this.txtApeMat.MaxLength = 50;
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.Size = new System.Drawing.Size(248, 20);
            this.txtApeMat.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(28, 87);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 8;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Primer Nombre:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPrimerNom
            // 
            this.txtPrimerNom.Location = new System.Drawing.Point(112, 84);
            this.txtPrimerNom.MaxLength = 50;
            this.txtPrimerNom.Name = "txtPrimerNom";
            this.txtPrimerNom.Size = new System.Drawing.Size(229, 20);
            this.txtPrimerNom.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Segundo Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSegundoNom
            // 
            this.txtSegundoNom.Location = new System.Drawing.Point(367, 84);
            this.txtSegundoNom.MaxLength = 50;
            this.txtSegundoNom.Name = "txtSegundoNom";
            this.txtSegundoNom.Size = new System.Drawing.Size(248, 20);
            this.txtSegundoNom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "DNI:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(28, 128);
            this.txtdni.MaxLength = 15;
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(96, 20);
            this.txtdni.TabIndex = 11;
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(253, 128);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(362, 20);
            this.txtDireccion.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dirección:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Telefono:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(141, 128);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(96, 20);
            this.txtTelefono.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(29, 171);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(204, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Fecha Nacimiento:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(251, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Cargo:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboCargo
            // 
            this.cboCargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(254, 170);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(221, 21);
            this.cboCargo.TabIndex = 17;
            // 
            // gbEmpleado
            // 
            this.gbEmpleado.Controls.Add(this.cboCargo);
            this.gbEmpleado.Controls.Add(this.label11);
            this.gbEmpleado.Controls.Add(this.label7);
            this.gbEmpleado.Controls.Add(this.dateTimePicker1);
            this.gbEmpleado.Controls.Add(this.txtTelefono);
            this.gbEmpleado.Controls.Add(this.label3);
            this.gbEmpleado.Controls.Add(this.label6);
            this.gbEmpleado.Controls.Add(this.txtDireccion);
            this.gbEmpleado.Controls.Add(this.txtdni);
            this.gbEmpleado.Controls.Add(this.label5);
            this.gbEmpleado.Controls.Add(this.txtSegundoNom);
            this.gbEmpleado.Controls.Add(this.label2);
            this.gbEmpleado.Controls.Add(this.txtPrimerNom);
            this.gbEmpleado.Controls.Add(this.label4);
            this.gbEmpleado.Controls.Add(this.chkEstado);
            this.gbEmpleado.Controls.Add(this.label1);
            this.gbEmpleado.Controls.Add(this.txtApeMat);
            this.gbEmpleado.Controls.Add(this.lblClave);
            this.gbEmpleado.Controls.Add(this.txtApePat);
            this.gbEmpleado.Controls.Add(this.lblUsuario);
            this.gbEmpleado.Controls.Add(this.txtIdPersonal);
            this.gbEmpleado.Controls.Add(this.lblIdUsuario);
            this.gbEmpleado.Location = new System.Drawing.Point(20, 55);
            this.gbEmpleado.Name = "gbEmpleado";
            this.gbEmpleado.Size = new System.Drawing.Size(636, 206);
            this.gbEmpleado.TabIndex = 13;
            this.gbEmpleado.TabStop = false;
            this.gbEmpleado.Text = "Datos Principales";
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
            // lvempleado
            // 
            this.lvempleado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvempleado.FullRowSelect = true;
            this.lvempleado.GridLines = true;
            this.lvempleado.HideSelection = false;
            this.lvempleado.Location = new System.Drawing.Point(259, 43);
            this.lvempleado.MultiSelect = false;
            this.lvempleado.Name = "lvempleado";
            this.lvempleado.Size = new System.Drawing.Size(397, 218);
            this.lvempleado.TabIndex = 5;
            this.lvempleado.UseCompatibleStateImageBehavior = false;
            this.lvempleado.View = System.Windows.Forms.View.Details;
            this.lvempleado.Visible = false;
            this.lvempleado.DoubleClick += new System.EventHandler(this.lvempleado_DoubleClick);
            this.lvempleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvempleado_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre Empleado";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DNI";
            this.columnHeader3.Width = 80;
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
            this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
            this.siticoneButton1.Location = new System.Drawing.Point(401, -28);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
            this.siticoneButton1.Size = new System.Drawing.Size(180, 45);
            this.siticoneButton1.TabIndex = 23;
            this.siticoneButton1.Text = "siticoneButton1";
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 393);
            this.Controls.Add(this.siticoneButton1);
            this.Controls.Add(this.lvempleado);
            this.Controls.Add(this.gbUbigeo);
            this.Controls.Add(this.gbBuscar);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.txtBuscarEmpleado);
            this.Controls.Add(this.gbEmpleado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Empleado";
            this.Load += new System.EventHandler(this.frmEmpleado_Load);
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            this.gbUbigeo.ResumeLayout(false);
            this.gbUbigeo.PerformLayout();
            this.gbEmpleado.ResumeLayout(false);
            this.gbEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscarEmpleado;
        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.RadioButton rbDoc;
        private System.Windows.Forms.RadioButton rbRazon;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.GroupBox gbUbigeo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.TextBox txtIdPersonal;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtApePat;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtApeMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrimerNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSegundoNom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.GroupBox gbEmpleado;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.ListView lvempleado;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Siticone.UI.WinForms.SiticoneButton siticoneButton1;
    }
}