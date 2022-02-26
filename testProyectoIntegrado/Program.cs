using PrintingController.Interface;
using PrintingController.Implementacion;
using System;
using PrintingController.Models;
using System.Collections.Generic;

namespace testProyectoIntegrado
{
    class Program
    {
        private static IPrintController ControllerPrint;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ControllerPrint = PrintController.Instance;
            IList<Template> template = new List<Template>();
            IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("useCase", "Venta");
            template.Add(new Template
            {
                Id = "Venta",
                StringifiedTemplate = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><document datasource=\"{Document}\" font-size=\"8\" align=\"left\" version=\"0.2\"><item align=\"center\"><img width=\"165px\" src=\"{/Settings.printingLogo}\" /></item><item align=\"center\" font-style=\"bold\" font-size=\"9\">{isatend}</item></document>",
                TemplateSettings = keyValuePairs,
            });
            ControllerPrint.SetTemplates(template);
            ControllerPrint.Print("", "{\"Document\":{\"isatend\":\"Atendido\"}}", 1, "Canon G4010 series (Copiar 1)", 40, "Venta", null);
        }
    }
}
