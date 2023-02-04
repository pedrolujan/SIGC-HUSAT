using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace wfaIntegradoCom.Sunat
{

    public class EmitirFactura
    {
        public int EmitirFacturasContado(Cliente clsCliente,List<DetalleVenta> detalleventa)
        {
            ParametrosFactura parametros = new ParametrosFactura();
            parametros.Monto_total = detalleventa.Sum(i=>i.ImporteRow);
            parametros.TotSubtotal = detalleventa.Sum(i => i.ImporteRow) / 1.18m;
            parametros.TotalIgv = (parametros.Monto_total- parametros.TotSubtotal);
            parametros.Porcentaje_IGV = 18;
            //Agregamos el detalle de la venta
            //List<LdetalleVenta> detalles = new List<LdetalleVenta>();
            //foreach (var item in detalleventa)
            //{
            //    var datadv = new LdetalleVenta();
            //    datadv.Unidad_de_medida = item.Unidad_de_medida;
            //    datadv.cantidad = item.cantidad;
            //    datadv.Total_a_pagar = item.Total_a_pagar;
            //    datadv.preciounitario = item.preciounitario;
            //    datadv.mtoValorVentaItem = datadv.Total_a_pagar;
            //    datadv.porIgvItem = parametrosPasar.TotalIgv;
            //    datadv.Descripcion = item.Descripcion;
            //    datadv.Codigo = item.Codigo;
            //    detalles.Add(datadv);
            //}
            //parametros.Detalles = detalles;



            var envios = new Envios();
            envios.Rutaxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\XML\";
            envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\LLAMA-PE-CERTIFICADO-DEMO-20606879904.pfx";
            envios.Password_Certificado = "123456";
            envios.RutaEnvios = Path.GetDirectoryName(Application.ExecutablePath) + @"\ENVIOS\";
            envios.RutaCDR = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            try
            {

                envios.GenerarFacturaXML(parametros, clsCliente,detalleventa);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public string[] ObtenerRespuestaZIPSunat(string ruta)
        {
            FileInfo arch = new FileInfo(ruta);
            if (arch.Extension == ".zip")
            {
                return LeerRespuestaCDR(ruta, Path.GetDirectoryName(ruta));
            }
            else
            {
                return null;
            }
        }


        public string[] LeerRespuestaCDR(string ruta, string nomfile)
        {
            string r = "";
            string file = "";
            string[] datos = new string[3];
            try
            {
                using (ZipArchive zip = ZipFile.Open(ruta, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry zentry = null;
                    file = zip.Entries[1].ToString();
                    zentry = zip.GetEntry(file);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(zentry.Open());
                    XmlNodeList xnl = xd.GetElementsByTagName("cbc:Description");
                    foreach (XmlElement item in xnl)
                    {
                        r = item.InnerText;
                    }
                    MessageBox.Show(r);

                }
            }
            catch (Exception)
            {
            }
            datos[0] = r;
            datos[1] = file;
            datos[2] = nomfile;
            return datos;
        }


    }
}
