using CapaUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Funciones.Models;
using wfaIntegradoCom.Funciones.Models.Order;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmProcesarPedido : Form
    {
        string strCodigo = string.Empty;
        clsUtil objUtil = new clsUtil();
        HubFirebaseClient HubFirebaseApi;
        public frmProcesarPedido()
        {
            InitializeComponent();
        }

        public frmProcesarPedido(string pstrCodigo)
        {
            bool bResult = false;
            InitializeComponent();
            HubFirebaseApi = new HubFirebaseClient();
            strCodigo = pstrCodigo;
            bResult = FunGeneral.fnLlenarTablaCodValor(cboEstadoPedido, "ESPE");
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar TablaCod -Estado de Pedidos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            fnGetAllorEspecificOrder(strCodigo);
        }

        private bool fnLoadFormOrder(Pedido objpedido)
        {
            try
            {
                lblCodigo.Text = lblCodigo.Text + " " + objpedido.Codigo;
                OrderWeb orderWeb = JsonConvert.DeserializeObject<OrderWeb>(objpedido.xmlObject);
                if(orderWeb != null)
                {
                    txtNombre.Text = orderWeb.orderData.name;
                    txtApellido.Text = orderWeb.orderData.name2;
                    txtDireccion.Text = orderWeb.orderData.street;
                    txtCoreo.Text = orderWeb.orderData.email;
                    txtCelular.Text = orderWeb.orderData.Celular;
                    txtNombre.Text = orderWeb.orderData.name;
                    txtTotal.Text = orderWeb.Totalprice.ToString("#0.00");
                    cboEstadoPedido.Text = FunGeneral.fnGetEnumDescription(objpedido.intEstado);
                    dgvDetalle.DataSource = null;
                    dgvDetalle.DataSource = orderWeb.products;
                } 
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void fnGetAllorEspecificOrder(string strCodigo)
        {
            bool blnResultado = false;
            GenericListResponse<Pedido> generic = FunGeneral.fnGeAllorEspecificOrder(strCodigo);
            if (generic.Status == 200)
            {
                List<Pedido> lstPedidos = generic.data;
                if (lstPedidos != null  && lstPedidos.Count >0)
                {
                    blnResultado = fnLoadFormOrder(lstPedidos[0]);
                    if (!blnResultado)
                        MessageBox.Show("Ha ocurrido un error al Cargar el Pedido al Formulario. Reintentar, si prosigue comunicar a TI.", "Aviso");
                }
            }
            else
                MessageBox.Show("Ha ocurrido un error al Cargar el Pedido. Reintentar, si prosigue comunicar a TI.", "Aviso");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmProcesarPedido_Load(object sender, EventArgs e)
        {

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool fnUpdateOrder()
        {
            OrderRequest orderRequest = new OrderRequest();
            OrderResponse orden = new OrderResponse();
            bool blnResult = false;

            try
            {
                orderRequest.order.Codigo = strCodigo;
                orderRequest.order.dFechaAct = Variables.gdFechaSis;
                orderRequest.order.dFechaRegistro = Variables.gdFechaSis;
                orderRequest.order.idUserAct = Variables.gnCodUser;
                orderRequest.order.intEstado = Convert.ToInt32(cboEstadoPedido.SelectedValue.ToString());
                orden = FunGeneral.fnSaveOrder(orderRequest);
                if (orden.Status == 200)
                {
                    blnResult =HubFirebaseApi.fnUpdateOrderId(orderRequest.order.Codigo, orderRequest.order.intEstado);
                    if (!blnResult)
                        objUtil.gsLogAplicativo("frmProcesarPedido.cs", "fnUpdateOrder", "No se ha actualizado el estado correctamente en el Firebase la orden:" + orderRequest.order.Codigo);
                    blnResult = true;
                }
                else
                {
                    objUtil.gsLogAplicativo("frmProcesarPedido.cs", "fnUpdateOrder", orden.Message+ ": " + orderRequest.order.Codigo);
                    MessageBox.Show("Ha ocurrido un error al Guardar estado del Pedido. Reintentar, si prosigue comunicar a TI.", "Aviso");
                    blnResult = false;
                }
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("frmProcesarPedido.cs", "fnUpdateOrder", ex.Message + ": " + orderRequest.order.Codigo);
                MessageBox.Show("Ha ocurrido un error no controlado al Guardar estado del Pedido. Reintentar, si prosigue comunicar a TI.", "Aviso");
                blnResult = false;
            }

            return blnResult;
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            bool blnResul = false;
            if (MessageBox.Show("¿Desea Guardar Estado de Pedido Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                blnResul = fnUpdateOrder();
                if (blnResul)
                {
                    MessageBox.Show("Se ha guardado correctamente estado del pedido.", "Aviso");
                    this.Dispose();
                }
            }

        }
    }
}
