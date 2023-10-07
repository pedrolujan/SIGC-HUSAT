using CapaEntidad;
using CapaNegocio;
using CapaUtil;
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

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmSimCardMasivo : Form
    {
        public frmSimCardMasivo()
        {
            InitializeComponent();

            fnCargarCombobox();

            btnGuardar.Enabled = false;

            dgvbuscarorden.Visible = false;
           


        }
        //static Int32 idDetalleSim = 0;
        //static String TipoIngresos = "";
        //static String NumeroOrdenSC = "";
        //static Int32 Stocks = 0;

        //static String OperadorS = "";
        private static SimCard clsSimcardValidar =new SimCard();
        private static SimCard clscodigovalidar = new SimCard();
        private static OrdenSimCard clsSimcard = new OrdenSimCard();
        private static List<SimCard> lstSimcardIzquierda = new List<SimCard>();
        private static List<SimCard> lstcodigoSCDerecha = new List<SimCard>();
        private static List<SimCard> lstSimCardRepetido = new List<SimCard>();
        private static List<SimCard> lstCodigoRepetido = new List<SimCard>();
        private static List<SimCard> IEnumerable = new List<SimCard>();
        static Int32 tabInicio;


        Boolean estSimCard = true;
        Boolean estCodigoSC = true;
        String mensajeSimcard = "";
        String mensajeCodigoSC = "";

        Boolean estSimCardBD = false;

        Boolean estcodigoBD = false;

        Boolean estSimCardRepetidodgv = false;
        Boolean estCodigoRepetidodgv = false;


        Boolean estSimCardcaracteresdgv = false;
        Boolean estCodigocaracteresdgv = false;


        private void fnCargarCombobox()
        {
            Boolean bResult = false;

            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoOrden, "TIOI", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden Compra", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESDO00", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden Compra", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
        private void BtnOrdenCompra_Click(object sender, EventArgs e)
        {
           
            dgvSimCod.Rows.Clear();

            frmDetalleIngresoEquipo frmOrdenCompra = new frmDetalleIngresoEquipo();

           

            frmOrdenCompra.Inicio(3);
            
            txtIdOrden.Text =Convert.ToString(clsSimcard.idDetalleSC);
            txtNumOrden.Text = clsSimcard.NumeroRecibo;
            txtTipoIngreso.Text = clsSimcard.TipoIngreso;
            txtOperador.Text = clsSimcard.OperadorSC;
            txtStock.Text =Convert.ToString(clsSimcard.StockOrdenSC);
            if (txtStock.Text != "")
            {
                

                for (Int32 i = 0; i < Convert.ToInt32(txtStock.Text); i++)
                {

                    dgvSimCod.Rows.Add(new DataGridViewRow());
                }
            }
        }
        //public static void fnRecuperarSimCard(Int32 idDetalleSC, String TipoIngreso, String _NumeroRecibo, Int32 _StockOrdenSC, String OperadorSC)
        //{

        //    idDetalleSim = idDetalleSC;
        //    TipoIngresos = TipoIngreso;
        //    NumeroOrdenSC = _NumeroRecibo;
        //    Stocks = _StockOrdenSC;
        
        //    OperadorS = OperadorSC;
        //}

        public static void fnRecuperarSimCard(OrdenSimCard ClsOrdenSC)
        {
            clsSimcard = ClsOrdenSC;


        }

        private void dgvSimCod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSimCod_CausesValidationChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvSimCod_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (dgvSimCod.CurrentCell.ColumnIndex == 1)
            {
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(dText_KeyPress);
                }
                else
                {
                    
                }

            }
            else
            {
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(dText_KeyPress);

                }
                else
                {
                   
                }
            }
        }
        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PasteClipboard();

            
        }

       

        Boolean estadopaste = false;

        IEnumerable<SimCard> resul;

        private void PasteClipboard()
        {
            lstSimcardIzquierda.Clear();
            lstcodigoSCDerecha.Clear();
            lstSimCardRepetido.Clear();
            lstCodigoRepetido.Clear();
            String codUltimo = "";

            

            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = dgvSimCod.CurrentCell.RowIndex;
                int iCol = dgvSimCod.CurrentCell.ColumnIndex;
                for (Int32 i = 0; i < lines.Length - 1; i++)
                {
                    String[] ArraySimCard = lines[i].Split('\t');
                    String[] ArrayCodigoSC = ArraySimCard[1].Split('\r');


                    lstSimcardIzquierda.Add(new SimCard
                    {

                        StrsimCard = ArraySimCard[0]
                        
                        

                    });


                    lstcodigoSCDerecha.Add(new SimCard
                    {


                        CodigoSimCard = ArrayCodigoSC[0]


                    });

                    dgvSimCod.Rows[i].Cells[0].Value = ArraySimCard[0];
                   

                    if (lines.Length - 1== i+1)
                    {
                        codUltimo = ArrayCodigoSC[0];
                    }
                    else
                    {
                        dgvSimCod.Rows[i].Cells[1].Value = ArrayCodigoSC[0];
                    }

                }


                estSimCardRepetidodgv=fnEncontrarRepetidos(lstSimcardIzquierda, 0);

                estCodigoRepetidodgv=fnEncontrarRepetidos(lstcodigoSCDerecha, 1);


                estSimCardBD = fnvalidarSimCardExistenteEnBD(lstSimcardIzquierda, 0);

                estcodigoBD = fnvalidarSimCardExistenteEnBD(lstcodigoSCDerecha, 1);


                var result=   fnvalidarcolumnas(dgvSimCod);
                      estSimCardcaracteresdgv = result.Item1;
                             lblMsgdsc.Text = result.Item2;

                var resulta = fnvalidarcolumna1(dgvSimCod);
                       estCodigocaracteresdgv = resulta.Item1;
                                lblcod.Text = resulta.Item2;


               

                 estadopaste = true;
                dgvSimCod.Rows[dgvSimCod.Rows.Count-1].Cells[1].Value = "11111111111111111111";
                var resultado = fnvalidarcolumna1(dgvSimCod);
                estCodigocaracteresdgv = resultado.Item1;
                lblcod.Text = resultado.Item2;
                dgvSimCod.Rows[dgvSimCod.Rows.Count - 1].Cells[1].Value = codUltimo;


            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }


        private Boolean fnEncontrarRepetidos(List<SimCard> lstSimcard, Int32 columna)
        {
            Boolean estadorepetido = false;
            for (Int32 i = 0; i < lstSimcard.Count; i++)
            {


                for (Int32 j = 0; j < lstSimcard.Count; j++)
                {
                    if (i == j)
                    {

                    }
                    else
                    {
                        if (columna==0)
                        {
                            if (lstSimcard[i].StrsimCard == lstSimcard[j].StrsimCard)
                            {
                                //lstSimCardRepetido[i].RepetidosimCard = lstSimcardIzquierda[i].StrsimCard;

                               

                                dgvSimCod.Rows[i].Cells[columna].Style.BackColor = Variables.Colororangeclaro;
                                
                                lblrepetidosim.Text = "Campos Repetidos";
                                estadorepetido = false;

                                break;
                            }
                            else
                            {
                                

                                dgvSimCod.Rows[i].Cells[columna].Style.BackColor = Color.AliceBlue;
                                
                                lblrepetidosim.Text = "";
                                estadorepetido = true;
                            }
                        }
                        else
                        {
                            if (lstSimcard[i].CodigoSimCard == lstSimcard[j].CodigoSimCard)
                            {
                               

                                //lstSimCardRepetido[i].RepetidosimCard = lstSimcardIzquierda[i].StrsimCard;
                                dgvSimCod.Rows[i].Cells[columna].Style.BackColor = Variables.Colororangeclaro;
                                
                                lblrepetidocodigo.Text = "Campos Repetidos";

                                estadorepetido = false;
                                break;
                            }
                            else
                            {
                              

                                dgvSimCod.Rows[i].Cells[columna].Style.BackColor = Color.AliceBlue;
                                
                                lblrepetidocodigo.Text = "";
                                estadorepetido = true;


                            }
                        }


                        //fnvalidarcolumnas(i, 0, dgvSimCod);

                        //fnvalidarcolumna1(i, 1, dgvSimCod);

                    }

                }
            }

            return estadorepetido;

        }


        private void fnvalidarlistas(Int32 fila, Int32 columna)
        {
            if (columna == 0)
            {

 
                    lstSimcardIzquierda[fila].StrsimCard = Convert.ToString(dgvSimCod.Rows[fila].Cells[columna].Value);
                fnEncontrarRepetidos(lstSimcardIzquierda, columna);
              


            }
            else if (columna == 1)
            {


                    lstcodigoSCDerecha[fila].CodigoSimCard = Convert.ToString(dgvSimCod.Rows[fila].Cells[columna].Value);
                fnEncontrarRepetidos(lstcodigoSCDerecha, columna);
               
            }


        }
        private Boolean fnGuardarSimcardCodigo(List<SimCard> lstSimCardGuardar, List<SimCard> lstCodigoGuardar, Int32 tipocon)
        {
            List<SimCard> listFinal = new List<SimCard>();
           

            //listFinal = lstSimCardGuardar.Union(lstCodigoGuardar).ToList();

            for(int i=0; i< lstSimCardGuardar.Count; i++)

            {

                lstSimCardGuardar[i].CodigoSimCard = lstCodigoGuardar[i].CodigoSimCard;

            }


            //lstSimCardGuardar.AddRange(lstCodigoGuardar);

            lstSimCardGuardar[0].iddetalleordensimcard = Convert.ToString(clsSimcard.idDetalleSC);

            lstSimCardGuardar[0].observacion = txtObservacion.Text;

            lstSimCardGuardar[0].idEstado = "ESCHI003";

            lstSimCardGuardar[0].idUsuario = Variables.gnCodUser;

            BLOperador objSimCod = new BLOperador();




            objSimCod.blGuardarSimCod(lstSimCardGuardar, tipocon);




            return true;
        }

        private Boolean fnvalidarSimCardExistenteEnBD(List<SimCard> lstSimCard , Int32 columna)
        {
            dgvSimCod.ThemeStyle.RowsStyle.ForeColor = Color.Black;

            

            DataTable SimCard = new DataTable();
            DataTable CodSimCard = new DataTable();

            BLOperador objSimCard = new BLOperador();


            SimCard = objSimCard.blValidarSimCard(lstSimCard, columna);
            if (SimCard.Rows.Count > 0)
            {
                for (int i = 0; i < SimCard.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvSimCod.Rows.Count; j++)
                    {
                        String dato = Convert.ToString(SimCard.Rows[i][0]);
                        if (Convert.ToString(dgvSimCod.Rows[j].Cells[columna].Value) == Convert.ToString(SimCard.Rows[i][0]))
                        {
                            dgvSimCod.Rows[j].Cells[columna].Style.BackColor = Variables.Colororangeclaro;

                            if (columna == 0)
                            {
                               
                                lblrepetidosim.Text = "Campos Repetidos De La Base De Datos";
                                // btnGuardar.Enabled = false;
                                estSimCardBD = false;
                                
                            }
                            else if(columna==1)
                            {
                                lblrepetidocodigo.Text = "Campos Repetidos De La Base De Datos";
                                // btnGuardar.Enabled = false;
                                estcodigoBD = false;
                            }

                            break;

                        }
                    }
                }


                    
                return false;

            }
            else
            {
                if (columna == 0)
                {
              
                    lblrepetidosim.Text = "";
                    //btnGuardar.Enabled = true;
                    estSimCardBD = true;
                }
                else if (columna == 1)
                {
                    lblrepetidocodigo.Text = "";
                    //btnGuardar.Enabled = true;
                    estcodigoBD = true;
                }
                
                return true;
            }

        }


     

        private void dgvSimCod_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = e.RowIndex;

            Int32 columna = e.ColumnIndex;

            //estSimCard = true;
           


            if (fila >= 0)
            {
                if (columna == 0)
                {
                    if (estSimCard != false)
                    {
                        var caracteresSimCard = fnvalidarcolumnas(dgvSimCod);
                        estSimCard = caracteresSimCard.Item1;
                        mensajeSimcard = caracteresSimCard.Item2;


                        lblMsgdsc.Text = mensajeSimcard;

                    }
              
                }

                else if (columna == 1)
                {

                    if (estCodigoSC != false)
                    {
                        var caracteresCodigo = fnvalidarcolumna1( dgvSimCod);
                        estCodigoSC = caracteresCodigo.Item1;
                        mensajeCodigoSC = caracteresCodigo.Item2;

                        lblcod.Text = mensajeCodigoSC;
                    }
                    else
                    {
                        lblcod.Text = "";
                      
                    }
                   
                }

            }

             if (estadopaste == true)
            {


                fnvalidarlistas(fila, columna);

                //  fnvalidarSimCardExistenteEnBD(lstSimcardIzquierda, columna);

                //fnvalidarSimCardExistenteEnBD(lstSimcardIzquierda, 0);
                //fnvalidarSimCardExistenteEnBD(lstcodigoSCDerecha, 1);




                estSimCardRepetidodgv = fnEncontrarRepetidos(lstSimcardIzquierda, 0);

                estCodigoRepetidodgv = fnEncontrarRepetidos(lstcodigoSCDerecha, 1);


                estSimCardBD = fnvalidarSimCardExistenteEnBD(lstSimcardIzquierda, 0);

                estcodigoBD = fnvalidarSimCardExistenteEnBD(lstcodigoSCDerecha, 1);


                var result = fnvalidarcolumnas(dgvSimCod);
                estSimCardcaracteresdgv = result.Item1;
                lblMsgdsc.Text = result.Item2;

                var resulta = fnvalidarcolumna1(dgvSimCod);
                estcodigoBD= resulta.Item1;
                lblcod.Text = resulta.Item2;

                var resul = fnvalidarcolumnas(dgvSimCod);
                estSimCardcaracteresdgv = resul.Item1;
                lblMsgdsc.Text = resul.Item2;

                var resultado = fnvalidarcolumna1(dgvSimCod);
                estCodigocaracteresdgv = resultado.Item1;
                lblcod.Text = resultado.Item2;




                if (estSimCardRepetidodgv == true && estCodigoRepetidodgv == true && estcodigoBD==true && estSimCardBD==true && estSimCardcaracteresdgv==true && estCodigocaracteresdgv==true)
                {

                    btnGuardar.Enabled = true;

                }
                else
                {
                    btnGuardar.Enabled = false;
                }



            }


        }
        Boolean estado = false;
        string mensaje = "";

        private Tuple<Boolean, String> fnvalidarcolumnas(DataGridView dgv)
        {

            for (Int32 i = 0; i < lstSimcardIzquierda.Count; i++)
            {


                if (Convert.ToString(dgv.Rows[i].Cells[0].Value).Length < 9)
                {

                    mensaje = "Minimo 9 Digitos";

                    dgv.Rows[i].Cells[0].Style.BackColor = Color.Tomato; 

                    estado = false;

                    estSimCardcaracteresdgv = false;

                    break;



                }

                else if (Convert.ToString(dgv.Rows[i].Cells[0].Value).Length == 9)
                {


                    mensaje = "";

                 
                    estado = true;

                }
            }
            
            return Tuple.Create(estado, mensaje);
     
        }

        private Tuple<Boolean, String> fnvalidarcolumna1( DataGridView dgv)
        {
            Boolean estado = false;
            string mensaje = "";

            for (Int32 i = 0; i < lstcodigoSCDerecha.Count; i++)
            {

                if (Convert.ToString(dgv.Rows[i].Cells[1].Value).Length < 19)
                {

                    mensaje = "Minimo 19 Digitos";

                    dgv.Rows[i].Cells[1].Style.BackColor = Color.Tomato;

                    estCodigocaracteresdgv = false;

                    estado = false;

                    break;

                }
   

                else
                {


                    mensaje = "";


                    estado = true;



                }
            }
            
            return Tuple.Create(estado, mensaje);

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

            fnvalidarSimCardExistenteEnBD(lstSimcardIzquierda, 0);
            fnvalidarSimCardExistenteEnBD(lstcodigoSCDerecha, 1);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Boolean respuest = false;
            String mensaje = "";


            respuest = fnGuardarSimcardCodigo(lstSimcardIzquierda, lstcodigoSCDerecha, 0);

            if (respuest == true )

            {
                mensaje = "SE GUARDO CORRETAMENTE";
                fnlimpiarformSimCardMasivo();
            }           
             
            else 
            {

                mensaje = "ERROR" ;
            }
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //dgvSimCod.Rows.Clear();
            fnlimpiarformSimCardMasivo();
        }
        private Boolean fnBuscarSimcard(Int32 numPag, Int32 tipocon)
        {
            BLOperador objSimcard = new BLOperador();
            clsUtil objUtil = new clsUtil();
            DataTable dtResultados = new DataTable();
            Int32 tabIndex = 0;
            Int32 filas = 10;
            String pcbuscar = "";
           String cboorden= cboTipoOrden.SelectedValue.ToString();
            String cboEstados = cboEstado.SelectedValue.ToString();
          

            if (tipocon == 0)
            {
                pcbuscar = Convert.ToString(txtBuscar.Text);
            }
            dtResultados = objSimcard.blBuscarSimCard(pcbuscar, cboorden, cboEstados, numPag, tipocon);
          
            DataTable dt = new DataTable();
            Int32 totalResultados = dtResultados.Rows.Count;
            Int32 y;
          

            if (tipocon == -1)
            {
                y = 0;
            }
            else
            {
                tabInicio = (numPag - 1) * filas;
                y = tabInicio;
            }

            if (totalResultados > 0)
            {
                
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("Simcard");
                    dt.Columns.Add("Codigo");


                for (int i = 0; i <= dtResultados.Rows.Count - 1; i++)
                {
                    y += 1;
                   
                    object[] row = {dtResultados.Rows[i][1],y, dtResultados.Rows[i][2], dtResultados.Rows[i][3]};
                    dt.Rows.Add(row);

                }

                dgvbuscarorden.DataSource = dt;
                dgvbuscarorden.Visible = true;
                dgvbuscarorden.Columns[0].Visible = false;
                dgvbuscarorden.Columns[1].Width = 10;
                dgvbuscarorden.Columns[2].Width = 50;
                dgvbuscarorden.Columns[3].Width = 200;

                if (tipocon == -1)
                {
                    gbPaginacion.Visible = true;

                    Int32 totalRegistros = Convert.ToInt32(dtResultados.Rows[0][0]);

                    FunValidaciones.fnCalcularPaginacion(
                        totalRegistros,
                        filas,
                        totalResultados,
                        cboPagina,
                        btnTotalPag,
                        btnNumFilas,
                        btnTotalReg
                    );
                }
                else
                {
                    btnNumFilas.Text = Convert.ToString(totalResultados);
                }
            }

            

            else
            {
                dt.Clear();
                dt.Columns.Add("NO SE ENCONTRARON DATOS PARA LA BUSQUEDA");
                dgvbuscarorden.Visible = true; dgvbuscarorden.DataSource = dt;

            }

            return true;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                dgvbuscarorden.Visible = true;
                fnBuscarSimcard(0,-1);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            fnlimpiarformSimCardMasivo();

        }

        private void fnlimpiarformSimCardMasivo()
        {
            txtBuscar.Text = "";
            txtIdOrden.Text = "";
            txtNumOrden.Text = "";
            txtOperador.Text = "";
            txtStock.Text = "";
            txtTipoIngreso.Text = "";
            txtObservacion.Text = "";
            dgvSimCod.Rows.Clear();
            lblcod.Text = "";
            lblMsgdsc.Text = "";
            lblrepetidocodigo.Text = "";
            lblrepetidosim.Text = "";
            dgvbuscarorden.Visible = false;

        }

        private void siticoneGroupBox2_Click(object sender, EventArgs e)
        {
            dgvbuscarorden.Visible = false;
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            dgvbuscarorden.Visible = true;
            fnBuscarSimcard(0,-1);
        }

        private void dgvbuscarorden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SiticoneHtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarSimcard(Convert.ToInt32(cboPagina.Text),-2);
        }

        private void frmSimCardMasivo_Load(object sender, EventArgs e)

        {
            FunValidaciones.fnColorBoton2(btnNuevo,btnGuardar);
            

        }
    }

}
