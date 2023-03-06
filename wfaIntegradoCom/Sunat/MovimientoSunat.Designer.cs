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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.dotNetBarTabControl1 = new wfaIntegradoCom.Mantenedores.DotNetBarTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.btnNumFilas = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label37 = new System.Windows.Forms.Label();
            this.siticoneVSeparator1 = new Siticone.UI.WinForms.SiticoneVSeparator();
            this.cboPagina = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnTotalReg = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.btnTotalPag = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label41 = new System.Windows.Forms.Label();
            this.siticoneComboBox1 = new Siticone.UI.WinForms.SiticoneComboBox();
            this.chkHabilitarFechasBus = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.gbBuscarListaVentas = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.dtpFechaFinalBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFechaInicialBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.pbBuscar = new FontAwesome.Sharp.IconPictureBox();
            this.dgvListaVentas = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.idDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAPAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehiculos_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciente_Rs_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgImprimir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.txtBuscar = new Siticone.UI.WinForms.SiticoneTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.siticonePanel1.SuspendLayout();
            this.dotNetBarTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbPaginacion.SuspendLayout();
            this.gbBuscarListaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.tabPage1.Controls.Add(this.iconButton1);
            this.tabPage1.Controls.Add(this.gbPaginacion);
            this.tabPage1.Controls.Add(this.siticoneComboBox1);
            this.tabPage1.Controls.Add(this.chkHabilitarFechasBus);
            this.tabPage1.Controls.Add(this.gbBuscarListaVentas);
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
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iconButton1.BackColor = System.Drawing.SystemColors.Control;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Green;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.iconButton1.IconColor = System.Drawing.Color.Green;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(39, 370);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(164, 40);
            this.iconButton1.TabIndex = 275;
            this.iconButton1.Text = "Exportar a excel";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // gbPaginacion
            // 
            this.gbPaginacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPaginacion.Controls.Add(this.btnNumFilas);
            this.gbPaginacion.Controls.Add(this.label37);
            this.gbPaginacion.Controls.Add(this.siticoneVSeparator1);
            this.gbPaginacion.Controls.Add(this.cboPagina);
            this.gbPaginacion.Controls.Add(this.label40);
            this.gbPaginacion.Controls.Add(this.btnTotalReg);
            this.gbPaginacion.Controls.Add(this.btnTotalPag);
            this.gbPaginacion.Controls.Add(this.label41);
            this.gbPaginacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPaginacion.Location = new System.Drawing.Point(403, 370);
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(340, 40);
            this.gbPaginacion.TabIndex = 274;
            this.gbPaginacion.TabStop = false;
            // 
            // btnNumFilas
            // 
            this.btnNumFilas.BackColor = System.Drawing.Color.Transparent;
            this.btnNumFilas.CheckedState.Parent = this.btnNumFilas;
            this.btnNumFilas.CustomImages.Parent = this.btnNumFilas;
            this.btnNumFilas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnNumFilas.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumFilas.ForeColor = System.Drawing.Color.White;
            this.btnNumFilas.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnNumFilas.HoveredState.Parent = this.btnNumFilas;
            this.btnNumFilas.Location = new System.Drawing.Point(209, 12);
            this.btnNumFilas.Name = "btnNumFilas";
            this.btnNumFilas.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnNumFilas.ShadowDecoration.Parent = this.btnNumFilas;
            this.btnNumFilas.Size = new System.Drawing.Size(25, 25);
            this.btnNumFilas.TabIndex = 171;
            this.btnNumFilas.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(240, 17);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(68, 15);
            this.label37.TabIndex = 173;
            this.label37.Text = "registros de";
            // 
            // siticoneVSeparator1
            // 
            this.siticoneVSeparator1.FillColor = System.Drawing.Color.Gray;
            this.siticoneVSeparator1.Location = new System.Drawing.Point(186, 8);
            this.siticoneVSeparator1.Name = "siticoneVSeparator1";
            this.siticoneVSeparator1.Size = new System.Drawing.Size(13, 27);
            this.siticoneVSeparator1.TabIndex = 174;
            // 
            // cboPagina
            // 
            this.cboPagina.DropDownHeight = 90;
            this.cboPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPagina.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPagina.FormattingEnabled = true;
            this.cboPagina.IntegralHeight = false;
            this.cboPagina.Location = new System.Drawing.Point(52, 13);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Size = new System.Drawing.Size(63, 23);
            this.cboPagina.TabIndex = 167;
            this.cboPagina.SelectedIndexChanged += new System.EventHandler(this.cboPagina_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 17);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(43, 15);
            this.label40.TabIndex = 168;
            this.label40.Text = "Página";
            // 
            // btnTotalReg
            // 
            this.btnTotalReg.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalReg.CheckedState.Parent = this.btnTotalReg;
            this.btnTotalReg.CustomImages.Parent = this.btnTotalReg;
            this.btnTotalReg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalReg.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalReg.ForeColor = System.Drawing.Color.White;
            this.btnTotalReg.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalReg.HoveredState.Parent = this.btnTotalReg;
            this.btnTotalReg.Location = new System.Drawing.Point(307, 12);
            this.btnTotalReg.Name = "btnTotalReg";
            this.btnTotalReg.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalReg.ShadowDecoration.Parent = this.btnTotalReg;
            this.btnTotalReg.Size = new System.Drawing.Size(25, 25);
            this.btnTotalReg.TabIndex = 172;
            this.btnTotalReg.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // btnTotalPag
            // 
            this.btnTotalPag.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalPag.CheckedState.Parent = this.btnTotalPag;
            this.btnTotalPag.CustomImages.Parent = this.btnTotalPag;
            this.btnTotalPag.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPag.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalPag.ForeColor = System.Drawing.Color.White;
            this.btnTotalPag.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPag.HoveredState.Parent = this.btnTotalPag;
            this.btnTotalPag.Location = new System.Drawing.Point(149, 12);
            this.btnTotalPag.Name = "btnTotalPag";
            this.btnTotalPag.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalPag.ShadowDecoration.Parent = this.btnTotalPag;
            this.btnTotalPag.Size = new System.Drawing.Size(25, 25);
            this.btnTotalPag.TabIndex = 169;
            this.btnTotalPag.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(124, 17);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(20, 15);
            this.label41.TabIndex = 170;
            this.label41.Text = "de";
            // 
            // siticoneComboBox1
            // 
            this.siticoneComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.siticoneComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siticoneComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.siticoneComboBox1.HoveredState.Parent = this.siticoneComboBox1;
            this.siticoneComboBox1.ItemHeight = 30;
            this.siticoneComboBox1.ItemsAppearance.Parent = this.siticoneComboBox1;
            this.siticoneComboBox1.Location = new System.Drawing.Point(453, 45);
            this.siticoneComboBox1.Name = "siticoneComboBox1";
            this.siticoneComboBox1.ShadowDecoration.Parent = this.siticoneComboBox1;
            this.siticoneComboBox1.Size = new System.Drawing.Size(140, 36);
            this.siticoneComboBox1.TabIndex = 272;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(447, 26);
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
            this.pbBuscar.Location = new System.Drawing.Point(717, 50);
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dgvListaVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvListaVentas.ColumnHeadersHeight = 42;
            this.dgvListaVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocumento,
            this.numero,
            this.codDocumento,
            this.FECHAPAGO,
            this.Vehiculos_lv,
            this.Ciente_Rs_lv,
            this.Estado_lv,
            this.imgImprimir});
            this.dgvListaVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaVentas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvListaVentas.EnableHeadersVisualStyles = false;
            this.dgvListaVentas.GridColor = System.Drawing.Color.Silver;
            this.dgvListaVentas.Location = new System.Drawing.Point(7, 91);
            this.dgvListaVentas.Name = "dgvListaVentas";
            this.dgvListaVentas.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvListaVentas.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvListaVentas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaVentas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaVentas.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.RowTemplate.Height = 60;
            this.dgvListaVentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaVentas.Size = new System.Drawing.Size(741, 277);
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
            // idDocumento
            // 
            this.idDocumento.HeaderText = "idDocumento";
            this.idDocumento.Name = "idDocumento";
            this.idDocumento.ReadOnly = true;
            this.idDocumento.Visible = false;
            // 
            // numero
            // 
            this.numero.FillWeight = 22.84264F;
            this.numero.HeaderText = "N°";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // codDocumento
            // 
            this.codDocumento.FillWeight = 116.8401F;
            this.codDocumento.HeaderText = "Codigo Documento";
            this.codDocumento.Name = "codDocumento";
            this.codDocumento.ReadOnly = true;
            // 
            // FECHAPAGO
            // 
            this.FECHAPAGO.FillWeight = 93.50409F;
            this.FECHAPAGO.HeaderText = "Fecha de Emision";
            this.FECHAPAGO.Name = "FECHAPAGO";
            this.FECHAPAGO.ReadOnly = true;
            // 
            // Vehiculos_lv
            // 
            this.Vehiculos_lv.FillWeight = 79.41992F;
            this.Vehiculos_lv.HeaderText = "Vehiculo";
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
            // Estado_lv
            // 
            this.Estado_lv.FillWeight = 162.0815F;
            this.Estado_lv.HeaderText = "Estado";
            this.Estado_lv.Name = "Estado_lv";
            this.Estado_lv.ReadOnly = true;
            // 
            // imgImprimir
            // 
            this.imgImprimir.HeaderText = "";
            this.imgImprimir.Name = "imgImprimir";
            this.imgImprimir.ReadOnly = true;
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneLabel1.Location = new System.Drawing.Point(604, 25);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(107, 18);
            this.siticoneLabel1.TabIndex = 1;
            this.siticoneLabel1.Text = "Buscar Factura";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Animated = false;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.Parent = this.txtBuscar;
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.FocusedState.Parent = this.txtBuscar;
            this.txtBuscar.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.HoveredState.Parent = this.txtBuscar;
            this.txtBuscar.Location = new System.Drawing.Point(604, 45);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            this.txtBuscar.Size = new System.Drawing.Size(141, 36);
            this.txtBuscar.TabIndex = 273;
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
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.gbBuscarListaVentas.ResumeLayout(false);
            this.gbBuscarListaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Mantenedores.DotNetBarTabControl dotNetBarTabControl1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticoneDataGridView dgvListaVentas;
        private FontAwesome.Sharp.IconPictureBox pbBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbBuscarListaVentas;
        private System.Windows.Forms.Label label35;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaFinalBus;
        private System.Windows.Forms.Label label22;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaInicialBus;
        private Siticone.UI.WinForms.SiticoneCheckBox chkHabilitarFechasBus;
        private Siticone.UI.WinForms.SiticoneComboBox siticoneComboBox1;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscar;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAPAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehiculos_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciente_Rs_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn imgImprimir;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private Siticone.UI.WinForms.SiticoneCircleButton btnNumFilas;
        private System.Windows.Forms.Label label37;
        private Siticone.UI.WinForms.SiticoneVSeparator siticoneVSeparator1;
        private System.Windows.Forms.ComboBox cboPagina;
        private System.Windows.Forms.Label label40;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalReg;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalPag;
        private System.Windows.Forms.Label label41;
        private FontAwesome.Sharp.IconButton iconButton1;
    }

}