namespace wfaIntegradoCom.Procesos
{
    partial class frmBajadeServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBajadeServicio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.siticoneControlBox2 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox1 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
            this.Toppanel = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarBajaServicio = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBuscarPlaca = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.dgBajaServicios = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.siticoneVSeparator1 = new Siticone.Desktop.UI.WinForms.SiticoneVSeparator();
            this.cboPagina = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnTotalReg = new Siticone.Desktop.UI.WinForms.SiticoneCircleButton();
            this.btnTotalPaginas = new Siticone.Desktop.UI.WinForms.SiticoneCircleButton();
            this.btnNumFilas = new Siticone.Desktop.UI.WinForms.SiticoneCircleButton();
            this.label26 = new System.Windows.Forms.Label();
            this.Toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarBajaServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBajaServicios)).BeginInit();
            this.gbPaginacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // siticoneControlBox2
            // 
            this.siticoneControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox2.ControlBoxType = Siticone.Desktop.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox2.HoverState.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox2.Location = new System.Drawing.Point(878, 0);
            this.siticoneControlBox2.Name = "siticoneControlBox2";
            this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox2.TabIndex = 76;
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox1.HoverState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(923, 0);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 75;
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
            this.Toppanel.Size = new System.Drawing.Size(968, 29);
            this.Toppanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "BAJA DE SERVICIOS-HUSAT";
            // 
            // btnBuscarBajaServicio
            // 
            this.btnBuscarBajaServicio.BackColor = System.Drawing.Color.White;
            this.btnBuscarBajaServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarBajaServicio.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarBajaServicio.Image")));
            this.btnBuscarBajaServicio.Location = new System.Drawing.Point(490, 60);
            this.btnBuscarBajaServicio.Name = "btnBuscarBajaServicio";
            this.btnBuscarBajaServicio.Size = new System.Drawing.Size(32, 30);
            this.btnBuscarBajaServicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBuscarBajaServicio.TabIndex = 247;
            this.btnBuscarBajaServicio.TabStop = false;
            this.btnBuscarBajaServicio.Click += new System.EventHandler(this.btnBuscarBajaServicio_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(12, 41);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 13);
            this.label23.TabIndex = 246;
            this.label23.Text = "Buscar Placa";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBuscarPlaca
            // 
            this.txtBuscarPlaca.Animated = false;
            this.txtBuscarPlaca.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscarPlaca.BorderRadius = 5;
            this.txtBuscarPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarPlaca.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarPlaca.DefaultText = "";
            this.txtBuscarPlaca.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarPlaca.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarPlaca.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarPlaca.DisabledState.Parent = this.txtBuscarPlaca;
            this.txtBuscarPlaca.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarPlaca.FocusedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtBuscarPlaca.FocusedState.Parent = this.txtBuscarPlaca;
            this.txtBuscarPlaca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarPlaca.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarPlaca.HoverState.Parent = this.txtBuscarPlaca;
            this.txtBuscarPlaca.Location = new System.Drawing.Point(10, 57);
            this.txtBuscarPlaca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscarPlaca.Name = "txtBuscarPlaca";
            this.txtBuscarPlaca.PasswordChar = '\0';
            this.txtBuscarPlaca.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBuscarPlaca.PlaceholderText = "";
            this.txtBuscarPlaca.SelectedText = "";
            this.txtBuscarPlaca.ShadowDecoration.Parent = this.txtBuscarPlaca;
            this.txtBuscarPlaca.Size = new System.Drawing.Size(519, 36);
            this.txtBuscarPlaca.TabIndex = 245;
            // 
            // dgBajaServicios
            // 
            this.dgBajaServicios.AllowUserToAddRows = false;
            this.dgBajaServicios.AllowUserToDeleteRows = false;
            this.dgBajaServicios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgBajaServicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBajaServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBajaServicios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgBajaServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgBajaServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBajaServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgBajaServicios.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBajaServicios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgBajaServicios.EnableHeadersVisualStyles = false;
            this.dgBajaServicios.GridColor = System.Drawing.Color.Silver;
            this.dgBajaServicios.Location = new System.Drawing.Point(15, 108);
            this.dgBajaServicios.Name = "dgBajaServicios";
            this.dgBajaServicios.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBajaServicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgBajaServicios.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgBajaServicios.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgBajaServicios.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgBajaServicios.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBajaServicios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBajaServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBajaServicios.Size = new System.Drawing.Size(930, 364);
            this.dgBajaServicios.TabIndex = 248;
            this.dgBajaServicios.Theme = Siticone.Desktop.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgBajaServicios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgBajaServicios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgBajaServicios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgBajaServicios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgBajaServicios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgBajaServicios.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.dgBajaServicios.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgBajaServicios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DimGray;
            this.dgBajaServicios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgBajaServicios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBajaServicios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgBajaServicios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgBajaServicios.ThemeStyle.HeaderStyle.Height = 30;
            this.dgBajaServicios.ThemeStyle.ReadOnly = true;
            this.dgBajaServicios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgBajaServicios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgBajaServicios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBajaServicios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgBajaServicios.ThemeStyle.RowsStyle.Height = 22;
            this.dgBajaServicios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.dgBajaServicios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.SteelBlue;
            this.dgBajaServicios.Visible = false;
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
            this.gbPaginacion.Location = new System.Drawing.Point(605, 478);
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(340, 40);
            this.gbPaginacion.TabIndex = 249;
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
            this.btnTotalReg.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalReg.HoverState.Parent = this.btnTotalReg;
            this.btnTotalReg.Location = new System.Drawing.Point(307, 9);
            this.btnTotalReg.Name = "btnTotalReg";
            this.btnTotalReg.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
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
            this.btnTotalPaginas.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnTotalPaginas.HoverState.Parent = this.btnTotalPaginas;
            this.btnTotalPaginas.Location = new System.Drawing.Point(149, 9);
            this.btnTotalPaginas.Name = "btnTotalPaginas";
            this.btnTotalPaginas.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
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
            this.btnNumFilas.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnNumFilas.HoverState.Parent = this.btnNumFilas;
            this.btnNumFilas.Location = new System.Drawing.Point(209, 9);
            this.btnNumFilas.Name = "btnNumFilas";
            this.btnNumFilas.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
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
            // frmBajadeServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 544);
            this.Controls.Add(this.gbPaginacion);
            this.Controls.Add(this.dgBajaServicios);
            this.Controls.Add(this.btnBuscarBajaServicio);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtBuscarPlaca);
            this.Controls.Add(this.Toppanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBajadeServicio";
            this.Text = "frmBajadeServicio";
            this.Toppanel.ResumeLayout(false);
            this.Toppanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarBajaServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBajaServicios)).EndInit();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox2;
        private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox1;
        private Siticone.Desktop.UI.WinForms.SiticonePanel Toppanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnBuscarBajaServicio;
        private System.Windows.Forms.Label label23;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtBuscarPlaca;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView dgBajaServicios;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private System.Windows.Forms.Label label24;
        private Siticone.Desktop.UI.WinForms.SiticoneVSeparator siticoneVSeparator1;
        private System.Windows.Forms.ComboBox cboPagina;
        private System.Windows.Forms.Label label25;
        private Siticone.Desktop.UI.WinForms.SiticoneCircleButton btnTotalReg;
        private Siticone.Desktop.UI.WinForms.SiticoneCircleButton btnTotalPaginas;
        private Siticone.Desktop.UI.WinForms.SiticoneCircleButton btnNumFilas;
        private System.Windows.Forms.Label label26;
    }
}