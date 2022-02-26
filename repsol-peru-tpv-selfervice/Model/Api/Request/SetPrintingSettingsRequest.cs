using System.Collections.Generic;

namespace selferviceSIGC.Model.Api.Request
{
    public class SetPrintingSettingsRequest
    {
        /// <summary>
        /// Diccionario con la configuracion comun para todas las impresiones
        /// </summary>
        public IDictionary<string, string> PrintingSettings { get; set; } = new Dictionary<string, string>();
    }
}