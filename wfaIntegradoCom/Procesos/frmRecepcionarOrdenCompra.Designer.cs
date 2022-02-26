namespace wfaIntegradoCom.Procesos
{
    partial class frmRecepcionarOrdenCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionarOrdenCompra));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.paTraslado = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.paDetalle = new System.Windows.Forms.Panel();
            this.lblAnulado = new System.Windows.Forms.Label();
            this.dgvMovimiento = new System.Windows.Forms.DataGridView();
            this.idDetalleTrasladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nCantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidadMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleTrasladoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paBuscar = new System.Windows.Forms.Panel();
            this.cboBuscarAlmacen = new System.Windows.Forms.ComboBox();
            this.lvProveedor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.paTraslado.SuspendLayout();
            this.paDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTrasladoBindingSource)).BeginInit();
            this.paBuscar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsBotonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.paTraslado);
            this.splitContainer1.Panel1.Controls.Add(this.paDetalle);
            this.splitContainer1.Panel1.Controls.Add(this.paBuscar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(551, 561);
            this.splitContainer1.SplitterDistance = 493;
            this.splitContainer1.TabIndex = 0;
            // 
            // paTraslado
            // 
            this.paTraslado.Controls.Add(this.label6);
            this.paTraslado.Controls.Add(this.chkEstado);
            this.paTraslado.Controls.Add(this.label2);
            this.paTraslado.Controls.Add(this.txtNroDoc);
            this.paTraslado.Controls.Add(this.label1);
            this.paTraslado.Controls.Add(this.label4);
            this.paTraslado.Controls.Add(this.cboDestino);
            this.paTraslado.Controls.Add(this.cboOrigen);
            this.paTraslado.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTraslado.Location = new System.Drawing.Point(0, 227);
            this.paTraslado.Name = "paTraslado";
            this.paTraslado.Size = new System.Drawing.Size(547, 95);
            this.paTraslado.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 90;
            this.label6.Text = "Estado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(468, 12);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 89;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Código:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDoc.Location = new System.Drawing.Point(128, 13);
            this.txtNroDoc.MaxLength = 100;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.ReadOnly = true;
            this.txtNroDoc.Size = new System.Drawing.Size(108, 20);
            this.txtNroDoc.TabIndex = 85;
            this.txtNroDoc.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Almacen Origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Almacen Destino";
            // 
            // cboDestino
            // 
            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(128, 68);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(396, 21);
            this.cboDestino.TabIndex = 82;
            // 
            // cboOrigen
            // 
            this.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(128, 41);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(396, 21);
            this.cboOrigen.TabIndex = 81;
            // 
            // paDetalle
            // 
            this.paDetalle.Controls.Add(this.lblAnulado);
            this.paDetalle.Controls.Add(this.dgvMovimiento);
            this.paDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paDetalle.Location = new System.Drawing.Point(0, 322);
            this.paDetalle.Name = "paDetalle";
            this.paDetalle.Size = new System.Drawing.Size(547, 167);
            this.paDetalle.TabIndex = 65;
            // 
            // lblAnulado
            // 
            this.lblAnulado.AutoEllipsis = true;
            this.lblAnulado.AutoSize = true;
            this.lblAnulado.BackColor = System.Drawing.Color.Transparent;
            this.lblAnulado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnulado.ForeColor = System.Drawing.Color.Lime;
            this.lblAnulado.Location = new System.Drawing.Point(100, 35);
            this.lblAnulado.Name = "lblAnulado";
            this.lblAnulado.Size = new System.Drawing.Size(351, 75);
            this.lblAnulado.TabIndex = 92;
            this.lblAnulado.Text = "ANULADO";
            this.lblAnulado.Visible = false;
            // 
            // dgvMovimiento
            // 
            this.dgvMovimiento.AutoGenerateColumns = false;
            this.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleTrasladoDataGridViewTextBoxColumn,
            this.idLoteDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.btnBuscar,
            this.nCantidadDataGridViewTextBoxColumn,
            this.cUnidadMedidaDataGridViewTextBoxColumn});
            this.dgvMovimiento.DataSource = this.detalleTrasladoBindingSource;
            this.dgvMovimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimiento.Location = new System.Drawing.Point(0, 0);
            this.dgvMovimiento.MultiSelect = false;
            this.dgvMovimiento.Name = "dgvMovimiento";
            this.dgvMovimiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMovimiento.Size = new System.Drawing.Size(547, 167);
            this.dgvMovimiento.TabIndex = 74;
            this.dgvMovimiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimiento_CellContentClick);
            this.dgvMovimiento.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMovimiento_CellPainting);
            // 
            // idDetalleTrasladoDataGridViewTextBoxColumn
            // 
            this.idDetalleTrasladoDataGridViewTextBoxColumn.DataPropertyName = "idDetalleTraslado";
            this.idDetalleTrasladoDataGridViewTextBoxColumn.HeaderText = "idDetalleTraslado";
            this.idDetalleTrasladoDataGridViewTextBoxColumn.Name = "idDetalleTrasladoDataGridViewTextBoxColumn";
            this.idDetalleTrasladoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idLoteDataGridViewTextBoxColumn
            // 
            this.idLoteDataGridViewTextBoxColumn.DataPropertyName = "idLote";
            this.idLoteDataGridViewTextBoxColumn.HeaderText = "Nro Lote";
            this.idLoteDataGridViewTextBoxColumn.Name = "idLoteDataGridViewTextBoxColumn";
            this.idLoteDataGridViewTextBoxColumn.Width = 80;
            // 
            // cProductoDataGridViewTextBoxColumn
            // 
            this.cProductoDataGridViewTextBoxColumn.DataPropertyName = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cProductoDataGridViewTextBoxColumn.Width = 170;
            // 
            // btnBuscar
            // 
            this.btnBuscar.HeaderText = "";
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.ReadOnly = true;
            this.btnBuscar.Width = 30;
            // 
            // nCantidadDataGridViewTextBoxColumn
            // 
            this.nCantidadDataGridViewTextBoxColumn.DataPropertyName = "nCantidad";
            this.nCantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.nCantidadDataGridViewTextBoxColumn.Name = "nCantidadDataGridViewTextBoxColumn";
            this.nCantidadDataGridViewTextBoxColumn.Width = 95;
            // 
            // cUnidadMedidaDataGridViewTextBoxColumn
            // 
            this.cUnidadMedidaDataGridViewTextBoxColumn.DataPropertyName = "cUnidadMedida";
            this.cUnidadMedidaDataGridViewTextBoxColumn.HeaderText = "Unidad Medida";
            this.cUnidadMedidaDataGridViewTextBoxColumn.Name = "cUnidadMedidaDataGridViewTextBoxColumn";
            this.cUnidadMedidaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUnidadMedidaDataGridViewTextBoxColumn.Width = 130;
            // 
            // detalleTrasladoBindingSource
            // 
            this.detalleTrasladoBindingSource.DataSource = typeof(CapaEntidad.DetalleTraslado);
            // 
            // paBuscar
            // 
            this.paBuscar.Controls.Add(this.cboBuscarAlmacen);
            this.paBuscar.Controls.Add(this.lvProveedor);
            this.paBuscar.Controls.Add(this.txtBuscar);
            this.paBuscar.Controls.Add(this.dtpFecha);
            this.paBuscar.Controls.Add(this.cboBuscar);
            this.paBuscar.Controls.Add(this.label5);
            this.paBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBuscar.Location = new System.Drawing.Point(0, 0);
            this.paBuscar.Name = "paBuscar";
            this.paBuscar.Size = new System.Drawing.Size(547, 227);
            this.paBuscar.TabIndex = 2;
            // 
            // cboBuscarAlmacen
            // 
            this.cboBuscarAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarAlmacen.FormattingEnabled = true;
            this.cboBuscarAlmacen.Location = new System.Drawing.Point(277, 10);
            this.cboBuscarAlmacen.Name = "cboBuscarAlmacen";
            this.cboBuscarAlmacen.Size = new System.Drawing.Size(247, 21);
            this.cboBuscarAlmacen.TabIndex = 97;
            this.cboBuscarAlmacen.SelectedIndexChanged += new System.EventHandler(this.cboBuscarAlmacen_SelectedIndexChanged);
            // 
            // lvProveedor
            // 
            this.lvProveedor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.Fecha,
            this.columnHeader5});
            this.lvProveedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvProveedor.FullRowSelect = true;
            this.lvProveedor.GridLines = true;
            this.lvProveedor.Location = new System.Drawing.Point(0, 39);
            this.lvProveedor.MultiSelect = false;
            this.lvProveedor.Name = "lvProveedor";
            this.lvProveedor.Size = new System.Drawing.Size(547, 188);
            this.lvProveedor.TabIndex = 96;
            this.lvProveedor.UseCompatibleStateImageBehavior = false;
            this.lvProveedor.View = System.Windows.Forms.View.Details;
            this.lvProveedor.DoubleClick += new System.EventHandler(this.lvProveedor_DoubleClick);
            this.lvProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvProveedor_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Almacén Origen";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Almacén Destino";
            this.columnHeader3.Width = 170;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Estado";
            this.columnHeader5.Width = 65;
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(277, 11);
            this.txtBuscar.MaxLength = 100;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(247, 20);
            this.txtBuscar.TabIndex = 89;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(277, 10);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(247, 21);
            this.dtpFecha.TabIndex = 6;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cboBuscar
            // 
            this.cboBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscar.FormattingEnabled = true;
            this.cboBuscar.Items.AddRange(new object[] {
            "Nro. Traslado",
            "Fecha de Traslado",
            "Almacen Origen"});
            this.cboBuscar.Location = new System.Drawing.Point(89, 10);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Size = new System.Drawing.Size(182, 23);
            this.cboBuscar.TabIndex = 5;
            this.cboBuscar.SelectedIndexChanged += new System.EventHandler(this.cboBuscar_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Buscar por:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.tsBotonera);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 60);
            this.panel2.TabIndex = 0;
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
            this.tsBotonera.Location = new System.Drawing.Point(164, 5);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(262, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 63;
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
            // frmRecepcionarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(551, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecepcionarOrdenCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traslado entre Almacenes";
            this.Load += new System.EventHandler(this.frmRecepcionarOrdenCompra_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.paTraslado.ResumeLayout(false);
            this.paTraslado.PerformLayout();
            this.paDetalle.ResumeLayout(false);
            this.paDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTrasladoBindingSource)).EndInit();
            this.paBuscar.ResumeLayout(false);
            this.paBuscar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.Panel paDetalle;
        private System.Windows.Forms.Panel paBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvProveedor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.BindingSource detalleTrasladoBindingSource;
        private System.Windows.Forms.Panel paTraslado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.ComboBox cboOrigen;
        internal System.Windows.Forms.DataGridView dgvMovimiento;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbBuscar;
        private System.Windows.Forms.Label lblAnulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleTrasladoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidadMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cboBuscarAlmacen;


    }
}