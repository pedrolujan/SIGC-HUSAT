namespace wfaIntegradoCom.Mantenedores
{
    partial class frmServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicios));
            this.Toppanel = new Siticone.UI.WinForms.SiticonePanel();
            this.siticoneControlBox2 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.dgServicios = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.btnBuscarServicios = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBuscarServicios = new Siticone.UI.WinForms.SiticoneTextBox();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.siticoneVSeparator1 = new Siticone.UI.WinForms.SiticoneVSeparator();
            this.cboPagina = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnTotalReg = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.btnTotalPaginas = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.btnNumFilas = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.label26 = new System.Windows.Forms.Label();
            this.barraMovimiento = new Siticone.UI.WinForms.SiticoneDragControl(this.components);
            this.gbActualizarServicios = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMonedaServ = new Siticone.UI.WinForms.SiticoneComboBox();
            this.chkEstadoServ = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescripcionServ = new Siticone.UI.WinForms.SiticoneTextBox();
            this.DtFechaRS = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.siticoneButton1 = new Siticone.UI.WinForms.SiticoneButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDServicio = new Siticone.UI.WinForms.SiticoneTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrecioServicio = new Siticone.UI.WinForms.SiticoneTextBox();
            this.txtNombreServicio = new Siticone.UI.WinForms.SiticoneTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnActualizarServicios = new Guna.UI.WinForms.GunaButton();
            this.cboEstadoBuscar = new Siticone.UI.WinForms.SiticoneComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarServicios)).BeginInit();
            this.gbPaginacion.SuspendLayout();
            this.gbActualizarServicios.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toppanel
            // 
            this.Toppanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.Toppanel.Controls.Add(this.siticoneControlBox2);
            this.Toppanel.Controls.Add(this.label1);
            this.Toppanel.Controls.Add(this.siticoneControlBox1);
            this.Toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toppanel.Location = new System.Drawing.Point(0, 0);
            this.Toppanel.Name = "Toppanel";
            this.Toppanel.ShadowDecoration.Parent = this.Toppanel;
            this.Toppanel.Size = new System.Drawing.Size(650, 29);
            this.Toppanel.TabIndex = 0;
            // 
            // siticoneControlBox2
            // 
            this.siticoneControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox2.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox2.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox2.Location = new System.Drawing.Point(560, 0);
            this.siticoneControlBox2.Name = "siticoneControlBox2";
            this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox2.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SERVICIOS-HUSAT";
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox1.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(605, 0);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 75;
            // 
            // dgServicios
            // 
            this.dgServicios.AllowUserToAddRows = false;
            this.dgServicios.AllowUserToDeleteRows = false;
            this.dgServicios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgServicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgServicios.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgServicios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgServicios.EnableHeadersVisualStyles = false;
            this.dgServicios.GridColor = System.Drawing.Color.Silver;
            this.dgServicios.Location = new System.Drawing.Point(10, 103);
            this.dgServicios.Name = "dgServicios";
            this.dgServicios.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgServicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgServicios.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgServicios.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgServicios.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgServicios.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgServicios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgServicios.Size = new System.Drawing.Size(628, 364);
            this.dgServicios.TabIndex = 232;
            this.dgServicios.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgServicios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgServicios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgServicios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgServicios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgServicios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgServicios.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgServicios.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgServicios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DimGray;
            this.dgServicios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgServicios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgServicios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgServicios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgServicios.ThemeStyle.HeaderStyle.Height = 30;
            this.dgServicios.ThemeStyle.ReadOnly = true;
            this.dgServicios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgServicios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgServicios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgServicios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgServicios.ThemeStyle.RowsStyle.Height = 22;
            this.dgServicios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.dgServicios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.SteelBlue;
            this.dgServicios.Visible = false;
            this.dgServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgServicios_CellDoubleClick);
            this.dgServicios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgServicios_CellMouseDown);
            // 
            // btnBuscarServicios
            // 
            this.btnBuscarServicios.BackColor = System.Drawing.Color.White;
            this.btnBuscarServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarServicios.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarServicios.Image")));
            this.btnBuscarServicios.Location = new System.Drawing.Point(600, 56);
            this.btnBuscarServicios.Name = "btnBuscarServicios";
            this.btnBuscarServicios.Size = new System.Drawing.Size(30, 30);
            this.btnBuscarServicios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBuscarServicios.TabIndex = 244;
            this.btnBuscarServicios.TabStop = false;
            this.btnBuscarServicios.Click += new System.EventHandler(this.btnBuscarServicios_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(300, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(86, 13);
            this.label23.TabIndex = 243;
            this.label23.Text = "Buscar Servicios";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBuscarServicios
            // 
            this.txtBuscarServicios.Animated = false;
            this.txtBuscarServicios.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscarServicios.BorderRadius = 5;
            this.txtBuscarServicios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarServicios.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarServicios.DefaultText = "";
            this.txtBuscarServicios.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarServicios.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarServicios.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarServicios.DisabledState.Parent = this.txtBuscarServicios;
            this.txtBuscarServicios.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarServicios.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtBuscarServicios.FocusedState.Parent = this.txtBuscarServicios;
            this.txtBuscarServicios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarServicios.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarServicios.HoveredState.Parent = this.txtBuscarServicios;
            this.txtBuscarServicios.Location = new System.Drawing.Point(298, 53);
            this.txtBuscarServicios.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscarServicios.Name = "txtBuscarServicios";
            this.txtBuscarServicios.PasswordChar = '\0';
            this.txtBuscarServicios.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBuscarServicios.PlaceholderText = "";
            this.txtBuscarServicios.SelectedText = "";
            this.txtBuscarServicios.ShadowDecoration.Parent = this.txtBuscarServicios;
            this.txtBuscarServicios.Size = new System.Drawing.Size(339, 36);
            this.txtBuscarServicios.TabIndex = 242;
            this.txtBuscarServicios.TextChanged += new System.EventHandler(this.txtBuscarServicios_TextChanged);
            this.txtBuscarServicios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarServicios_KeyPress);
            // 
            // gbPaginacion
            // 
            this.gbPaginacion.Controls.Add(this.label24);
            this.gbPaginacion.Controls.Add(this.siticoneVSeparator1);
            this.gbPaginacion.Controls.Add(this.cboPagina);
            this.gbPaginacion.Controls.Add(this.label25);
            this.gbPaginacion.Controls.Add(this.btnTotalReg);
            this.gbPaginacion.Controls.Add(this.btnTotalPaginas);
            this.gbPaginacion.Controls.Add(this.btnNumFilas);
            this.gbPaginacion.Controls.Add(this.label26);
            this.gbPaginacion.Location = new System.Drawing.Point(298, 515);
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(340, 40);
            this.gbPaginacion.TabIndex = 234;
            this.gbPaginacion.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(240, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(61, 13);
            this.label24.TabIndex = 173;
            this.label24.Text = "registros de";
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
            this.cboPagina.FormattingEnabled = true;
            this.cboPagina.Location = new System.Drawing.Point(52, 13);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Size = new System.Drawing.Size(63, 21);
            this.cboPagina.TabIndex = 167;
            this.cboPagina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPagina_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 13);
            this.label25.TabIndex = 168;
            this.label25.Text = "Página";
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
            this.btnTotalReg.Location = new System.Drawing.Point(307, 9);
            this.btnTotalReg.Name = "btnTotalReg";
            this.btnTotalReg.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalReg.ShadowDecoration.Parent = this.btnTotalReg;
            this.btnTotalReg.Size = new System.Drawing.Size(25, 25);
            this.btnTotalReg.TabIndex = 172;
            this.btnTotalReg.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // btnTotalPaginas
            // 
            this.btnTotalPaginas.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalPaginas.CheckedState.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.CustomImages.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginas.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalPaginas.ForeColor = System.Drawing.Color.White;
            this.btnTotalPaginas.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginas.HoveredState.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.Location = new System.Drawing.Point(149, 9);
            this.btnTotalPaginas.Name = "btnTotalPaginas";
            this.btnTotalPaginas.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnTotalPaginas.ShadowDecoration.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.Size = new System.Drawing.Size(25, 25);
            this.btnTotalPaginas.TabIndex = 169;
            this.btnTotalPaginas.TextOffset = new System.Drawing.Point(0, 1);
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
            this.btnNumFilas.Location = new System.Drawing.Point(209, 9);
            this.btnNumFilas.Name = "btnNumFilas";
            this.btnNumFilas.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnNumFilas.ShadowDecoration.Parent = this.btnNumFilas;
            this.btnNumFilas.Size = new System.Drawing.Size(25, 25);
            this.btnNumFilas.TabIndex = 171;
            this.btnNumFilas.TextOffset = new System.Drawing.Point(0, 1);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(124, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 13);
            this.label26.TabIndex = 170;
            this.label26.Text = "de";
            // 
            // barraMovimiento
            // 
            this.barraMovimiento.TargetControl = this.Toppanel;
            // 
            // gbActualizarServicios
            // 
            this.gbActualizarServicios.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbActualizarServicios.BorderRadius = 5;
            this.gbActualizarServicios.Controls.Add(this.label8);
            this.gbActualizarServicios.Controls.Add(this.cboMonedaServ);
            this.gbActualizarServicios.Controls.Add(this.chkEstadoServ);
            this.gbActualizarServicios.Controls.Add(this.label6);
            this.gbActualizarServicios.Controls.Add(this.txtDescripcionServ);
            this.gbActualizarServicios.Controls.Add(this.DtFechaRS);
            this.gbActualizarServicios.Controls.Add(this.siticoneButton1);
            this.gbActualizarServicios.Controls.Add(this.label4);
            this.gbActualizarServicios.Controls.Add(this.txtIDServicio);
            this.gbActualizarServicios.Controls.Add(this.label2);
            this.gbActualizarServicios.Controls.Add(this.txtPrecioServicio);
            this.gbActualizarServicios.Controls.Add(this.txtNombreServicio);
            this.gbActualizarServicios.Controls.Add(this.label3);
            this.gbActualizarServicios.Controls.Add(this.label5);
            this.gbActualizarServicios.CustomBorderColor = System.Drawing.Color.DimGray;
            this.gbActualizarServicios.CustomBorderThickness = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.gbActualizarServicios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActualizarServicios.ForeColor = System.Drawing.Color.White;
            this.gbActualizarServicios.Location = new System.Drawing.Point(18, 103);
            this.gbActualizarServicios.Name = "gbActualizarServicios";
            this.gbActualizarServicios.ShadowDecoration.Parent = this.gbActualizarServicios;
            this.gbActualizarServicios.Size = new System.Drawing.Size(619, 361);
            this.gbActualizarServicios.TabIndex = 246;
            this.gbActualizarServicios.Text = "Actualizar Servicios";
            this.gbActualizarServicios.TextOffset = new System.Drawing.Point(0, -7);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(285, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 262;
            this.label8.Text = "Moneda";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboMonedaServ
            // 
            this.cboMonedaServ.BackColor = System.Drawing.Color.Transparent;
            this.cboMonedaServ.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonedaServ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaServ.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonedaServ.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMonedaServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMonedaServ.HoveredState.Parent = this.cboMonedaServ;
            this.cboMonedaServ.ItemHeight = 30;
            this.cboMonedaServ.ItemsAppearance.Parent = this.cboMonedaServ;
            this.cboMonedaServ.Location = new System.Drawing.Point(285, 199);
            this.cboMonedaServ.Name = "cboMonedaServ";
            this.cboMonedaServ.ShadowDecoration.Parent = this.cboMonedaServ;
            this.cboMonedaServ.Size = new System.Drawing.Size(173, 36);
            this.cboMonedaServ.TabIndex = 263;
            // 
            // chkEstadoServ
            // 
            this.chkEstadoServ.AutoSize = true;
            this.chkEstadoServ.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkEstadoServ.CheckedState.BorderRadius = 0;
            this.chkEstadoServ.CheckedState.BorderThickness = 0;
            this.chkEstadoServ.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkEstadoServ.ForeColor = System.Drawing.Color.Black;
            this.chkEstadoServ.Location = new System.Drawing.Point(25, 199);
            this.chkEstadoServ.Name = "chkEstadoServ";
            this.chkEstadoServ.Size = new System.Drawing.Size(67, 21);
            this.chkEstadoServ.TabIndex = 257;
            this.chkEstadoServ.Text = "Estado";
            this.chkEstadoServ.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkEstadoServ.UncheckedState.BorderRadius = 0;
            this.chkEstadoServ.UncheckedState.BorderThickness = 0;
            this.chkEstadoServ.UncheckedState.FillColor = System.Drawing.Color.Gray;
            this.chkEstadoServ.CheckedChanged += new System.EventHandler(this.chkEstadoServ_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(16, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 256;
            this.label6.Text = "Descripcion";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripcionServ
            // 
            this.txtDescripcionServ.Animated = false;
            this.txtDescripcionServ.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcionServ.BorderRadius = 5;
            this.txtDescripcionServ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionServ.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcionServ.DefaultText = "";
            this.txtDescripcionServ.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescripcionServ.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescripcionServ.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcionServ.DisabledState.Parent = this.txtDescripcionServ;
            this.txtDescripcionServ.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcionServ.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDescripcionServ.FocusedState.Parent = this.txtDescripcionServ;
            this.txtDescripcionServ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDescripcionServ.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcionServ.HoveredState.Parent = this.txtDescripcionServ;
            this.txtDescripcionServ.Location = new System.Drawing.Point(17, 271);
            this.txtDescripcionServ.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcionServ.Multiline = true;
            this.txtDescripcionServ.Name = "txtDescripcionServ";
            this.txtDescripcionServ.PasswordChar = '\0';
            this.txtDescripcionServ.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDescripcionServ.PlaceholderText = "";
            this.txtDescripcionServ.SelectedText = "";
            this.txtDescripcionServ.ShadowDecoration.Parent = this.txtDescripcionServ;
            this.txtDescripcionServ.Size = new System.Drawing.Size(598, 77);
            this.txtDescripcionServ.TabIndex = 255;
            // 
            // DtFechaRS
            // 
            this.DtFechaRS.CheckedState.Parent = this.DtFechaRS;
            this.DtFechaRS.FillColor = System.Drawing.Color.White;
            this.DtFechaRS.ForeColor = System.Drawing.Color.Black;
            this.DtFechaRS.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DtFechaRS.HoveredState.Parent = this.DtFechaRS;
            this.DtFechaRS.Location = new System.Drawing.Point(285, 129);
            this.DtFechaRS.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtFechaRS.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtFechaRS.Name = "DtFechaRS";
            this.DtFechaRS.ShadowDecoration.Parent = this.DtFechaRS;
            this.DtFechaRS.Size = new System.Drawing.Size(321, 36);
            this.DtFechaRS.TabIndex = 254;
            this.DtFechaRS.Value = new System.DateTime(2023, 1, 25, 16, 15, 25, 314);
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneButton1.BorderRadius = 15;
            this.siticoneButton1.BorderThickness = 1;
            this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
            this.siticoneButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
            this.siticoneButton1.FillColor = System.Drawing.Color.White;
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneButton1.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneButton1.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneButton1.HoveredState.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.HoveredState.Image = global::wfaIntegradoCom.Properties.Resources.limpiar_blanco_32;
            this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
            this.siticoneButton1.Image = global::wfaIntegradoCom.Properties.Resources.limpiar_32;
            this.siticoneButton1.Location = new System.Drawing.Point(1141, 131);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
            this.siticoneButton1.Size = new System.Drawing.Size(118, 36);
            this.siticoneButton1.TabIndex = 159;
            this.siticoneButton1.Text = "Limpiar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(16, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 252;
            this.label4.Text = "Precio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIDServicio
            // 
            this.txtIDServicio.Animated = false;
            this.txtIDServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtIDServicio.BorderRadius = 5;
            this.txtIDServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDServicio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDServicio.DefaultText = "";
            this.txtIDServicio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIDServicio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIDServicio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDServicio.DisabledState.Parent = this.txtIDServicio;
            this.txtIDServicio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDServicio.Enabled = false;
            this.txtIDServicio.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtIDServicio.FocusedState.Parent = this.txtIDServicio;
            this.txtIDServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIDServicio.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIDServicio.HoveredState.Parent = this.txtIDServicio;
            this.txtIDServicio.Location = new System.Drawing.Point(17, 52);
            this.txtIDServicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDServicio.Name = "txtIDServicio";
            this.txtIDServicio.PasswordChar = '\0';
            this.txtIDServicio.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtIDServicio.PlaceholderText = "";
            this.txtIDServicio.SelectedText = "";
            this.txtIDServicio.ShadowDecoration.Parent = this.txtIDServicio;
            this.txtIDServicio.Size = new System.Drawing.Size(229, 36);
            this.txtIDServicio.TabIndex = 245;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 246;
            this.label2.Text = "Id Servicio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPrecioServicio
            // 
            this.txtPrecioServicio.Animated = false;
            this.txtPrecioServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPrecioServicio.BorderRadius = 5;
            this.txtPrecioServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecioServicio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioServicio.DefaultText = "";
            this.txtPrecioServicio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioServicio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioServicio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioServicio.DisabledState.Parent = this.txtPrecioServicio;
            this.txtPrecioServicio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioServicio.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtPrecioServicio.FocusedState.Parent = this.txtPrecioServicio;
            this.txtPrecioServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioServicio.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioServicio.HoveredState.Parent = this.txtPrecioServicio;
            this.txtPrecioServicio.Location = new System.Drawing.Point(19, 129);
            this.txtPrecioServicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrecioServicio.Name = "txtPrecioServicio";
            this.txtPrecioServicio.PasswordChar = '\0';
            this.txtPrecioServicio.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrecioServicio.PlaceholderText = "";
            this.txtPrecioServicio.SelectedText = "";
            this.txtPrecioServicio.ShadowDecoration.Parent = this.txtPrecioServicio;
            this.txtPrecioServicio.Size = new System.Drawing.Size(227, 36);
            this.txtPrecioServicio.TabIndex = 251;
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Animated = false;
            this.txtNombreServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNombreServicio.BorderRadius = 5;
            this.txtNombreServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreServicio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombreServicio.DefaultText = "";
            this.txtNombreServicio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNombreServicio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNombreServicio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombreServicio.DisabledState.Parent = this.txtNombreServicio;
            this.txtNombreServicio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombreServicio.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtNombreServicio.FocusedState.Parent = this.txtNombreServicio;
            this.txtNombreServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreServicio.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombreServicio.HoveredState.Parent = this.txtNombreServicio;
            this.txtNombreServicio.Location = new System.Drawing.Point(285, 52);
            this.txtNombreServicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.PasswordChar = '\0';
            this.txtNombreServicio.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNombreServicio.PlaceholderText = "";
            this.txtNombreServicio.SelectedText = "";
            this.txtNombreServicio.ShadowDecoration.Parent = this.txtNombreServicio;
            this.txtNombreServicio.Size = new System.Drawing.Size(321, 36);
            this.txtNombreServicio.TabIndex = 247;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(282, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 248;
            this.label3.Text = "Nombre ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(282, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 250;
            this.label5.Text = "Fecha Registro";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnActualizarServicios
            // 
            this.btnActualizarServicios.AnimationHoverSpeed = 0.07F;
            this.btnActualizarServicios.AnimationSpeed = 0.03F;
            this.btnActualizarServicios.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarServicios.BaseColor = System.Drawing.Color.Transparent;
            this.btnActualizarServicios.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(57)))));
            this.btnActualizarServicios.BorderSize = 1;
            this.btnActualizarServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarServicios.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnActualizarServicios.FocusedColor = System.Drawing.Color.Empty;
            this.btnActualizarServicios.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnActualizarServicios.Image = global::wfaIntegradoCom.Properties.Resources.search_base;
            this.btnActualizarServicios.ImageSize = new System.Drawing.Size(15, 15);
            this.btnActualizarServicios.Location = new System.Drawing.Point(263, 473);
            this.btnActualizarServicios.Name = "btnActualizarServicios";
            this.btnActualizarServicios.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(57)))));
            this.btnActualizarServicios.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(57)))));
            this.btnActualizarServicios.OnHoverForeColor = System.Drawing.Color.White;
            this.btnActualizarServicios.OnHoverImage = global::wfaIntegradoCom.Properties.Resources.search_hover;
            this.btnActualizarServicios.OnPressedColor = System.Drawing.Color.Black;
            this.btnActualizarServicios.Radius = 10;
            this.btnActualizarServicios.Size = new System.Drawing.Size(150, 36);
            this.btnActualizarServicios.TabIndex = 253;
            this.btnActualizarServicios.Text = "Actualizar Servicios";
            this.btnActualizarServicios.Click += new System.EventHandler(this.btnActualizarServicios_Click_1);
            // 
            // cboEstadoBuscar
            // 
            this.cboEstadoBuscar.BackColor = System.Drawing.Color.Transparent;
            this.cboEstadoBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEstadoBuscar.BorderRadius = 5;
            this.cboEstadoBuscar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoBuscar.FocusedColor = System.Drawing.Color.DodgerBlue;
            this.cboEstadoBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstadoBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboEstadoBuscar.HoveredState.Parent = this.cboEstadoBuscar;
            this.cboEstadoBuscar.ItemHeight = 30;
            this.cboEstadoBuscar.Items.AddRange(new object[] {
            "TODOS",
            "ACTIVOS",
            "INACTIVOS"});
            this.cboEstadoBuscar.ItemsAppearance.Parent = this.cboEstadoBuscar;
            this.cboEstadoBuscar.Location = new System.Drawing.Point(15, 56);
            this.cboEstadoBuscar.Name = "cboEstadoBuscar";
            this.cboEstadoBuscar.ShadowDecoration.Parent = this.cboEstadoBuscar;
            this.cboEstadoBuscar.Size = new System.Drawing.Size(244, 36);
            this.cboEstadoBuscar.TabIndex = 260;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(15, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 261;
            this.label7.Text = "Estado";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 567);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboEstadoBuscar);
            this.Controls.Add(this.btnActualizarServicios);
            this.Controls.Add(this.btnBuscarServicios);
            this.Controls.Add(this.gbActualizarServicios);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtBuscarServicios);
            this.Controls.Add(this.gbPaginacion);
            this.Controls.Add(this.dgServicios);
            this.Controls.Add(this.Toppanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmServicios";
            this.Load += new System.EventHandler(this.frmServicios_Load);
            this.Toppanel.ResumeLayout(false);
            this.Toppanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarServicios)).EndInit();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.gbActualizarServicios.ResumeLayout(false);
            this.gbActualizarServicios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.UI.WinForms.SiticonePanel Toppanel;
        private System.Windows.Forms.Label label1;
        private Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;
        private Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;
        private Siticone.UI.WinForms.SiticoneDataGridView dgServicios;
        private System.Windows.Forms.PictureBox btnBuscarServicios;
        private System.Windows.Forms.Label label23;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscarServicios;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private System.Windows.Forms.Label label24;
        private Siticone.UI.WinForms.SiticoneVSeparator siticoneVSeparator1;
        private System.Windows.Forms.ComboBox cboPagina;
        private System.Windows.Forms.Label label25;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalReg;
        private Siticone.UI.WinForms.SiticoneCircleButton btnTotalPaginas;
        private Siticone.UI.WinForms.SiticoneCircleButton btnNumFilas;
        private System.Windows.Forms.Label label26;
        private Siticone.UI.WinForms.SiticoneDragControl barraMovimiento;
        private Siticone.UI.WinForms.SiticoneGroupBox gbActualizarServicios;
        private Guna.UI.WinForms.GunaButton btnActualizarServicios;
        private Siticone.UI.WinForms.SiticoneButton siticoneButton1;
        private System.Windows.Forms.Label label4;
        private Siticone.UI.WinForms.SiticoneTextBox txtIDServicio;
        private System.Windows.Forms.Label label2;
        private Siticone.UI.WinForms.SiticoneTextBox txtPrecioServicio;
        private Siticone.UI.WinForms.SiticoneTextBox txtNombreServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Siticone.UI.WinForms.SiticoneDateTimePicker DtFechaRS;
        private System.Windows.Forms.Label label6;
        private Siticone.UI.WinForms.SiticoneTextBox txtDescripcionServ;
        private Siticone.UI.WinForms.SiticoneCheckBox chkEstadoServ;
        private Siticone.UI.WinForms.SiticoneComboBox cboMonedaServ;
        private Siticone.UI.WinForms.SiticoneComboBox cboEstadoBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}