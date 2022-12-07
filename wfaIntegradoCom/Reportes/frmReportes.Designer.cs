namespace wfaIntegradoCom.Reportes
{
    partial class frmReportes
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
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.siticoneGroupBox1 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.chkHabilitarFechasBusG = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.pbBuscar = new FontAwesome.Sharp.IconPictureBox();
            this.txtBuscar = new Siticone.UI.WinForms.SiticoneTextBox();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneLabel3 = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneLabel11 = new Siticone.UI.WinForms.SiticoneLabel();
            this.cboEstado = new Siticone.UI.WinForms.SiticoneComboBox();
            this.cboCiclo = new Siticone.UI.WinForms.SiticoneComboBox();
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.dtpFechaFinalBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaInicialBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.siticoneGroupBox2 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.siticoneCheckBox1 = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.pbBuscar1 = new FontAwesome.Sharp.IconPictureBox();
            this.siticoneTextBox1 = new Siticone.UI.WinForms.SiticoneTextBox();
            this.siticoneLabel2 = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneLabel4 = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneComboBox1 = new Siticone.UI.WinForms.SiticoneComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.siticoneDateTimePicker1 = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.siticoneDateTimePicker2 = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaControlBox3 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.siticonePanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.siticoneGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).BeginInit();
            this.gbBuscar.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.siticoneGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel1.BorderThickness = 2;
            this.siticonePanel1.Controls.Add(this.tabControl1);
            this.siticonePanel1.Controls.Add(this.gunaPanel1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(788, 521);
            this.siticonePanel1.TabIndex = 0;
            this.siticonePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.siticonePanel1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 491);
            this.tabControl1.TabIndex = 165;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Controls.Add(this.siticoneGroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(773, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recaudación";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(3, 160);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(767, 302);
            this.reportViewer1.TabIndex = 270;
            // 
            // siticoneGroupBox1
            // 
            this.siticoneGroupBox1.BorderRadius = 5;
            this.siticoneGroupBox1.Controls.Add(this.chkHabilitarFechasBusG);
            this.siticoneGroupBox1.Controls.Add(this.pbBuscar);
            this.siticoneGroupBox1.Controls.Add(this.txtBuscar);
            this.siticoneGroupBox1.Controls.Add(this.siticoneLabel1);
            this.siticoneGroupBox1.Controls.Add(this.siticoneLabel3);
            this.siticoneGroupBox1.Controls.Add(this.siticoneLabel11);
            this.siticoneGroupBox1.Controls.Add(this.cboEstado);
            this.siticoneGroupBox1.Controls.Add(this.cboCiclo);
            this.siticoneGroupBox1.Controls.Add(this.gbBuscar);
            this.siticoneGroupBox1.CustomBorderColor = System.Drawing.Color.Gray;
            this.siticoneGroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.siticoneGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticoneGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneGroupBox1.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.siticoneGroupBox1.Name = "siticoneGroupBox1";
            this.siticoneGroupBox1.ShadowDecoration.Parent = this.siticoneGroupBox1;
            this.siticoneGroupBox1.Size = new System.Drawing.Size(767, 157);
            this.siticoneGroupBox1.TabIndex = 269;
            this.siticoneGroupBox1.Text = "Buscar fechas";
            this.siticoneGroupBox1.TextOffset = new System.Drawing.Point(0, -10);
            // 
            // chkHabilitarFechasBusG
            // 
            this.chkHabilitarFechasBusG.AutoSize = true;
            this.chkHabilitarFechasBusG.BackColor = System.Drawing.Color.Transparent;
            this.chkHabilitarFechasBusG.Checked = true;
            this.chkHabilitarFechasBusG.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkHabilitarFechasBusG.CheckedState.BorderRadius = 0;
            this.chkHabilitarFechasBusG.CheckedState.BorderThickness = 0;
            this.chkHabilitarFechasBusG.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkHabilitarFechasBusG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitarFechasBusG.FlatAppearance.BorderSize = 0;
            this.chkHabilitarFechasBusG.ForeColor = System.Drawing.Color.DimGray;
            this.chkHabilitarFechasBusG.Location = new System.Drawing.Point(168, 18);
            this.chkHabilitarFechasBusG.Name = "chkHabilitarFechasBusG";
            this.chkHabilitarFechasBusG.Size = new System.Drawing.Size(110, 19);
            this.chkHabilitarFechasBusG.TabIndex = 268;
            this.chkHabilitarFechasBusG.Text = "Habilitar Fechas";
            this.chkHabilitarFechasBusG.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechasBusG.UncheckedState.BorderRadius = 0;
            this.chkHabilitarFechasBusG.UncheckedState.BorderThickness = 0;
            this.chkHabilitarFechasBusG.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechasBusG.UseVisualStyleBackColor = false;
            // 
            // pbBuscar
            // 
            this.pbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBuscar.ForeColor = System.Drawing.Color.Gray;
            this.pbBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.pbBuscar.IconColor = System.Drawing.Color.Gray;
            this.pbBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbBuscar.IconSize = 27;
            this.pbBuscar.Location = new System.Drawing.Point(716, 108);
            this.pbBuscar.Name = "pbBuscar";
            this.pbBuscar.Size = new System.Drawing.Size(27, 34);
            this.pbBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscar.TabIndex = 239;
            this.pbBuscar.TabStop = false;
            this.pbBuscar.Tag = "pbBuscar";
            this.pbBuscar.Click += new System.EventHandler(this.pbBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Animated = false;
            this.txtBuscar.BorderRadius = 5;
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
            this.txtBuscar.Location = new System.Drawing.Point(539, 107);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderText = "";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            this.txtBuscar.Size = new System.Drawing.Size(206, 36);
            this.txtBuscar.TabIndex = 238;
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel1.Location = new System.Drawing.Point(539, 90);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(68, 15);
            this.siticoneLabel1.TabIndex = 236;
            this.siticoneLabel1.Text = "Tipo Reporte:";
            // 
            // siticoneLabel3
            // 
            this.siticoneLabel3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel3.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel3.Location = new System.Drawing.Point(284, 90);
            this.siticoneLabel3.Name = "siticoneLabel3";
            this.siticoneLabel3.Size = new System.Drawing.Size(39, 15);
            this.siticoneLabel3.TabIndex = 236;
            this.siticoneLabel3.Text = "Estado:";
            // 
            // siticoneLabel11
            // 
            this.siticoneLabel11.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel11.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel11.Location = new System.Drawing.Point(284, 34);
            this.siticoneLabel11.Name = "siticoneLabel11";
            this.siticoneLabel11.Size = new System.Drawing.Size(29, 15);
            this.siticoneLabel11.TabIndex = 236;
            this.siticoneLabel11.Text = "Ciclo:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.Transparent;
            this.cboEstado.BorderRadius = 5;
            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstado.HoveredState.Parent = this.cboEstado;
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.ItemsAppearance.Parent = this.cboEstado;
            this.cboEstado.Location = new System.Drawing.Point(284, 107);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.ShadowDecoration.Parent = this.cboEstado;
            this.cboEstado.Size = new System.Drawing.Size(206, 36);
            this.cboEstado.TabIndex = 237;
            // 
            // cboCiclo
            // 
            this.cboCiclo.BackColor = System.Drawing.Color.Transparent;
            this.cboCiclo.BorderRadius = 5;
            this.cboCiclo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiclo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCiclo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCiclo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCiclo.HoveredState.Parent = this.cboCiclo;
            this.cboCiclo.ItemHeight = 30;
            this.cboCiclo.ItemsAppearance.Parent = this.cboCiclo;
            this.cboCiclo.Location = new System.Drawing.Point(284, 51);
            this.cboCiclo.Name = "cboCiclo";
            this.cboCiclo.ShadowDecoration.Parent = this.cboCiclo;
            this.cboCiclo.Size = new System.Drawing.Size(206, 36);
            this.cboCiclo.TabIndex = 237;
            // 
            // gbBuscar
            // 
            this.gbBuscar.BackColor = System.Drawing.Color.White;
            this.gbBuscar.Controls.Add(this.dtpFechaFinalBus);
            this.gbBuscar.Controls.Add(this.label14);
            this.gbBuscar.Controls.Add(this.dtpFechaInicialBus);
            this.gbBuscar.Controls.Add(this.label1);
            this.gbBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbBuscar.Location = new System.Drawing.Point(4, 29);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(274, 117);
            this.gbBuscar.TabIndex = 269;
            this.gbBuscar.TabStop = false;
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
            this.dtpFechaFinalBus.Location = new System.Drawing.Point(17, 78);
            this.dtpFechaFinalBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFinalBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFinalBus.Name = "dtpFechaFinalBus";
            this.dtpFechaFinalBus.ShadowDecoration.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Size = new System.Drawing.Size(235, 36);
            this.dtpFechaFinalBus.TabIndex = 233;
            this.dtpFechaFinalBus.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(17, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 227;
            this.label14.Text = "Fecha Inicial:";
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
            this.dtpFechaInicialBus.Location = new System.Drawing.Point(17, 25);
            this.dtpFechaInicialBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicialBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicialBus.Name = "dtpFechaInicialBus";
            this.dtpFechaInicialBus.ShadowDecoration.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.Size = new System.Drawing.Size(235, 36);
            this.dtpFechaInicialBus.TabIndex = 231;
            this.dtpFechaInicialBus.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(17, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 232;
            this.label1.Text = "Fecha Final:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Controls.Add(this.siticoneGroupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Renovaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(3, 160);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(767, 302);
            this.reportViewer2.TabIndex = 271;
            // 
            // siticoneGroupBox2
            // 
            this.siticoneGroupBox2.BorderRadius = 5;
            this.siticoneGroupBox2.Controls.Add(this.siticoneCheckBox1);
            this.siticoneGroupBox2.Controls.Add(this.pbBuscar1);
            this.siticoneGroupBox2.Controls.Add(this.siticoneTextBox1);
            this.siticoneGroupBox2.Controls.Add(this.siticoneLabel2);
            this.siticoneGroupBox2.Controls.Add(this.siticoneLabel4);
            this.siticoneGroupBox2.Controls.Add(this.siticoneComboBox1);
            this.siticoneGroupBox2.Controls.Add(this.groupBox1);
            this.siticoneGroupBox2.CustomBorderColor = System.Drawing.Color.Gray;
            this.siticoneGroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.siticoneGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticoneGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneGroupBox2.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.siticoneGroupBox2.Name = "siticoneGroupBox2";
            this.siticoneGroupBox2.ShadowDecoration.Parent = this.siticoneGroupBox2;
            this.siticoneGroupBox2.Size = new System.Drawing.Size(767, 157);
            this.siticoneGroupBox2.TabIndex = 270;
            this.siticoneGroupBox2.Text = "Buscar fechas";
            this.siticoneGroupBox2.TextOffset = new System.Drawing.Point(0, -10);
            // 
            // siticoneCheckBox1
            // 
            this.siticoneCheckBox1.AutoSize = true;
            this.siticoneCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneCheckBox1.Checked = true;
            this.siticoneCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneCheckBox1.CheckedState.BorderRadius = 0;
            this.siticoneCheckBox1.CheckedState.BorderThickness = 0;
            this.siticoneCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.siticoneCheckBox1.FlatAppearance.BorderSize = 0;
            this.siticoneCheckBox1.ForeColor = System.Drawing.Color.DimGray;
            this.siticoneCheckBox1.Location = new System.Drawing.Point(168, 18);
            this.siticoneCheckBox1.Name = "siticoneCheckBox1";
            this.siticoneCheckBox1.Size = new System.Drawing.Size(110, 19);
            this.siticoneCheckBox1.TabIndex = 268;
            this.siticoneCheckBox1.Text = "Habilitar Fechas";
            this.siticoneCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.siticoneCheckBox1.UncheckedState.BorderRadius = 0;
            this.siticoneCheckBox1.UncheckedState.BorderThickness = 0;
            this.siticoneCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.siticoneCheckBox1.UseVisualStyleBackColor = false;
            // 
            // pbBuscar1
            // 
            this.pbBuscar1.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBuscar1.ForeColor = System.Drawing.Color.Gray;
            this.pbBuscar1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.pbBuscar1.IconColor = System.Drawing.Color.Gray;
            this.pbBuscar1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbBuscar1.IconSize = 27;
            this.pbBuscar1.Location = new System.Drawing.Point(716, 108);
            this.pbBuscar1.Name = "pbBuscar1";
            this.pbBuscar1.Size = new System.Drawing.Size(27, 34);
            this.pbBuscar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscar1.TabIndex = 239;
            this.pbBuscar1.TabStop = false;
            this.pbBuscar1.Tag = "pbBuscar";
            this.pbBuscar1.Click += new System.EventHandler(this.pbBuscar1_Click);
            // 
            // siticoneTextBox1
            // 
            this.siticoneTextBox1.Animated = false;
            this.siticoneTextBox1.BorderRadius = 5;
            this.siticoneTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.siticoneTextBox1.DefaultText = "";
            this.siticoneTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.siticoneTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.siticoneTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.siticoneTextBox1.DisabledState.Parent = this.siticoneTextBox1;
            this.siticoneTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.siticoneTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneTextBox1.FocusedState.Parent = this.siticoneTextBox1;
            this.siticoneTextBox1.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneTextBox1.HoveredState.Parent = this.siticoneTextBox1;
            this.siticoneTextBox1.Location = new System.Drawing.Point(539, 107);
            this.siticoneTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.siticoneTextBox1.Name = "siticoneTextBox1";
            this.siticoneTextBox1.PasswordChar = '\0';
            this.siticoneTextBox1.PlaceholderText = "";
            this.siticoneTextBox1.SelectedText = "";
            this.siticoneTextBox1.ShadowDecoration.Parent = this.siticoneTextBox1;
            this.siticoneTextBox1.Size = new System.Drawing.Size(206, 36);
            this.siticoneTextBox1.TabIndex = 238;
            // 
            // siticoneLabel2
            // 
            this.siticoneLabel2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel2.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel2.Location = new System.Drawing.Point(539, 90);
            this.siticoneLabel2.Name = "siticoneLabel2";
            this.siticoneLabel2.Size = new System.Drawing.Size(68, 15);
            this.siticoneLabel2.TabIndex = 236;
            this.siticoneLabel2.Text = "Tipo Reporte:";
            // 
            // siticoneLabel4
            // 
            this.siticoneLabel4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel4.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel4.Location = new System.Drawing.Point(284, 90);
            this.siticoneLabel4.Name = "siticoneLabel4";
            this.siticoneLabel4.Size = new System.Drawing.Size(39, 15);
            this.siticoneLabel4.TabIndex = 236;
            this.siticoneLabel4.Text = "Estado:";
            // 
            // siticoneComboBox1
            // 
            this.siticoneComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneComboBox1.BorderRadius = 5;
            this.siticoneComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.siticoneComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siticoneComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.siticoneComboBox1.HoveredState.Parent = this.siticoneComboBox1;
            this.siticoneComboBox1.ItemHeight = 30;
            this.siticoneComboBox1.ItemsAppearance.Parent = this.siticoneComboBox1;
            this.siticoneComboBox1.Location = new System.Drawing.Point(284, 107);
            this.siticoneComboBox1.Name = "siticoneComboBox1";
            this.siticoneComboBox1.ShadowDecoration.Parent = this.siticoneComboBox1;
            this.siticoneComboBox1.Size = new System.Drawing.Size(206, 36);
            this.siticoneComboBox1.TabIndex = 237;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.siticoneDateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.siticoneDateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(4, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 117);
            this.groupBox1.TabIndex = 269;
            this.groupBox1.TabStop = false;
            // 
            // siticoneDateTimePicker1
            // 
            this.siticoneDateTimePicker1.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneDateTimePicker1.BorderRadius = 3;
            this.siticoneDateTimePicker1.BorderThickness = 1;
            this.siticoneDateTimePicker1.CheckedState.Parent = this.siticoneDateTimePicker1;
            this.siticoneDateTimePicker1.FillColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.siticoneDateTimePicker1.HoveredState.Parent = this.siticoneDateTimePicker1;
            this.siticoneDateTimePicker1.Location = new System.Drawing.Point(17, 78);
            this.siticoneDateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.siticoneDateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.siticoneDateTimePicker1.Name = "siticoneDateTimePicker1";
            this.siticoneDateTimePicker1.ShadowDecoration.Parent = this.siticoneDateTimePicker1;
            this.siticoneDateTimePicker1.Size = new System.Drawing.Size(235, 36);
            this.siticoneDateTimePicker1.TabIndex = 233;
            this.siticoneDateTimePicker1.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(17, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 227;
            this.label2.Text = "Fecha Inicial:";
            // 
            // siticoneDateTimePicker2
            // 
            this.siticoneDateTimePicker2.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneDateTimePicker2.BorderRadius = 3;
            this.siticoneDateTimePicker2.BorderThickness = 1;
            this.siticoneDateTimePicker2.CheckedState.Parent = this.siticoneDateTimePicker2;
            this.siticoneDateTimePicker2.FillColor = System.Drawing.Color.White;
            this.siticoneDateTimePicker2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.siticoneDateTimePicker2.HoveredState.Parent = this.siticoneDateTimePicker2;
            this.siticoneDateTimePicker2.Location = new System.Drawing.Point(17, 25);
            this.siticoneDateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.siticoneDateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.siticoneDateTimePicker2.Name = "siticoneDateTimePicker2";
            this.siticoneDateTimePicker2.ShadowDecoration.Parent = this.siticoneDateTimePicker2;
            this.siticoneDateTimePicker2.Size = new System.Drawing.Size(235, 36);
            this.siticoneDateTimePicker2.TabIndex = 231;
            this.siticoneDateTimePicker2.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(17, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 232;
            this.label4.Text = "Fecha Final:";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.gunaPanel1.Controls.Add(this.label3);
            this.gunaPanel1.Controls.Add(this.gunaControlBox3);
            this.gunaPanel1.Controls.Add(this.gunaControlBox2);
            this.gunaPanel1.Controls.Add(this.gunaControlBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(788, 29);
            this.gunaPanel1.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 76;
            this.label3.Text = "Reportes";
            // 
            // gunaControlBox3
            // 
            this.gunaControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox3.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox3.AnimationSpeed = 0.03F;
            this.gunaControlBox3.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MaximizeBox;
            this.gunaControlBox3.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox3.IconSize = 15F;
            this.gunaControlBox3.Location = new System.Drawing.Point(696, 0);
            this.gunaControlBox3.Name = "gunaControlBox3";
            this.gunaControlBox3.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox3.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox3.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox3.TabIndex = 75;
            this.gunaControlBox3.Click += new System.EventHandler(this.gunaControlBox3_Click);
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(651, 0);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 75;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(739, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 74;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 521);
            this.Controls.Add(this.siticonePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.siticoneGroupBox1.ResumeLayout(false);
            this.siticoneGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).EndInit();
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.siticoneGroupBox2.ResumeLayout(false);
            this.siticoneGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox3;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox1;
        private Siticone.UI.WinForms.SiticoneCheckBox chkHabilitarFechasBusG;
        private FontAwesome.Sharp.IconPictureBox pbBuscar;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscar;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel3;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel11;
        private Siticone.UI.WinForms.SiticoneComboBox cboEstado;
        private Siticone.UI.WinForms.SiticoneComboBox cboCiclo;
        private System.Windows.Forms.GroupBox gbBuscar;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaFinalBus;
        private System.Windows.Forms.Label label14;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaInicialBus;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox2;
        private Siticone.UI.WinForms.SiticoneCheckBox siticoneCheckBox1;
        private FontAwesome.Sharp.IconPictureBox pbBuscar1;
        private Siticone.UI.WinForms.SiticoneTextBox siticoneTextBox1;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel2;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel4;
        private Siticone.UI.WinForms.SiticoneComboBox siticoneComboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Siticone.UI.WinForms.SiticoneDateTimePicker siticoneDateTimePicker1;
        private System.Windows.Forms.Label label2;
        private Siticone.UI.WinForms.SiticoneDateTimePicker siticoneDateTimePicker2;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}