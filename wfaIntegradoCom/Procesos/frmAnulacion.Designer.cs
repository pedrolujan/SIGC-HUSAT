namespace wfaIntegradoCom.Procesos
{
    partial class frmAnulacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.lvempleado = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.txtBuscarEmpleado = new Siticone.UI.WinForms.SiticoneTextBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvempleado)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconPictureBox2);
            this.panel1.Controls.Add(this.siticoneLabel1);
            this.panel1.Controls.Add(this.lvempleado);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Arial", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.Location = new System.Drawing.Point(124, 53);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(173, 21);
            this.siticoneLabel1.TabIndex = 241;
            this.siticoneLabel1.Text = "BUSCAR ANULACION";
            // 
            // lvempleado
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.lvempleado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.lvempleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lvempleado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.lvempleado.BackgroundColor = System.Drawing.Color.Azure;
            this.lvempleado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvempleado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.lvempleado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lvempleado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lvempleado.ColumnHeadersHeight = 40;
            this.lvempleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.NombreEmpleado,
            this.DNI});
            this.lvempleado.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(129)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lvempleado.DefaultCellStyle = dataGridViewCellStyle3;
            this.lvempleado.EnableHeadersVisualStyles = false;
            this.lvempleado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(189)))), ((int)(((byte)(184)))));
            this.lvempleado.Location = new System.Drawing.Point(12, 158);
            this.lvempleado.Name = "lvempleado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lvempleado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.lvempleado.RowHeadersVisible = false;
            this.lvempleado.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lvempleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lvempleado.Size = new System.Drawing.Size(776, 251);
            this.lvempleado.TabIndex = 240;
            this.lvempleado.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Red;
            this.lvempleado.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.lvempleado.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.lvempleado.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.lvempleado.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.lvempleado.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.lvempleado.ThemeStyle.BackColor = System.Drawing.Color.Azure;
            this.lvempleado.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(189)))), ((int)(((byte)(184)))));
            this.lvempleado.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lvempleado.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.lvempleado.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lvempleado.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.lvempleado.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.lvempleado.ThemeStyle.HeaderStyle.Height = 40;
            this.lvempleado.ThemeStyle.ReadOnly = false;
            this.lvempleado.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            this.lvempleado.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.lvempleado.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lvempleado.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.lvempleado.ThemeStyle.RowsStyle.Height = 22;
            this.lvempleado.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(129)))), ((int)(((byte)(121)))));
            this.lvempleado.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Código
            // 
            this.Código.FillWeight = 76.14212F;
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            // 
            // NombreEmpleado
            // 
            this.NombreEmpleado.FillWeight = 135.3255F;
            this.NombreEmpleado.HeaderText = "Nombre Empleado";
            this.NombreEmpleado.Name = "NombreEmpleado";
            // 
            // DNI
            // 
            this.DNI.FillWeight = 88.53233F;
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Controls.Add(this.txtBuscarEmpleado);
            this.panel2.Location = new System.Drawing.Point(316, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 40);
            this.panel2.TabIndex = 239;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Cornsilk;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Cornsilk;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 38;
            this.iconPictureBox1.Location = new System.Drawing.Point(423, 2);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(46, 38);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox1.TabIndex = 238;
            this.iconPictureBox1.TabStop = false;
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.Animated = false;
            this.txtBuscarEmpleado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarEmpleado.DefaultText = "";
            this.txtBuscarEmpleado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarEmpleado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarEmpleado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarEmpleado.DisabledState.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarEmpleado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarEmpleado.FocusedState.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarEmpleado.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarEmpleado.HoveredState.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(4, 2);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.PasswordChar = '\0';
            this.txtBuscarEmpleado.PlaceholderText = "";
            this.txtBuscarEmpleado.SelectedText = "";
            this.txtBuscarEmpleado.ShadowDecoration.Parent = this.txtBuscarEmpleado;
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(417, 36);
            this.txtBuscarEmpleado.TabIndex = 23;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.DollyBox;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 109;
            this.iconPictureBox2.Location = new System.Drawing.Point(398, 268);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(204, 109);
            this.iconPictureBox2.TabIndex = 242;
            this.iconPictureBox2.TabStop = false;
            // 
            // frmAnulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmAnulacion";
            this.Text = "frmAnulacion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvempleado)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticoneDataGridView lvempleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscarEmpleado;
    }
}