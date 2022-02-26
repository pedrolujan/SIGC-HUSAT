namespace selferviceSIGC.Core.Common
{
    public class Constants
    {
        //Constante para tipos de identificacion
        /// <summary>
        /// TPV=1/DNI=2/QR=3/DG= Digitado/CBDNI=Codigo de barras DNI
        /// </summary>
        public const int CONTADO = 1, DNI = 2, QR = 3;//, DNIDG = 4, DNICB = 5;
        public const string CodigoClienteContado = "00000";
        public const string PrefixReferencia = "R";
        public const string InicioTramaPrecio = "\u0002";
        public const string FinTramaPrecio = "\u0003";
        public const string CodigoPrecioCorrecto = "PR";
    }
}
