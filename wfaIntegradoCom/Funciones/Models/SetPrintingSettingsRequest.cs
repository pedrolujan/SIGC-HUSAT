using System.Collections.Generic;

namespace wfaIntegradoCom.Funciones.Models
{
    public class SetPrintingSettingsRequest
    {
        /// <summary>
        /// Diccionario con la configuracion comun para todas las impresiones
        /// </summary>
        public IDictionary<string, string> PrintingSettings { get; set; } = new Dictionary<string, string>();
    }
}