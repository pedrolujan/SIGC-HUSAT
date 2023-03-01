﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using System.Drawing;
using ZXing.Common;
using ZXing;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using CapaNegocio;

namespace wfaIntegradoCom.Sunat
{

    public class EmitirFactura
    {
        static Cliente claseCliente = new Cliente();
        static Cargo claseDocumentoVenta = new Cargo();
        static ParametrosFactura parametrosFactura = new ParametrosFactura();
        public int EmitirFacturasContado(Cliente clsCliente,List<DetalleVenta> detalleventa,Cargo clsCargo)
        {
            claseCliente = clsCliente;
            claseDocumentoVenta = clsCargo;
            clsCliente.cCliente = clsCliente.cNombre + " " + clsCliente.cApePat + " " + clsCliente.cApePat;
            ParametrosFactura parametros = new ParametrosFactura();
            parametros.Monto_total = (detalleventa.Sum(i=>i.ImporteRow)- Convert.ToDecimal(detalleventa.Sum(i => i.TotalTipoDescuento)));
            parametros.TotSubtotal = (detalleventa.Sum(i => i.ImporteRow)-Convert.ToDecimal(detalleventa.Sum(i => i.TotalTipoDescuento))) / 1.18m;
            parametros.TotalIgv = (parametros.Monto_total- parametros.TotSubtotal);
            parametros.Porcentaje_IGV = 18;
            parametros.Serie = clsCargo.SerieDoc;//"FA01";
            parametros.Correlativo =FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsCargo.nValor2));// "00000132";
            parametros.fecha_venta = clsCargo.dFechaVenta;
            parametros.Fecha_de_pago = clsCargo.dFechaPago;
            parametros.CodigoComprobante = clsCargo.nValor1;
            
            var envios = new Envios();
            envios.Rutaxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\XML\";
            //envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\LLAMA-PE-CERTIFICADO-DEMO-20602404863.pfx";
            //envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\LLAMA-PE-CERTIFICADO-DEMO-20606879904.pfx";
            envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\certificado.pfx";
            //envios.Password_Certificado = "123456";
            envios.Password_Certificado = "Husatsunat1";
            envios.RutaEnvios = Path.GetDirectoryName(Application.ExecutablePath) + @"\ENVIOS\";
            envios.RutaCDR = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            parametrosFactura = parametros;
            try
            {

                envios.GenerarFacturaBoletaXML(parametros, clsCliente,detalleventa);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int EmitirNotaCredito(Cliente clsCliente, List<DetalleVenta> detalleventa, Cargo clsCargo)
        {
           
           

            claseCliente = clsCliente;
            claseDocumentoVenta = clsCargo;
            clsCliente.cCliente = clsCliente.cNombre + " " + clsCliente.cApePat + " " + clsCliente.cApePat;
            ParametrosFactura parametros = new ParametrosFactura();
            parametros.Ref_Serie = "FA01";
            parametros.Ref_Numero = "00000525";
            parametros.Ref_Motivo = "DUPLICIDAD EN LA EMISION";
            parametros.Ref_TipoComprobante = "01";
            parametros.CodigoTipoNotacredito = "01";



            parametros.Monto_total = detalleventa.Sum(i => i.ImporteRow);
            parametros.TotSubtotal = detalleventa.Sum(i => i.ImporteRow) / 1.18m;
            parametros.TotalIgv = (parametros.Monto_total - parametros.TotSubtotal);
            parametros.Porcentaje_IGV = 18;
            parametros.Serie = clsCargo.SerieDoc;//"FA01";
            parametros.Correlativo = FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsCargo.nValor2));// "00000132";
            parametros.fecha_venta = Variables.gdFechaSis;
            parametros.Fecha_de_pago = Variables.gdFechaSis;
            parametros.CodigoComprobante = clsCargo.nValor1;

            var envios = new Envios();
            envios.Rutaxml = Path.GetDirectoryName(Application.ExecutablePath) + @"\XML\";
            //envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\LLAMA-PE-CERTIFICADO-DEMO-20602404863.pfx";
            //envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\LLAMA-PE-CERTIFICADO-DEMO-20606879904.pfx";
            envios.Ruta_Certificado = Path.GetDirectoryName(Application.ExecutablePath) + @"\Certificado\certificado.pfx";
            //envios.Password_Certificado = "123456";
            envios.Password_Certificado = "Husatsunat1";
            envios.RutaEnvios = Path.GetDirectoryName(Application.ExecutablePath) + @"\ENVIOS\";
            envios.RutaCDR = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            parametrosFactura = parametros;
            try
            {

                envios.GenerarNotaCredito(parametros, clsCliente, detalleventa);
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
            String strSignatureValue = "";
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
                    XmlNodeList xnlDigestValue = xd.GetElementsByTagName("SignedInfo");

                    foreach (XmlElement item in xnlDigestValue)
                    {
                        XmlNodeList x1 = item.GetElementsByTagName("DigestValue");
                        foreach (XmlElement it in x1)
                        {
                            //strSignatureValue = it.Value;
                            strSignatureValue = it.InnerText;
                        }
                       
                    }
                    MessageBox.Show(r);

                }
                ObtenerQr(strSignatureValue);
            }
            catch (Exception ex)
            {
            }
            datos[0] = r;
            datos[1] = file;
            datos[2] = nomfile;
            return datos;
        }

        public void ObtenerQr(String firmaDigit)
        {
            String Ruc =Variables.claseEmpresa.Ruc;
            String TipoFactura = parametrosFactura.CodigoComprobante;
            String Serie = parametrosFactura.Serie;
            String Correlativo = parametrosFactura.Correlativo;
            String igv = parametrosFactura.TotalIgv.ToString();
            String importTotal = parametrosFactura.Monto_total.ToString();
            String fecha = parametrosFactura.fecha_venta.ToString("yyyy-MM-dd");// "2023-02-09";
            String codTipoDocResceptor = claseCliente.TiDocumentoSunat;// "6";
            String RucReceptor =claseCliente.cDocumento ;//"20600039491";
            String firmaDigital = firmaDigit;//"8YTJ4EeWCLkgfsNqD4eS+QRZoOM=";

            String nombreQR = RucReceptor + "-" + TipoFactura + "-" + Serie + "-" + Correlativo;

            String digestValue = Ruc + "|" + TipoFactura + "|" + Serie + "|" + Correlativo + "|" + igv + "|" + importTotal + "|" + fecha + "|" + codTipoDocResceptor + "|" + RucReceptor + "|" + firmaDigital + "|";

            String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            Bitmap bitmap = GenerarQR(digestValue);

            bitmap.Save(rutaArchivo + "QR\\" + nombreQR + ".png");
            //byte[] imageBytes = File.ReadAllBytes("ruta/a/la/imagen.jpg");
        }
        static Bitmap GenerarQR(string texto)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300
                }
            };
            return writer.Write(texto);
        }

    }
}
