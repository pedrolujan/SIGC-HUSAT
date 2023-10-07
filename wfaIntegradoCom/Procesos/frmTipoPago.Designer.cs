namespace wfaIntegradoCom.Procesos
{
    partial class frmTipoPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.pncargando = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.SiticoneHtmlLabel1 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.siticoneProgressIndicator1 = new Siticone.Desktop.UI.WinForms.SiticoneProgressIndicator();
            this.dgvEntidades = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cntMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.elimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new Siticone.Desktop.UI.WinForms.SiticoneCircleButton();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gbRespuestaPago = new System.Windows.Forms.GroupBox();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbSi = new System.Windows.Forms.RadioButton();
            this.txtImporteAbonado = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.txtImporteRestante = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAPagar = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnAceptar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.pbOservacion = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.txtObsevacion = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoVenta = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.siticonePanel1.SuspendLayout();
            this.pncargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntidades)).BeginInit();
            this.cntMenu.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.gbRespuestaPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOservacion)).BeginInit();
            this.SuspendLayout();
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel1.BorderThickness = 2;
            this.siticonePanel1.Controls.Add(this.pncargando);
            this.siticonePanel1.Controls.Add(this.dgvEntidades);
            this.siticonePanel1.Controls.Add(this.btnAdd);
            this.siticonePanel1.Controls.Add(this.gunaPanel1);
            this.siticonePanel1.Controls.Add(this.gbRespuestaPago);
            this.siticonePanel1.Controls.Add(this.txtImporteAbonado);
            this.siticonePanel1.Controls.Add(this.txtImporteRestante);
            this.siticonePanel1.Controls.Add(this.label6);
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Controls.Add(this.txtTotalAPagar);
            this.siticonePanel1.Controls.Add(this.label2);
            this.siticonePanel1.Controls.Add(this.label4);
            this.siticonePanel1.Controls.Add(this.btnCancelar);
            this.siticonePanel1.Controls.Add(this.btnAceptar);
            this.siticonePanel1.Controls.Add(this.pbOservacion);
            this.siticonePanel1.Controls.Add(this.txtObsevacion);
            this.siticonePanel1.Controls.Add(this.label5);
            this.siticonePanel1.Controls.Add(this.cboTipoVenta);
            this.siticonePanel1.Controls.Add(this.lblObservaciones);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(614, 402);
            this.siticonePanel1.TabIndex = 12;
            this.siticonePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.siticonePanel1_Paint);
            // 
            // pncargando
            // 
            this.pncargando.Controls.Add(this.SiticoneHtmlLabel1);
            this.pncargando.Controls.Add(this.siticoneProgressIndicator1);
            this.pncargando.Location = new System.Drawing.Point(546, 27);
            this.pncargando.Name = "pncargando";
            this.pncargando.ShadowDecoration.Parent = this.pncargando;
            this.pncargando.Size = new System.Drawing.Size(64, 52);
            this.pncargando.TabIndex = 179;
            this.pncargando.Visible = false;
            // 
            // SiticoneHtmlLabel1
            // 
            this.SiticoneHtmlLabel1.AutoSize = false;
            this.SiticoneHtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.SiticoneHtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiticoneHtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SiticoneHtmlLabel1.Location = new System.Drawing.Point(256, 118);
            this.SiticoneHtmlLabel1.Name = "SiticoneHtmlLabel1";
            this.SiticoneHtmlLabel1.Size = new System.Drawing.Size(100, 68);
            this.SiticoneHtmlLabel1.TabIndex = 2;
            this.SiticoneHtmlLabel1.Text = "Emitiendo documento a SUNAT";
            this.SiticoneHtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // siticoneProgressIndicator1
            // 
            this.siticoneProgressIndicator1.CircleSize = 1F;
            this.siticoneProgressIndicator1.Location = new System.Drawing.Point(159, 5);
            this.siticoneProgressIndicator1.Name = "siticoneProgressIndicator1";
            this.siticoneProgressIndicator1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneProgressIndicator1.Size = new System.Drawing.Size(295, 295);
            this.siticoneProgressIndicator1.TabIndex = 3;
            // 
            // dgvEntidades
            // 
            this.dgvEntidades.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvEntidades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEntidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntidades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntidades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEntidades.ColumnHeadersHeight = 21;
            this.dgvEntidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvEntidades.ContextMenuStrip = this.cntMenu;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEntidades.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEntidades.EnableHeadersVisualStyles = false;
            this.dgvEntidades.GridColor = System.Drawing.Color.White;
            this.dgvEntidades.Location = new System.Drawing.Point(8, 116);
            this.dgvEntidades.Name = "dgvEntidades";
            this.dgvEntidades.ReadOnly = true;
            this.dgvEntidades.RowHeadersVisible = false;
            this.dgvEntidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntidades.Size = new System.Drawing.Size(485, 125);
            this.dgvEntidades.TabIndex = 178;
            this.dgvEntidades.Theme = Siticone.Desktop.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvEntidades.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntidades.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEntidades.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEntidades.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEntidades.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEntidades.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntidades.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgvEntidades.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvEntidades.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEntidades.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEntidades.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEntidades.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEntidades.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvEntidades.ThemeStyle.ReadOnly = true;
            this.dgvEntidades.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEntidades.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntidades.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvEntidades.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvEntidades.ThemeStyle.RowsStyle.Height = 22;
            this.dgvEntidades.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEntidades.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEntidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntidades_CellClick);
            this.dgvEntidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntidades_CellContentClick);
            this.dgvEntidades.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntidades_CellContentDoubleClick);
            this.dgvEntidades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntidades_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Medios de págo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cntMenu
            // 
            this.cntMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elimiToolStripMenuItem});
            this.cntMenu.Name = "cntMenu";
            this.cntMenu.Size = new System.Drawing.Size(190, 26);
            // 
            // elimiToolStripMenuItem
            // 
            this.elimiToolStripMenuItem.Name = "elimiToolStripMenuItem";
            this.elimiToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.elimiToolStripMenuItem.Text = "Eliminar seleccionado";
            this.elimiToolStripMenuItem.Click += new System.EventHandler(this.elimiToolStripMenuItem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.CheckedState.Parent = this.btnAdd;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.CustomImages.Parent = this.btnAdd;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.Parent = this.btnAdd;
            this.btnAdd.Location = new System.Drawing.Point(529, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.btnAdd.ShadowDecoration.Parent = this.btnAdd;
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 177;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.gunaPanel1.Controls.Add(this.label3);
            this.gunaPanel1.Controls.Add(this.gunaControlBox2);
            this.gunaPanel1.Controls.Add(this.gunaControlBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(614, 29);
            this.gunaPanel1.TabIndex = 160;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 76;
            this.label3.Text = "Forma de Pago";
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(495, 0);
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
            this.gunaControlBox1.Location = new System.Drawing.Point(565, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 74;
            this.gunaControlBox1.Click += new System.EventHandler(this.gunaControlBox1_Click);
            // 
            // gbRespuestaPago
            // 
            this.gbRespuestaPago.BackColor = System.Drawing.Color.White;
            this.gbRespuestaPago.Controls.Add(this.rdbNo);
            this.gbRespuestaPago.Controls.Add(this.rdbSi);
            this.gbRespuestaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbRespuestaPago.Location = new System.Drawing.Point(204, 24);
            this.gbRespuestaPago.Name = "gbRespuestaPago";
            this.gbRespuestaPago.Size = new System.Drawing.Size(206, 35);
            this.gbRespuestaPago.TabIndex = 175;
            this.gbRespuestaPago.TabStop = false;
            this.gbRespuestaPago.Visible = false;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Location = new System.Drawing.Point(108, 11);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(58, 17);
            this.rdbNo.TabIndex = 1;
            this.rdbNo.Text = "Credito";
            this.rdbNo.UseVisualStyleBackColor = true;
            this.rdbNo.CheckedChanged += new System.EventHandler(this.rdbNo_CheckedChanged);
            // 
            // rdbSi
            // 
            this.rdbSi.AutoSize = true;
            this.rdbSi.Checked = true;
            this.rdbSi.Location = new System.Drawing.Point(9, 11);
            this.rdbSi.Name = "rdbSi";
            this.rdbSi.Size = new System.Drawing.Size(65, 17);
            this.rdbSi.TabIndex = 0;
            this.rdbSi.TabStop = true;
            this.rdbSi.Text = "Contado";
            this.rdbSi.UseVisualStyleBackColor = true;
            this.rdbSi.CheckedChanged += new System.EventHandler(this.rdbSi_CheckedChanged);
            // 
            // txtImporteAbonado
            // 
            this.txtImporteAbonado.Animated = false;
            this.txtImporteAbonado.BorderColor = System.Drawing.Color.LightGray;
            this.txtImporteAbonado.BorderRadius = 3;
            this.txtImporteAbonado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImporteAbonado.DefaultText = "";
            this.txtImporteAbonado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtImporteAbonado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtImporteAbonado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtImporteAbonado.DisabledState.Parent = this.txtImporteAbonado;
            this.txtImporteAbonado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtImporteAbonado.Enabled = false;
            this.txtImporteAbonado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtImporteAbonado.FocusedState.Parent = this.txtImporteAbonado;
            this.txtImporteAbonado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImporteAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImporteAbonado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImporteAbonado.HoverState.Parent = this.txtImporteAbonado;
            this.txtImporteAbonado.Location = new System.Drawing.Point(262, 65);
            this.txtImporteAbonado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImporteAbonado.Name = "txtImporteAbonado";
            this.txtImporteAbonado.PasswordChar = '\0';
            this.txtImporteAbonado.PlaceholderText = "";
            this.txtImporteAbonado.SelectedText = "";
            this.txtImporteAbonado.ShadowDecoration.Parent = this.txtImporteAbonado;
            this.txtImporteAbonado.Size = new System.Drawing.Size(166, 36);
            this.txtImporteAbonado.TabIndex = 174;
            this.txtImporteAbonado.TextOffset = new System.Drawing.Point(25, 0);
            this.txtImporteAbonado.WordWrap = false;
            // 
            // txtImporteRestante
            // 
            this.txtImporteRestante.Animated = false;
            this.txtImporteRestante.BorderColor = System.Drawing.Color.LightGray;
            this.txtImporteRestante.BorderRadius = 3;
            this.txtImporteRestante.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImporteRestante.DefaultText = "";
            this.txtImporteRestante.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtImporteRestante.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtImporteRestante.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtImporteRestante.DisabledState.Parent = this.txtImporteRestante;
            this.txtImporteRestante.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtImporteRestante.Enabled = false;
            this.txtImporteRestante.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtImporteRestante.FocusedState.Parent = this.txtImporteRestante;
            this.txtImporteRestante.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImporteRestante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImporteRestante.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImporteRestante.HoverState.Parent = this.txtImporteRestante;
            this.txtImporteRestante.Location = new System.Drawing.Point(435, 65);
            this.txtImporteRestante.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImporteRestante.Name = "txtImporteRestante";
            this.txtImporteRestante.PasswordChar = '\0';
            this.txtImporteRestante.PlaceholderText = "";
            this.txtImporteRestante.SelectedText = "";
            this.txtImporteRestante.ShadowDecoration.Parent = this.txtImporteRestante;
            this.txtImporteRestante.Size = new System.Drawing.Size(166, 36);
            this.txtImporteRestante.TabIndex = 174;
            this.txtImporteRestante.TextOffset = new System.Drawing.Point(25, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(262, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 173;
            this.label6.Text = "Importe Abonado";
            this.label6.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(435, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 173;
            this.label1.Text = "Importe Restante";
            // 
            // txtTotalAPagar
            // 
            this.txtTotalAPagar.Animated = false;
            this.txtTotalAPagar.BorderColor = System.Drawing.Color.LightGray;
            this.txtTotalAPagar.BorderRadius = 3;
            this.txtTotalAPagar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalAPagar.DefaultText = "";
            this.txtTotalAPagar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalAPagar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalAPagar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalAPagar.DisabledState.Parent = this.txtTotalAPagar;
            this.txtTotalAPagar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalAPagar.Enabled = false;
            this.txtTotalAPagar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtTotalAPagar.FocusedState.Parent = this.txtTotalAPagar;
            this.txtTotalAPagar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTotalAPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTotalAPagar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTotalAPagar.HoverState.Parent = this.txtTotalAPagar;
            this.txtTotalAPagar.Location = new System.Drawing.Point(8, 65);
            this.txtTotalAPagar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalAPagar.Name = "txtTotalAPagar";
            this.txtTotalAPagar.PasswordChar = '\0';
            this.txtTotalAPagar.PlaceholderText = "";
            this.txtTotalAPagar.SelectedText = "";
            this.txtTotalAPagar.ShadowDecoration.Parent = this.txtTotalAPagar;
            this.txtTotalAPagar.Size = new System.Drawing.Size(246, 36);
            this.txtTotalAPagar.TabIndex = 174;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(489, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 36);
            this.label2.TabIndex = 173;
            this.label2.Text = "Agregar Medios de Pago";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(8, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 173;
            this.label4.Text = "Total a pagar:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderRadius = 3;
            this.btnCancelar.BorderThickness = 1;
            this.btnCancelar.CheckedState.Parent = this.btnCancelar;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.CustomImages.Parent = this.btnCancelar;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.HoverState.Parent = this.btnCancelar;
            this.btnCancelar.Location = new System.Drawing.Point(334, 347);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShadowDecoration.Parent = this.btnCancelar;
            this.btnCancelar.Size = new System.Drawing.Size(108, 42);
            this.btnCancelar.TabIndex = 159;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BorderRadius = 3;
            this.btnAceptar.BorderThickness = 1;
            this.btnAceptar.CheckedState.Parent = this.btnAceptar;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.CustomImages.Parent = this.btnAceptar;
            this.btnAceptar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAceptar.HoverState.Parent = this.btnAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(169, 347);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.PressedColor = System.Drawing.Color.White;
            this.btnAceptar.ShadowDecoration.Parent = this.btnAceptar;
            this.btnAceptar.Size = new System.Drawing.Size(130, 42);
            this.btnAceptar.TabIndex = 158;
            this.btnAceptar.Text = "Generar Venta";
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbOservacion
            // 
            this.pbOservacion.BackColor = System.Drawing.Color.Transparent;
            this.pbOservacion.BaseColor = System.Drawing.Color.Transparent;
            this.pbOservacion.Location = new System.Drawing.Point(547, 267);
            this.pbOservacion.Name = "pbOservacion";
            this.pbOservacion.Size = new System.Drawing.Size(22, 22);
            this.pbOservacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOservacion.TabIndex = 157;
            this.pbOservacion.TabStop = false;
            this.pbOservacion.UseTransfarantBackground = false;
            // 
            // txtObsevacion
            // 
            this.txtObsevacion.Animated = false;
            this.txtObsevacion.BorderColor = System.Drawing.Color.LightGray;
            this.txtObsevacion.BorderRadius = 3;
            this.txtObsevacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObsevacion.DefaultText = "";
            this.txtObsevacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObsevacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObsevacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObsevacion.DisabledState.Parent = this.txtObsevacion;
            this.txtObsevacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObsevacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtObsevacion.FocusedState.Parent = this.txtObsevacion;
            this.txtObsevacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObsevacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObsevacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObsevacion.HoverState.Parent = this.txtObsevacion;
            this.txtObsevacion.Location = new System.Drawing.Point(8, 266);
            this.txtObsevacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObsevacion.Multiline = true;
            this.txtObsevacion.Name = "txtObsevacion";
            this.txtObsevacion.PasswordChar = '\0';
            this.txtObsevacion.PlaceholderText = "";
            this.txtObsevacion.SelectedText = "";
            this.txtObsevacion.ShadowDecoration.Parent = this.txtObsevacion;
            this.txtObsevacion.Size = new System.Drawing.Size(562, 61);
            this.txtObsevacion.TabIndex = 156;
            this.txtObsevacion.TextChanged += new System.EventHandler(this.txtObsevacion_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(8, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 155;
            this.label5.Text = "Observaciones:";
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoVenta.BorderColor = System.Drawing.Color.LightGray;
            this.cboTipoVenta.BorderRadius = 3;
            this.cboTipoVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTipoVenta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVenta.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboTipoVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboTipoVenta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboTipoVenta.HoverState.Parent = this.cboTipoVenta;
            this.cboTipoVenta.ItemHeight = 30;
            this.cboTipoVenta.ItemsAppearance.Parent = this.cboTipoVenta;
            this.cboTipoVenta.Location = new System.Drawing.Point(476, 353);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.ShadowDecoration.Parent = this.cboTipoVenta;
            this.cboTipoVenta.Size = new System.Drawing.Size(110, 36);
            this.cboTipoVenta.TabIndex = 152;
            this.cboTipoVenta.Visible = false;
            this.cboTipoVenta.SelectedIndexChanged += new System.EventHandler(this.cboTipoVenta_SelectedIndexChanged);
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.BackColor = System.Drawing.Color.Transparent;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.ForeColor = System.Drawing.Color.Red;
            this.lblObservaciones.Location = new System.Drawing.Point(21, 329);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(0, 15);
            this.lblObservaciones.TabIndex = 170;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTipoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 402);
            this.Controls.Add(this.siticonePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Cancelación";
            this.Load += new System.EventHandler(this.frmTipoPago_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.pncargando.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntidades)).EndInit();
            this.cntMenu.ResumeLayout(false);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.gbRespuestaPago.ResumeLayout(false);
            this.gbRespuestaPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOservacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cboTipoVenta;
        private Guna.UI.WinForms.GunaCirclePictureBox pbOservacion;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtObsevacion;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnCancelar;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnAceptar;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblObservaciones;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtTotalAPagar;
        private System.Windows.Forms.Label label4;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtImporteRestante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbRespuestaPago;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbSi;
        private Siticone.Desktop.UI.WinForms.SiticoneCircleButton btnAdd;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView dgvEntidades;
        private System.Windows.Forms.ContextMenuStrip cntMenu;
        private System.Windows.Forms.ToolStripMenuItem elimiToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticonePanel pncargando;
        private System.Windows.Forms.Timer timer1;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel SiticoneHtmlLabel1;
        private Siticone.Desktop.UI.WinForms.SiticoneProgressIndicator siticoneProgressIndicator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtImporteAbonado;
        private System.Windows.Forms.Label label6;
    }
}