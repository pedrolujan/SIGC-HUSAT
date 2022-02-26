using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmPrecio : Form
    {
        public frmPrecio()
        {
            InitializeComponent();
        }

        BLPrecio objPrecio = null;
        clsUtil objUtil = null;
        int idProducto = 0;

        public void fnInicio(int pidProducto)
        {
            idProducto = pidProducto;
        }

        private bool fnObtenerPreciosxProductoxUM(int idProducto)
        {
            try
            {
                objPrecio = new BLPrecio();
                List<Precio> precios = objPrecio.blDevolverPrecioxProducto(idProducto);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = precios;
                return true;
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("frmPrecio.cs", "fnObtenerPreciosxProductoxUM", ex.Message);
                return false;
            }
        }

        private void frmPrecio_Load(object sender, EventArgs e)
        {
            bool blnResultado = false;
            blnResultado = fnObtenerPreciosxProductoxUM(idProducto);
            if(!blnResultado)
                MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private List<Precio> fnRecorrerGrilla()
        {
            List<Precio> lstPrecio = new List<Precio>();
            decimal decPrecioActual = 0;
            decimal decNuevoPrecio = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decNuevoPrecio = Convert.ToDecimal(row.Cells[4].Value);
                decPrecioActual = Convert.ToDecimal(row.Cells[5].Value);
                if (decNuevoPrecio != decPrecioActual)
                {
                    lstPrecio.Add(
                    new Precio
                    {
                        idPrecio = Convert.ToInt32(row.Cells[0].Value),
                        idProducto = Convert.ToInt32(row.Cells[1].Value),
                        intIdUnidaMedida = Convert.ToInt32(row.Cells[2].Value),
                        precio = Convert.ToDecimal(row.Cells[4].Value),
                        idUsuario = Variables.gnCodUser,
                        dFechaRegistro = Variables.gdFechaSis,
                        bitEstado = true
                    });
                }
            }

            return lstPrecio;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            bool blnResultado = false;
            objPrecio = new BLPrecio();
            List<Precio> lstPrecio = fnRecorrerGrilla();
            if (lstPrecio.Count > 0)
            {
                if (MessageBox.Show("¿Desea Guardar el ajuste de precio a Producto(s) y Unidad de medida Seleccionado(s)?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    blnResultado = objPrecio.blGuardarPrecio(fnRecorrerGrilla());
                    if (blnResultado)
                    {
                        blnResultado=fnObtenerPreciosxProductoxUM(idProducto);
                        if (!blnResultado)
                            MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show("Guardado correctamente el Ajuste de Inventario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("No se ha modificado algun precio. Tener en cuenta modificar Columna Nuevo Precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {

                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }
    }
}
