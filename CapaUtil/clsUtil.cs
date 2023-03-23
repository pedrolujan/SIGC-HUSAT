using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using ZXing;
using ZXing.Common;
using System.Drawing;
using System.Windows.Forms;

namespace CapaUtil
{
#pragma warning disable IDE1006 // Estilos de nombres
    public class clsUtil
#pragma warning restore IDE1006 // Estilos de nombres
    {
      

        public String GetFechaHoraFormato(DateTime pdFecha, Int32 piFormato)
        {
            String sFecSis;
            String sDia, sMes, sAnio;
            String sHoraActual = (DateTime.Now.TimeOfDay.ToString());
            sFecSis = "";
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

                        sFecSis = sDia + "-" + sMes + "-" + sAnio;
                        break;
                }

                return sFecSis;

            }
            catch (Exception ex)
            {
                gsLogAplicativo("msUtil.svc", "GetFechaHoraFormato", ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerQr(String texto,String carpeta, String nombre)
        {

            String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\QR\";
            Bitmap bitmap = GenerarQR(texto);

            bitmap.Save(rutaArchivo + carpeta+"\\" + nombre + ".png");
            //byte[] imageBytes = File.ReadAllBytes("ruta/a/la/imagen.jpg");
        }
        public Bitmap GenerarQR(string texto)
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
        public void gsLogAplicativo(String psServicio, String psFuncion, String psMensaje)
        {
            String cTexto = String.Empty;
            String cRutaLog = String.Empty;
            String lsFecha = GetFechaHoraFormato(DateTime.Now, 6);
            String lsHora = DateTime.Now.ToLongTimeString();
            FileStream fs = null;
            StreamWriter oSW;
            try
            {
                cRutaLog = AppDomain.CurrentDomain.BaseDirectory.Trim() + "LogMovServFinan" + @"\";
                fs = new FileStream(cRutaLog.ToString().Trim() + lsFecha + ".LOG", FileMode.Append, FileAccess.Write, FileShare.Write);
                fs.Close();
                oSW = new StreamWriter(cRutaLog.ToString().Trim() + lsFecha + ".LOG", true);
                cTexto = lsFecha + " " + lsHora + "     [" + psServicio + "]     [" + psFuncion + "]" + "\n" + "==>> " + psMensaje;
                oSW.WriteLine(cTexto);
                oSW.Flush();
                oSW.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            return (T)XmlDeserializeFromString(xmlText, typeof(T));
            //if (String.IsNullOrWhiteSpace(xmlText)) return default(T);

            //using (StringReader stringReader = new System.IO.StringReader(xmlText))
            //{
            //    XmlDocument doc = new XmlDocument();
            //    doc.LoadXml(xmlText);
            //    var serializer = new XmlSerializer(typeof(T));

            //    return (T)serializer.Deserialize(stringReader);
            //}
        }

        private static object XmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }

    }
}
