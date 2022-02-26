namespace wfaIntegradoCom.Procesos
{
    partial class frmOrdenCompra
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
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "Codigo de Orden"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Nro. Lote");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Doc. Compra");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Proveedor");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Nro. Documento");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Fecha de Compra");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenCompra));
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.lvVenta = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarDoc = new System.Windows.Forms.TextBox();
            this.lvBuscarFov = new System.Windows.Forms.ListView();
            this.gbDocumento = new System.Windows.Forms.GroupBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtidVenta = new System.Windows.Forms.TextBox();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lbTipoDoc = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.lblIGV = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.unidadMedidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalleCompraBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblAnulado = new System.Windows.Forms.Label();
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.idDetalleCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrdenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidadMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.importeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBuscar.SuspendLayout();
            this.gbDocumento.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.tsBotonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadMedidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleCompraBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBuscar
            // 
            this.gbBuscar.Controls.Add(this.lvVenta);
            this.gbBuscar.Controls.Add(this.dateTimePicker2);
            this.gbBuscar.Controls.Add(this.label1);
            this.gbBuscar.Controls.Add(this.txtBuscarDoc);
            this.gbBuscar.Controls.Add(this.lvBuscarFov);
            this.gbBuscar.Location = new System.Drawing.Point(4, 129);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(794, 238);
            this.gbBuscar.TabIndex = 55;
            this.gbBuscar.TabStop = false;
            this.gbBuscar.Visible = false;
            // 
            // lvVenta
            // 
            this.lvVenta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvVenta.FullRowSelect = true;
            this.lvVenta.GridLines = true;
            this.lvVenta.HideSelection = false;
            this.lvVenta.Location = new System.Drawing.Point(150, 52);
            this.lvVenta.MultiSelect = false;
            this.lvVenta.Name = "lvVenta";
            this.lvVenta.Size = new System.Drawing.Size(626, 180);
            this.lvVenta.TabIndex = 37;
            this.lvVenta.UseCompatibleStateImageBehavior = false;
            this.lvVenta.View = System.Windows.Forms.View.Details;
            this.lvVenta.Visible = false;
            this.lvVenta.DoubleClick += new System.EventHandler(this.lvVenta_DoubleClick);
            this.lvVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvVenta_KeyPress);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Código";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Doc Compra";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fecha Compra";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Proveedor";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Documento";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tipo Docu";
            this.columnHeader9.Width = 90;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(151, 33);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(207, 20);
            this.dateTimePicker2.TabIndex = 36;
            this.dateTimePicker2.Value = new System.DateTime(2015, 11, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Visible = false;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Elija Opción de Búsqueda";
            // 
            // txtBuscarDoc
            // 
            this.txtBuscarDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarDoc.Location = new System.Drawing.Point(150, 33);
            this.txtBuscarDoc.MaxLength = 100;
            this.txtBuscarDoc.Name = "txtBuscarDoc";
            this.txtBuscarDoc.Size = new System.Drawing.Size(308, 20);
            this.txtBuscarDoc.TabIndex = 33;
            this.txtBuscarDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarDoc_KeyPress);
            // 
            // lvBuscarFov
            // 
            this.lvBuscarFov.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvBuscarFov.FullRowSelect = true;
            this.lvBuscarFov.GridLines = true;
            this.lvBuscarFov.HideSelection = false;
            listViewItem13.StateImageIndex = 0;
            this.lvBuscarFov.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18});
            this.lvBuscarFov.Location = new System.Drawing.Point(17, 33);
            this.lvBuscarFov.MultiSelect = false;
            this.lvBuscarFov.Name = "lvBuscarFov";
            this.lvBuscarFov.Scrollable = false;
            this.lvBuscarFov.Size = new System.Drawing.Size(127, 199);
            this.lvBuscarFov.TabIndex = 0;
            this.lvBuscarFov.UseCompatibleStateImageBehavior = false;
            this.lvBuscarFov.View = System.Windows.Forms.View.Tile;
            this.lvBuscarFov.Click += new System.EventHandler(this.lvBuscarFov_Click);
            this.lvBuscarFov.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvBuscarFov_KeyPress);
            // 
            // gbDocumento
            // 
            this.gbDocumento.Controls.Add(this.cboEstado);
            this.gbDocumento.Controls.Add(this.label11);
            this.gbDocumento.Controls.Add(this.lblNroDoc);
            this.gbDocumento.Controls.Add(this.txtNroDoc);
            this.gbDocumento.Controls.Add(this.label3);
            this.gbDocumento.Controls.Add(this.dtFecha);
            this.gbDocumento.Controls.Add(this.txtidVenta);
            this.gbDocumento.Location = new System.Drawing.Point(4, -2);
            this.gbDocumento.Name = "gbDocumento";
            this.gbDocumento.Size = new System.Drawing.Size(794, 41);
            this.gbDocumento.TabIndex = 53;
            this.gbDocumento.TabStop = false;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(476, 10);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(144, 21);
            this.cboEstado.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(427, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Estado:";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(21, 15);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(50, 13);
            this.lblNroDoc.TabIndex = 35;
            this.lblNroDoc.Text = "Nro. Doc";
            this.lblNroDoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDoc.Location = new System.Drawing.Point(77, 12);
            this.txtNroDoc.MaxLength = 100;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(108, 20);
            this.txtNroDoc.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(251, 11);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(144, 20);
            this.dtFecha.TabIndex = 38;
            // 
            // txtidVenta
            // 
            this.txtidVenta.Location = new System.Drawing.Point(14, 12);
            this.txtidVenta.Name = "txtidVenta";
            this.txtidVenta.Size = new System.Drawing.Size(57, 20);
            this.txtidVenta.TabIndex = 49;
            this.txtidVenta.Text = "0";
            this.txtidVenta.Visible = false;
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.btnBuscar);
            this.gbCliente.Controls.Add(this.btnAgregar);
            this.gbCliente.Controls.Add(this.lbTipoDoc);
            this.gbCliente.Controls.Add(this.cboCliente);
            this.gbCliente.Controls.Add(this.label4);
            this.gbCliente.Controls.Add(this.txtDireccion);
            this.gbCliente.Controls.Add(this.label6);
            this.gbCliente.Controls.Add(this.txtDoc);
            this.gbCliente.Location = new System.Drawing.Point(4, 44);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(794, 86);
            this.gbCliente.TabIndex = 51;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Datos Proveedor";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(437, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(21, 23);
            this.btnBuscar.TabIndex = 35;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(412, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(19, 23);
            this.btnAgregar.TabIndex = 34;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lbTipoDoc
            // 
            this.lbTipoDoc.AutoSize = true;
            this.lbTipoDoc.Location = new System.Drawing.Point(613, 28);
            this.lbTipoDoc.Name = "lbTipoDoc";
            this.lbTipoDoc.Size = new System.Drawing.Size(30, 13);
            this.lbTipoDoc.TabIndex = 33;
            this.lbTipoDoc.Text = "Ruc.";
            this.lbTipoDoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(77, 24);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(318, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Proveedor:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(77, 53);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(699, 20);
            this.txtDireccion.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Dirección:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(673, 25);
            this.txtDoc.MaxLength = 15;
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.ReadOnly = true;
            this.txtDoc.Size = new System.Drawing.Size(103, 20);
            this.txtDoc.TabIndex = 28;
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.toolStripSeparator1,
            this.tsbGuardar,
            this.toolStripSeparator2,
            this.tsbBuscar,
            this.toolStripSeparator3,
            this.tsbImprimir,
            this.toolStripSeparator4,
            this.tsbSalir});
            this.tsBotonera.Location = new System.Drawing.Point(200, 379);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(262, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 62;
            this.tsBotonera.TabStop = true;
            this.tsBotonera.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(46, 35);
            this.tsbNuevo.Text = "&Nuevo";
            this.tsbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(53, 35);
            this.tsbGuardar.Text = "&Guardar";
            this.tsbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbBuscar
            // 
            this.tsbBuscar.Image = ((System.Drawing.Image)(resources.GetObject("tsbBuscar.Image")));
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(46, 35);
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbBuscar.Click += new System.EventHandler(this.tsbBuscar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Enabled = false;
            this.tsbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsbImprimir.Image")));
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(57, 35);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbImprimir.Click += new System.EventHandler(this.tsbImprimir_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(33, 35);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.ToolTipText = "Salir de Formulario";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Location = new System.Drawing.Point(690, 410);
            this.txtTotal.MaxLength = 100;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(108, 20);
            this.txtTotal.TabIndex = 60;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(608, 413);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Total S/.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIGV
            // 
            this.txtIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIGV.Location = new System.Drawing.Point(690, 388);
            this.txtIGV.MaxLength = 100;
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(108, 20);
            this.txtIGV.TabIndex = 58;
            this.txtIGV.Text = "0";
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGV
            // 
            this.lblIGV.AutoSize = true;
            this.lblIGV.Location = new System.Drawing.Point(608, 390);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(51, 13);
            this.lblIGV.TabIndex = 59;
            this.lblIGV.Text = "IGV(    %)";
            this.lblIGV.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubTotal.Location = new System.Drawing.Point(690, 367);
            this.txtSubTotal.MaxLength = 100;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(108, 20);
            this.txtSubTotal.TabIndex = 56;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(608, 370);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(71, 13);
            this.lblSubTotal.TabIndex = 57;
            this.lblSubTotal.Text = "Sub Total S/.";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // epUsuario
            // 
            this.epUsuario.ContainerControl = this;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AutoGenerateColumns = false;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleCompraDataGridViewTextBoxColumn,
            this.idOrdenDataGridViewTextBoxColumn,
            this.idProductoDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.btnNuevo,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioCompraDataGridViewTextBoxColumn,
            this.idUnidadMedidaDataGridViewTextBoxColumn,
            this.importeDataGridViewTextBoxColumn});
            this.dgvDetalleVenta.DataSource = this.detalleCompraBindingSource1;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(4, 136);
            this.dgvDetalleVenta.MultiSelect = false;
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(794, 231);
            this.dgvDetalleVenta.TabIndex = 52;
            this.dgvDetalleVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellContentClick);
            this.dgvDetalleVenta.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellEndEdit);
            this.dgvDetalleVenta.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalleVenta_CellPainting);
            this.dgvDetalleVenta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellValueChanged);
            this.dgvDetalleVenta.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalleVenta_DataError);
            this.dgvDetalleVenta.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleVenta_EditingControlShowing);
            this.dgvDetalleVenta.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDetalleVenta_RowsRemoved);
            this.dgvDetalleVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetalleVenta_KeyDown);
            // 
            // unidadMedidaBindingSource
            // 
            this.unidadMedidaBindingSource.DataSource = typeof(CapaEntidad.UnidadMedida);
            // 
            // detalleCompraBindingSource1
            // 
            this.detalleCompraBindingSource1.DataSource = typeof(CapaEntidad.DetalleCompra);
            // 
            // lblAnulado
            // 
            this.lblAnulado.AutoEllipsis = true;
            this.lblAnulado.AutoSize = true;
            this.lblAnulado.BackColor = System.Drawing.Color.Transparent;
            this.lblAnulado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnulado.ForeColor = System.Drawing.Color.Lime;
            this.lblAnulado.Location = new System.Drawing.Point(226, 180);
            this.lblAnulado.Name = "lblAnulado";
            this.lblAnulado.Size = new System.Drawing.Size(351, 75);
            this.lblAnulado.TabIndex = 68;
            this.lblAnulado.Text = "ANULADO";
            this.lblAnulado.Visible = false;
            // 
            // epControlOk
            // 
            this.epControlOk.BlinkRate = 0;
            this.epControlOk.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epControlOk.ContainerControl = this;
            this.epControlOk.Icon = ((System.Drawing.Icon)(resources.GetObject("epControlOk.Icon")));
            // 
            // idDetalleCompraDataGridViewTextBoxColumn
            // 
            this.idDetalleCompraDataGridViewTextBoxColumn.DataPropertyName = "idDetalleCompra";
            this.idDetalleCompraDataGridViewTextBoxColumn.HeaderText = "idDetalleCompra";
            this.idDetalleCompraDataGridViewTextBoxColumn.Name = "idDetalleCompraDataGridViewTextBoxColumn";
            this.idDetalleCompraDataGridViewTextBoxColumn.Visible = false;
            // 
            // idOrdenDataGridViewTextBoxColumn
            // 
            this.idOrdenDataGridViewTextBoxColumn.DataPropertyName = "idOrden";
            this.idOrdenDataGridViewTextBoxColumn.HeaderText = "idOrden";
            this.idOrdenDataGridViewTextBoxColumn.Name = "idOrdenDataGridViewTextBoxColumn";
            this.idOrdenDataGridViewTextBoxColumn.Visible = false;
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "idProducto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.Width = 70;
            // 
            // cProductoDataGridViewTextBoxColumn
            // 
            this.cProductoDataGridViewTextBoxColumn.DataPropertyName = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.Width = 230;
            // 
            // btnNuevo
            // 
            this.btnNuevo.DataPropertyName = "idDetalleCompra";
            this.btnNuevo.HeaderText = "";
            this.btnNuevo.Name = "btnNuevo";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 80;
            // 
            // precioCompraDataGridViewTextBoxColumn
            // 
            this.precioCompraDataGridViewTextBoxColumn.DataPropertyName = "PrecioCompra";
            this.precioCompraDataGridViewTextBoxColumn.HeaderText = "PrecioCompra";
            this.precioCompraDataGridViewTextBoxColumn.Name = "precioCompraDataGridViewTextBoxColumn";
            // 
            // idUnidadMedidaDataGridViewTextBoxColumn
            // 
            this.idUnidadMedidaDataGridViewTextBoxColumn.DataPropertyName = "idUnidadMedida";
            this.idUnidadMedidaDataGridViewTextBoxColumn.DataSource = this.unidadMedidaBindingSource;
            this.idUnidadMedidaDataGridViewTextBoxColumn.DisplayMember = "cNombreUM";
            this.idUnidadMedidaDataGridViewTextBoxColumn.HeaderText = "Unidad Medida";
            this.idUnidadMedidaDataGridViewTextBoxColumn.Name = "idUnidadMedidaDataGridViewTextBoxColumn";
            this.idUnidadMedidaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idUnidadMedidaDataGridViewTextBoxColumn.ValueMember = "idUnidadMedida";
            this.idUnidadMedidaDataGridViewTextBoxColumn.Width = 150;
            // 
            // importeDataGridViewTextBoxColumn
            // 
            this.importeDataGridViewTextBoxColumn.DataPropertyName = "Importe";
            this.importeDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDataGridViewTextBoxColumn.Name = "importeDataGridViewTextBoxColumn";
            this.importeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 434);
            this.Controls.Add(this.lblAnulado);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtIGV);
            this.Controls.Add(this.lblIGV);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.gbBuscar);
            this.Controls.Add(this.gbDocumento);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.gbCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrdenCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Compra";
            this.Load += new System.EventHandler(this.frmOrdenCompra_Load);
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            this.gbDocumento.ResumeLayout(false);
            this.gbDocumento.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadMedidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleCompraBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.ListView lvVenta;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarDoc;
        private System.Windows.Forms.ListView lvBuscarFov;
        private System.Windows.Forms.GroupBox gbDocumento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtidVenta;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lbTipoDoc;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.BindingSource detalleCompraBindingSource1;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.BindingSource unidadMedidaBindingSource;
        internal System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Label lblAnulado;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idUnidadMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDataGridViewTextBoxColumn;
    }
}