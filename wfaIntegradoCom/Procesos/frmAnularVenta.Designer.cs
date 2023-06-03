﻿namespace wfaIntegradoCom.Procesos
{
    partial class frmAnularVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnularVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBuscar = new Siticone.UI.WinForms.SiticoneTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.cmsAnularVenta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarRegistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarContratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBuscarListaVentas = new System.Windows.Forms.GroupBox();
            this.dtpFechaFinalBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.dtpFechaInicialBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.label13 = new System.Windows.Forms.Label();
            this.siticonePanel2 = new Siticone.UI.WinForms.SiticonePanel();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.cboNotaCredit = new System.Windows.Forms.ComboBox();
            this.cbF0 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbR0 = new System.Windows.Forms.CheckBox();
            this.cbFechas = new System.Windows.Forms.CheckBox();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.btnNumFilas = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label37 = new System.Windows.Forms.Label();
            this.siticoneVSeparator1 = new Siticone.UI.WinForms.SiticoneVSeparator();
            this.cboPagina = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnTotalReg = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.btnTotalPag = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label41 = new System.Windows.Forms.Label();
            this.dgVentas = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodVenta_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAVENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFinContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehiculos_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciente_Rs_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lvBtnImprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idTipoTarida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.cmsAnularVenta.SuspendLayout();
            this.gbBuscarListaVentas.SuspendLayout();
            this.siticonePanel2.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            this.gbPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Animated = false;
            this.txtBuscar.BorderColor = System.Drawing.Color.Silver;
            this.txtBuscar.BorderRadius = 3;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.Parent = this.txtBuscar;
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtBuscar.FocusedState.Parent = this.txtBuscar;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.HoveredState.Parent = this.txtBuscar;
            this.txtBuscar.Location = new System.Drawing.Point(483, 35);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBuscar.PlaceholderText = "INGRESE COD VENTA...";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            this.txtBuscar.Size = new System.Drawing.Size(424, 36);
            this.txtBuscar.TabIndex = 189;
            this.txtBuscar.TextOffset = new System.Drawing.Point(30, 0);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(865, 39);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 190;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // cmsAnularVenta
            // 
            this.cmsAnularVenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarRegistroToolStripMenuItem,
            this.eliminarContratoToolStripMenuItem});
            this.cmsAnularVenta.Name = "cmsAnularVenta";
            this.cmsAnularVenta.Size = new System.Drawing.Size(176, 48);
            // 
            // eliminarRegistroToolStripMenuItem
            // 
            this.eliminarRegistroToolStripMenuItem.Name = "eliminarRegistroToolStripMenuItem";
            this.eliminarRegistroToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.eliminarRegistroToolStripMenuItem.Text = "Anular Documento";
            this.eliminarRegistroToolStripMenuItem.Click += new System.EventHandler(this.eliminarRegistroToolStripMenuItem_Click);
            // 
            // eliminarContratoToolStripMenuItem
            // 
            this.eliminarContratoToolStripMenuItem.Name = "eliminarContratoToolStripMenuItem";
            this.eliminarContratoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.eliminarContratoToolStripMenuItem.Text = "Eliminar contrato";
            this.eliminarContratoToolStripMenuItem.Click += new System.EventHandler(this.eliminarContratoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(425, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 196;
            this.label1.Text = "BUSCAR";
            // 
            // gbBuscarListaVentas
            // 
            this.gbBuscarListaVentas.BackColor = System.Drawing.Color.Transparent;
            this.gbBuscarListaVentas.Controls.Add(this.dtpFechaFinalBus);
            this.gbBuscarListaVentas.Controls.Add(this.dtpFechaInicialBus);
            this.gbBuscarListaVentas.Controls.Add(this.label35);
            this.gbBuscarListaVentas.Controls.Add(this.label14);
            this.gbBuscarListaVentas.Enabled = false;
            this.gbBuscarListaVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbBuscarListaVentas.Location = new System.Drawing.Point(15, 12);
            this.gbBuscarListaVentas.Name = "gbBuscarListaVentas";
            this.gbBuscarListaVentas.Size = new System.Drawing.Size(268, 117);
            this.gbBuscarListaVentas.TabIndex = 225;
            this.gbBuscarListaVentas.TabStop = false;
            // 
            // dtpFechaFinalBus
            // 
            this.dtpFechaFinalBus.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpFechaFinalBus.BorderRadius = 3;
            this.dtpFechaFinalBus.BorderThickness = 1;
            this.dtpFechaFinalBus.CheckedState.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.FillColor = System.Drawing.Color.White;
            this.dtpFechaFinalBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaFinalBus.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaFinalBus.HoveredState.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Location = new System.Drawing.Point(8, 77);
            this.dtpFechaFinalBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFinalBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFinalBus.Name = "dtpFechaFinalBus";
            this.dtpFechaFinalBus.ShadowDecoration.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Size = new System.Drawing.Size(254, 36);
            this.dtpFechaFinalBus.TabIndex = 233;
            this.dtpFechaFinalBus.Value = new System.DateTime(2022, 4, 8, 18, 42, 0, 0);
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
            this.dtpFechaInicialBus.Location = new System.Drawing.Point(8, 25);
            this.dtpFechaInicialBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicialBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicialBus.Name = "dtpFechaInicialBus";
            this.dtpFechaInicialBus.ShadowDecoration.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.Size = new System.Drawing.Size(254, 36);
            this.dtpFechaInicialBus.TabIndex = 231;
            this.dtpFechaInicialBus.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label35.Location = new System.Drawing.Point(8, 60);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 17);
            this.label35.TabIndex = 232;
            this.label35.Text = "Fecha Final:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(8, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 227;
            this.label14.Text = "Fecha Inicial:";
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(930, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 76;
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(883, 0);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 77;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 141;
            this.label13.Text = "Anular Venta";
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel2.Controls.Add(this.label13);
            this.siticonePanel2.Controls.Add(this.gunaControlBox2);
            this.siticonePanel2.Controls.Add(this.gunaControlBox1);
            this.siticonePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel2.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.ShadowDecoration.Parent = this.siticonePanel2;
            this.siticonePanel2.Size = new System.Drawing.Size(975, 25);
            this.siticonePanel2.TabIndex = 79;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.White;
            this.siticonePanel1.Controls.Add(this.cboNotaCredit);
            this.siticonePanel1.Controls.Add(this.cbF0);
            this.siticonePanel1.Controls.Add(this.checkBox1);
            this.siticonePanel1.Controls.Add(this.cbR0);
            this.siticonePanel1.Controls.Add(this.cbFechas);
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Controls.Add(this.pictureBox4);
            this.siticonePanel1.Controls.Add(this.txtBuscar);
            this.siticonePanel1.Controls.Add(this.gbBuscarListaVentas);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 25);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(975, 135);
            this.siticonePanel1.TabIndex = 226;
            // 
            // cboNotaCredit
            // 
            this.cboNotaCredit.FormattingEnabled = true;
            this.cboNotaCredit.Location = new System.Drawing.Point(304, 108);
            this.cboNotaCredit.Name = "cboNotaCredit";
            this.cboNotaCredit.Size = new System.Drawing.Size(121, 21);
            this.cboNotaCredit.TabIndex = 383;
            this.cboNotaCredit.SelectedIndexChanged += new System.EventHandler(this.cboNotaCredit_SelectedIndexChanged);
            // 
            // cbF0
            // 
            this.cbF0.AutoSize = true;
            this.cbF0.Location = new System.Drawing.Point(824, 92);
            this.cbF0.Name = "cbF0";
            this.cbF0.Size = new System.Drawing.Size(83, 17);
            this.cbF0.TabIndex = 228;
            this.cbF0.Text = "F001-00000";
            this.cbF0.UseVisualStyleBackColor = true;
            this.cbF0.CheckedChanged += new System.EventHandler(this.cbF0_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(653, 92);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 17);
            this.checkBox1.TabIndex = 227;
            this.checkBox1.Text = "B001-00000";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // cbR0
            // 
            this.cbR0.AutoSize = true;
            this.cbR0.Location = new System.Drawing.Point(483, 92);
            this.cbR0.Name = "cbR0";
            this.cbR0.Size = new System.Drawing.Size(85, 17);
            this.cbR0.TabIndex = 227;
            this.cbR0.Text = "R001-00000";
            this.cbR0.UseVisualStyleBackColor = true;
            this.cbR0.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // cbFechas
            // 
            this.cbFechas.AutoSize = true;
            this.cbFechas.Location = new System.Drawing.Point(183, 0);
            this.cbFechas.Name = "cbFechas";
            this.cbFechas.Size = new System.Drawing.Size(97, 17);
            this.cbFechas.TabIndex = 226;
            this.cbFechas.Text = "Activar Fechas";
            this.cbFechas.UseVisualStyleBackColor = true;
            this.cbFechas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // gbPaginacion
            // 
            this.gbPaginacion.Controls.Add(this.btnNumFilas);
            this.gbPaginacion.Controls.Add(this.label37);
            this.gbPaginacion.Controls.Add(this.siticoneVSeparator1);
            this.gbPaginacion.Controls.Add(this.cboPagina);
            this.gbPaginacion.Controls.Add(this.label40);
            this.gbPaginacion.Controls.Add(this.btnTotalReg);
            this.gbPaginacion.Controls.Add(this.btnTotalPag);
            this.gbPaginacion.Controls.Add(this.label41);
            this.gbPaginacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPaginacion.Location = new System.Drawing.Point(626, 541);
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(340, 48);
            this.gbPaginacion.TabIndex = 227;
            this.gbPaginacion.TabStop = false;
            // 
            // btnNumFilas
            // 
            this.btnNumFilas.BackColor = System.Drawing.Color.Transparent;
            this.btnNumFilas.CheckedState.Parent = this.btnNumFilas;
            this.btnNumFilas.CustomImages.Parent = this.btnNumFilas;
            this.btnNumFilas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnNumFilas.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumFilas.ForeColor = System.Drawing.Color.White;
            this.btnNumFilas.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnNumFilas.HoveredState.Parent = this.btnNumFilas;
            this.btnNumFilas.Location = new System.Drawing.Point(209, 13);
            this.btnNumFilas.Name = "btnNumFilas";
            this.btnNumFilas.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnNumFilas.ShadowDecoration.Parent = this.btnNumFilas;
            this.btnNumFilas.Size = new System.Drawing.Size(29, 29);
            this.btnNumFilas.TabIndex = 171;
            this.btnNumFilas.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(240, 20);
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
            this.cboPagina.Location = new System.Drawing.Point(52, 16);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Size = new System.Drawing.Size(63, 23);
            this.cboPagina.TabIndex = 167;
            this.cboPagina.SelectedIndexChanged += new System.EventHandler(this.cboPagina_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 20);
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
            this.btnTotalReg.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalReg.ForeColor = System.Drawing.Color.White;
            this.btnTotalReg.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalReg.HoveredState.Parent = this.btnTotalReg;
            this.btnTotalReg.Location = new System.Drawing.Point(307, 13);
            this.btnTotalReg.Name = "btnTotalReg";
            this.btnTotalReg.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalReg.ShadowDecoration.Parent = this.btnTotalReg;
            this.btnTotalReg.Size = new System.Drawing.Size(29, 29);
            this.btnTotalReg.TabIndex = 172;
            this.btnTotalReg.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // btnTotalPag
            // 
            this.btnTotalPag.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalPag.CheckedState.Parent = this.btnTotalPag;
            this.btnTotalPag.CustomImages.Parent = this.btnTotalPag;
            this.btnTotalPag.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPag.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalPag.ForeColor = System.Drawing.Color.White;
            this.btnTotalPag.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPag.HoveredState.Parent = this.btnTotalPag;
            this.btnTotalPag.Location = new System.Drawing.Point(149, 13);
            this.btnTotalPag.Name = "btnTotalPag";
            this.btnTotalPag.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalPag.ShadowDecoration.Parent = this.btnTotalPag;
            this.btnTotalPag.Size = new System.Drawing.Size(29, 29);
            this.btnTotalPag.TabIndex = 169;
            this.btnTotalPag.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(124, 20);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(20, 15);
            this.label41.TabIndex = 170;
            this.label41.Text = "de";
            // 
            // dgVentas
            // 
            this.dgVentas.AllowUserToAddRows = false;
            this.dgVentas.AllowUserToDeleteRows = false;
            this.dgVentas.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgVentas.ColumnHeadersHeight = 45;
            this.dgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Numero_lv,
            this.CodVenta_lv,
            this.fechaPago,
            this.FECHAVENTA,
            this.fechaFinContrato,
            this.Vehiculos_lv,
            this.Ciente_Rs_lv,
            this.Plan_lv,
            this.TipoVenta,
            this.Estado_lv,
            this.EstadoContrato,
            this.Usuario_lv,
            this.ImporteTotal,
            this.txtEstado,
            this.lvBtnImprimir,
            this.idTipoTarida,
            this.idContrato});
            this.dgVentas.ContextMenuStrip = this.cmsAnularVenta;
            this.dgVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVentas.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgVentas.EnableHeadersVisualStyles = false;
            this.dgVentas.GridColor = System.Drawing.Color.Silver;
            this.dgVentas.Location = new System.Drawing.Point(8, 161);
            this.dgVentas.Name = "dgVentas";
            this.dgVentas.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgVentas.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgVentas.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgVentas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVentas.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.RowTemplate.Height = 50;
            this.dgVentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgVentas.Size = new System.Drawing.Size(958, 382);
            this.dgVentas.TabIndex = 228;
            this.dgVentas.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgVentas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgVentas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DimGray;
            this.dgVentas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgVentas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVentas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgVentas.ThemeStyle.HeaderStyle.Height = 45;
            this.dgVentas.ThemeStyle.ReadOnly = true;
            this.dgVentas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgVentas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVentas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgVentas.ThemeStyle.RowsStyle.Height = 50;
            this.dgVentas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.dgVentas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.SteelBlue;
            this.dgVentas.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Numero_lv
            // 
            this.Numero_lv.HeaderText = "N°";
            this.Numero_lv.Name = "Numero_lv";
            this.Numero_lv.ReadOnly = true;
            // 
            // CodVenta_lv
            // 
            this.CodVenta_lv.HeaderText = "Cod. Venta";
            this.CodVenta_lv.Name = "CodVenta_lv";
            this.CodVenta_lv.ReadOnly = true;
            this.CodVenta_lv.Visible = false;
            // 
            // fechaPago
            // 
            this.fechaPago.HeaderText = "Fecha Venta";
            this.fechaPago.Name = "fechaPago";
            this.fechaPago.ReadOnly = true;
            // 
            // FECHAVENTA
            // 
            this.FECHAVENTA.HeaderText = "Fecha inicio contrato";
            this.FECHAVENTA.Name = "FECHAVENTA";
            this.FECHAVENTA.ReadOnly = true;
            // 
            // fechaFinContrato
            // 
            this.fechaFinContrato.HeaderText = "Fecha fin contrato";
            this.fechaFinContrato.Name = "fechaFinContrato";
            this.fechaFinContrato.ReadOnly = true;
            // 
            // Vehiculos_lv
            // 
            this.Vehiculos_lv.HeaderText = "Vehiculos";
            this.Vehiculos_lv.Name = "Vehiculos_lv";
            this.Vehiculos_lv.ReadOnly = true;
            // 
            // Ciente_Rs_lv
            // 
            this.Ciente_Rs_lv.HeaderText = "Cliente/Razon Social";
            this.Ciente_Rs_lv.Name = "Ciente_Rs_lv";
            this.Ciente_Rs_lv.ReadOnly = true;
            // 
            // Plan_lv
            // 
            this.Plan_lv.HeaderText = "Plan";
            this.Plan_lv.Name = "Plan_lv";
            this.Plan_lv.ReadOnly = true;
            // 
            // TipoVenta
            // 
            this.TipoVenta.HeaderText = "Tipo Venta";
            this.TipoVenta.Name = "TipoVenta";
            this.TipoVenta.ReadOnly = true;
            // 
            // Estado_lv
            // 
            this.Estado_lv.HeaderText = "Estado";
            this.Estado_lv.Name = "Estado_lv";
            this.Estado_lv.ReadOnly = true;
            // 
            // EstadoContrato
            // 
            this.EstadoContrato.HeaderText = "Estado Contrato";
            this.EstadoContrato.Name = "EstadoContrato";
            this.EstadoContrato.ReadOnly = true;
            // 
            // Usuario_lv
            // 
            this.Usuario_lv.HeaderText = "Usuario";
            this.Usuario_lv.Name = "Usuario_lv";
            this.Usuario_lv.ReadOnly = true;
            // 
            // ImporteTotal
            // 
            this.ImporteTotal.HeaderText = "Importe Total";
            this.ImporteTotal.Name = "ImporteTotal";
            this.ImporteTotal.ReadOnly = true;
            // 
            // txtEstado
            // 
            this.txtEstado.HeaderText = "Estado Renovacion";
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            // 
            // lvBtnImprimir
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lvBtnImprimir.DefaultCellStyle = dataGridViewCellStyle9;
            this.lvBtnImprimir.HeaderText = "";
            this.lvBtnImprimir.Name = "lvBtnImprimir";
            this.lvBtnImprimir.ReadOnly = true;
            // 
            // idTipoTarida
            // 
            this.idTipoTarida.HeaderText = "idTipoTarida";
            this.idTipoTarida.Name = "idTipoTarida";
            this.idTipoTarida.ReadOnly = true;
            this.idTipoTarida.Visible = false;
            // 
            // idContrato
            // 
            this.idContrato.HeaderText = "idContrato";
            this.idContrato.Name = "idContrato";
            this.idContrato.ReadOnly = true;
            this.idContrato.Visible = false;
            // 
            // frmAnularVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 593);
            this.Controls.Add(this.dgVentas);
            this.Controls.Add(this.gbPaginacion);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.siticonePanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnularVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAnularVenta";
            this.Load += new System.EventHandler(this.frmAnularVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.cmsAnularVenta.ResumeLayout(false);
            this.gbBuscarListaVentas.ResumeLayout(false);
            this.gbBuscarListaVentas.PerformLayout();
            this.siticonePanel2.ResumeLayout(false);
            this.siticonePanel2.PerformLayout();
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbBuscarListaVentas;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaFinalBus;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaInicialBus;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label14;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private System.Windows.Forms.Label label13;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel2;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.CheckBox cbFechas;
        private System.Windows.Forms.ContextMenuStrip cmsAnularVenta;
        private System.Windows.Forms.ToolStripMenuItem eliminarRegistroToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbF0;
        private System.Windows.Forms.CheckBox cbR0;
        private System.Windows.Forms.ToolStripMenuItem eliminarContratoToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private Siticone.UI.WinForms.SiticoneCircleButton btnNumFilas;
        private System.Windows.Forms.Label label37;
        private Siticone.UI.WinForms.SiticoneVSeparator siticoneVSeparator1;
        private System.Windows.Forms.ComboBox cboPagina;
        private System.Windows.Forms.Label label40;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalReg;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalPag;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox checkBox1;
        private Siticone.UI.WinForms.SiticoneDataGridView dgVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodVenta_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAVENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFinContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehiculos_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciente_Rs_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario_lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEstado;
        private System.Windows.Forms.DataGridViewButtonColumn lvBtnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoTarida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idContrato;
        private System.Windows.Forms.ComboBox cboNotaCredit;
    }
}