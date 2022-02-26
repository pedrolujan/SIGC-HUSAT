using System.Collections.Generic;

namespace PrintingController.Models
{
    public class Template
    {
        /// <summary>
        /// Identificador de template
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Contenido del template en formato de cadena de texto
        /// </summary>
        public string StringifiedTemplate { get; set; }

        /// <summary>
        /// Diccionario con la configuracion de las empresas
        /// </summary>
        public IDictionary<string, string> TemplateSettings { get; set; } = new Dictionary<string, string>();
    }
}