using CapaEntidad;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace wfaIntegradoCom.Funciones
{
    public class Variables
    {
        public static String gsVersion = string.Empty;
        public static Int32 gnCodUser = 0;
        public static String gsCodUser = string.Empty;
        public static String gsCodPers = string.Empty;
        public static String gsNomPers = string.Empty;
        public static Int16 idSucursal = 1;
        public static string gsSucursal = string.Empty;
        public static string gsSucursalDir = string.Empty;
        public static string gsSucursalUbigeo = string.Empty;
        public static DateTime gdFechaSis = DateTime.Now;
        public static string gsEmpresa = string.Empty;
        public static string gsEmpresaDir = string.Empty;
        public static string gsRuc = string.Empty;
        public static string gsCargoUsuario = string.Empty;
        public static string gsImpresora = "EPSON099E3E (L395 Series)";
        public static IList<string> template = new List<string>();
        public static bool bitActivePrintDirect = false;
        public static Sucursal sucursal = null;      



        /* declaramos y definimos la variables de color del sistema*/

        public static Color ColorEmpresa = Color.FromArgb(242, 68, 29);
        public static Color ColorDesactivado = Color.FromArgb(246, 246, 246);
        public static Color ColorGroupBox = Color.FromArgb(105, 105, 105);
        public static Color ColorGroupBoxDesactivado = Color.FromArgb(169, 169, 169);
        public static Color ColorDescativadoFuerte = Color.FromArgb(226, 226, 226);
        public static Color ColorError = Color.FromArgb(242, 68, 43);
        public static Color ColorSuccess = Color.FromArgb(39, 168, 68);
        public static Color ColorWarning = Color.FromArgb(250, 211, 23);
        public static Color Colororangeclaro = Color.FromArgb(235, 142, 54);

        #region thema principal
        //Colores SubMenus de Botones Menu Principal
        public static Color ColorBackColorSubMenus = Color.FromArgb(109, 109, 109);
        public static Color ColorForeColorSubMenus = Color.White;
        public static Color ColorSelectSubMenus = Color.FromArgb(117, 46, 30);
        //public static Color ColorSelectSubMenus = Color.DimGray;

        #endregion
    }
}
