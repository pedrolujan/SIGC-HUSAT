namespace wfaIntegradoCom.Procesos
{
    partial class frmDocumentoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentoVenta));
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "Cod. Venta"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Doc. Venta");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Nombre Cliente");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Nro. Documento");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Fecha de Venta");
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lbTipoDoc = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.cboTipoDocuVen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.idDetalleVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buscarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNuevo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cNombreUM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmsUnidadMedida = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadMedidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idUnidadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mDescuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.lblIGV = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDocumento = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.txtidVenta = new System.Windows.Forms.TextBox();
            this.gbGuia = new System.Windows.Forms.GroupBox();
            this.txtGuiaTrans = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNroGuiaRem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.lvVenta = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBuscarDoc = new System.Windows.Forms.TextBox();
            this.lvBuscarFov = new System.Windows.Forms.ListView();
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAnulado = new System.Windows.Forms.Label();
            this.gbCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.cmsProducto.SuspendLayout();
            this.cmsUnidadMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unidadMedidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource)).BeginInit();
            this.gbDocumento.SuspendLayout();
            this.gbGuia.SuspendLayout();
            this.tsBotonera.SuspendLayout();
            this.gbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.btnBuscar);
            this.gbCliente.Controls.Add(this.btnAgregar);
            this.gbCliente.Controls.Add(this.lbTipoDoc);
            this.gbCliente.Controls.Add(this.cboCliente);
            this.gbCliente.Controls.Add(this.label2);
            this.gbCliente.Controls.Add(this.txtDireccion);
            this.gbCliente.Controls.Add(this.label6);
            this.gbCliente.Controls.Add(this.txtDoc);
            this.gbCliente.Location = new System.Drawing.Point(19, 72);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(794, 86);
            this.gbCliente.TabIndex = 0;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Datos Cliente";
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
            this.btnAgregar.Location = new System.Drawing.Point(412, 24);
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
            this.lbTipoDoc.Size = new System.Drawing.Size(54, 13);
            this.lbTipoDoc.TabIndex = 33;
            this.lbTipoDoc.Text = "Tipo Doc.";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente:";
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
            // cboTipoDocuVen
            // 
            this.cboTipoDocuVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocuVen.FormattingEnabled = true;
            this.cboTipoDocuVen.Location = new System.Drawing.Point(125, 12);
            this.cboTipoDocuVen.Name = "cboTipoDocuVen";
            this.cboTipoDocuVen.Size = new System.Drawing.Size(144, 21);
            this.cboTipoDocuVen.TabIndex = 1;
            this.cboTipoDocuVen.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocuVen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de Documento:";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AutoGenerateColumns = false;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleVentaDataGridViewTextBoxColumn,
            this.idVenta,
            this.idLote,
            this.dgvcProducto,
            this.btnNuevo,
            this.cNombreUM,
            this.idUnidadOrigen,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioCompraDataGridViewTextBoxColumn,
            this.PrecioVenta,
            this.mDescuentoDataGridViewTextBoxColumn,
            this.Importe,
            this.idProducto});
            this.dgvDetalleVenta.DataSource = this.detalleVentaBindingSource;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(19, 202);
            this.dgvDetalleVenta.MultiSelect = false;
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(794, 238);
            this.dgvDetalleVenta.TabIndex = 3;
            this.dgvDetalleVenta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellClick);
            this.dgvDetalleVenta.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellEndEdit);
            this.dgvDetalleVenta.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellEnter);
            this.dgvDetalleVenta.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalleVenta_CellPainting);
            this.dgvDetalleVenta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellValueChanged);
            this.dgvDetalleVenta.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetalleVenta_CurrentCellDirtyStateChanged);
            this.dgvDetalleVenta.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalleVenta_DataError);
            this.dgvDetalleVenta.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleVenta_EditingControlShowing);
            this.dgvDetalleVenta.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDetalleVenta_RowsRemoved);
            this.dgvDetalleVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetalleVenta_KeyDown);
            // 
            // idDetalleVentaDataGridViewTextBoxColumn
            // 
            this.idDetalleVentaDataGridViewTextBoxColumn.DataPropertyName = "idDetalleVenta";
            this.idDetalleVentaDataGridViewTextBoxColumn.HeaderText = "idDetalleVenta";
            this.idDetalleVentaDataGridViewTextBoxColumn.Name = "idDetalleVentaDataGridViewTextBoxColumn";
            this.idDetalleVentaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idVenta
            // 
            this.idVenta.DataPropertyName = "idVenta";
            this.idVenta.HeaderText = "Cod Venta";
            this.idVenta.Name = "idVenta";
            this.idVenta.Visible = false;
            // 
            // idLote
            // 
            this.idLote.DataPropertyName = "idLote";
            this.idLote.HeaderText = "Nro Lote";
            this.idLote.Name = "idLote";
            // 
            // dgvcProducto
            // 
            this.dgvcProducto.ContextMenuStrip = this.cmsProducto;
            this.dgvcProducto.DataPropertyName = "cProducto";
            this.dgvcProducto.HeaderText = "Producto";
            this.dgvcProducto.MaxInputLength = 200;
            this.dgvcProducto.Name = "dgvcProducto";
            this.dgvcProducto.ReadOnly = true;
            this.dgvcProducto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcProducto.Width = 250;
            // 
            // cmsProducto
            // 
            this.cmsProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarProductoToolStripMenuItem});
            this.cmsProducto.Name = "contextMenuStrip1";
            this.cmsProducto.Size = new System.Drawing.Size(162, 26);
            // 
            // buscarProductoToolStripMenuItem
            // 
            this.buscarProductoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("buscarProductoToolStripMenuItem.Image")));
            this.buscarProductoToolStripMenuItem.Name = "buscarProductoToolStripMenuItem";
            this.buscarProductoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.buscarProductoToolStripMenuItem.Text = "Buscar Producto";
            this.buscarProductoToolStripMenuItem.Click += new System.EventHandler(this.buscarProductoToolStripMenuItem_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.HeaderText = "";
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ToolTipText = "Buscar Producto";
            this.btnNuevo.Width = 21;
            // 
            // cNombreUM
            // 
            this.cNombreUM.ContextMenuStrip = this.cmsUnidadMedida;
            this.cNombreUM.DataPropertyName = "idUnidadMedida";
            this.cNombreUM.DataSource = this.unidadMedidaBindingSource;
            this.cNombreUM.DisplayMember = "cNombreUM";
            this.cNombreUM.HeaderText = "U.M.";
            this.cNombreUM.Name = "cNombreUM";
            this.cNombreUM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cNombreUM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cNombreUM.ValueMember = "idUnidadMedida";
            this.cNombreUM.Width = 90;
            // 
            // cmsUnidadMedida
            // 
            this.cmsUnidadMedida.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsUnidadMedida.Name = "contextMenuStrip1";
            this.cmsUnidadMedida.Size = new System.Drawing.Size(210, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItem1.Text = "Buscar Unidad de Medida";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // unidadMedidaBindingSource
            // 
            this.unidadMedidaBindingSource.DataSource = typeof(CapaEntidad.UnidadMedida);
            // 
            // idUnidadOrigen
            // 
            this.idUnidadOrigen.DataPropertyName = "idUnidadOrigen";
            this.idUnidadOrigen.HeaderText = "UMB";
            this.idUnidadOrigen.Name = "idUnidadOrigen";
            this.idUnidadOrigen.Visible = false;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.MaxInputLength = 20;
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 60;
            // 
            // precioCompraDataGridViewTextBoxColumn
            // 
            this.precioCompraDataGridViewTextBoxColumn.DataPropertyName = "PrecioCompra";
            this.precioCompraDataGridViewTextBoxColumn.HeaderText = "PrecioCompra";
            this.precioCompraDataGridViewTextBoxColumn.MaxInputLength = 20;
            this.precioCompraDataGridViewTextBoxColumn.Name = "precioCompraDataGridViewTextBoxColumn";
            this.precioCompraDataGridViewTextBoxColumn.Visible = false;
            this.precioCompraDataGridViewTextBoxColumn.Width = 80;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "PrecioVenta";
            this.PrecioVenta.HeaderText = "PrecioVenta";
            this.PrecioVenta.MaxInputLength = 20;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.Width = 80;
            // 
            // mDescuentoDataGridViewTextBoxColumn
            // 
            this.mDescuentoDataGridViewTextBoxColumn.DataPropertyName = "mDescuento";
            this.mDescuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
            this.mDescuentoDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.mDescuentoDataGridViewTextBoxColumn.Name = "mDescuentoDataGridViewTextBoxColumn";
            this.mDescuentoDataGridViewTextBoxColumn.Width = 80;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 90;
            // 
            // idProducto
            // 
            this.idProducto.DataPropertyName = "idProducto";
            this.idProducto.HeaderText = "Cod. Prod.";
            this.idProducto.Name = "idProducto";
            this.idProducto.Visible = false;
            // 
            // detalleVentaBindingSource
            // 
            this.detalleVentaBindingSource.DataSource = typeof(CapaEntidad.DetalleVenta);
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDoc.Location = new System.Drawing.Point(668, 13);
            this.txtNroDoc.MaxLength = 100;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(108, 20);
            this.txtNroDoc.TabIndex = 34;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(571, 15);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(63, 13);
            this.lblNroDoc.TabIndex = 35;
            this.lblNroDoc.Text = "Nro. Boleta:";
            this.lblNroDoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(125, 39);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(202, 20);
            this.dtFecha.TabIndex = 38;
            this.dtFecha.ValueChanged += new System.EventHandler(this.dtFecha_ValueChanged);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubTotal.Location = new System.Drawing.Point(705, 446);
            this.txtSubTotal.MaxLength = 100;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(108, 20);
            this.txtSubTotal.TabIndex = 39;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(623, 449);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(71, 13);
            this.lblSubTotal.TabIndex = 40;
            this.lblSubTotal.Text = "Sub Total S/.";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIGV
            // 
            this.txtIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIGV.Location = new System.Drawing.Point(705, 467);
            this.txtIGV.MaxLength = 100;
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(108, 20);
            this.txtIGV.TabIndex = 41;
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGV
            // 
            this.lblIGV.AutoSize = true;
            this.lblIGV.Location = new System.Drawing.Point(623, 469);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(51, 13);
            this.lblIGV.TabIndex = 42;
            this.lblIGV.Text = "IGV(    %)";
            this.lblIGV.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Location = new System.Drawing.Point(705, 489);
            this.txtTotal.MaxLength = 100;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(108, 20);
            this.txtTotal.TabIndex = 43;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(623, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Total S/.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(424, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Cancelado:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbDocumento
            // 
            this.gbDocumento.Controls.Add(this.label11);
            this.gbDocumento.Controls.Add(this.cboEstado);
            this.gbDocumento.Controls.Add(this.txtidVenta);
            this.gbDocumento.Controls.Add(this.dateTimePicker1);
            this.gbDocumento.Controls.Add(this.cboTipoDocuVen);
            this.gbDocumento.Controls.Add(this.label5);
            this.gbDocumento.Controls.Add(this.label1);
            this.gbDocumento.Controls.Add(this.lblNroDoc);
            this.gbDocumento.Controls.Add(this.txtNroDoc);
            this.gbDocumento.Controls.Add(this.label3);
            this.gbDocumento.Controls.Add(this.dtFecha);
            this.gbDocumento.Location = new System.Drawing.Point(19, 5);
            this.gbDocumento.Name = "gbDocumento";
            this.gbDocumento.Size = new System.Drawing.Size(794, 64);
            this.gbDocumento.TabIndex = 47;
            this.gbDocumento.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(319, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(363, 12);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(162, 21);
            this.cboEstado.TabIndex = 50;
            // 
            // txtidVenta
            // 
            this.txtidVenta.Location = new System.Drawing.Point(14, 38);
            this.txtidVenta.Name = "txtidVenta";
            this.txtidVenta.Size = new System.Drawing.Size(57, 20);
            this.txtidVenta.TabIndex = 49;
            this.txtidVenta.Text = "0";
            // 
            // gbGuia
            // 
            this.gbGuia.Controls.Add(this.txtGuiaTrans);
            this.gbGuia.Controls.Add(this.label8);
            this.gbGuia.Controls.Add(this.txtNroGuiaRem);
            this.gbGuia.Controls.Add(this.label7);
            this.gbGuia.Location = new System.Drawing.Point(19, 159);
            this.gbGuia.Name = "gbGuia";
            this.gbGuia.Size = new System.Drawing.Size(794, 37);
            this.gbGuia.TabIndex = 48;
            this.gbGuia.TabStop = false;
            // 
            // txtGuiaTrans
            // 
            this.txtGuiaTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuiaTrans.Location = new System.Drawing.Point(424, 11);
            this.txtGuiaTrans.MaxLength = 100;
            this.txtGuiaTrans.Name = "txtGuiaTrans";
            this.txtGuiaTrans.Size = new System.Drawing.Size(118, 20);
            this.txtGuiaTrans.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Guía Rem. Transp. N°:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNroGuiaRem
            // 
            this.txtNroGuiaRem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroGuiaRem.Location = new System.Drawing.Point(151, 11);
            this.txtNroGuiaRem.MaxLength = 100;
            this.txtNroGuiaRem.Name = "txtNroGuiaRem";
            this.txtNroGuiaRem.Size = new System.Drawing.Size(118, 20);
            this.txtNroGuiaRem.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Guía Rem. Remitente N°:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.tsBotonera.Location = new System.Drawing.Point(215, 458);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(262, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 49;
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
            // gbBuscar
            // 
            this.gbBuscar.Controls.Add(this.lvVenta);
            this.gbBuscar.Controls.Add(this.dateTimePicker2);
            this.gbBuscar.Controls.Add(this.lblAnulado);
            this.gbBuscar.Controls.Add(this.label10);
            this.gbBuscar.Controls.Add(this.txtBuscarDoc);
            this.gbBuscar.Controls.Add(this.lvBuscarFov);
            this.gbBuscar.Location = new System.Drawing.Point(19, 202);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(794, 238);
            this.gbBuscar.TabIndex = 50;
            this.gbBuscar.TabStop = false;
            this.gbBuscar.Visible = false;
            // 
            // lvVenta
            // 
            this.lvVenta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Doc Venta";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha Ven";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cliente";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Documento";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tipo Docu";
            this.columnHeader6.Width = 90;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Elija Opción de Búsqueda";
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
            listViewItem11.StateImageIndex = 0;
            this.lvBuscarFov.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15});
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
            // lblAnulado
            // 
            this.lblAnulado.AutoEllipsis = true;
            this.lblAnulado.AutoSize = true;
            this.lblAnulado.BackColor = System.Drawing.Color.Transparent;
            this.lblAnulado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnulado.ForeColor = System.Drawing.Color.Lime;
            this.lblAnulado.Location = new System.Drawing.Point(412, -46);
            this.lblAnulado.Name = "lblAnulado";
            this.lblAnulado.Size = new System.Drawing.Size(351, 75);
            this.lblAnulado.TabIndex = 69;
            this.lblAnulado.Text = "ANULADO";
            this.lblAnulado.Visible = false;
            // 
            // frmDocumentoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 516);
            this.Controls.Add(this.gbBuscar);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.gbGuia);
            this.Controls.Add(this.gbDocumento);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIGV);
            this.Controls.Add(this.lblIGV);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.gbCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocumentoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emitir Documento de Venta";
            this.Load += new System.EventHandler(this.frmDocumentoVenta_Load);
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.cmsProducto.ResumeLayout(false);
            this.cmsUnidadMedida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unidadMedidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource)).EndInit();
            this.gbDocumento.ResumeLayout(false);
            this.gbDocumento.PerformLayout();
            this.gbGuia.ResumeLayout(false);
            this.gbGuia.PerformLayout();
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.ComboBox cboTipoDocuVen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lbTipoDoc;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbDocumento;
        private System.Windows.Forms.GroupBox gbGuia;
        private System.Windows.Forms.TextBox txtGuiaTrans;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNroGuiaRem;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.TextBox txtBuscarDoc;
        private System.Windows.Forms.ListView lvBuscarFov;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ListView lvVenta;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtidVenta;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource;
        private System.Windows.Forms.ContextMenuStrip cmsProducto;
        private System.Windows.Forms.ToolStripMenuItem buscarProductoToolStripMenuItem;
        internal System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.ContextMenuStrip cmsUnidadMedida;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.BindingSource unidadMedidaBindingSource;
        private System.Windows.Forms.Label lblAnulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProducto;
        private System.Windows.Forms.DataGridViewButtonColumn btnNuevo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cNombreUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn mDescuentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
    }
}