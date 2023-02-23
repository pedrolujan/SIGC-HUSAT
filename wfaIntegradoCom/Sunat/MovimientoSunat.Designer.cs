namespace wfaIntegradoCom.Sunat
{
    partial class MovimientoSunat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.dotNetBarTabControl1 = new wfaIntegradoCom.Mantenedores.DotNetBarTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbBuscarListaVentas = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.dtpFechaFinalBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFechaInicialBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.cboEstadopago = new Siticone.UI.WinForms.SiticoneComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pbBuscar = new FontAwesome.Sharp.IconPictureBox();
            this.dgvListaVentas = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.IDCRONOGRAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAPAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehiculos_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciente_Rs_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CicloPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.txtBuscar = new RJCodeAdvance.RJControls.RJTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkHabilitarFechasBus = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.siticonePanel1.SuspendLayout();
            this.dotNetBarTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbBuscarListaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.Controls.Add(this.dotNetBarTabControl1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(903, 430);
            this.siticonePanel1.TabIndex = 1;
            // 
            // dotNetBarTabControl1
            // 
            this.dotNetBarTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.dotNetBarTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dotNetBarTabControl1.Controls.Add(this.tabPage1);
            this.dotNetBarTabControl1.Controls.Add(this.tabPage2);
            this.dotNetBarTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotNetBarTabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dotNetBarTabControl1.ItemSize = new System.Drawing.Size(44, 136);
            this.dotNetBarTabControl1.Location = new System.Drawing.Point(3, 3);
            this.dotNetBarTabControl1.Multiline = true;
            this.dotNetBarTabControl1.Name = "dotNetBarTabControl1";
            this.dotNetBarTabControl1.SelectedIndex = 0;
            this.dotNetBarTabControl1.Size = new System.Drawing.Size(897, 424);
            this.dotNetBarTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.dotNetBarTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkHabilitarFechasBus);
            this.tabPage1.Controls.Add(this.gbBuscarListaVentas);
            this.tabPage1.Controls.Add(this.cboEstadopago);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.pbBuscar);
            this.tabPage1.Controls.Add(this.dgvListaVentas);
            this.tabPage1.Controls.Add(this.siticoneLabel1);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Location = new System.Drawing.Point(140, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(753, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FACTURAS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbBuscarListaVentas
            // 
            this.gbBuscarListaVentas.BackColor = System.Drawing.Color.Transparent;
            this.gbBuscarListaVentas.Controls.Add(this.label35);
            this.gbBuscarListaVentas.Controls.Add(this.dtpFechaFinalBus);
            this.gbBuscarListaVentas.Controls.Add(this.label22);
            this.gbBuscarListaVentas.Controls.Add(this.dtpFechaInicialBus);
            this.gbBuscarListaVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbBuscarListaVentas.Location = new System.Drawing.Point(11, 12);
            this.gbBuscarListaVentas.Name = "gbBuscarListaVentas";
            this.gbBuscarListaVentas.Size = new System.Drawing.Size(430, 76);
            this.gbBuscarListaVentas.TabIndex = 269;
            this.gbBuscarListaVentas.TabStop = false;
            this.gbBuscarListaVentas.Text = "Buscar por fechas";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label35.Location = new System.Drawing.Point(222, 14);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 17);
            this.label35.TabIndex = 232;
            this.label35.Text = "Fecha Final:";
            // 
            // dtpFechaFinalBus
            // 
            this.dtpFechaFinalBus.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpFechaFinalBus.BorderRadius = 3;
            this.dtpFechaFinalBus.BorderThickness = 1;
            this.dtpFechaFinalBus.CheckedState.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.CustomFormat = "MMMM";
            this.dtpFechaFinalBus.FillColor = System.Drawing.Color.White;
            this.dtpFechaFinalBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaFinalBus.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaFinalBus.HoveredState.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Location = new System.Drawing.Point(222, 34);
            this.dtpFechaFinalBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFinalBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFinalBus.Name = "dtpFechaFinalBus";
            this.dtpFechaFinalBus.ShadowDecoration.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Size = new System.Drawing.Size(197, 36);
            this.dtpFechaFinalBus.TabIndex = 233;
            this.dtpFechaFinalBus.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(8, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 17);
            this.label22.TabIndex = 227;
            this.label22.Text = "Fecha Inicial:";
            // 
            // dtpFechaInicialBus
            // 
            this.dtpFechaInicialBus.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpFechaInicialBus.BorderRadius = 3;
            this.dtpFechaInicialBus.BorderThickness = 1;
            this.dtpFechaInicialBus.CheckedState.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.FillColor = System.Drawing.Color.White;
            this.dtpFechaInicialBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaInicialBus.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaInicialBus.HoveredState.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.Location = new System.Drawing.Point(8, 33);
            this.dtpFechaInicialBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicialBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicialBus.Name = "dtpFechaInicialBus";
            this.dtpFechaInicialBus.ShadowDecoration.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.Size = new System.Drawing.Size(197, 36);
            this.dtpFechaInicialBus.TabIndex = 231;
            this.dtpFechaInicialBus.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // cboEstadopago
            // 
            this.cboEstadopago.BackColor = System.Drawing.Color.Transparent;
            this.cboEstadopago.BorderColor = System.Drawing.Color.Silver;
            this.cboEstadopago.BorderRadius = 5;
            this.cboEstadopago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboEstadopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadopago.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboEstadopago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstadopago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboEstadopago.HoveredState.Parent = this.cboEstadopago;
            this.cboEstadopago.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboEstadopago.IntegralHeight = false;
            this.cboEstadopago.ItemHeight = 30;
            this.cboEstadopago.ItemsAppearance.Parent = this.cboEstadopago;
            this.cboEstadopago.Location = new System.Drawing.Point(447, 45);
            this.cboEstadopago.Name = "cboEstadopago";
            this.cboEstadopago.ShadowDecoration.Parent = this.cboEstadopago;
            this.cboEstadopago.Size = new System.Drawing.Size(165, 36);
            this.cboEstadopago.TabIndex = 268;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(447, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 267;
            this.label10.Text = "Buscar Por:";
            // 
            // pbBuscar
            // 
            this.pbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.pbBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.pbBuscar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.pbBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbBuscar.IconSize = 26;
            this.pbBuscar.Location = new System.Drawing.Point(720, 52);
            this.pbBuscar.Name = "pbBuscar";
            this.pbBuscar.Size = new System.Drawing.Size(26, 26);
            this.pbBuscar.TabIndex = 266;
            this.pbBuscar.TabStop = false;
            this.pbBuscar.Click += new System.EventHandler(this.pbBuscar_Click);
            // 
            // dgvListaVentas
            // 
            this.dgvListaVentas.AllowUserToAddRows = false;
            this.dgvListaVentas.AllowUserToDeleteRows = false;
            this.dgvListaVentas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListaVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaVentas.ColumnHeadersHeight = 42;
            this.dgvListaVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCRONOGRAMA,
            this.IDCONTRATO,
            this.numero,
            this.codContrato,
            this.FECHAPAGO,
            this.Vehiculos_lv,
            this.Ciente_Rs_lv,
            this.Plan_lv,
            this.TipoVenta,
            this.CicloPago,
            this.Estado_lv});
            this.dgvListaVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaVentas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaVentas.EnableHeadersVisualStyles = false;
            this.dgvListaVentas.GridColor = System.Drawing.Color.Silver;
            this.dgvListaVentas.Location = new System.Drawing.Point(6, 87);
            this.dgvListaVentas.Name = "dgvListaVentas";
            this.dgvListaVentas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaVentas.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListaVentas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaVentas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaVentas.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.RowTemplate.Height = 60;
            this.dgvListaVentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaVentas.Size = new System.Drawing.Size(741, 156);
            this.dgvListaVentas.TabIndex = 265;
            this.dgvListaVentas.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvListaVentas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaVentas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListaVentas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListaVentas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListaVentas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListaVentas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaVentas.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgvListaVentas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvListaVentas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvListaVentas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaVentas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvListaVentas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListaVentas.ThemeStyle.HeaderStyle.Height = 42;
            this.dgvListaVentas.ThemeStyle.ReadOnly = true;
            this.dgvListaVentas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaVentas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvListaVentas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaVentas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvListaVentas.ThemeStyle.RowsStyle.Height = 60;
            this.dgvListaVentas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.dgvListaVentas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.SteelBlue;
            this.dgvListaVentas.Visible = false;
            // 
            // IDCRONOGRAMA
            // 
            this.IDCRONOGRAMA.HeaderText = "IDCRONOGRAMA";
            this.IDCRONOGRAMA.Name = "IDCRONOGRAMA";
            this.IDCRONOGRAMA.ReadOnly = true;
            this.IDCRONOGRAMA.Visible = false;
            // 
            // IDCONTRATO
            // 
            this.IDCONTRATO.HeaderText = "IDCONTRATO";
            this.IDCONTRATO.Name = "IDCONTRATO";
            this.IDCONTRATO.ReadOnly = true;
            this.IDCONTRATO.Visible = false;
            // 
            // numero
            // 
            this.numero.FillWeight = 22.84264F;
            this.numero.HeaderText = "N°";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // codContrato
            // 
            this.codContrato.FillWeight = 116.8401F;
            this.codContrato.HeaderText = "Codigo Contrato";
            this.codContrato.Name = "codContrato";
            this.codContrato.ReadOnly = true;
            // 
            // FECHAPAGO
            // 
            this.FECHAPAGO.FillWeight = 93.50409F;
            this.FECHAPAGO.HeaderText = "Fecha estimada de pago";
            this.FECHAPAGO.Name = "FECHAPAGO";
            this.FECHAPAGO.ReadOnly = true;
            // 
            // Vehiculos_lv
            // 
            this.Vehiculos_lv.FillWeight = 79.41992F;
            this.Vehiculos_lv.HeaderText = "Vehiculos";
            this.Vehiculos_lv.Name = "Vehiculos_lv";
            this.Vehiculos_lv.ReadOnly = true;
            // 
            // Ciente_Rs_lv
            // 
            this.Ciente_Rs_lv.FillWeight = 175.2433F;
            this.Ciente_Rs_lv.HeaderText = "Cliente/Razon Social";
            this.Ciente_Rs_lv.Name = "Ciente_Rs_lv";
            this.Ciente_Rs_lv.ReadOnly = true;
            // 
            // Plan_lv
            // 
            this.Plan_lv.FillWeight = 79.41992F;
            this.Plan_lv.HeaderText = "Plan";
            this.Plan_lv.Name = "Plan_lv";
            this.Plan_lv.ReadOnly = true;
            // 
            // TipoVenta
            // 
            this.TipoVenta.FillWeight = 79.41992F;
            this.TipoVenta.HeaderText = "Tipo Venta";
            this.TipoVenta.Name = "TipoVenta";
            this.TipoVenta.ReadOnly = true;
            // 
            // CicloPago
            // 
            this.CicloPago.FillWeight = 91.2287F;
            this.CicloPago.HeaderText = "Ciclo de Pago";
            this.CicloPago.Name = "CicloPago";
            this.CicloPago.ReadOnly = true;
            // 
            // Estado_lv
            // 
            this.Estado_lv.FillWeight = 162.0815F;
            this.Estado_lv.HeaderText = "Estado";
            this.Estado_lv.Name = "Estado_lv";
            this.Estado_lv.ReadOnly = true;
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneLabel1.Location = new System.Drawing.Point(615, 28);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(107, 18);
            this.siticoneLabel1.TabIndex = 1;
            this.siticoneLabel1.Text = "Buscar Factura";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtBuscar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtBuscar.BorderRadius = 4;
            this.txtBuscar.BorderSize = 1;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.Location = new System.Drawing.Point(615, 50);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBuscar.PasswordChar = false;
            this.txtBuscar.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.Size = new System.Drawing.Size(131, 31);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Texts = "";
            this.txtBuscar.UnderlinedStyle = false;
            // 
            // tabPage2
            // 
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(140, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(753, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "NOTAS DE CREDITO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkHabilitarFechasBus
            // 
            this.chkHabilitarFechasBus.AutoSize = true;
            this.chkHabilitarFechasBus.BackColor = System.Drawing.Color.Transparent;
            this.chkHabilitarFechasBus.Checked = true;
            this.chkHabilitarFechasBus.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkHabilitarFechasBus.CheckedState.BorderRadius = 0;
            this.chkHabilitarFechasBus.CheckedState.BorderThickness = 0;
            this.chkHabilitarFechasBus.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkHabilitarFechasBus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitarFechasBus.ForeColor = System.Drawing.Color.Black;
            this.chkHabilitarFechasBus.Location = new System.Drawing.Point(339, 1);
            this.chkHabilitarFechasBus.Name = "chkHabilitarFechasBus";
            this.chkHabilitarFechasBus.Size = new System.Drawing.Size(102, 17);
            this.chkHabilitarFechasBus.TabIndex = 271;
            this.chkHabilitarFechasBus.Text = "Habilitar Fechas";
            this.chkHabilitarFechasBus.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechasBus.UncheckedState.BorderRadius = 0;
            this.chkHabilitarFechasBus.UncheckedState.BorderThickness = 0;
            this.chkHabilitarFechasBus.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechasBus.UseVisualStyleBackColor = false;
            // 
            // MovimientoSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 430);
            this.Controls.Add(this.siticonePanel1);
            this.Name = "MovimientoSunat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento Sunat";
            this.Load += new System.EventHandler(this.MovimientoSunat_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.dotNetBarTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbBuscarListaVentas.ResumeLayout(false);
            this.gbBuscarListaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Mantenedores.DotNetBarTabControl dotNetBarTabControl1;
        private RJCodeAdvance.RJControls.RJTextBox txtBuscar;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticoneDataGridView dgvListaVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCRONOGRAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAPAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehiculos_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciente_Rs_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CicloPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_lv;
        private FontAwesome.Sharp.IconPictureBox pbBuscar;
        private Siticone.UI.WinForms.SiticoneComboBox cboEstadopago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbBuscarListaVentas;
        private System.Windows.Forms.Label label35;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaFinalBus;
        private System.Windows.Forms.Label label22;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaInicialBus;
        private Siticone.UI.WinForms.SiticoneCheckBox chkHabilitarFechasBus;
    }
}