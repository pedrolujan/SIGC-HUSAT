using System.ComponentModel;
using System.Windows.Forms;

namespace wfaIntegradoCom.Mantenedores
{
    partial class frmRegistrarVehiculo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarVehiculo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.epVehiculo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.panelFondo = new Siticone.UI.WinForms.SiticonePanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgVehiculo = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modo_uso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuVehiculo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new Guna.UI.WinForms.GunaButton();
            this.cboPropietario = new Siticone.UI.WinForms.SiticoneComboBox();
            this.lblCboPropietario = new System.Windows.Forms.Label();
            this.gbBuscar = new Guna.UI.WinForms.GunaGroupBox();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbPlaca = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.gbDatosVehiculo = new Guna.UI.WinForms.GunaGroupBox();
            this.txtPlaca2 = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.pbObsevacion = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtidVehiculo = new System.Windows.Forms.TextBox();
            this.pbAnio = new System.Windows.Forms.PictureBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.pbSerie = new System.Windows.Forms.PictureBox();
            this.cboModUso = new Siticone.UI.WinForms.SiticoneComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cboModeloVh = new Siticone.UI.WinForms.SiticoneComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbModoUso = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMarcaVh = new Siticone.UI.WinForms.SiticoneComboBox();
            this.txtObservaciones = new Siticone.UI.WinForms.SiticoneTextBox();
            this.pbModelo = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboClaseV = new Siticone.UI.WinForms.SiticoneComboBox();
            this.pbPlaca = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.lblCboModoUso = new System.Windows.Forms.Label();
            this.txtColorVh = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtAnio = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtSerieVh = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtConPlaca = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtPlacaVh = new Siticone.UI.WinForms.SiticoneTextBox();
            this.chkOtro = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMarca = new System.Windows.Forms.PictureBox();
            this.lblCboClase = new System.Windows.Forms.Label();
            this.lblCboModelo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblPlacaVehiculo = new System.Windows.Forms.Label();
            this.pbClase = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCboMarca = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new Siticone.UI.WinForms.SiticoneButton();
            this.btnEditar = new Siticone.UI.WinForms.SiticoneButton();
            this.btnNuevo = new Siticone.UI.WinForms.SiticoneButton();
            this.pbSearch = new Guna.UI.WinForms.GunaPictureBox();
            this.txtBuscarVehiculo = new Siticone.UI.WinForms.SiticoneTextBox();
            this.gbRegistros = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.btnCantRegistros = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.lblCantRegistrosTotal = new System.Windows.Forms.Label();
            this.btnCantTotalRegistros = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPaginas = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.cboPaginacion = new Siticone.UI.WinForms.SiticoneComboBox();
            this.btnTotalPaginas = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.siticoneGroupBox3 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.btnCantRegistrosM = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCantTotalRegistrosM = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label16 = new System.Windows.Forms.Label();
            this.siticoneGroupBox4 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.cboPaginacionM = new Siticone.UI.WinForms.SiticoneComboBox();
            this.btnTotalPaginasM = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscarVehiculoM = new Siticone.UI.WinForms.SiticoneTextBox();
            this.dgConsultas = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.SIMCARDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siticoneGroupBox1 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.siticoneGroupBox2 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.rbVehiculo = new Siticone.UI.WinForms.SiticoneRadioButton();
            this.rbSerie = new Siticone.UI.WinForms.SiticoneRadioButton();
            this.chkHabilitarFechas = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.btnNuevoHistorial = new Siticone.UI.WinForms.SiticoneButton();
            this.dtHfechaFinal = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.dtHFechaInicio = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgMovimientoVH = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.n = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerieM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaseM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMsgMVehiculo = new System.Windows.Forms.Label();
            this.sDC1mover = new Siticone.UI.WinForms.SiticoneDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epVehiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.gunaPanel1.SuspendLayout();
            this.panelFondo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehiculo)).BeginInit();
            this.MenuVehiculo.SuspendLayout();
            this.gbBuscar.SuspendLayout();
            this.gbDatosVehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbObsevacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModoUso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.gbRegistros.SuspendLayout();
            this.gbPaginas.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.siticoneGroupBox3.SuspendLayout();
            this.siticoneGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultas)).BeginInit();
            this.siticoneGroupBox1.SuspendLayout();
            this.siticoneGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovimientoVH)).BeginInit();
            this.SuspendLayout();
            // 
            // epVehiculo
            // 
            this.epVehiculo.ContainerControl = this;
            // 
            // epControlOk
            // 
            this.epControlOk.ContainerControl = this;
            this.epControlOk.Icon = ((System.Drawing.Icon)(resources.GetObject("epControlOk.Icon")));
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.gunaPanel1.Controls.Add(this.label14);
            this.gunaPanel1.Controls.Add(this.gunaControlBox2);
            this.gunaPanel1.Controls.Add(this.gunaControlBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(1168, 34);
            this.gunaPanel1.TabIndex = 170;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(15, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 21);
            this.label14.TabIndex = 100;
            this.label14.Text = "Vehiculo";
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(1071, 2);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 1;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(1119, 2);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 0;
            // 
            // panelFondo
            // 
            this.panelFondo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.panelFondo.BorderThickness = 2;
            this.panelFondo.Controls.Add(this.tabControl1);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(0, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.ShadowDecoration.Parent = this.panelFondo;
            this.panelFondo.Size = new System.Drawing.Size(1168, 704);
            this.panelFondo.TabIndex = 177;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1134, 668);
            this.tabControl1.TabIndex = 178;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgVehiculo);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.cboPropietario);
            this.tabPage1.Controls.Add(this.lblCboPropietario);
            this.tabPage1.Controls.Add(this.gbBuscar);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.gbDatosVehiculo);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.btnEditar);
            this.tabPage1.Controls.Add(this.btnNuevo);
            this.tabPage1.Controls.Add(this.pbSearch);
            this.tabPage1.Controls.Add(this.txtBuscarVehiculo);
            this.tabPage1.Controls.Add(this.gbRegistros);
            this.tabPage1.Controls.Add(this.gbPaginas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1126, 642);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vehiculo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgVehiculo
            // 
            this.dgVehiculo.AllowUserToAddRows = false;
            this.dgVehiculo.AllowUserToDeleteRows = false;
            this.dgVehiculo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgVehiculo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVehiculo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVehiculo.BackgroundColor = System.Drawing.Color.White;
            this.dgVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgVehiculo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehiculo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgVehiculo.ColumnHeadersHeight = 24;
            this.dgVehiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.Column1,
            this.Placa,
            this.serie,
            this.Clase,
            this.Marca,
            this.Modelo,
            this.Modo_uso,
            this.Estado});
            this.dgVehiculo.ContextMenuStrip = this.MenuVehiculo;
            this.dgVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVehiculo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgVehiculo.EnableHeadersVisualStyles = false;
            this.dgVehiculo.GridColor = System.Drawing.Color.LightGray;
            this.dgVehiculo.Location = new System.Drawing.Point(169, 41);
            this.dgVehiculo.Name = "dgVehiculo";
            this.dgVehiculo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehiculo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgVehiculo.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVehiculo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgVehiculo.RowTemplate.ReadOnly = true;
            this.dgVehiculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVehiculo.Size = new System.Drawing.Size(951, 486);
            this.dgVehiculo.TabIndex = 178;
            this.dgVehiculo.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgVehiculo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVehiculo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgVehiculo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgVehiculo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgVehiculo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgVehiculo.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgVehiculo.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dgVehiculo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.dgVehiculo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgVehiculo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVehiculo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgVehiculo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgVehiculo.ThemeStyle.HeaderStyle.Height = 24;
            this.dgVehiculo.ThemeStyle.ReadOnly = true;
            this.dgVehiculo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVehiculo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgVehiculo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVehiculo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgVehiculo.ThemeStyle.RowsStyle.Height = 22;
            this.dgVehiculo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgVehiculo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgVehiculo.Visible = false;
            this.dgVehiculo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVehiculo_CellDoubleClick);
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.MinimumWidth = 2;
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Placa
            // 
            this.Placa.FillWeight = 79.47787F;
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            // 
            // serie
            // 
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            // 
            // Clase
            // 
            this.Clase.FillWeight = 79.47787F;
            this.Clase.HeaderText = "Clase";
            this.Clase.Name = "Clase";
            this.Clase.ReadOnly = true;
            // 
            // Marca
            // 
            this.Marca.FillWeight = 79.47787F;
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Modelo
            // 
            this.Modelo.FillWeight = 79.47787F;
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // Modo_uso
            // 
            this.Modo_uso.FillWeight = 79.47787F;
            this.Modo_uso.HeaderText = "Modo de uso";
            this.Modo_uso.Name = "Modo_uso";
            this.Modo_uso.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.FillWeight = 79.47787F;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // MenuVehiculo
            // 
            this.MenuVehiculo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcHistorial});
            this.MenuVehiculo.Name = "MenuImies";
            this.MenuVehiculo.Size = new System.Drawing.Size(272, 26);
            // 
            // opcHistorial
            // 
            this.opcHistorial.Name = "opcHistorial";
            this.opcHistorial.Size = new System.Drawing.Size(271, 22);
            this.opcHistorial.Text = "Ver historial de Vehiculo seleccionado";
            this.opcHistorial.Click += new System.EventHandler(this.opcHistorial_Click);
            // 
            // button1
            // 
            this.button1.AnimationHoverSpeed = 0.07F;
            this.button1.AnimationSpeed = 0.03F;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BaseColor = System.Drawing.Color.Transparent;
            this.button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(57)))));
            this.button1.BorderSize = 1;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.button1.Enabled = false;
            this.button1.FocusedColor = System.Drawing.Color.Empty;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.button1.Image = global::wfaIntegradoCom.Properties.Resources.search_base;
            this.button1.ImageSize = new System.Drawing.Size(15, 15);
            this.button1.Location = new System.Drawing.Point(169, 595);
            this.button1.Name = "button1";
            this.button1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(57)))));
            this.button1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(57)))));
            this.button1.OnHoverForeColor = System.Drawing.Color.White;
            this.button1.OnHoverImage = global::wfaIntegradoCom.Properties.Resources.search_hover;
            this.button1.OnPressedColor = System.Drawing.Color.Black;
            this.button1.Radius = 15;
            this.button1.Size = new System.Drawing.Size(161, 36);
            this.button1.TabIndex = 138;
            this.button1.Text = "Buscar Cliente...";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPropietario
            // 
            this.cboPropietario.BackColor = System.Drawing.Color.Transparent;
            this.cboPropietario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropietario.Enabled = false;
            this.cboPropietario.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPropietario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboPropietario.HoveredState.Parent = this.cboPropietario;
            this.cboPropietario.ItemHeight = 30;
            this.cboPropietario.ItemsAppearance.Parent = this.cboPropietario;
            this.cboPropietario.Location = new System.Drawing.Point(13, 595);
            this.cboPropietario.Name = "cboPropietario";
            this.cboPropietario.ShadowDecoration.Parent = this.cboPropietario;
            this.cboPropietario.Size = new System.Drawing.Size(120, 36);
            this.cboPropietario.TabIndex = 88;
            this.cboPropietario.Visible = false;
            this.cboPropietario.SelectedIndexChanged += new System.EventHandler(this.cboPropietario_SelectedIndexChanged);
            // 
            // lblCboPropietario
            // 
            this.lblCboPropietario.AutoSize = true;
            this.lblCboPropietario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboPropietario.ForeColor = System.Drawing.Color.Red;
            this.lblCboPropietario.Location = new System.Drawing.Point(233, 476);
            this.lblCboPropietario.Name = "lblCboPropietario";
            this.lblCboPropietario.Size = new System.Drawing.Size(0, 13);
            this.lblCboPropietario.TabIndex = 69;
            // 
            // gbBuscar
            // 
            this.gbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.gbBuscar.BaseColor = System.Drawing.Color.White;
            this.gbBuscar.BorderColor = System.Drawing.Color.DarkGray;
            this.gbBuscar.BorderSize = 1;
            this.gbBuscar.Controls.Add(this.rbNombre);
            this.gbBuscar.Controls.Add(this.rbPlaca);
            this.gbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscar.ForeColor = System.Drawing.Color.White;
            this.gbBuscar.LineColor = System.Drawing.Color.DimGray;
            this.gbBuscar.LineTop = 20;
            this.gbBuscar.Location = new System.Drawing.Point(3, 5);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Radius = 5;
            this.gbBuscar.Size = new System.Drawing.Size(160, 82);
            this.gbBuscar.TabIndex = 186;
            this.gbBuscar.Text = "BUSCAR POR:";
            this.gbBuscar.TextLocation = new System.Drawing.Point(10, 3);
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbNombre.Location = new System.Drawing.Point(21, 53);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(58, 20);
            this.rbNombre.TabIndex = 3;
            this.rbNombre.Text = "Serie";
            this.rbNombre.UseVisualStyleBackColor = true;
            // 
            // rbPlaca
            // 
            this.rbPlaca.AutoSize = true;
            this.rbPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbPlaca.Location = new System.Drawing.Point(21, 27);
            this.rbPlaca.Name = "rbPlaca";
            this.rbPlaca.Size = new System.Drawing.Size(61, 20);
            this.rbPlaca.TabIndex = 4;
            this.rbPlaca.Text = "Placa";
            this.rbPlaca.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(16, 575);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Propietario (*)";
            this.label7.Visible = false;
            // 
            // gbDatosVehiculo
            // 
            this.gbDatosVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.gbDatosVehiculo.BaseColor = System.Drawing.Color.White;
            this.gbDatosVehiculo.BorderColor = System.Drawing.Color.DarkGray;
            this.gbDatosVehiculo.BorderSize = 1;
            this.gbDatosVehiculo.Controls.Add(this.txtPlaca2);
            this.gbDatosVehiculo.Controls.Add(this.chkActivo);
            this.gbDatosVehiculo.Controls.Add(this.pbColor);
            this.gbDatosVehiculo.Controls.Add(this.pbObsevacion);
            this.gbDatosVehiculo.Controls.Add(this.label11);
            this.gbDatosVehiculo.Controls.Add(this.lblColor);
            this.gbDatosVehiculo.Controls.Add(this.txtidVehiculo);
            this.gbDatosVehiculo.Controls.Add(this.pbAnio);
            this.gbDatosVehiculo.Controls.Add(this.lblObservacion);
            this.gbDatosVehiculo.Controls.Add(this.pbSerie);
            this.gbDatosVehiculo.Controls.Add(this.cboModUso);
            this.gbDatosVehiculo.Controls.Add(this.label10);
            this.gbDatosVehiculo.Controls.Add(this.lblAnio);
            this.gbDatosVehiculo.Controls.Add(this.cboModeloVh);
            this.gbDatosVehiculo.Controls.Add(this.label5);
            this.gbDatosVehiculo.Controls.Add(this.pbModoUso);
            this.gbDatosVehiculo.Controls.Add(this.label9);
            this.gbDatosVehiculo.Controls.Add(this.cboMarcaVh);
            this.gbDatosVehiculo.Controls.Add(this.txtObservaciones);
            this.gbDatosVehiculo.Controls.Add(this.pbModelo);
            this.gbDatosVehiculo.Controls.Add(this.label8);
            this.gbDatosVehiculo.Controls.Add(this.cboClaseV);
            this.gbDatosVehiculo.Controls.Add(this.pbPlaca);
            this.gbDatosVehiculo.Controls.Add(this.lblCboModoUso);
            this.gbDatosVehiculo.Controls.Add(this.txtColorVh);
            this.gbDatosVehiculo.Controls.Add(this.txtAnio);
            this.gbDatosVehiculo.Controls.Add(this.txtSerieVh);
            this.gbDatosVehiculo.Controls.Add(this.txtConPlaca);
            this.gbDatosVehiculo.Controls.Add(this.txtPlacaVh);
            this.gbDatosVehiculo.Controls.Add(this.chkOtro);
            this.gbDatosVehiculo.Controls.Add(this.label1);
            this.gbDatosVehiculo.Controls.Add(this.pbMarca);
            this.gbDatosVehiculo.Controls.Add(this.lblCboClase);
            this.gbDatosVehiculo.Controls.Add(this.lblCboModelo);
            this.gbDatosVehiculo.Controls.Add(this.lblPlaca);
            this.gbDatosVehiculo.Controls.Add(this.lblPlacaVehiculo);
            this.gbDatosVehiculo.Controls.Add(this.pbClase);
            this.gbDatosVehiculo.Controls.Add(this.label3);
            this.gbDatosVehiculo.Controls.Add(this.lblCboMarca);
            this.gbDatosVehiculo.Controls.Add(this.label6);
            this.gbDatosVehiculo.Controls.Add(this.lblSerie);
            this.gbDatosVehiculo.Controls.Add(this.label4);
            this.gbDatosVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosVehiculo.ForeColor = System.Drawing.Color.Silver;
            this.gbDatosVehiculo.LineColor = System.Drawing.Color.DimGray;
            this.gbDatosVehiculo.Location = new System.Drawing.Point(3, 92);
            this.gbDatosVehiculo.Name = "gbDatosVehiculo";
            this.gbDatosVehiculo.Radius = 5;
            this.gbDatosVehiculo.Size = new System.Drawing.Size(1075, 435);
            this.gbDatosVehiculo.TabIndex = 187;
            this.gbDatosVehiculo.Text = "DATOS DEL VEHICULO :";
            this.gbDatosVehiculo.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // txtPlaca2
            // 
            this.txtPlaca2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPlaca2.Location = new System.Drawing.Point(808, 29);
            this.txtPlaca2.Name = "txtPlaca2";
            this.txtPlaca2.Size = new System.Drawing.Size(100, 23);
            this.txtPlaca2.TabIndex = 85;
            this.txtPlaca2.Visible = false;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkActivo.Location = new System.Drawing.Point(783, 69);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(65, 21);
            this.chkActivo.TabIndex = 87;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.White;
            this.pbColor.Location = new System.Drawing.Point(987, 223);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(20, 20);
            this.pbColor.TabIndex = 72;
            this.pbColor.TabStop = false;
            // 
            // pbObsevacion
            // 
            this.pbObsevacion.BackColor = System.Drawing.SystemColors.Control;
            this.pbObsevacion.Location = new System.Drawing.Point(987, 306);
            this.pbObsevacion.Name = "pbObsevacion";
            this.pbObsevacion.Size = new System.Drawing.Size(20, 20);
            this.pbObsevacion.TabIndex = 83;
            this.pbObsevacion.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(783, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 86;
            this.label11.Text = "Estado";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.ForeColor = System.Drawing.Color.Red;
            this.lblColor.Location = new System.Drawing.Point(741, 254);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(0, 13);
            this.lblColor.TabIndex = 67;
            // 
            // txtidVehiculo
            // 
            this.txtidVehiculo.Enabled = false;
            this.txtidVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtidVehiculo.Location = new System.Drawing.Point(919, 30);
            this.txtidVehiculo.Name = "txtidVehiculo";
            this.txtidVehiculo.Size = new System.Drawing.Size(57, 23);
            this.txtidVehiculo.TabIndex = 50;
            this.txtidVehiculo.Text = "0";
            this.txtidVehiculo.Visible = false;
            // 
            // pbAnio
            // 
            this.pbAnio.BackColor = System.Drawing.Color.White;
            this.pbAnio.Location = new System.Drawing.Point(645, 224);
            this.pbAnio.Name = "pbAnio";
            this.pbAnio.Size = new System.Drawing.Size(20, 20);
            this.pbAnio.TabIndex = 71;
            this.pbAnio.TabStop = false;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.ForeColor = System.Drawing.Color.Red;
            this.lblObservacion.Location = new System.Drawing.Point(27, 366);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(0, 13);
            this.lblObservacion.TabIndex = 82;
            // 
            // pbSerie
            // 
            this.pbSerie.BackColor = System.Drawing.Color.White;
            this.pbSerie.Location = new System.Drawing.Point(270, 223);
            this.pbSerie.Name = "pbSerie";
            this.pbSerie.Size = new System.Drawing.Size(20, 20);
            this.pbSerie.TabIndex = 70;
            this.pbSerie.TabStop = false;
            // 
            // cboModUso
            // 
            this.cboModUso.BackColor = System.Drawing.Color.Transparent;
            this.cboModUso.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModUso.DropDownHeight = 200;
            this.cboModUso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModUso.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboModUso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboModUso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboModUso.HoveredState.Parent = this.cboModUso;
            this.cboModUso.IntegralHeight = false;
            this.cboModUso.ItemHeight = 30;
            this.cboModUso.ItemsAppearance.Parent = this.cboModUso;
            this.cboModUso.Location = new System.Drawing.Point(738, 142);
            this.cboModUso.Name = "cboModUso";
            this.cboModUso.ShadowDecoration.Parent = this.cboModUso;
            this.cboModUso.Size = new System.Drawing.Size(245, 36);
            this.cboModUso.TabIndex = 88;
            this.cboModUso.SelectedIndexChanged += new System.EventHandler(this.cboModUso_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(23, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 17);
            this.label10.TabIndex = 81;
            this.label10.Text = "Observaciones";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.ForeColor = System.Drawing.Color.Red;
            this.lblAnio.Location = new System.Drawing.Point(369, 255);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(0, 13);
            this.lblAnio.TabIndex = 66;
            // 
            // cboModeloVh
            // 
            this.cboModeloVh.BackColor = System.Drawing.Color.Transparent;
            this.cboModeloVh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModeloVh.DropDownHeight = 200;
            this.cboModeloVh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeloVh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboModeloVh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboModeloVh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboModeloVh.HoveredState.Parent = this.cboModeloVh;
            this.cboModeloVh.IntegralHeight = false;
            this.cboModeloVh.ItemHeight = 30;
            this.cboModeloVh.ItemsAppearance.Parent = this.cboModeloVh;
            this.cboModeloVh.Location = new System.Drawing.Point(368, 140);
            this.cboModeloVh.Name = "cboModeloVh";
            this.cboModeloVh.ShadowDecoration.Parent = this.cboModeloVh;
            this.cboModeloVh.Size = new System.Drawing.Size(267, 36);
            this.cboModeloVh.TabIndex = 88;
            this.cboModeloVh.SelectedIndexChanged += new System.EventHandler(this.cboModeloVh_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(739, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Color";
            // 
            // pbModoUso
            // 
            this.pbModoUso.BackColor = System.Drawing.SystemColors.Control;
            this.pbModoUso.Location = new System.Drawing.Point(987, 148);
            this.pbModoUso.Name = "pbModoUso";
            this.pbModoUso.Size = new System.Drawing.Size(20, 20);
            this.pbModoUso.TabIndex = 74;
            this.pbModoUso.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(365, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 17);
            this.label9.TabIndex = 56;
            this.label9.Text = "Año del Modelo (*)";
            // 
            // cboMarcaVh
            // 
            this.cboMarcaVh.BackColor = System.Drawing.Color.Transparent;
            this.cboMarcaVh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarcaVh.DropDownHeight = 200;
            this.cboMarcaVh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarcaVh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboMarcaVh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMarcaVh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboMarcaVh.HoveredState.Parent = this.cboMarcaVh;
            this.cboMarcaVh.IntegralHeight = false;
            this.cboMarcaVh.ItemHeight = 30;
            this.cboMarcaVh.ItemsAppearance.Parent = this.cboMarcaVh;
            this.cboMarcaVh.Location = new System.Drawing.Point(21, 140);
            this.cboMarcaVh.Name = "cboMarcaVh";
            this.cboMarcaVh.ShadowDecoration.Parent = this.cboMarcaVh;
            this.cboMarcaVh.Size = new System.Drawing.Size(245, 36);
            this.cboMarcaVh.TabIndex = 88;
            this.cboMarcaVh.SelectedIndexChanged += new System.EventHandler(this.cboMarcaVh_SelectedIndexChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Animated = false;
            this.txtObservaciones.BorderColor = System.Drawing.Color.LightGray;
            this.txtObservaciones.BorderRadius = 3;
            this.txtObservaciones.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservaciones.DefaultText = "";
            this.txtObservaciones.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservaciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservaciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservaciones.DisabledState.Parent = this.txtObservaciones;
            this.txtObservaciones.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservaciones.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtObservaciones.FocusedState.Parent = this.txtObservaciones;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservaciones.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservaciones.HoveredState.Parent = this.txtObservaciones;
            this.txtObservaciones.Location = new System.Drawing.Point(24, 306);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PasswordChar = '\0';
            this.txtObservaciones.PlaceholderText = "";
            this.txtObservaciones.SelectedText = "";
            this.txtObservaciones.ShadowDecoration.Parent = this.txtObservaciones;
            this.txtObservaciones.Size = new System.Drawing.Size(985, 58);
            this.txtObservaciones.TabIndex = 62;
            this.txtObservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
            this.txtObservaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservaciones_KeyPress);
            // 
            // pbModelo
            // 
            this.pbModelo.BackColor = System.Drawing.SystemColors.Control;
            this.pbModelo.Location = new System.Drawing.Point(645, 148);
            this.pbModelo.Name = "pbModelo";
            this.pbModelo.Size = new System.Drawing.Size(20, 20);
            this.pbModelo.TabIndex = 79;
            this.pbModelo.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(739, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Uso(*)";
            // 
            // cboClaseV
            // 
            this.cboClaseV.BackColor = System.Drawing.Color.Transparent;
            this.cboClaseV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClaseV.DropDownHeight = 200;
            this.cboClaseV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaseV.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboClaseV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboClaseV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboClaseV.HoveredState.Parent = this.cboClaseV;
            this.cboClaseV.IntegralHeight = false;
            this.cboClaseV.ItemHeight = 30;
            this.cboClaseV.ItemsAppearance.Parent = this.cboClaseV;
            this.cboClaseV.Location = new System.Drawing.Point(21, 61);
            this.cboClaseV.Name = "cboClaseV";
            this.cboClaseV.ShadowDecoration.Parent = this.cboClaseV;
            this.cboClaseV.Size = new System.Drawing.Size(245, 36);
            this.cboClaseV.TabIndex = 88;
            this.cboClaseV.SelectedIndexChanged += new System.EventHandler(this.cboClaseV_SelectedIndexChanged);
            // 
            // pbPlaca
            // 
            this.pbPlaca.BackColor = System.Drawing.Color.Transparent;
            this.pbPlaca.BaseColor = System.Drawing.Color.Transparent;
            this.pbPlaca.Location = new System.Drawing.Point(608, 68);
            this.pbPlaca.Name = "pbPlaca";
            this.pbPlaca.Size = new System.Drawing.Size(22, 22);
            this.pbPlaca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPlaca.TabIndex = 87;
            this.pbPlaca.TabStop = false;
            this.pbPlaca.UseTransfarantBackground = false;
            // 
            // lblCboModoUso
            // 
            this.lblCboModoUso.AutoSize = true;
            this.lblCboModoUso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboModoUso.ForeColor = System.Drawing.Color.Red;
            this.lblCboModoUso.Location = new System.Drawing.Point(741, 179);
            this.lblCboModoUso.Name = "lblCboModoUso";
            this.lblCboModoUso.Size = new System.Drawing.Size(0, 13);
            this.lblCboModoUso.TabIndex = 68;
            // 
            // txtColorVh
            // 
            this.txtColorVh.Animated = false;
            this.txtColorVh.BorderColor = System.Drawing.Color.LightGray;
            this.txtColorVh.BorderRadius = 3;
            this.txtColorVh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtColorVh.DefaultText = "";
            this.txtColorVh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtColorVh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtColorVh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtColorVh.DisabledState.Parent = this.txtColorVh;
            this.txtColorVh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtColorVh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtColorVh.FocusedState.Parent = this.txtColorVh;
            this.txtColorVh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtColorVh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtColorVh.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtColorVh.HoveredState.Parent = this.txtColorVh;
            this.txtColorVh.Location = new System.Drawing.Point(738, 216);
            this.txtColorVh.Margin = new System.Windows.Forms.Padding(4);
            this.txtColorVh.Name = "txtColorVh";
            this.txtColorVh.PasswordChar = '\0';
            this.txtColorVh.PlaceholderText = "";
            this.txtColorVh.SelectedText = "";
            this.txtColorVh.ShadowDecoration.Parent = this.txtColorVh;
            this.txtColorVh.Size = new System.Drawing.Size(245, 36);
            this.txtColorVh.TabIndex = 62;
            this.txtColorVh.TextChanged += new System.EventHandler(this.txtColorVh_TextChanged);
            this.txtColorVh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColorVh_KeyPress);
            // 
            // txtAnio
            // 
            this.txtAnio.Animated = false;
            this.txtAnio.BorderColor = System.Drawing.Color.LightGray;
            this.txtAnio.BorderRadius = 3;
            this.txtAnio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAnio.DefaultText = "";
            this.txtAnio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAnio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAnio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAnio.DisabledState.Parent = this.txtAnio;
            this.txtAnio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAnio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtAnio.FocusedState.Parent = this.txtAnio;
            this.txtAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAnio.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAnio.HoveredState.Parent = this.txtAnio;
            this.txtAnio.Location = new System.Drawing.Point(365, 217);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.PasswordChar = '\0';
            this.txtAnio.PlaceholderText = "";
            this.txtAnio.SelectedText = "";
            this.txtAnio.ShadowDecoration.Parent = this.txtAnio;
            this.txtAnio.Size = new System.Drawing.Size(270, 36);
            this.txtAnio.TabIndex = 62;
            this.txtAnio.TextChanged += new System.EventHandler(this.txtAnio_TextChanged);
            this.txtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // txtSerieVh
            // 
            this.txtSerieVh.Animated = false;
            this.txtSerieVh.BorderColor = System.Drawing.Color.LightGray;
            this.txtSerieVh.BorderRadius = 3;
            this.txtSerieVh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerieVh.DefaultText = "";
            this.txtSerieVh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSerieVh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSerieVh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerieVh.DisabledState.Parent = this.txtSerieVh;
            this.txtSerieVh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerieVh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtSerieVh.FocusedState.Parent = this.txtSerieVh;
            this.txtSerieVh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSerieVh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSerieVh.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSerieVh.HoveredState.Parent = this.txtSerieVh;
            this.txtSerieVh.Location = new System.Drawing.Point(21, 216);
            this.txtSerieVh.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerieVh.Name = "txtSerieVh";
            this.txtSerieVh.PasswordChar = '\0';
            this.txtSerieVh.PlaceholderText = "";
            this.txtSerieVh.SelectedText = "";
            this.txtSerieVh.ShadowDecoration.Parent = this.txtSerieVh;
            this.txtSerieVh.Size = new System.Drawing.Size(245, 36);
            this.txtSerieVh.TabIndex = 62;
            this.txtSerieVh.TextChanged += new System.EventHandler(this.txtSerieVh_TextChanged);
            this.txtSerieVh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerieVh_KeyPress);
            // 
            // txtConPlaca
            // 
            this.txtConPlaca.Animated = false;
            this.txtConPlaca.BorderColor = System.Drawing.Color.LightGray;
            this.txtConPlaca.BorderRadius = 3;
            this.txtConPlaca.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConPlaca.DefaultText = "";
            this.txtConPlaca.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConPlaca.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConPlaca.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConPlaca.DisabledState.Parent = this.txtConPlaca;
            this.txtConPlaca.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConPlaca.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtConPlaca.FocusedState.Parent = this.txtConPlaca;
            this.txtConPlaca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConPlaca.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConPlaca.HoveredState.Parent = this.txtConPlaca;
            this.txtConPlaca.Location = new System.Drawing.Point(213, 37);
            this.txtConPlaca.Margin = new System.Windows.Forms.Padding(4);
            this.txtConPlaca.Name = "txtConPlaca";
            this.txtConPlaca.PasswordChar = '\0';
            this.txtConPlaca.PlaceholderText = "";
            this.txtConPlaca.SelectedText = "";
            this.txtConPlaca.ShadowDecoration.Parent = this.txtConPlaca;
            this.txtConPlaca.Size = new System.Drawing.Size(62, 24);
            this.txtConPlaca.TabIndex = 62;
            this.txtConPlaca.Visible = false;
            this.txtConPlaca.TextChanged += new System.EventHandler(this.txtPlacaVh_TextChanged);
            this.txtConPlaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtPlacaVh
            // 
            this.txtPlacaVh.Animated = false;
            this.txtPlacaVh.BorderColor = System.Drawing.Color.LightGray;
            this.txtPlacaVh.BorderRadius = 3;
            this.txtPlacaVh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlacaVh.DefaultText = "";
            this.txtPlacaVh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPlacaVh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPlacaVh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPlacaVh.DisabledState.Parent = this.txtPlacaVh;
            this.txtPlacaVh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPlacaVh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtPlacaVh.FocusedState.Parent = this.txtPlacaVh;
            this.txtPlacaVh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPlacaVh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPlacaVh.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPlacaVh.HoveredState.Parent = this.txtPlacaVh;
            this.txtPlacaVh.Location = new System.Drawing.Point(368, 61);
            this.txtPlacaVh.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlacaVh.Name = "txtPlacaVh";
            this.txtPlacaVh.PasswordChar = '\0';
            this.txtPlacaVh.PlaceholderText = "";
            this.txtPlacaVh.SelectedText = "";
            this.txtPlacaVh.ShadowDecoration.Parent = this.txtPlacaVh;
            this.txtPlacaVh.Size = new System.Drawing.Size(267, 36);
            this.txtPlacaVh.TabIndex = 62;
            this.txtPlacaVh.TextChanged += new System.EventHandler(this.txtPlacaVh_TextChanged);
            this.txtPlacaVh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // chkOtro
            // 
            this.chkOtro.AutoSize = true;
            this.chkOtro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkOtro.Enabled = false;
            this.chkOtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkOtro.Location = new System.Drawing.Point(437, 37);
            this.chkOtro.Name = "chkOtro";
            this.chkOtro.Size = new System.Drawing.Size(85, 21);
            this.chkOtro.TabIndex = 80;
            this.chkOtro.Text = "Sin placa";
            this.chkOtro.UseVisualStyleBackColor = true;
            this.chkOtro.Visible = false;
            this.chkOtro.CheckedChanged += new System.EventHandler(this.chkOtro_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clase (*)";
            // 
            // pbMarca
            // 
            this.pbMarca.BackColor = System.Drawing.SystemColors.Control;
            this.pbMarca.Location = new System.Drawing.Point(270, 148);
            this.pbMarca.Name = "pbMarca";
            this.pbMarca.Size = new System.Drawing.Size(20, 20);
            this.pbMarca.TabIndex = 78;
            this.pbMarca.TabStop = false;
            // 
            // lblCboClase
            // 
            this.lblCboClase.AutoSize = true;
            this.lblCboClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboClase.ForeColor = System.Drawing.Color.Red;
            this.lblCboClase.Location = new System.Drawing.Point(24, 100);
            this.lblCboClase.Name = "lblCboClase";
            this.lblCboClase.Size = new System.Drawing.Size(0, 13);
            this.lblCboClase.TabIndex = 61;
            // 
            // lblCboModelo
            // 
            this.lblCboModelo.AutoSize = true;
            this.lblCboModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboModelo.ForeColor = System.Drawing.Color.Red;
            this.lblCboModelo.Location = new System.Drawing.Point(371, 180);
            this.lblCboModelo.Name = "lblCboModelo";
            this.lblCboModelo.Size = new System.Drawing.Size(0, 13);
            this.lblCboModelo.TabIndex = 62;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.Red;
            this.lblPlaca.Location = new System.Drawing.Point(369, 100);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(0, 13);
            this.lblPlaca.TabIndex = 64;
            // 
            // lblPlacaVehiculo
            // 
            this.lblPlacaVehiculo.AutoSize = true;
            this.lblPlacaVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPlacaVehiculo.Location = new System.Drawing.Point(369, 41);
            this.lblPlacaVehiculo.Name = "lblPlacaVehiculo";
            this.lblPlacaVehiculo.Size = new System.Drawing.Size(62, 17);
            this.lblPlacaVehiculo.TabIndex = 5;
            this.lblPlacaVehiculo.Text = "Placa (*)";
            // 
            // pbClase
            // 
            this.pbClase.BackColor = System.Drawing.SystemColors.Control;
            this.pbClase.Location = new System.Drawing.Point(270, 68);
            this.pbClase.Name = "pbClase";
            this.pbClase.Size = new System.Drawing.Size(20, 20);
            this.pbClase.TabIndex = 77;
            this.pbClase.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(21, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Marca (*)";
            // 
            // lblCboMarca
            // 
            this.lblCboMarca.AutoSize = true;
            this.lblCboMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboMarca.ForeColor = System.Drawing.Color.Red;
            this.lblCboMarca.Location = new System.Drawing.Point(24, 179);
            this.lblCboMarca.Name = "lblCboMarca";
            this.lblCboMarca.Size = new System.Drawing.Size(0, 13);
            this.lblCboMarca.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(21, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Serie (*)";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.ForeColor = System.Drawing.Color.Red;
            this.lblSerie.Location = new System.Drawing.Point(24, 253);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(0, 13);
            this.lblSerie.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(369, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Modelo (*)";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 3;
            this.btnGuardar.BorderThickness = 1;
            this.btnGuardar.CheckedState.Parent = this.btnGuardar;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.CustomImages.Parent = this.btnGuardar;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.HoveredState.Parent = this.btnGuardar;
            this.btnGuardar.Location = new System.Drawing.Point(553, 596);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ShadowDecoration.Parent = this.btnGuardar;
            this.btnGuardar.Size = new System.Drawing.Size(85, 42);
            this.btnGuardar.TabIndex = 185;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BorderRadius = 3;
            this.btnEditar.BorderThickness = 1;
            this.btnEditar.CheckedState.Parent = this.btnEditar;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.CustomImages.Parent = this.btnEditar;
            this.btnEditar.Enabled = false;
            this.btnEditar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.HoveredState.Parent = this.btnEditar;
            this.btnEditar.Location = new System.Drawing.Point(462, 596);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ShadowDecoration.Parent = this.btnEditar;
            this.btnEditar.Size = new System.Drawing.Size(85, 42);
            this.btnEditar.TabIndex = 184;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BorderRadius = 3;
            this.btnNuevo.BorderThickness = 1;
            this.btnNuevo.CheckedState.Parent = this.btnNuevo;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.CustomImages.Parent = this.btnNuevo;
            this.btnNuevo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNuevo.HoveredState.Parent = this.btnNuevo;
            this.btnNuevo.Location = new System.Drawing.Point(371, 596);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.PressedColor = System.Drawing.Color.White;
            this.btnNuevo.ShadowDecoration.Parent = this.btnNuevo;
            this.btnNuevo.Size = new System.Drawing.Size(85, 42);
            this.btnNuevo.TabIndex = 183;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.BackColor = System.Drawing.Color.White;
            this.pbSearch.BaseColor = System.Drawing.Color.Transparent;
            this.pbSearch.Image = global::wfaIntegradoCom.Properties.Resources.buscar_base;
            this.pbSearch.InitialImage = null;
            this.pbSearch.Location = new System.Drawing.Point(180, 11);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(28, 24);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSearch.TabIndex = 182;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // txtBuscarVehiculo
            // 
            this.txtBuscarVehiculo.Animated = false;
            this.txtBuscarVehiculo.BorderColor = System.Drawing.Color.Gray;
            this.txtBuscarVehiculo.BorderRadius = 3;
            this.txtBuscarVehiculo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarVehiculo.DefaultText = "";
            this.txtBuscarVehiculo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarVehiculo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarVehiculo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarVehiculo.DisabledState.Parent = this.txtBuscarVehiculo;
            this.txtBuscarVehiculo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarVehiculo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarVehiculo.FocusedState.Parent = this.txtBuscarVehiculo;
            this.txtBuscarVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarVehiculo.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtBuscarVehiculo.HoveredState.Parent = this.txtBuscarVehiculo;
            this.txtBuscarVehiculo.Location = new System.Drawing.Point(169, 5);
            this.txtBuscarVehiculo.Name = "txtBuscarVehiculo";
            this.txtBuscarVehiculo.PasswordChar = '\0';
            this.txtBuscarVehiculo.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarVehiculo.PlaceholderText = "Buscar sim Vehiculo";
            this.txtBuscarVehiculo.SelectedText = "";
            this.txtBuscarVehiculo.ShadowDecoration.Parent = this.txtBuscarVehiculo;
            this.txtBuscarVehiculo.Size = new System.Drawing.Size(951, 36);
            this.txtBuscarVehiculo.TabIndex = 181;
            this.txtBuscarVehiculo.TextOffset = new System.Drawing.Point(40, 0);
            this.txtBuscarVehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarVehiculo_KeyPress);
            // 
            // gbRegistros
            // 
            this.gbRegistros.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbRegistros.Controls.Add(this.btnCantRegistros);
            this.gbRegistros.Controls.Add(this.lblCantRegistrosTotal);
            this.gbRegistros.Controls.Add(this.btnCantTotalRegistros);
            this.gbRegistros.Controls.Add(this.label2);
            this.gbRegistros.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gbRegistros.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.gbRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRegistros.ForeColor = System.Drawing.Color.White;
            this.gbRegistros.Location = new System.Drawing.Point(893, 591);
            this.gbRegistros.Name = "gbRegistros";
            this.gbRegistros.ShadowDecoration.Parent = this.gbRegistros;
            this.gbRegistros.Size = new System.Drawing.Size(200, 44);
            this.gbRegistros.TabIndex = 179;
            this.gbRegistros.Text = "REGISTROS:";
            this.gbRegistros.TextOffset = new System.Drawing.Point(0, -12);
            // 
            // btnCantRegistros
            // 
            this.btnCantRegistros.BackColor = System.Drawing.Color.Transparent;
            this.btnCantRegistros.CheckedState.Parent = this.btnCantRegistros;
            this.btnCantRegistros.CustomImages.Parent = this.btnCantRegistros;
            this.btnCantRegistros.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantRegistros.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCantRegistros.ForeColor = System.Drawing.Color.White;
            this.btnCantRegistros.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantRegistros.HoveredState.Parent = this.btnCantRegistros;
            this.btnCantRegistros.Location = new System.Drawing.Point(78, 7);
            this.btnCantRegistros.Name = "btnCantRegistros";
            this.btnCantRegistros.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnCantRegistros.ShadowDecoration.Parent = this.btnCantRegistros;
            this.btnCantRegistros.Size = new System.Drawing.Size(30, 30);
            this.btnCantRegistros.TabIndex = 150;
            this.btnCantRegistros.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // lblCantRegistrosTotal
            // 
            this.lblCantRegistrosTotal.AutoSize = true;
            this.lblCantRegistrosTotal.BackColor = System.Drawing.Color.White;
            this.lblCantRegistrosTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistrosTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblCantRegistrosTotal.Location = new System.Drawing.Point(4, 14);
            this.lblCantRegistrosTotal.Name = "lblCantRegistrosTotal";
            this.lblCantRegistrosTotal.Size = new System.Drawing.Size(68, 17);
            this.lblCantRegistrosTotal.TabIndex = 145;
            this.lblCantRegistrosTotal.Text = "Registros";
            // 
            // btnCantTotalRegistros
            // 
            this.btnCantTotalRegistros.BackColor = System.Drawing.Color.Transparent;
            this.btnCantTotalRegistros.CheckedState.Parent = this.btnCantTotalRegistros;
            this.btnCantTotalRegistros.CustomImages.Parent = this.btnCantTotalRegistros;
            this.btnCantTotalRegistros.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCantTotalRegistros.ForeColor = System.Drawing.Color.White;
            this.btnCantTotalRegistros.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantTotalRegistros.HoveredState.Parent = this.btnCantTotalRegistros;
            this.btnCantTotalRegistros.Location = new System.Drawing.Point(161, 7);
            this.btnCantTotalRegistros.Name = "btnCantTotalRegistros";
            this.btnCantTotalRegistros.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnCantTotalRegistros.ShadowDecoration.Parent = this.btnCantTotalRegistros;
            this.btnCantTotalRegistros.Size = new System.Drawing.Size(30, 30);
            this.btnCantTotalRegistros.TabIndex = 151;
            this.btnCantTotalRegistros.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(129, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 147;
            this.label2.Text = "De";
            // 
            // gbPaginas
            // 
            this.gbPaginas.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbPaginas.Controls.Add(this.cboPaginacion);
            this.gbPaginas.Controls.Add(this.btnTotalPaginas);
            this.gbPaginas.Controls.Add(this.label12);
            this.gbPaginas.Controls.Add(this.label13);
            this.gbPaginas.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gbPaginas.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.gbPaginas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPaginas.ForeColor = System.Drawing.Color.White;
            this.gbPaginas.Location = new System.Drawing.Point(657, 591);
            this.gbPaginas.Name = "gbPaginas";
            this.gbPaginas.ShadowDecoration.Parent = this.gbPaginas;
            this.gbPaginas.Size = new System.Drawing.Size(235, 44);
            this.gbPaginas.TabIndex = 180;
            this.gbPaginas.Text = "PAGINAS:";
            this.gbPaginas.TextOffset = new System.Drawing.Point(0, -12);
            // 
            // cboPaginacion
            // 
            this.cboPaginacion.BackColor = System.Drawing.Color.Transparent;
            this.cboPaginacion.BorderRadius = 3;
            this.cboPaginacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboPaginacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaginacion.DropDownHeight = 200;
            this.cboPaginacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaginacion.DropDownWidth = 100;
            this.cboPaginacion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboPaginacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPaginacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboPaginacion.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cboPaginacion.HoveredState.Parent = this.cboPaginacion;
            this.cboPaginacion.IntegralHeight = false;
            this.cboPaginacion.ItemHeight = 16;
            this.cboPaginacion.ItemsAppearance.Parent = this.cboPaginacion;
            this.cboPaginacion.Location = new System.Drawing.Point(70, 10);
            this.cboPaginacion.Name = "cboPaginacion";
            this.cboPaginacion.ShadowDecoration.Parent = this.cboPaginacion;
            this.cboPaginacion.Size = new System.Drawing.Size(80, 22);
            this.cboPaginacion.TabIndex = 140;
            this.cboPaginacion.SelectedIndexChanged += new System.EventHandler(this.cboPaginacion_SelectedIndexChanged);
            // 
            // btnTotalPaginas
            // 
            this.btnTotalPaginas.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalPaginas.CheckedState.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.CustomImages.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTotalPaginas.ForeColor = System.Drawing.Color.White;
            this.btnTotalPaginas.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginas.HoveredState.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.Location = new System.Drawing.Point(188, 7);
            this.btnTotalPaginas.Name = "btnTotalPaginas";
            this.btnTotalPaginas.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalPaginas.ShadowDecoration.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.Size = new System.Drawing.Size(30, 30);
            this.btnTotalPaginas.TabIndex = 152;
            this.btnTotalPaginas.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label12.Location = new System.Drawing.Point(15, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 141;
            this.label12.Text = "Pagina";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label13.Location = new System.Drawing.Point(156, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 17);
            this.label13.TabIndex = 143;
            this.label13.Text = "De";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.siticoneGroupBox3);
            this.tabPage2.Controls.Add(this.siticoneGroupBox4);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.txtBuscarVehiculoM);
            this.tabPage2.Controls.Add(this.dgConsultas);
            this.tabPage2.Controls.Add(this.siticoneGroupBox1);
            this.tabPage2.Controls.Add(this.dgMovimientoVH);
            this.tabPage2.Controls.Add(this.lblMsgMVehiculo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1126, 642);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Movimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // siticoneGroupBox3
            // 
            this.siticoneGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneGroupBox3.Controls.Add(this.btnCantRegistrosM);
            this.siticoneGroupBox3.Controls.Add(this.label15);
            this.siticoneGroupBox3.Controls.Add(this.btnCantTotalRegistrosM);
            this.siticoneGroupBox3.Controls.Add(this.label16);
            this.siticoneGroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.siticoneGroupBox3.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.siticoneGroupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneGroupBox3.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox3.Location = new System.Drawing.Point(899, 572);
            this.siticoneGroupBox3.Name = "siticoneGroupBox3";
            this.siticoneGroupBox3.ShadowDecoration.Parent = this.siticoneGroupBox3;
            this.siticoneGroupBox3.Size = new System.Drawing.Size(200, 44);
            this.siticoneGroupBox3.TabIndex = 234;
            this.siticoneGroupBox3.Text = "REGISTROS:";
            this.siticoneGroupBox3.TextOffset = new System.Drawing.Point(0, -12);
            // 
            // btnCantRegistrosM
            // 
            this.btnCantRegistrosM.BackColor = System.Drawing.Color.Transparent;
            this.btnCantRegistrosM.CheckedState.Parent = this.btnCantRegistrosM;
            this.btnCantRegistrosM.CustomImages.Parent = this.btnCantRegistrosM;
            this.btnCantRegistrosM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantRegistrosM.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCantRegistrosM.ForeColor = System.Drawing.Color.White;
            this.btnCantRegistrosM.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantRegistrosM.HoveredState.Parent = this.btnCantRegistrosM;
            this.btnCantRegistrosM.Location = new System.Drawing.Point(78, 7);
            this.btnCantRegistrosM.Name = "btnCantRegistrosM";
            this.btnCantRegistrosM.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnCantRegistrosM.ShadowDecoration.Parent = this.btnCantRegistrosM;
            this.btnCantRegistrosM.Size = new System.Drawing.Size(30, 30);
            this.btnCantRegistrosM.TabIndex = 150;
            this.btnCantRegistrosM.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label15.Location = new System.Drawing.Point(4, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 17);
            this.label15.TabIndex = 145;
            this.label15.Text = "Registros";
            // 
            // btnCantTotalRegistrosM
            // 
            this.btnCantTotalRegistrosM.BackColor = System.Drawing.Color.Transparent;
            this.btnCantTotalRegistrosM.CheckedState.Parent = this.btnCantTotalRegistrosM;
            this.btnCantTotalRegistrosM.CustomImages.Parent = this.btnCantTotalRegistrosM;
            this.btnCantTotalRegistrosM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantTotalRegistrosM.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCantTotalRegistrosM.ForeColor = System.Drawing.Color.White;
            this.btnCantTotalRegistrosM.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnCantTotalRegistrosM.HoveredState.Parent = this.btnCantTotalRegistrosM;
            this.btnCantTotalRegistrosM.Location = new System.Drawing.Point(161, 7);
            this.btnCantTotalRegistrosM.Name = "btnCantTotalRegistrosM";
            this.btnCantTotalRegistrosM.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnCantTotalRegistrosM.ShadowDecoration.Parent = this.btnCantTotalRegistrosM;
            this.btnCantTotalRegistrosM.Size = new System.Drawing.Size(30, 30);
            this.btnCantTotalRegistrosM.TabIndex = 151;
            this.btnCantTotalRegistrosM.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label16.Location = new System.Drawing.Point(129, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 17);
            this.label16.TabIndex = 147;
            this.label16.Text = "De";
            // 
            // siticoneGroupBox4
            // 
            this.siticoneGroupBox4.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneGroupBox4.Controls.Add(this.cboPaginacionM);
            this.siticoneGroupBox4.Controls.Add(this.btnTotalPaginasM);
            this.siticoneGroupBox4.Controls.Add(this.label17);
            this.siticoneGroupBox4.Controls.Add(this.label18);
            this.siticoneGroupBox4.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.siticoneGroupBox4.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.siticoneGroupBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneGroupBox4.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox4.Location = new System.Drawing.Point(663, 572);
            this.siticoneGroupBox4.Name = "siticoneGroupBox4";
            this.siticoneGroupBox4.ShadowDecoration.Parent = this.siticoneGroupBox4;
            this.siticoneGroupBox4.Size = new System.Drawing.Size(235, 44);
            this.siticoneGroupBox4.TabIndex = 235;
            this.siticoneGroupBox4.Text = "PAGINAS:";
            this.siticoneGroupBox4.TextOffset = new System.Drawing.Point(0, -12);
            // 
            // cboPaginacionM
            // 
            this.cboPaginacionM.BackColor = System.Drawing.Color.Transparent;
            this.cboPaginacionM.BorderRadius = 10;
            this.cboPaginacionM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaginacionM.DropDownHeight = 200;
            this.cboPaginacionM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaginacionM.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboPaginacionM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPaginacionM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboPaginacionM.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cboPaginacionM.HoveredState.Parent = this.cboPaginacionM;
            this.cboPaginacionM.IntegralHeight = false;
            this.cboPaginacionM.ItemHeight = 30;
            this.cboPaginacionM.ItemsAppearance.Parent = this.cboPaginacionM;
            this.cboPaginacionM.Location = new System.Drawing.Point(70, 4);
            this.cboPaginacionM.Name = "cboPaginacionM";
            this.cboPaginacionM.ShadowDecoration.Parent = this.cboPaginacionM;
            this.cboPaginacionM.Size = new System.Drawing.Size(67, 36);
            this.cboPaginacionM.TabIndex = 140;
            // 
            // btnTotalPaginasM
            // 
            this.btnTotalPaginasM.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalPaginasM.CheckedState.Parent = this.btnTotalPaginasM;
            this.btnTotalPaginasM.CustomImages.Parent = this.btnTotalPaginasM;
            this.btnTotalPaginasM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginasM.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTotalPaginasM.ForeColor = System.Drawing.Color.White;
            this.btnTotalPaginasM.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginasM.HoveredState.Parent = this.btnTotalPaginasM;
            this.btnTotalPaginasM.Location = new System.Drawing.Point(188, 7);
            this.btnTotalPaginasM.Name = "btnTotalPaginasM";
            this.btnTotalPaginasM.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalPaginasM.ShadowDecoration.Parent = this.btnTotalPaginasM;
            this.btnTotalPaginasM.Size = new System.Drawing.Size(30, 30);
            this.btnTotalPaginasM.TabIndex = 152;
            this.btnTotalPaginasM.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label17.Location = new System.Drawing.Point(15, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 17);
            this.label17.TabIndex = 141;
            this.label17.Text = "Pagina";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label18.Location = new System.Drawing.Point(156, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 17);
            this.label18.TabIndex = 143;
            this.label18.Text = "De";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 232;
            this.pictureBox2.TabStop = false;
            // 
            // txtBuscarVehiculoM
            // 
            this.txtBuscarVehiculoM.Animated = false;
            this.txtBuscarVehiculoM.BorderColor = System.Drawing.Color.Silver;
            this.txtBuscarVehiculoM.BorderRadius = 3;
            this.txtBuscarVehiculoM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarVehiculoM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarVehiculoM.DefaultText = "";
            this.txtBuscarVehiculoM.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarVehiculoM.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarVehiculoM.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarVehiculoM.DisabledState.Parent = this.txtBuscarVehiculoM;
            this.txtBuscarVehiculoM.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarVehiculoM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtBuscarVehiculoM.FocusedState.Parent = this.txtBuscarVehiculoM;
            this.txtBuscarVehiculoM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarVehiculoM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarVehiculoM.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarVehiculoM.HoveredState.Parent = this.txtBuscarVehiculoM;
            this.txtBuscarVehiculoM.Location = new System.Drawing.Point(16, 52);
            this.txtBuscarVehiculoM.Name = "txtBuscarVehiculoM";
            this.txtBuscarVehiculoM.PasswordChar = '\0';
            this.txtBuscarVehiculoM.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBuscarVehiculoM.PlaceholderText = "DATOS A BUSCAR...";
            this.txtBuscarVehiculoM.SelectedText = "";
            this.txtBuscarVehiculoM.ShadowDecoration.Parent = this.txtBuscarVehiculoM;
            this.txtBuscarVehiculoM.Size = new System.Drawing.Size(296, 36);
            this.txtBuscarVehiculoM.TabIndex = 231;
            this.txtBuscarVehiculoM.TextOffset = new System.Drawing.Point(30, 0);
            this.txtBuscarVehiculoM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarVehiculoM_KeyPress);
            // 
            // dgConsultas
            // 
            this.dgConsultas.AllowUserToAddRows = false;
            this.dgConsultas.AllowUserToDeleteRows = false;
            this.dgConsultas.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dgConsultas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgConsultas.BackgroundColor = System.Drawing.Color.White;
            this.dgConsultas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgConsultas.CausesValidation = false;
            this.dgConsultas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgConsultas.ColumnHeadersHeight = 30;
            this.dgConsultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SIMCARDD,
            this.IMEI});
            this.dgConsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsultas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgConsultas.EnableHeadersVisualStyles = false;
            this.dgConsultas.GridColor = System.Drawing.Color.Silver;
            this.dgConsultas.Location = new System.Drawing.Point(16, 83);
            this.dgConsultas.Name = "dgConsultas";
            this.dgConsultas.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsultas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgConsultas.RowHeadersVisible = false;
            this.dgConsultas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsultas.Size = new System.Drawing.Size(295, 139);
            this.dgConsultas.TabIndex = 226;
            this.dgConsultas.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgConsultas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgConsultas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgConsultas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgConsultas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgConsultas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgConsultas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgConsultas.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgConsultas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.dgConsultas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgConsultas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgConsultas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgConsultas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgConsultas.ThemeStyle.HeaderStyle.Height = 30;
            this.dgConsultas.ThemeStyle.ReadOnly = true;
            this.dgConsultas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgConsultas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgConsultas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgConsultas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgConsultas.ThemeStyle.RowsStyle.Height = 22;
            this.dgConsultas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgConsultas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.dgConsultas.Visible = false;
            this.dgConsultas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsultas_CellDoubleClick);
            // 
            // SIMCARDD
            // 
            this.SIMCARDD.FillWeight = 85.2792F;
            this.SIMCARDD.HeaderText = "id";
            this.SIMCARDD.MinimumWidth = 7;
            this.SIMCARDD.Name = "SIMCARDD";
            this.SIMCARDD.ReadOnly = true;
            this.SIMCARDD.Visible = false;
            // 
            // IMEI
            // 
            this.IMEI.FillWeight = 69.60992F;
            this.IMEI.HeaderText = "simcard";
            this.IMEI.Name = "IMEI";
            this.IMEI.ReadOnly = true;
            // 
            // siticoneGroupBox1
            // 
            this.siticoneGroupBox1.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneGroupBox1.BorderRadius = 5;
            this.siticoneGroupBox1.Controls.Add(this.siticoneGroupBox2);
            this.siticoneGroupBox1.Controls.Add(this.chkHabilitarFechas);
            this.siticoneGroupBox1.Controls.Add(this.btnNuevoHistorial);
            this.siticoneGroupBox1.Controls.Add(this.dtHfechaFinal);
            this.siticoneGroupBox1.Controls.Add(this.dtHFechaInicio);
            this.siticoneGroupBox1.Controls.Add(this.label20);
            this.siticoneGroupBox1.Controls.Add(this.label19);
            this.siticoneGroupBox1.CustomBorderColor = System.Drawing.Color.DimGray;
            this.siticoneGroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.siticoneGroupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneGroupBox1.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox1.Location = new System.Drawing.Point(3, 4);
            this.siticoneGroupBox1.Name = "siticoneGroupBox1";
            this.siticoneGroupBox1.ShadowDecoration.Parent = this.siticoneGroupBox1;
            this.siticoneGroupBox1.Size = new System.Drawing.Size(1117, 103);
            this.siticoneGroupBox1.TabIndex = 225;
            this.siticoneGroupBox1.Text = "BUSCAR POR:";
            this.siticoneGroupBox1.TextOffset = new System.Drawing.Point(0, -10);
            // 
            // siticoneGroupBox2
            // 
            this.siticoneGroupBox2.BorderThickness = 0;
            this.siticoneGroupBox2.Controls.Add(this.rbVehiculo);
            this.siticoneGroupBox2.Controls.Add(this.rbSerie);
            this.siticoneGroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.siticoneGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.siticoneGroupBox2.Location = new System.Drawing.Point(14, 23);
            this.siticoneGroupBox2.Name = "siticoneGroupBox2";
            this.siticoneGroupBox2.ShadowDecoration.Parent = this.siticoneGroupBox2;
            this.siticoneGroupBox2.Size = new System.Drawing.Size(269, 23);
            this.siticoneGroupBox2.TabIndex = 221;
            // 
            // rbVehiculo
            // 
            this.rbVehiculo.AutoSize = true;
            this.rbVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.rbVehiculo.Checked = true;
            this.rbVehiculo.CheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.rbVehiculo.CheckedState.BorderThickness = 1;
            this.rbVehiculo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.rbVehiculo.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbVehiculo.CheckedState.InnerOffset = -2;
            this.rbVehiculo.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.rbVehiculo.FlatAppearance.BorderSize = 3;
            this.rbVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.rbVehiculo.ForeColor = System.Drawing.Color.Black;
            this.rbVehiculo.Location = new System.Drawing.Point(19, 3);
            this.rbVehiculo.Name = "rbVehiculo";
            this.rbVehiculo.Size = new System.Drawing.Size(52, 17);
            this.rbVehiculo.TabIndex = 221;
            this.rbVehiculo.TabStop = true;
            this.rbVehiculo.Text = "Placa";
            this.rbVehiculo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbVehiculo.UncheckedState.BorderThickness = 0;
            this.rbVehiculo.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbVehiculo.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbVehiculo.UseVisualStyleBackColor = false;
            // 
            // rbSerie
            // 
            this.rbSerie.AutoSize = true;
            this.rbSerie.BackColor = System.Drawing.Color.Transparent;
            this.rbSerie.CheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.rbSerie.CheckedState.BorderThickness = 1;
            this.rbSerie.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.rbSerie.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbSerie.CheckedState.InnerOffset = -2;
            this.rbSerie.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.rbSerie.FlatAppearance.BorderSize = 3;
            this.rbSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.rbSerie.ForeColor = System.Drawing.Color.Black;
            this.rbSerie.Location = new System.Drawing.Point(119, 4);
            this.rbSerie.Name = "rbSerie";
            this.rbSerie.Size = new System.Drawing.Size(49, 17);
            this.rbSerie.TabIndex = 221;
            this.rbSerie.Text = "Serie";
            this.rbSerie.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbSerie.UncheckedState.BorderThickness = 0;
            this.rbSerie.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbSerie.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbSerie.UseVisualStyleBackColor = false;
            // 
            // chkHabilitarFechas
            // 
            this.chkHabilitarFechas.AutoSize = true;
            this.chkHabilitarFechas.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkHabilitarFechas.CheckedState.BorderRadius = 0;
            this.chkHabilitarFechas.CheckedState.BorderThickness = 0;
            this.chkHabilitarFechas.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkHabilitarFechas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabilitarFechas.ForeColor = System.Drawing.Color.Black;
            this.chkHabilitarFechas.Location = new System.Drawing.Point(325, 62);
            this.chkHabilitarFechas.Name = "chkHabilitarFechas";
            this.chkHabilitarFechas.Size = new System.Drawing.Size(108, 17);
            this.chkHabilitarFechas.TabIndex = 219;
            this.chkHabilitarFechas.Text = "Habilitar Fechas";
            this.chkHabilitarFechas.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechas.UncheckedState.BorderRadius = 0;
            this.chkHabilitarFechas.UncheckedState.BorderThickness = 0;
            this.chkHabilitarFechas.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechas.CheckedChanged += new System.EventHandler(this.chkHabilitarFechas_CheckedChanged);
            // 
            // btnNuevoHistorial
            // 
            this.btnNuevoHistorial.BorderRadius = 3;
            this.btnNuevoHistorial.BorderThickness = 1;
            this.btnNuevoHistorial.CheckedState.Parent = this.btnNuevoHistorial;
            this.btnNuevoHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoHistorial.CustomImages.Parent = this.btnNuevoHistorial;
            this.btnNuevoHistorial.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevoHistorial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevoHistorial.ForeColor = System.Drawing.Color.White;
            this.btnNuevoHistorial.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNuevoHistorial.HoveredState.Parent = this.btnNuevoHistorial;
            this.btnNuevoHistorial.Location = new System.Drawing.Point(920, 49);
            this.btnNuevoHistorial.Name = "btnNuevoHistorial";
            this.btnNuevoHistorial.PressedColor = System.Drawing.Color.White;
            this.btnNuevoHistorial.ShadowDecoration.Parent = this.btnNuevoHistorial;
            this.btnNuevoHistorial.Size = new System.Drawing.Size(161, 42);
            this.btnNuevoHistorial.TabIndex = 201;
            this.btnNuevoHistorial.Text = "Nueva busqueda";
            this.btnNuevoHistorial.Click += new System.EventHandler(this.btnNuevoHistorial_Click);
            // 
            // dtHfechaFinal
            // 
            this.dtHfechaFinal.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtHfechaFinal.BorderRadius = 3;
            this.dtHfechaFinal.BorderThickness = 1;
            this.dtHfechaFinal.CheckedState.Parent = this.dtHfechaFinal;
            this.dtHfechaFinal.Enabled = false;
            this.dtHfechaFinal.FillColor = System.Drawing.Color.White;
            this.dtHfechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHfechaFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dtHfechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtHfechaFinal.HoveredState.Parent = this.dtHfechaFinal;
            this.dtHfechaFinal.Location = new System.Drawing.Point(695, 52);
            this.dtHfechaFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtHfechaFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtHfechaFinal.Name = "dtHfechaFinal";
            this.dtHfechaFinal.ShadowDecoration.Parent = this.dtHfechaFinal;
            this.dtHfechaFinal.Size = new System.Drawing.Size(210, 36);
            this.dtHfechaFinal.TabIndex = 195;
            this.dtHfechaFinal.Value = new System.DateTime(2021, 3, 18, 18, 11, 57, 673);
            // 
            // dtHFechaInicio
            // 
            this.dtHFechaInicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtHFechaInicio.BorderRadius = 3;
            this.dtHFechaInicio.BorderThickness = 1;
            this.dtHFechaInicio.CheckedState.Parent = this.dtHFechaInicio;
            this.dtHFechaInicio.Enabled = false;
            this.dtHFechaInicio.FillColor = System.Drawing.Color.White;
            this.dtHFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dtHFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtHFechaInicio.HoveredState.Parent = this.dtHFechaInicio;
            this.dtHFechaInicio.Location = new System.Drawing.Point(445, 52);
            this.dtHFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtHFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtHFechaInicio.Name = "dtHFechaInicio";
            this.dtHFechaInicio.ShadowDecoration.Parent = this.dtHFechaInicio;
            this.dtHFechaInicio.Size = new System.Drawing.Size(209, 36);
            this.dtHFechaInicio.TabIndex = 195;
            this.dtHFechaInicio.Value = new System.DateTime(2021, 3, 18, 18, 11, 57, 673);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label20.Location = new System.Drawing.Point(670, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 17);
            this.label20.TabIndex = 194;
            this.label20.Text = "Hasta";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label19.Location = new System.Drawing.Point(419, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 17);
            this.label19.TabIndex = 194;
            this.label19.Text = "Desde";
            // 
            // dgMovimientoVH
            // 
            this.dgMovimientoVH.AllowUserToAddRows = false;
            this.dgMovimientoVH.AllowUserToDeleteRows = false;
            this.dgMovimientoVH.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgMovimientoVH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgMovimientoVH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMovimientoVH.BackgroundColor = System.Drawing.Color.White;
            this.dgMovimientoVH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMovimientoVH.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMovimientoVH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgMovimientoVH.ColumnHeadersHeight = 40;
            this.dgMovimientoVH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.n,
            this.PlacaM,
            this.SerieM,
            this.FechaM,
            this.ClaseM,
            this.MarcaM,
            this.ModeloM,
            this.UsoM,
            this.AnioM,
            this.ColorM,
            this.DescripcionM,
            this.EstadoM,
            this.UsuarioM});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMovimientoVH.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgMovimientoVH.EnableHeadersVisualStyles = false;
            this.dgMovimientoVH.GridColor = System.Drawing.Color.Silver;
            this.dgMovimientoVH.Location = new System.Drawing.Point(3, 115);
            this.dgMovimientoVH.Name = "dgMovimientoVH";
            this.dgMovimientoVH.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMovimientoVH.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgMovimientoVH.RowHeadersVisible = false;
            this.dgMovimientoVH.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMovimientoVH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMovimientoVH.Size = new System.Drawing.Size(1117, 401);
            this.dgMovimientoVH.TabIndex = 233;
            this.dgMovimientoVH.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgMovimientoVH.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgMovimientoVH.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgMovimientoVH.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgMovimientoVH.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgMovimientoVH.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgMovimientoVH.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgMovimientoVH.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgMovimientoVH.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.dgMovimientoVH.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgMovimientoVH.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMovimientoVH.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgMovimientoVH.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgMovimientoVH.ThemeStyle.HeaderStyle.Height = 40;
            this.dgMovimientoVH.ThemeStyle.ReadOnly = true;
            this.dgMovimientoVH.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgMovimientoVH.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgMovimientoVH.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMovimientoVH.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMovimientoVH.ThemeStyle.RowsStyle.Height = 22;
            this.dgMovimientoVH.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgMovimientoVH.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            // 
            // n
            // 
            this.n.HeaderText = "N°";
            this.n.Name = "n";
            this.n.ReadOnly = true;
            // 
            // PlacaM
            // 
            this.PlacaM.HeaderText = "Placa";
            this.PlacaM.Name = "PlacaM";
            this.PlacaM.ReadOnly = true;
            // 
            // SerieM
            // 
            this.SerieM.HeaderText = "Serie";
            this.SerieM.Name = "SerieM";
            this.SerieM.ReadOnly = true;
            // 
            // FechaM
            // 
            this.FechaM.HeaderText = "Fech. Movimiento";
            this.FechaM.Name = "FechaM";
            this.FechaM.ReadOnly = true;
            // 
            // ClaseM
            // 
            this.ClaseM.HeaderText = "Clase";
            this.ClaseM.Name = "ClaseM";
            this.ClaseM.ReadOnly = true;
            // 
            // MarcaM
            // 
            this.MarcaM.HeaderText = "Marca";
            this.MarcaM.Name = "MarcaM";
            this.MarcaM.ReadOnly = true;
            // 
            // ModeloM
            // 
            this.ModeloM.HeaderText = "Modelo";
            this.ModeloM.Name = "ModeloM";
            this.ModeloM.ReadOnly = true;
            // 
            // UsoM
            // 
            this.UsoM.HeaderText = "Uso";
            this.UsoM.Name = "UsoM";
            this.UsoM.ReadOnly = true;
            // 
            // AnioM
            // 
            this.AnioM.HeaderText = "Año";
            this.AnioM.Name = "AnioM";
            this.AnioM.ReadOnly = true;
            // 
            // ColorM
            // 
            this.ColorM.HeaderText = "Color";
            this.ColorM.Name = "ColorM";
            this.ColorM.ReadOnly = true;
            // 
            // DescripcionM
            // 
            this.DescripcionM.HeaderText = "Descripcion";
            this.DescripcionM.Name = "DescripcionM";
            this.DescripcionM.ReadOnly = true;
            // 
            // EstadoM
            // 
            this.EstadoM.HeaderText = "Estado";
            this.EstadoM.Name = "EstadoM";
            this.EstadoM.ReadOnly = true;
            // 
            // UsuarioM
            // 
            this.UsuarioM.HeaderText = "Usuario";
            this.UsuarioM.Name = "UsuarioM";
            this.UsuarioM.ReadOnly = true;
            // 
            // lblMsgMVehiculo
            // 
            this.lblMsgMVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.lblMsgMVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgMVehiculo.ForeColor = System.Drawing.Color.White;
            this.lblMsgMVehiculo.Location = new System.Drawing.Point(3, 115);
            this.lblMsgMVehiculo.Name = "lblMsgMVehiculo";
            this.lblMsgMVehiculo.Size = new System.Drawing.Size(1117, 40);
            this.lblMsgMVehiculo.TabIndex = 194;
            this.lblMsgMVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsgMVehiculo.Visible = false;
            // 
            // sDC1mover
            // 
            this.sDC1mover.TargetControl = this.gunaPanel1;
            // 
            // frmRegistrarVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 704);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.panelFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistrarVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRAR VEHICULO - HUSAT";
            this.Load += new System.EventHandler(this.frmRegistrarVehiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epVehiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.panelFondo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehiculo)).EndInit();
            this.MenuVehiculo.ResumeLayout(false);
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            this.gbDatosVehiculo.ResumeLayout(false);
            this.gbDatosVehiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbObsevacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModoUso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.gbRegistros.ResumeLayout(false);
            this.gbRegistros.PerformLayout();
            this.gbPaginas.ResumeLayout(false);
            this.gbPaginas.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.siticoneGroupBox3.ResumeLayout(false);
            this.siticoneGroupBox3.PerformLayout();
            this.siticoneGroupBox4.ResumeLayout(false);
            this.siticoneGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultas)).EndInit();
            this.siticoneGroupBox1.ResumeLayout(false);
            this.siticoneGroupBox1.PerformLayout();
            this.siticoneGroupBox2.ResumeLayout(false);
            this.siticoneGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovimientoVH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epVehiculo;
        private System.Windows.Forms.ErrorProvider epControlOk;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Label label14;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Siticone.UI.WinForms.SiticonePanel panelFondo;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Guna.UI.WinForms.GunaGroupBox gbBuscar;
        private RadioButton rbNombre;
        private RadioButton rbPlaca;
        private Guna.UI.WinForms.GunaGroupBox gbDatosVehiculo;
        private TextBox txtPlaca2;
        private CheckBox chkActivo;
        private PictureBox pbColor;
        private Label label11;
        private Label lblColor;
        private TextBox txtidVehiculo;
        private PictureBox pbAnio;
        private PictureBox pbSerie;
        private Siticone.UI.WinForms.SiticoneComboBox cboModUso;
        private Label lblAnio;
        private Siticone.UI.WinForms.SiticoneComboBox cboModeloVh;
        private Label label5;
        private PictureBox pbModoUso;
        private Label label9;
        private Siticone.UI.WinForms.SiticoneComboBox cboMarcaVh;
        private PictureBox pbModelo;
        private Label label8;
        private Siticone.UI.WinForms.SiticoneComboBox cboClaseV;
        private Guna.UI.WinForms.GunaCirclePictureBox pbPlaca;
        private Label lblCboModoUso;
        private Siticone.UI.WinForms.SiticoneTextBox txtColorVh;
        private Siticone.UI.WinForms.SiticoneTextBox txtAnio;
        private Siticone.UI.WinForms.SiticoneTextBox txtSerieVh;
        private Siticone.UI.WinForms.SiticoneTextBox txtPlacaVh;
        private CheckBox chkOtro;
        private Label label1;
        private PictureBox pbMarca;
        private Label lblCboClase;
        private Label lblCboModelo;
        private Label lblPlaca;
        private Label lblPlacaVehiculo;
        private PictureBox pbClase;
        private Label label3;
        private Label lblCboMarca;
        private Label label6;
        private Label lblSerie;
        private Label label4;
        private Siticone.UI.WinForms.SiticoneButton btnGuardar;
        private Siticone.UI.WinForms.SiticoneButton btnEditar;
        private Siticone.UI.WinForms.SiticoneButton btnNuevo;
        private Guna.UI.WinForms.GunaPictureBox pbSearch;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscarVehiculo;
        private Siticone.UI.WinForms.SiticoneGroupBox gbRegistros;
        private Siticone.UI.WinForms.SiticoneCircleButton btnCantRegistros;
        private Label lblCantRegistrosTotal;
        private Siticone.UI.WinForms.SiticoneCircleButton btnCantTotalRegistros;
        private Label label2;
        private Siticone.UI.WinForms.SiticoneGroupBox gbPaginas;
        private Siticone.UI.WinForms.SiticoneComboBox cboPaginacion;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalPaginas;
        private Label label12;
        private Label label13;
        private Guna.UI.WinForms.GunaButton button1;
        private PictureBox pbObsevacion;
        private Label lblObservacion;
        private Label label10;
        private Siticone.UI.WinForms.SiticoneComboBox cboPropietario;
        private Label lblCboPropietario;
        private Siticone.UI.WinForms.SiticoneTextBox txtObservaciones;
        private Siticone.UI.WinForms.SiticoneDataGridView dgVehiculo;
        private TabPage tabPage2;
        private Siticone.UI.WinForms.SiticoneDataGridView dgConsultas;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox1;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox2;
        private Siticone.UI.WinForms.SiticoneRadioButton rbVehiculo;
        private Siticone.UI.WinForms.SiticoneRadioButton rbSerie;
        private Siticone.UI.WinForms.SiticoneCheckBox chkHabilitarFechas;
        private Siticone.UI.WinForms.SiticoneButton btnNuevoHistorial;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtHfechaFinal;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtHFechaInicio;
        private Label label20;
        private Label label19;
        private PictureBox pictureBox2;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscarVehiculoM;
        private Siticone.UI.WinForms.SiticoneDataGridView dgMovimientoVH;
        private DataGridViewTextBoxColumn SIMCARDD;
        private DataGridViewTextBoxColumn IMEI;
        private Label label7;
        private Siticone.UI.WinForms.SiticoneTextBox txtConPlaca;
        private Label lblMsgMVehiculo;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox3;
        private Siticone.UI.WinForms.SiticoneCircleButton btnCantRegistrosM;
        private Label label15;
        private Siticone.UI.WinForms.SiticoneCircleButton btnCantTotalRegistrosM;
        private Label label16;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox4;
        private Siticone.UI.WinForms.SiticoneComboBox cboPaginacionM;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalPaginasM;
        private Label label17;
        private Label label18;
        private DataGridViewTextBoxColumn n;
        private DataGridViewTextBoxColumn PlacaM;
        private DataGridViewTextBoxColumn SerieM;
        private DataGridViewTextBoxColumn FechaM;
        private DataGridViewTextBoxColumn ClaseM;
        private DataGridViewTextBoxColumn MarcaM;
        private DataGridViewTextBoxColumn ModeloM;
        private DataGridViewTextBoxColumn UsoM;
        private DataGridViewTextBoxColumn AnioM;
        private DataGridViewTextBoxColumn ColorM;
        private DataGridViewTextBoxColumn DescripcionM;
        private DataGridViewTextBoxColumn EstadoM;
        private DataGridViewTextBoxColumn UsuarioM;
        private ContextMenuStrip MenuVehiculo;
        private ToolStripMenuItem opcHistorial;
        private DataGridViewTextBoxColumn codigo;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Placa;
        private DataGridViewTextBoxColumn serie;
        private DataGridViewTextBoxColumn Clase;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Modo_uso;
        private DataGridViewTextBoxColumn Estado;
        private Siticone.UI.WinForms.SiticoneDragControl sDC1mover;
    }
}