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
            this.cboDistrito = new Siticone.UI.WinForms.SiticoneComboBox();
            this.cboProvincia = new Siticone.UI.WinForms.SiticoneComboBox();
            this.cboDepartamento = new Siticone.UI.WinForms.SiticoneComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbEmpleado = new System.Windows.Forms.GroupBox();
            this.cboCargo = new Siticone.UI.WinForms.SiticoneComboBox();
            this.dateTimePicker1 = new Siticone.UI.WinForms.SiticoneRoundedDateTimePicker();
            this.txtIdPersonal = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtDireccion = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtTelefono = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtdni = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtPrimerNom = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtSegundoNom = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtApeMat = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtApePat = new Siticone.UI.WinForms.SiticoneTextBox();
            this.lvempleado = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBuscarEmpleado = new Siticone.UI.WinForms.SiticoneTextBox();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.siticonePanel2 = new Siticone.UI.WinForms.SiticonePanel();
            this.tsBotonera.SuspendLayout();
            this.gbBuscar.SuspendLayout();
            this.gbUbigeo.SuspendLayout();
            this.gbEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.siticonePanel1.SuspendLayout();
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
            this.tsBotonera.Location = new System.Drawing.Point(373, 610);
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
            this.gbBuscar.Location = new System.Drawing.Point(90, 55);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(297, 47);
            this.gbBuscar.TabIndex = 20;
            this.gbBuscar.TabStop = false;
            this.gbBuscar.Text = "Buscar por:";
            // 
            // rbDoc
            // 
            this.rbDoc.AutoSize = true;
            this.rbDoc.Location = new System.Drawing.Point(204, 18);
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
            this.rbRazon.Location = new System.Drawing.Point(8, 18);
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
            this.rbCodigo.Location = new System.Drawing.Point(102, 18);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbCodigo.TabIndex = 2;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
            // 
            // gbUbigeo
            // 
            this.gbUbigeo.Controls.Add(this.cboDistrito);
            this.gbUbigeo.Controls.Add(this.cboProvincia);
            this.gbUbigeo.Controls.Add(this.cboDepartamento);
            this.gbUbigeo.Controls.Add(this.label10);
            this.gbUbigeo.Controls.Add(this.label9);
            this.gbUbigeo.Controls.Add(this.label8);
            this.gbUbigeo.Location = new System.Drawing.Point(62, 466);
            this.gbUbigeo.Name = "gbUbigeo";
            this.gbUbigeo.Size = new System.Drawing.Size(849, 101);
            this.gbUbigeo.TabIndex = 22;
            this.gbUbigeo.TabStop = false;
            this.gbUbigeo.Text = "Seleccionar Ubigeo";
            // 
            // cboDistrito
            // 
            this.cboDistrito.BackColor = System.Drawing.Color.Transparent;
            this.cboDistrito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDistrito.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDistrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDistrito.HoveredState.Parent = this.cboDistrito;
            this.cboDistrito.ItemHeight = 30;
            this.cboDistrito.ItemsAppearance.Parent = this.cboDistrito;
            this.cboDistrito.Location = new System.Drawing.Point(538, 44);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.ShadowDecoration.Parent = this.cboDistrito;
            this.cboDistrito.Size = new System.Drawing.Size(189, 36);
            this.cboDistrito.TabIndex = 23;
            // 
            // cboProvincia
            // 
            this.cboProvincia.BackColor = System.Drawing.Color.Transparent;
            this.cboProvincia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboProvincia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProvincia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboProvincia.HoveredState.Parent = this.cboProvincia;
            this.cboProvincia.ItemHeight = 30;
            this.cboProvincia.ItemsAppearance.Parent = this.cboProvincia;
            this.cboProvincia.Location = new System.Drawing.Point(269, 44);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.ShadowDecoration.Parent = this.cboProvincia;
            this.cboProvincia.Size = new System.Drawing.Size(189, 36);
            this.cboProvincia.TabIndex = 23;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.cboDepartamento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDepartamento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDepartamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDepartamento.HoveredState.Parent = this.cboDepartamento;
            this.cboDepartamento.ItemHeight = 30;
            this.cboDepartamento.ItemsAppearance.Parent = this.cboDepartamento;
            this.cboDepartamento.Location = new System.Drawing.Point(16, 44);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.ShadowDecoration.Parent = this.cboDepartamento;
            this.cboDepartamento.Size = new System.Drawing.Size(189, 36);
            this.cboDepartamento.TabIndex = 23;
            this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(534, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Elegir Distrito";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Elegir Provincia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(411, 22);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(89, 13);
            this.lblClave.TabIndex = 4;
            this.lblClave.Text = "Apellido Materno:";
            this.lblClave.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(28, 111);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 8;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Primer Nombre:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Segundo Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "DNI:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dirección:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Telefono:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Fecha Nacimiento:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Cargo:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbEmpleado
            // 
            this.gbEmpleado.Controls.Add(this.lvempleado);
            this.gbEmpleado.Controls.Add(this.cboCargo);
            this.gbEmpleado.Controls.Add(this.dateTimePicker1);
            this.gbEmpleado.Controls.Add(this.txtIdPersonal);
            this.gbEmpleado.Controls.Add(this.txtDireccion);
            this.gbEmpleado.Controls.Add(this.txtTelefono);
            this.gbEmpleado.Controls.Add(this.txtdni);
            this.gbEmpleado.Controls.Add(this.txtPrimerNom);
            this.gbEmpleado.Controls.Add(this.txtSegundoNom);
            this.gbEmpleado.Controls.Add(this.txtApeMat);
            this.gbEmpleado.Controls.Add(this.txtApePat);
            this.gbEmpleado.Controls.Add(this.label11);
            this.gbEmpleado.Controls.Add(this.label7);
            this.gbEmpleado.Controls.Add(this.label3);
            this.gbEmpleado.Controls.Add(this.label6);
            this.gbEmpleado.Controls.Add(this.label5);
            this.gbEmpleado.Controls.Add(this.label2);
            this.gbEmpleado.Controls.Add(this.label4);
            this.gbEmpleado.Controls.Add(this.chkEstado);
            this.gbEmpleado.Controls.Add(this.label1);
            this.gbEmpleado.Controls.Add(this.lblClave);
            this.gbEmpleado.Controls.Add(this.lblUsuario);
            this.gbEmpleado.Controls.Add(this.lblIdUsuario);
            this.gbEmpleado.Location = new System.Drawing.Point(62, 108);
            this.gbEmpleado.Name = "gbEmpleado";
            this.gbEmpleado.Size = new System.Drawing.Size(849, 306);
            this.gbEmpleado.TabIndex = 13;
            this.gbEmpleado.TabStop = false;
            this.gbEmpleado.Text = "Datos Principales";
            // 
            // cboCargo
            // 
            this.cboCargo.BackColor = System.Drawing.Color.Transparent;
            this.cboCargo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCargo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCargo.HoveredState.Parent = this.cboCargo;
            this.cboCargo.ItemHeight = 30;
            this.cboCargo.ItemsAppearance.Parent = this.cboCargo;
            this.cboCargo.Location = new System.Drawing.Point(298, 267);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.ShadowDecoration.Parent = this.cboCargo;
            this.cboCargo.Size = new System.Drawing.Size(221, 36);
            this.cboCargo.TabIndex = 28;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackColor = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CheckedState.Parent = this.dateTimePicker1;
            this.dateTimePicker1.FillColor = System.Drawing.Color.White;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimePicker1.HoveredState.Parent = this.dateTimePicker1;
            this.dateTimePicker1.Location = new System.Drawing.Point(29, 267);
            this.dateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShadowDecoration.Parent = this.dateTimePicker1;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.UseTransparentBackground = true;
            this.dateTimePicker1.Value = new System.DateTime(2022, 6, 14, 13, 14, 15, 763);
            // 
            // txtIdPersonal
            // 
            this.txtIdPersonal.Animated = false;
            this.txtIdPersonal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdPersonal.DefaultText = "";
            this.txtIdPersonal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIdPersonal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIdPersonal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdPersonal.DisabledState.Parent = this.txtIdPersonal;
            this.txtIdPersonal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdPersonal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdPersonal.FocusedState.Parent = this.txtIdPersonal;
            this.txtIdPersonal.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdPersonal.HoveredState.Parent = this.txtIdPersonal;
            this.txtIdPersonal.Location = new System.Drawing.Point(16, 40);
            this.txtIdPersonal.Name = "txtIdPersonal";
            this.txtIdPersonal.PasswordChar = '\0';
            this.txtIdPersonal.PlaceholderText = "";
            this.txtIdPersonal.SelectedText = "";
            this.txtIdPersonal.ShadowDecoration.Parent = this.txtIdPersonal;
            this.txtIdPersonal.Size = new System.Drawing.Size(84, 36);
            this.txtIdPersonal.TabIndex = 26;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Animated = false;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.DefaultText = "";
            this.txtDireccion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDireccion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDireccion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDireccion.DisabledState.Parent = this.txtDireccion;
            this.txtDireccion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDireccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDireccion.FocusedState.Parent = this.txtDireccion;
            this.txtDireccion.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDireccion.HoveredState.Parent = this.txtDireccion;
            this.txtDireccion.Location = new System.Drawing.Point(311, 170);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PasswordChar = '\0';
            this.txtDireccion.PlaceholderText = "";
            this.txtDireccion.SelectedText = "";
            this.txtDireccion.ShadowDecoration.Parent = this.txtDireccion;
            this.txtDireccion.Size = new System.Drawing.Size(362, 36);
            this.txtDireccion.TabIndex = 26;
            this.txtDireccion.TextChanged += new System.EventHandler(this.siticoneTextBox8_TextChanged);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Animated = false;
            this.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelefono.DefaultText = "";
            this.txtTelefono.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTelefono.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTelefono.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTelefono.DisabledState.Parent = this.txtTelefono;
            this.txtTelefono.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTelefono.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTelefono.FocusedState.Parent = this.txtTelefono;
            this.txtTelefono.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTelefono.HoveredState.Parent = this.txtTelefono;
            this.txtTelefono.Location = new System.Drawing.Point(141, 170);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.PlaceholderText = "";
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.ShadowDecoration.Parent = this.txtTelefono;
            this.txtTelefono.Size = new System.Drawing.Size(135, 36);
            this.txtTelefono.TabIndex = 26;
            // 
            // txtdni
            // 
            this.txtdni.Animated = false;
            this.txtdni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdni.DefaultText = "";
            this.txtdni.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdni.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdni.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdni.DisabledState.Parent = this.txtdni;
            this.txtdni.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdni.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdni.FocusedState.Parent = this.txtdni;
            this.txtdni.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdni.HoveredState.Parent = this.txtdni;
            this.txtdni.Location = new System.Drawing.Point(16, 170);
            this.txtdni.Name = "txtdni";
            this.txtdni.PasswordChar = '\0';
            this.txtdni.PlaceholderText = "";
            this.txtdni.SelectedText = "";
            this.txtdni.ShadowDecoration.Parent = this.txtdni;
            this.txtdni.Size = new System.Drawing.Size(96, 36);
            this.txtdni.TabIndex = 26;
            // 
            // txtPrimerNom
            // 
            this.txtPrimerNom.Animated = false;
            this.txtPrimerNom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrimerNom.DefaultText = "";
            this.txtPrimerNom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrimerNom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrimerNom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrimerNom.DisabledState.Parent = this.txtPrimerNom;
            this.txtPrimerNom.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrimerNom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrimerNom.FocusedState.Parent = this.txtPrimerNom;
            this.txtPrimerNom.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrimerNom.HoveredState.Parent = this.txtPrimerNom;
            this.txtPrimerNom.Location = new System.Drawing.Point(109, 101);
            this.txtPrimerNom.Name = "txtPrimerNom";
            this.txtPrimerNom.PasswordChar = '\0';
            this.txtPrimerNom.PlaceholderText = "";
            this.txtPrimerNom.SelectedText = "";
            this.txtPrimerNom.ShadowDecoration.Parent = this.txtPrimerNom;
            this.txtPrimerNom.Size = new System.Drawing.Size(285, 36);
            this.txtPrimerNom.TabIndex = 26;
            // 
            // txtSegundoNom
            // 
            this.txtSegundoNom.Animated = false;
            this.txtSegundoNom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSegundoNom.DefaultText = "";
            this.txtSegundoNom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSegundoNom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSegundoNom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSegundoNom.DisabledState.Parent = this.txtSegundoNom;
            this.txtSegundoNom.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSegundoNom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSegundoNom.FocusedState.Parent = this.txtSegundoNom;
            this.txtSegundoNom.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSegundoNom.HoveredState.Parent = this.txtSegundoNom;
            this.txtSegundoNom.Location = new System.Drawing.Point(412, 101);
            this.txtSegundoNom.Name = "txtSegundoNom";
            this.txtSegundoNom.PasswordChar = '\0';
            this.txtSegundoNom.PlaceholderText = "";
            this.txtSegundoNom.SelectedText = "";
            this.txtSegundoNom.ShadowDecoration.Parent = this.txtSegundoNom;
            this.txtSegundoNom.Size = new System.Drawing.Size(315, 38);
            this.txtSegundoNom.TabIndex = 26;
            // 
            // txtApeMat
            // 
            this.txtApeMat.Animated = false;
            this.txtApeMat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApeMat.DefaultText = "";
            this.txtApeMat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtApeMat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtApeMat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtApeMat.DisabledState.Parent = this.txtApeMat;
            this.txtApeMat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtApeMat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtApeMat.FocusedState.Parent = this.txtApeMat;
            this.txtApeMat.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtApeMat.HoveredState.Parent = this.txtApeMat;
            this.txtApeMat.Location = new System.Drawing.Point(412, 40);
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.PasswordChar = '\0';
            this.txtApeMat.PlaceholderText = "";
            this.txtApeMat.SelectedText = "";
            this.txtApeMat.ShadowDecoration.Parent = this.txtApeMat;
            this.txtApeMat.Size = new System.Drawing.Size(315, 36);
            this.txtApeMat.TabIndex = 26;
            // 
            // txtApePat
            // 
            this.txtApePat.Animated = false;
            this.txtApePat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApePat.DefaultText = "";
            this.txtApePat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtApePat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtApePat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtApePat.DisabledState.Parent = this.txtApePat;
            this.txtApePat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtApePat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtApePat.FocusedState.Parent = this.txtApePat;
            this.txtApePat.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtApePat.HoveredState.Parent = this.txtApePat;
            this.txtApePat.Location = new System.Drawing.Point(109, 40);
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.PasswordChar = '\0';
            this.txtApePat.PlaceholderText = "";
            this.txtApePat.SelectedText = "";
            this.txtApePat.ShadowDecoration.Parent = this.txtApePat;
            this.txtApePat.Size = new System.Drawing.Size(285, 36);
            this.txtApePat.TabIndex = 26;
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
            this.lvempleado.Location = new System.Drawing.Point(452, -22);
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
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.Animated = false;
            this.txtBuscarEmpleado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarEmpleado.DefaultText = "";
            this.txtBuscarEmpleado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarEmpleado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarEmpleado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarEmpleado.DisabledState.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarEmpleado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarEmpleado.FocusedState.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarEmpleado.HoveredState.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(514, 54);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.PasswordChar = '\0';
            this.txtBuscarEmpleado.PlaceholderText = "";
            this.txtBuscarEmpleado.SelectedText = "";
            this.txtBuscarEmpleado.ShadowDecoration.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(397, 36);
            this.txtBuscarEmpleado.TabIndex = 23;
            this.txtBuscarEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarEmpleado_KeyPress);
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BorderColor = System.Drawing.Color.Red;
            this.siticonePanel1.BorderThickness = 2;
            this.siticonePanel1.Controls.Add(this.siticonePanel2);
            this.siticonePanel1.Controls.Add(this.gbBuscar);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(984, 661);
            this.siticonePanel1.TabIndex = 24;
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.BackColor = System.Drawing.Color.Red;
            this.siticonePanel2.BorderColor = System.Drawing.Color.Red;
            this.siticonePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel2.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.ShadowDecoration.Parent = this.siticonePanel2;
            this.siticonePanel2.Size = new System.Drawing.Size(984, 45);
            this.siticonePanel2.TabIndex = 0;
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.txtBuscarEmpleado);
            this.Controls.Add(this.gbUbigeo);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.gbEmpleado);
            this.Controls.Add(this.siticonePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.siticonePanel1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.RadioButton rbDoc;
        private System.Windows.Forms.RadioButton rbRazon;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.GroupBox gbUbigeo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbEmpleado;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.ListView lvempleado;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscarEmpleado;
        private Siticone.UI.WinForms.SiticoneTextBox txtIdPersonal;
        private Siticone.UI.WinForms.SiticoneTextBox txtDireccion;
        private Siticone.UI.WinForms.SiticoneTextBox txtTelefono;
        private Siticone.UI.WinForms.SiticoneTextBox txtdni;
        private Siticone.UI.WinForms.SiticoneTextBox txtPrimerNom;
        private Siticone.UI.WinForms.SiticoneTextBox txtSegundoNom;
        private Siticone.UI.WinForms.SiticoneTextBox txtApeMat;
        private Siticone.UI.WinForms.SiticoneTextBox txtApePat;
        private Siticone.UI.WinForms.SiticoneComboBox cboDistrito;
        private Siticone.UI.WinForms.SiticoneComboBox cboProvincia;
        private Siticone.UI.WinForms.SiticoneComboBox cboDepartamento;
        private Siticone.UI.WinForms.SiticoneComboBox cboCargo;
        private Siticone.UI.WinForms.SiticoneRoundedDateTimePicker dateTimePicker1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel2;
    }
}