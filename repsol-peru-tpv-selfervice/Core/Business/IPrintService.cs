using PrintingController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Core.Business
{
    public interface IPrintService
    {
        void SetTemplates(IList<Template> template);
        Task Print(string identity, string stringifiedDocumentData, int numberOfCopies, string targetPrinterName, int paperWidth, string templateName, IList<string> commandsList);
        void SetSettings(IDictionary<string, string> settings);
    }
}
