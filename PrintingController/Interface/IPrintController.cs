using PrintingController.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintingController.Interface
{
    public interface IPrintController
    {

        /// <summary>
        /// Pasa una lista de templates a la intancia asociada del módulo de impresión
        /// </summary>
        /// <param name="templates"></param>
        /// <exception cref="BadTemplateException"></exception>
        /// <exception cref="GenericErrorException"></exception>
        void SetTemplates(IList<Template> templates);

        /// <summary>
        /// Añade un template a la intancia asociada del módulo de impresión
        /// </summary>
        /// <param name="templateName">Nombre del template a añadir</param>
        /// <param name="templateData">Información del template a añadir</param>
        /// <param name="templateSettings"></param>
        /// <exception cref="BadTemplateException"></exception>
        /// <exception cref="GenericErrorException"></exception>
        void AddOrUpdateTemplate(string templateName, string templateData, IDictionary<string, string> templateSettings);

        /// <summary>
        /// Elimina un template de la instancia asociada del módulo de impresión
        /// </summary>
        /// <param name="templateName">Nombre del template a eliminar</param>
        /// <exception cref="TemplateNotFoundException"></exception>
        /// <exception cref="GenericErrorException"></exception>
        void DeleteTemplate(string templateName);

        /// <summary>
        /// Devuelve la lista de nombres de template disponibles en la instancia actual del módulo de impresión
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GenericErrorException"></exception>
        IList<string> GetAvailableTemplateNames();

        /// <summary>
        /// Añade la configuracion a la instancia actual del modulo de impresión.
        /// Esta configuracion la tendran todos los documentos que se vayan a imprimir.
        /// En caso de que la plantilla del documento a imprimir tenga tambien su propia configuracion, los campos
        /// que coincidan, prevalecerá los de la plantilla.
        /// </summary>
        /// <param name="settings"></param>
        /// <exception cref="GenericErrorException"></exception>
        void SetSettings(IDictionary<string, string> settings);


        /// <summary>
        /// Agrega la configuracion de literales a la instancia actual del modulo de impresion
        /// Esta configuraicon la tendran todos los documentso que se vayan a imprimir
        /// </summary>
        /// <param name="literals"></param>
        /// <exception cref="GenericErrorException"></exception>
        void SetLiterals(IDictionary<string, string> literals);

        /// <summary>
        /// Obtiene la configuracion de la instancia del modulo de impresion
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GenericErrorException"></exception>
        IDictionary<string, string> GetSettings();

        /// <summary>
        /// Se simula la impresión de un documento de impresión
        /// </summary>
        /// <param name="identity">identificador del llamante</param>
        /// <param name="stringifiedDocumentData">documento para la simulación de impresión</param>
        /// <param name="numberOfCopies">número de copias solicitadas</param>
        /// <param name="targetPrinterName">nombre de impresora objetivo de la impresión</param>
        /// <param name="paperWidth"></param>
        /// <param name="templateName">Nombre del template a aplicar</param>
        /// <param name="commandsList"></param>
        /// <exception cref="TemplateNotFoundException"></exception>
        /// <exception cref="ParsingException"></exception>
        /// <exception cref="PrintingErrorException"></exception>
        /// <exception cref="GenericErrorException"></exception>
        Task SimulatePrint(string identity, string stringifiedDocumentData, int numberOfCopies, string targetPrinterName, int paperWidth, string templateName, IList<string> commandsList);

        /// <summary>
        /// Se solicita la impresión de un documento de impresión genérico
        /// </summary>
        /// <param name="identity">identificador del llamante</param>
        /// <param name="stringifiedDocumentData">documento a imprimir</param>
        /// <param name="numberOfCopies">número de copias solicitadas</param>
        /// <param name="targetPrinterName">nombre de impresora objetivo de la impresión</param>
        /// <param name="paperWidth"></param>
        /// <param name="templateName">Nombre del template a aplicar</param>
        /// <param name="commandsList"></param>
        /// <exception cref="TemplateNotFoundException"></exception>
        /// <exception cref="ParsingException"></exception>
        /// <exception cref="PrintingErrorException"></exception>
        /// <exception cref="GenericErrorException"></exception>
        Task Print(string identity, string stringifiedDocumentData, int numberOfCopies, string targetPrinterName, int paperWidth, string templateName, IList<string> commandsList);

    }
}
