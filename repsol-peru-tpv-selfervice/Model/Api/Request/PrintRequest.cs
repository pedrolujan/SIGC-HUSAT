using System.Collections.Generic;

namespace selferviceSIGC.Model.Api.Request
{
    public class PrintRequest
    {
        /// <summary>
        /// Identificador del pos desde el que se solicita la acción
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Identificador del operador que solicita la acción
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// Información del documento de impresión a imprimir en formato Json
        /// </summary>
        public string StringifiedDocumentData { get; set; }

        /// <summary>
        /// Número de copias del documento a imprimir
        /// </summary>
        public int NumberOfCopies { get; set; }

        /// <summary>
        /// Nombre de la impresora de destino prara la impresión
        /// </summary>
        public string TargetPrinterName { get; set; }

        /// <summary>
        /// Ancho del papel de la impresora
        /// </summary>
        public int PaperWidth { get; set; }

        /// <summary>
        /// Nombre del template que deberá utilizarse
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Lista de comandos que va a ejecutar la impresora
        /// </summary>
        public IList<string> CommandsList { get; set; } = new List<string>();
    }
}