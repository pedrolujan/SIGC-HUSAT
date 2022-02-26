
namespace wfaIntegradoCom.Mantenedores
{
    partial class frmOperador
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
            this.pnlTop = new Siticone.UI.WinForms.SiticonePanel();
            this.siticoneControlBox2 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.gunaLabel10 = new Guna.UI.WinForms.GunaLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.siticoneGroupBox1 = new Siticone.UI.WinForms.SiticoneGroupBox();
            this.dgvOperador = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.IdOperador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnvolver = new Siticone.UI.WinForms.SiticoneButton();
            this.pnlTop.SuspendLayout();
            this.siticoneGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperador)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.pnlTop.Controls.Add(this.siticoneControlBox2);
            this.pnlTop.Controls.Add(this.siticoneControlBox1);
            this.pnlTop.Controls.Add(this.gunaLabel10);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Parent = this.pnlTop;
            this.pnlTop.Size = new System.Drawing.Size(365, 29);
            this.pnlTop.TabIndex = 163;
            // 
            // siticoneControlBox2
            // 
            this.siticoneControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox2.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox2.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox2.Location = new System.Drawing.Point(275, 0);
            this.siticoneControlBox2.Name = "siticoneControlBox2";
            this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox2.TabIndex = 74;
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox1.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(320, 0);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 73;
            // 
            // gunaLabel10
            // 
            this.gunaLabel10.AutoSize = true;
            this.gunaLabel10.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel10.ForeColor = System.Drawing.SystemColors.Control;
            this.gunaLabel10.Location = new System.Drawing.Point(6, 7);
            this.gunaLabel10.Name = "gunaLabel10";
            this.gunaLabel10.Size = new System.Drawing.Size(80, 15);
            this.gunaLabel10.TabIndex = 49;
            this.gunaLabel10.Text = "OPERADORES";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(84, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(194, 21);
            this.label13.TabIndex = 165;
            this.label13.Text = "SELECCIONE OPERADOR";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // siticoneGroupBox1
            // 
            this.siticoneGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneGroupBox1.BorderRadius = 5;
            this.siticoneGroupBox1.Controls.Add(this.dgvOperador);
            this.siticoneGroupBox1.Controls.Add(this.btnvolver);
            this.siticoneGroupBox1.CustomBorderColor = System.Drawing.Color.DimGray;
            this.siticoneGroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.siticoneGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneGroupBox1.ForeColor = System.Drawing.Color.White;
            this.siticoneGroupBox1.Location = new System.Drawing.Point(9, 67);
            this.siticoneGroupBox1.Name = "siticoneGroupBox1";
            this.siticoneGroupBox1.ShadowDecoration.Parent = this.siticoneGroupBox1;
            this.siticoneGroupBox1.Size = new System.Drawing.Size(344, 333);
            this.siticoneGroupBox1.TabIndex = 167;
            this.siticoneGroupBox1.Text = "SELECCIONE OPERADOR";
            this.siticoneGroupBox1.TextOffset = new System.Drawing.Point(0, -5);
            this.siticoneGroupBox1.Click += new System.EventHandler(this.siticoneGroupBox1_Click);
            // 
            // dgvOperador
            // 
            this.dgvOperador.AllowUserToAddRows = false;
            this.dgvOperador.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvOperador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOperador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperador.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperador.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOperador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOperador.ColumnHeadersHeight = 30;
            this.dgvOperador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOperador,
            this.Operador});
            this.dgvOperador.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperador.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOperador.EnableHeadersVisualStyles = false;
            this.dgvOperador.GridColor = System.Drawing.Color.Silver;
            this.dgvOperador.Location = new System.Drawing.Point(36, 57);
            this.dgvOperador.Name = "dgvOperador";
            this.dgvOperador.ReadOnly = true;
            this.dgvOperador.RowHeadersVisible = false;
            this.dgvOperador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOperador.Size = new System.Drawing.Size(283, 212);
            this.dgvOperador.TabIndex = 144;
            this.dgvOperador.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvOperador.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvOperador.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvOperador.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvOperador.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvOperador.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvOperador.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvOperador.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgvOperador.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DimGray;
            this.dgvOperador.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvOperador.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvOperador.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOperador.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvOperador.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvOperador.ThemeStyle.ReadOnly = true;
            this.dgvOperador.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvOperador.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOperador.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvOperador.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvOperador.ThemeStyle.RowsStyle.Height = 22;
            this.dgvOperador.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvOperador.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.dgvOperador.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperador_CellContentDoubleClick);
            // 
            // IdOperador
            // 
            this.IdOperador.HeaderText = "IdOperador";
            this.IdOperador.Name = "IdOperador";
            this.IdOperador.ReadOnly = true;
            this.IdOperador.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Operador
            // 
            this.Operador.HeaderText = "Operador";
            this.Operador.Name = "Operador";
            this.Operador.ReadOnly = true;
            this.Operador.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnvolver
            // 
            this.btnvolver.BorderRadius = 3;
            this.btnvolver.BorderThickness = 1;
            this.btnvolver.CheckedState.Parent = this.btnvolver;
            this.btnvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnvolver.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnvolver.CustomImages.Parent = this.btnvolver;
            this.btnvolver.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnvolver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnvolver.ForeColor = System.Drawing.Color.White;
            this.btnvolver.HoveredState.Parent = this.btnvolver;
            this.btnvolver.Location = new System.Drawing.Point(129, 278);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.PressedColor = System.Drawing.Color.Gray;
            this.btnvolver.ShadowDecoration.Parent = this.btnvolver;
            this.btnvolver.Size = new System.Drawing.Size(97, 37);
            this.btnvolver.TabIndex = 143;
            this.btnvolver.Text = "VOLVER";
            this.btnvolver.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // frmOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 413);
            this.Controls.Add(this.siticoneGroupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOperador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrdenIngresoSimCard";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.siticoneGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.UI.WinForms.SiticonePanel pnlTop;
        private Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;
        private Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;
        private Guna.UI.WinForms.GunaLabel gunaLabel10;
        private System.Windows.Forms.Label label13;
        private Siticone.UI.WinForms.SiticoneGroupBox siticoneGroupBox1;
        private Siticone.UI.WinForms.SiticoneButton btnvolver;
        private Siticone.UI.WinForms.SiticoneDataGridView dgvOperador;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOperador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operador;
    }
}