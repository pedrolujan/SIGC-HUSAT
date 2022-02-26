using System.Collections.Generic;

namespace selferviceSIGC.Model.Api.Request
{
    public class SetAvailableTemplatesRequest
    {
        /// <summary>
        /// Lista de templates a añadir a la instancia del módulo de impresión
        /// </summary>
        public IList<PrintingTemplate> Templates { get; set; } = new List<PrintingTemplate>();
    }
}