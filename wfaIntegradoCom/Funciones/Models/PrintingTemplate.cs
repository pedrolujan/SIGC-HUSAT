using System.Collections.Generic;

namespace wfaIntegradoCom.Funciones.Models
{
    public class PrintingTemplate
    {
        /// <summary>
        /// Identificador 
        /// (company + nombre del template)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre del template. Cada caso de uso utilizará una plantilla que se indica meediante este campo.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Plantilla en formato texto
        /// </summary>
        public string StringifiedTemplate { get; set; }

        /// <summary>
        /// Diccionario con la configuración de la plantilla
        /// </summary>
        public IDictionary<string, string> TemplateSettings { get; set; } = new Dictionary<string, string>();
    }
}
