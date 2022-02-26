using System.Collections.Generic;
using System.Threading.Tasks;
using PrintingController.Implementacion;
using PrintingController.Interface;
using PrintingController.Models;

namespace selferviceSIGC.Core.Business
{
    public class PrintService: SinglentonSelfService, IPrintService
    {
        private static IPrintController ControllerPrint;
        public PrintService()
        {
            ControllerPrint = PrintController.Instance;
        }

        public Task Print(string identity, string stringifiedDocumentData, int numberOfCopies, string targetPrinterName, int paperWidth, string templateName, IList<string> commandsList)
        {
            return ControllerPrint.Print(identity, stringifiedDocumentData, numberOfCopies, targetPrinterName, paperWidth, templateName, commandsList);
        }

        public void SetSettings(IDictionary<string, string> settings)
        {
            ControllerPrint.SetSettings(settings);
        }

        public void SetTemplates(IList<Template> template)
        {
            ControllerPrint.SetTemplates(template);
        }
    }
}
