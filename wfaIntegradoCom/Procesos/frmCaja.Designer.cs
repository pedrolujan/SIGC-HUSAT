namespace wfaIntegradoCom.Procesos
{
    partial class frmCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.siticoneGroupBox1 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.chkDiaEspecificoG = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.chkHabilitarFechasBusG = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.gbHabilitarBusqFechas = new System.Windows.Forms.GroupBox();
            this.dtFechaFinG = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaInicioG = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.siticoneLabel11 = new Siticone.UI.WinForms.SiticoneLabel();
            this.cboTipoReporte = new Siticone.UI.WinForms.SiticoneComboBox();
            this.dgvListaPorBloque = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siticoneGroupBox1.SuspendLayout();
            this.gbHabilitarBusqFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPorBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // siticoneGroupBox1
            // 
            this.siticoneGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneGroupBox1.BorderRadius = 5;
            this.siticoneGroupBox1.Controls.Add(this.chkDiaEspecificoG);
            this.siticoneGroupBox1.Controls.Add(this.chkHabilitarFechasBusG);
            this.siticoneGroupBox1.Controls.Add(this.gbHabilitarBusqFechas);
            this.siticoneGroupBox1.Controls.Add(this.siticoneLabel11);
            this.siticoneGroupBox1.Controls.Add(this.cboTipoReporte);
            this.siticoneGroupBox1.CustomBorderColor = System.Drawing.Color.DimGray;
            this.siticoneGroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.siticoneGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneGroupBox1.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.siticoneGroupBox1.Name = "siticoneGroupBox1";
            this.siticoneGroupBox1.ShadowDecoration.Parent = this.siticoneGroupBox1;
            this.siticoneGroupBox1.Size = new System.Drawing.Size(976, 92);
            this.siticoneGroupBox1.TabIndex = 266;
            this.siticoneGroupBox1.Text = "Buscar por";
            this.siticoneGroupBox1.TextOffset = new System.Drawing.Point(0, -7);
            // 
            // chkDiaEspecificoG
            // 
            this.chkDiaEspecificoG.AutoSize = true;
            this.chkDiaEspecificoG.BackColor = System.Drawing.Color.Transparent;
            this.chkDiaEspecificoG.Checked = true;
            this.chkDiaEspecificoG.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkDiaEspecificoG.CheckedState.BorderRadius = 0;
            this.chkDiaEspecificoG.CheckedState.BorderThickness = 0;
            this.chkDiaEspecificoG.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkDiaEspecificoG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiaEspecificoG.ForeColor = System.Drawing.Color.White;
            this.chkDiaEspecificoG.Location = new System.Drawing.Point(223, 4);
            this.chkDiaEspecificoG.Name = "chkDiaEspecificoG";
            this.chkDiaEspecificoG.Size = new System.Drawing.Size(108, 21);
            this.chkDiaEspecificoG.TabIndex = 266;
            this.chkDiaEspecificoG.Text = "Dia especifico";
            this.chkDiaEspecificoG.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDiaEspecificoG.UncheckedState.BorderRadius = 0;
            this.chkDiaEspecificoG.UncheckedState.BorderThickness = 0;
            this.chkDiaEspecificoG.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDiaEspecificoG.UseVisualStyleBackColor = false;
            this.chkDiaEspecificoG.CheckedChanged += new System.EventHandler(this.chkDiaEspecificoG_CheckedChanged);
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
            this.chkHabilitarFechasBusG.ForeColor = System.Drawing.Color.White;
            this.chkHabilitarFechasBusG.Location = new System.Drawing.Point(92, 4);
            this.chkHabilitarFechasBusG.Name = "chkHabilitarFechasBusG";
            this.chkHabilitarFechasBusG.Size = new System.Drawing.Size(119, 21);
            this.chkHabilitarFechasBusG.TabIndex = 266;
            this.chkHabilitarFechasBusG.Text = "Habilitar Fechas";
            this.chkHabilitarFechasBusG.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechasBusG.UncheckedState.BorderRadius = 0;
            this.chkHabilitarFechasBusG.UncheckedState.BorderThickness = 0;
            this.chkHabilitarFechasBusG.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHabilitarFechasBusG.UseVisualStyleBackColor = false;
            // 
            // gbHabilitarBusqFechas
            // 
            this.gbHabilitarBusqFechas.AutoSize = true;
            this.gbHabilitarBusqFechas.BackColor = System.Drawing.Color.Transparent;
            this.gbHabilitarBusqFechas.Controls.Add(this.dtFechaFinG);
            this.gbHabilitarBusqFechas.Controls.Add(this.label1);
            this.gbHabilitarBusqFechas.Controls.Add(this.dtFechaInicioG);
            this.gbHabilitarBusqFechas.Controls.Add(this.label2);
            this.gbHabilitarBusqFechas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbHabilitarBusqFechas.Location = new System.Drawing.Point(1, 17);
            this.gbHabilitarBusqFechas.Name = "gbHabilitarBusqFechas";
            this.gbHabilitarBusqFechas.Size = new System.Drawing.Size(502, 72);
            this.gbHabilitarBusqFechas.TabIndex = 267;
            this.gbHabilitarBusqFechas.TabStop = false;
            // 
            // dtFechaFinG
            // 
            this.dtFechaFinG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtFechaFinG.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtFechaFinG.BorderRadius = 3;
            this.dtFechaFinG.BorderThickness = 1;
            this.dtFechaFinG.CheckedState.Parent = this.dtFechaFinG;
            this.dtFechaFinG.FillColor = System.Drawing.Color.White;
            this.dtFechaFinG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtFechaFinG.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtFechaFinG.HoveredState.Parent = this.dtFechaFinG;
            this.dtFechaFinG.Location = new System.Drawing.Point(255, 32);
            this.dtFechaFinG.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFechaFinG.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFechaFinG.Name = "dtFechaFinG";
            this.dtFechaFinG.ShadowDecoration.Parent = this.dtFechaFinG;
            this.dtFechaFinG.Size = new System.Drawing.Size(241, 36);
            this.dtFechaFinG.TabIndex = 233;
            this.dtFechaFinG.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 227;
            this.label1.Text = "Fecha Inicial:";
            // 
            // dtFechaInicioG
            // 
            this.dtFechaInicioG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFechaInicioG.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtFechaInicioG.BorderRadius = 3;
            this.dtFechaInicioG.BorderThickness = 1;
            this.dtFechaInicioG.CheckedState.Parent = this.dtFechaInicioG;
            this.dtFechaInicioG.FillColor = System.Drawing.Color.White;
            this.dtFechaInicioG.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtFechaInicioG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtFechaInicioG.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtFechaInicioG.HoveredState.Parent = this.dtFechaInicioG;
            this.dtFechaInicioG.Location = new System.Drawing.Point(8, 32);
            this.dtFechaInicioG.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFechaInicioG.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFechaInicioG.Name = "dtFechaInicioG";
            this.dtFechaInicioG.ShadowDecoration.Parent = this.dtFechaInicioG;
            this.dtFechaInicioG.Size = new System.Drawing.Size(242, 36);
            this.dtFechaInicioG.TabIndex = 231;
            this.dtFechaInicioG.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(252, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 232;
            this.label2.Text = "Fecha Final:";
            // 
            // siticoneLabel11
            // 
            this.siticoneLabel11.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel11.ForeColor = System.Drawing.Color.Black;
            this.siticoneLabel11.Location = new System.Drawing.Point(534, 31);
            this.siticoneLabel11.Name = "siticoneLabel11";
            this.siticoneLabel11.Size = new System.Drawing.Size(68, 15);
            this.siticoneLabel11.TabIndex = 1;
            this.siticoneLabel11.Text = "Tipo Reporte:";
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoReporte.BorderRadius = 5;
            this.cboTipoReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoReporte.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipoReporte.HoveredState.Parent = this.cboTipoReporte;
            this.cboTipoReporte.ItemHeight = 30;
            this.cboTipoReporte.ItemsAppearance.Parent = this.cboTipoReporte;
            this.cboTipoReporte.Location = new System.Drawing.Point(534, 49);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.ShadowDecoration.Parent = this.cboTipoReporte;
            this.cboTipoReporte.Size = new System.Drawing.Size(405, 36);
            this.cboTipoReporte.TabIndex = 2;
            // 
            // dgvListaPorBloque
            // 
            this.dgvListaPorBloque.AllowUserToAddRows = false;
            this.dgvListaPorBloque.AllowUserToDeleteRows = false;
            this.dgvListaPorBloque.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListaPorBloque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaPorBloque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaPorBloque.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPorBloque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListaPorBloque.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaPorBloque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaPorBloque.ColumnHeadersHeight = 30;
            this.dgvListaPorBloque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListaPorBloque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.numero,
            this.Detalle,
            this.Cantidad1,
            this.importeRow});
            this.dgvListaPorBloque.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaPorBloque.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListaPorBloque.EnableHeadersVisualStyles = false;
            this.dgvListaPorBloque.GridColor = System.Drawing.Color.Silver;
            this.dgvListaPorBloque.Location = new System.Drawing.Point(0, 95);
            this.dgvListaPorBloque.Name = "dgvListaPorBloque";
            this.dgvListaPorBloque.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaPorBloque.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListaPorBloque.RowHeadersVisible = false;
            this.dgvListaPorBloque.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaPorBloque.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvListaPorBloque.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaPorBloque.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaPorBloque.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaPorBloque.RowTemplate.Height = 25;
            this.dgvListaPorBloque.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaPorBloque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPorBloque.Size = new System.Drawing.Size(976, 237);
            this.dgvListaPorBloque.TabIndex = 271;
            this.dgvListaPorBloque.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvListaPorBloque.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaPorBloque.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListaPorBloque.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListaPorBloque.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListaPorBloque.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListaPorBloque.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaPorBloque.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgvListaPorBloque.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DimGray;
            this.dgvListaPorBloque.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvListaPorBloque.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaPorBloque.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListaPorBloque.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListaPorBloque.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvListaPorBloque.ThemeStyle.ReadOnly = true;
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.Height = 25;
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.dgvListaPorBloque.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.SteelBlue;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            // 
            // numero
            // 
            this.numero.FillWeight = 10.15229F;
            this.numero.HeaderText = "N°";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // Detalle
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Detalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.Detalle.FillWeight = 218.6924F;
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            // 
            // Cantidad1
            // 
            this.Cantidad1.FillWeight = 84.8747F;
            this.Cantidad1.HeaderText = "Cantidad";
            this.Cantidad1.Name = "Cantidad1";
            this.Cantidad1.ReadOnly = true;
            // 
            // importeRow
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.importeRow.DefaultCellStyle = dataGridViewCellStyle4;
            this.importeRow.FillWeight = 86.28063F;
            this.importeRow.HeaderText = "Importe";
            this.importeRow.Name = "importeRow";
            this.importeRow.ReadOnly = true;
            // 
            // frmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(976, 450);
            this.Controls.Add(this.dgvListaPorBloque);
            this.Controls.Add(this.siticoneGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmCaja";
            this.Load += new System.EventHandler(this.frmCaja_Load);
            this.siticoneGroupBox1.ResumeLayout(false);
            this.siticoneGroupBox1.PerformLayout();
            this.gbHabilitarBusqFechas.ResumeLayout(false);
            this.gbHabilitarBusqFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPorBloque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox1;
        private Siticone.UI.WinForms.SiticoneCheckBox chkDiaEspecificoG;
        private Siticone.UI.WinForms.SiticoneCheckBox chkHabilitarFechasBusG;
        private System.Windows.Forms.GroupBox gbHabilitarBusqFechas;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtFechaFinG;
        private System.Windows.Forms.Label label1;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtFechaInicioG;
        private System.Windows.Forms.Label label2;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel11;
        private Siticone.UI.WinForms.SiticoneComboBox cboTipoReporte;
        private Siticone.UI.WinForms.SiticoneDataGridView dgvListaPorBloque;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad1;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeRow;
    }
}