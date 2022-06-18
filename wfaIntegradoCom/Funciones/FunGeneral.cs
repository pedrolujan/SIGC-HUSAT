using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaUtil;
using CapaNegocio;
using CapaEntidad;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones.Models;
using wfaIntegradoCom.Funciones.Helper;
using Newtonsoft.Json;
using wfaIntegradoCom.Funciones.Enum;
using Siticone.UI.WinForms;
using System.Globalization;

namespace wfaIntegradoCom.Funciones
{
    public class FunGeneral
    {
        static clsUtil objUtil = new clsUtil();
        public static Boolean fnLlenarTablaCod(ComboBox cboCombo, String cCodTab)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        public static Boolean fnLlenarTablaCodTipoCon(ComboBox cboCombo, String cCodTab,Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCodTipoCon(cCodTab,buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static Boolean fnLlenarCboSegunTablaTipoCon(ComboBox cboCombo, String nomCampoId,String nomCampoNombre,String nomTabla,String nomEstado,String condicionDeEstado, Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blLlenarCboSegunTablaTipoCon( nomCampoId,  nomCampoNombre,  nomTabla,  nomEstado,  condicionDeEstado,  buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }


        //llenar combobox de la instalacion
        public static Boolean fnLlenarAccesorios(ComboBox cboCombo, Int32 cCodTab)
        {
            BLAccesorio objTablaCod = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            List<Accesorios> lstTablaCod = new List<Accesorios>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverAccesorio(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember ="idAccesorio";
                cboCombo.DisplayMember ="cAccesorio";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        public static Boolean fnLlenarTablaCodValor(ComboBox cboCombo, String cCodTab)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cValor";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCodValor", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        public static Cargo[] fnDevolverParametro(String pcCodTab)
        {
            BLCargo objCargo = new BLCargo();
            Cargo[] arrParametro = new Cargo[1];
            clsUtil objUtil = new clsUtil();
            
            try {
                arrParametro = objCargo.blDevolverTablaCod(pcCodTab).ToArray();
                return arrParametro;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("fnValidaTipoDato", "GetFechaHoraFormato", ex.Message);
                return null;
            }
            finally
            {
                objCargo = null;
                arrParametro = null;
                objUtil = null;
            }
        }

        public static String GetFechaHoraFormato(DateTime pdFecha, Int32 piFormato)
        {
            String sFecSis;
            String sDia, sMes, sAnio;
            String sHoraActual = (DateTime.Now.TimeOfDay.ToString());
            sFecSis = "";
            clsUtil objUtil = new clsUtil();
            try
            {

                switch (piFormato)
                {
                    case 1:       //Presentación        dd//mm/yyyy           
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sDia + "/" + sMes + "/" + sAnio;
                        break;
                    case 5:       //Fecha corta              
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "/" + sMes + "/" + sDia;
                        break;
                    case 2:       //Registro en Base  FechaHora   
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + sMes + sDia + " " + sHoraActual.Substring(0, 12);
                        break;
                    case 3:       //yyyy-mm-dd hh:mm:ss                         

                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "-" + sMes + "-" + sDia;

                        sFecSis = sFecSis + " " + sHoraActual.Substring(0, 12);
                        break;
                    case 4:

                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "-" + sMes + "-" + sDia + " " + pdFecha.Hour + ":" + pdFecha.Minute + ":" + pdFecha.Second + "." + pdFecha.Millisecond.ToString().PadLeft(3, '0');
                        break;
                    case 6:       //Presentación        dd//mm/yyyy           
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sDia + "/" + sMes + "/" + sAnio+" "+sHoraActual.Substring(0, 12);;
                        break;
                }

                return sFecSis;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("fnValidaTipoDato", "GetFechaHoraFormato", ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public static Boolean fnVerificarApertura()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            BLDocumentoVenta objApertura = new BLDocumentoVenta();
            try
            {
                bResul = objApertura.blVerificarApertura(FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5), Variables.idSucursal);
                return bResul;
            }
            catch (Exception ex)
            {
                bResul = false;
                objUtil.gsLogAplicativo("frmAperturaCaja", "fnVerificarApertura", ex.Message);
                return bResul;
            }
        }

        public static void fnVerificarFechaSistema(Form[] children)
        {
            if (Variables.gdFechaSis.Date != DateTime.Now.Date)
            {
                Variables.gdFechaSis = DateTime.Now;
                var arrayFormOpens = Application.OpenForms;

                if (arrayFormOpens != null)
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name.Trim() != "MDIParent1")
                            frm.Close();
                    }
                }
            }
        }

        public static IList<PrintingTemplate> GetPrintingTemplates(IList<string> templatesList)
        {
            try
            {

                string originPath = Application.StartupPath + "\\Template";
                //Validate Path
                if (System.IO.Directory.Exists(originPath))
                {
                    //Initialize Uploading Files list
                    List<PrintingTemplate> templates = new List<PrintingTemplate>();

                    //Get files path in directory
                    String[] templateFiles = System.IO.Directory.GetFiles(originPath, "*.xml");
                    String[] configFiles = System.IO.Directory.GetFiles(originPath, "*.config");
                    int intContador = 0;
                    //Look into templates files
                    foreach (String templateFile in templateFiles)
                    {
                        intContador = intContador + 1;
                        try
                        {
                            String[] pathSplit = templateFile.Split('\\');
                            string templateName = pathSplit[pathSplit.Count() - 1];
                            templateName = templateName.Substring(0, templateName.IndexOf("."));
                            if (templatesList.FirstOrDefault(t => t == templateName) != null)
                            {
                                PrintingTemplate currentTemplate = new PrintingTemplate()
                                {
                                    Id = templateName,
                                    Name = templateName,
                                    StringifiedTemplate = System.IO.File.ReadAllText(templateFile),
                                };

                                templates.Add(currentTemplate);
                            }
                        }
                        catch (Exception)
                        {
                            //Log: Ha fallado la obtencion de este template
                            //No hacemos  nada con este template
                        }
                    }

                    //Look into config files
                    foreach (String configFile in configFiles)
                    {
                        try
                        {
                            String[] pathSplit = configFile.Split('\\');
                            string templateName = pathSplit[pathSplit.Count() - 1];
                            templateName = templateName.Substring(0, templateName.IndexOf("."));
                            PrintingTemplate template = templates.Find(t => t.Name == templateName);
                            if (template != null)
                            {
                                try
                                {
                                    IDictionary<string, string> settings = new Dictionary<string, string>();
                                    string stringifiedTemplateSettings = System.IO.File.ReadAllText(configFile);
                                    settings = Format.FormatPrintingServiceStringifiedJson(stringifiedTemplateSettings);
                                    template.TemplateSettings = settings;
                                }
                                catch (Exception)
                                {
                                    template.TemplateSettings = new Dictionary<string, string>();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //Log: Ha fallado la obtencion de una configuracion
                        }
                    }

                    //Return List Uploading Files
                    return templates;
                }
                else
                {
                    throw new System.IO.DirectoryNotFoundException($"No se logró el acceso a la carpeta: {originPath}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void fnImprimirVoucher(PrintRequest printRequest)
        {
           var response = ApiHelper.Post<PrintRequest>("http://localhost:8085/api/Print/PrintDocument", printRequest, "Application/json", null, null);
        }

        /// <summary>
        /// Obtiene la imagen de la ruta y lo devuelve en base64
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetLogo(string filename)
        {
            try
            {

                try
                {
                    string originPath = Application.StartupPath + "\\Template";
                    byte[] imageArray = System.IO.File.ReadAllBytes(originPath + "\\" + filename);
                    string logoBase64 = Convert.ToBase64String(imageArray);
                    return logoBase64;
                }
                catch (Exception)
                {
                    return "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static OrderResponse fnSaveOrder(OrderRequest orderRequest)
        {
            OrderResponse orderResponse = new OrderResponse();
            try
            {
                var response = ApiHelper.Post<OrderRequest>("http://localhost:8085/api/Order/SaveOrder", orderRequest, "Application/json", null, null);
                //orderResponse = response;
                if (response != null && response.Item1.ToString() == "OK")
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(response.Item2);
                }
                else
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(response.Item2);
                    orderResponse.Status = 400;
                }
            }catch(Exception ex)
            {
                //objUtil.gsLogAplicativo("FunGeneral", "fnSaveOrder", ex.Message);
                orderResponse.Message = "Error Interno de lado de la Aplicacion";
                orderResponse.Status = 500;
            }
            return orderResponse;
        }

        public static OrderResponse fnGetOrderxCodigo(string Codigo)
        {
            OrderResponse orderResponse = new OrderResponse();
            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("Codigo", Codigo);
                var order = ApiHelper.Get("http://localhost:8085/api/Order/getOrderxCodigo", pairs, null);
                if (order != null && order.Item1.ToString() == "OK")
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(order.Item2);
                }
                else
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(order.Item2);
                    orderResponse.Status = 400;
                }
            }
            catch(Exception ex)
            {
                //objUtil.gsLogAplicativo("FunGeneral", "fnGetOrderxCodigo", ex.Message);
                orderResponse.Message = "Error Interno de lado de la Aplicacion";
                orderResponse.Status = 500;
            }
            return orderResponse;
        }


        public static GenericListResponse<Pedido> fnGeAllorEspecificOrder(string Codigo)
        {
            GenericListResponse<Pedido> genericListResponse = new GenericListResponse<Pedido>();
            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("Codigo", Codigo);
                var order = ApiHelper.Get("http://localhost:8085/api/Order/fnGeAllorEspecificOrder", pairs, null);
                if (order != null && order.Item1.ToString() == "OK")
                {
                    genericListResponse = JsonConvert.DeserializeObject<GenericListResponse<Pedido>>(order.Item2);
                }
                else
                {
                    genericListResponse = JsonConvert.DeserializeObject<GenericListResponse<Pedido>>(order.Item2);
                    genericListResponse.Status = 400;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnGeAllorEspecificOrder", ex.Message);
                genericListResponse.Message = "Error Interno de lado de la Aplicacion";
                genericListResponse.Status = 500;
            }
            return genericListResponse;
        }

        public static string fnGetEnumDescription(int intEstado)
        {
            string strEstado = "";
            switch (intEstado)
            {
                case (int)StateOrder.Pendiente:
                    strEstado = "Pendiente";
                    break;
                case (int)StateOrder.Procesado:
                    strEstado = "Procesado";
                    break;
                case (int)StateOrder.Cancelado:
                    strEstado = "Cancelado";
                    break;
                case (int)StateOrder.Entregado:
                    strEstado = "Entregado";
                    break;
                default:
                    break;
            }

            return strEstado;
        }

        public static Boolean fnRegistrarAccionDiaria(String descrip,Boolean estado,Int32 idOpera,String fechaOperacion)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                return  objTablaCod.blRegistrarAccionDiaria( descrip,  estado,  idOpera,  fechaOperacion);
               

                 
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCodValor", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }
        }

        public static Int32 fnBuscarAccionDiaria(Int32 idOpera, string fechaOperacion)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                return objTablaCod.blBuscarAccionDiaria(idOpera, fechaOperacion);



            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCodValor", ex.Message);
                return 0;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }
        }
        public static Int32 fnValidarDatosExistentes(String txtPlaca, String txtPlaca2, Int16 pnTipoCon,String Procedimiento)
        {
            BLValidarDatosExistentes objDatosDuplicados = new BLValidarDatosExistentes();
            clsUtil objUtil = new clsUtil();
            Int32 validarDatos = 0;
            try
            {
                validarDatos = objDatosDuplicados.blDevolverDatosExistentes(txtPlaca, txtPlaca2, pnTipoCon, Procedimiento);
                return validarDatos;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return validarDatos;
            }
            finally
            {
            }
        }

        public static string FormatearCadenaTitleCase(String str)
        {
            String dat = str.ToLower();
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dat); ;
        }
        public static void cbo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        public static Boolean fnLlenarUsuarioPorCargo(ComboBox cboCombo, String cCodCargo, Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverUsuarioPorCargo(cCodCargo, buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static String fnFormatearPrecio(String simbolo,Double Precio,Int32 lnTipoCon)
        {
            String srt = "";
            if (lnTipoCon==0)
            {
                srt = $"{simbolo} {String.Format("{0:#,##0.00}", Precio)}";

            }else if (lnTipoCon==1)
            {

                srt = $"{simbolo} {string.Format("{0:0.00}", Precio)}";
            }
            else if (lnTipoCon==2)
            {
                srt = $"{string.Format("{0:0.00}", Precio)}";

            }
            return srt;
        }
        public static String fnObtenerUsuarioActual()
        {
            BLVentaGeneral blVG = new BLVentaGeneral();
            clsUtil objUtil = new clsUtil();
            Boolean bResult;
            String cUsuario = "";
            try
            {
                cUsuario = blVG.blObtenerUsuarioActual(Variables.gnCodUser);

                return cUsuario;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return "";
            }
            finally
            {
                objUtil = null;
            }
        }

    }
}
