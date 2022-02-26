using PrintingController.Exceptions;
using PrintingController.Helper;
using PrintingController.Interface;
using PrintingController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintingController.Implementacion
{
    public class PrintController : IPrintController
    {

        private const string IGNORE_PRINT = "IgnorePrintForTesting";
        private HubblePOS.PrintModule.IPrintModule _printModule;
        private static volatile IPrintController _instance = new PrintController();

        #region Constructors

        /// <exception cref="GenericErrorException"></exception>
        private PrintController()
        {
            try
            {
                //Inicializamos el módulo de impresión sin templates. -Se incluirán mediante llamadas a AddOrUpdateTemplate -
                _printModule = new HubblePOS.PrintModule.PrintModule();
            }
            catch (Exception ex)
            {
                throw new GenericErrorException($"Se produjo un error en la inicialización del módulo de impresión. Información adicional: {ex.Message}");
            }
        }

        #endregion Constructors

        #region Instance

        public static IPrintController Instance => _instance;

        #endregion Instance

        #region IPrintController Implementation
        public void AddOrUpdateTemplate(string templateName, string templateData, IDictionary<string, string> templateSettings)
        {
            try
            {
                //Generamos el objeto PrintModule.Template y validamos su calidad
                HubblePOS.PrintModule.Template template = new HubblePOS.PrintModule.Template()
                {
                    StringfiedTemplate = templateData,
                    TemplateSettings = templateSettings
                };
                template.Valid();

                //Si el item ya existe, se elimina para insertarlo con el nuevo contenido
                if (_printModule.GetTemplatesNames != null &&
                    _printModule.GetTemplatesNames.Contains(templateName))
                {
                    _printModule.DeleteTemplate(templateName);
                }

                _printModule.AddTemplate(templateName, template);
            }
            catch (HubblePOS.PrintModule.ValidationException ex)
            {
                throw new BadTemplateException(ex);
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex);
            }
        }

        public void DeleteTemplate(string templateName)
        {
            try
            {
                //Si el item ya existe, se elimina para insertarlo con el nuevo contenido
                if (!_printModule.GetTemplatesNames.Contains(templateName))
                {
                    throw new TemplateNotFoundException("El nombre de template introducido no se corresponde con ningún template disponible.");
                }
                else
                {
                    _printModule.DeleteTemplate(templateName);
                }
            }
            catch (TemplateNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex);
            }
        }

        public IList<string> GetAvailableTemplateNames()
        {
            try
            {
                return (_printModule.GetTemplatesNames as IEnumerable<string>).ToList();
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex);
            }
        }

        public IDictionary<string, string> GetSettings()
        {
            try
            {
                return _printModule.GetSettings;
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex.Message);
            }
        }

        public async Task Print(string identity, string stringifiedDocumentData, int numberOfCopies, string targetPrinterName, int paperWidth, string templateName, IList<string> commandsList)
        {
            try
            {

                if (targetPrinterName != IGNORE_PRINT)
                {
                    //validamos la existencia del template proporcionado
                    if (_printModule.GetTemplatesNames != null &&
                    !_printModule.GetTemplatesNames.Contains(templateName))
                    {
                        throw new TemplateNotFoundException($"Actualmente, el template solicitado ({templateName}) no está disponible en el módulo de impresión.");
                    }
                    else
                    {

                        //ejecutamos la impresión solicitada
                        _printModule.PrintDocument(stringifiedDocumentData, numberOfCopies, targetPrinterName, paperWidth, templateName, commandsList);
                    }
                }
            }
            catch (TemplateNotFoundException)
            {
                throw;
            }
            catch (HubblePOS.PrintModule.DataErrorException ex)
            {
                throw new ParsingException(ex);
            }
            catch (HubblePOS.PrintModule.UnknownTagException ex)
            {
                throw new ParsingException(ex);
            }
            catch (HubblePOS.PrintModule.PrinterException ex)
            {
                throw new PrintingErrorException(ex);
            }
            catch (HubblePOS.PrintModule.InterfaceNotExistsException ex)
            {
                throw new GenericErrorException(ex);
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex);
            }
        }

        public void SetLiterals(IDictionary<string, string> literals)
        {
            try
            {
                _printModule.SetLiterals(literals);
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex.Message);
            }
        }

        public void SetSettings(IDictionary<string, string> settings)
        {
            try
            {
                _printModule.SetSettings(settings);
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex.Message);
            }
        }

        public async Task SimulatePrint(string identity, string stringifiedDocumentData, int numberOfCopies, string targetPrinterName, int paperWidth, string templateName, IList<string> commandsList)
        {
            try
            {
                // Solicitamos la factoría de objetos del núcleo
            
                if (targetPrinterName != IGNORE_PRINT)
                {
                    //validamos la existencia del template proporcionado
                    if (!_printModule.GetTemplatesNames.Contains(templateName))
                    {
                        throw new TemplateNotFoundException($"Actualmente, el template solicitado ({templateName}) no está disponible en el módulo de impresión.");
                    }
                    else
                    {
                        //ejecutamos la simulación solicitada
                        _printModule.PrintDocumentSimulated(stringifiedDocumentData, numberOfCopies, targetPrinterName, paperWidth, templateName, commandsList);
                    }
                }
            }
            catch (TemplateNotFoundException)
            {
                throw;
            }
            catch (HubblePOS.PrintModule.DataErrorException ex)
            {
                throw new ParsingException(ex);
            }
            catch (HubblePOS.PrintModule.UnknownTagException ex)
            {
                throw new ParsingException(ex);
            }
            catch (HubblePOS.PrintModule.PrinterException ex)
            {
                throw new PrintingErrorException(ex);
            }
            catch (HubblePOS.PrintModule.InterfaceNotExistsException ex)
            {
                throw new GenericErrorException(ex);
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex);
            }
        }

        public void SetTemplates(IList<Models.Template> templates)
        {
            try
            {
                IDictionary<string, HubblePOS.PrintModule.Template> printModuleTemplates = new Dictionary<string, HubblePOS.PrintModule.Template>();
                foreach (Template t in templates)
                {
                    HubblePOS.PrintModule.Template template = new HubblePOS.PrintModule.Template()
                    {
                        StringfiedTemplate = t.StringifiedTemplate,
                        TemplateSettings = t.TemplateSettings
                    };
                    try
                    {
                        template.Valid();
                        printModuleTemplates[t.Id] = template;
                    }
                    catch (ValidationException ex)
                    {
                        //TEMPLATE NO VÁLIDO!!!
                        throw new BadTemplateException($"La plantilla '{t.Id}' no es válida por la siguiente razón: {ex.Message}");
                    }
                }
                _printModule.SetTemplates(printModuleTemplates);
            }
            catch (HubblePOS.PrintModule.ValidationException ex)
            {
                throw new BadTemplateException(ex);
            }
            catch (BadTemplateException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex);
            }
        }

        public IList<Template> GetPrintingTemplates(IList<string> templatesList)
        {
            try
            {


                string originPath = Environment.CurrentDirectory + "\\Template";
                //Validate Path
                if (System.IO.Directory.Exists(originPath))
                {
                    //Initialize Uploading Files list
                    List<Template> templates = new List<Template>();

                    //Get files path in directory
                    String[] templateFiles = System.IO.Directory.GetFiles(originPath, "*.xml");
                    String[] configFiles = System.IO.Directory.GetFiles(originPath, "*.config");

                    //Look into templates files
                    foreach (String templateFile in templateFiles)
                    {
                        try
                        {
                            String[] pathSplit = templateFile.Split('\\');
                            string templateName = pathSplit[pathSplit.Count() - 1];
                            templateName = templateName.Substring(0, templateName.IndexOf("."));
                            if (templatesList.FirstOrDefault(t => t == templateName) != null)
                            {
                                Template currentTemplate = new Template()
                                {
                                    Id =  templateName,
                                    Name = templateName,
                                    StringifiedTemplate = System.IO.File.ReadAllText(templateFile),
                                };

                                templates.Add(currentTemplate);
                            }
                        }
                        catch (Exception)
                        {
                            //Log: Ha fallado la obtencion de este template
                            //No hacemos  nada con este template
                        }
                    }

                    //Look into config files
                    foreach (String configFile in configFiles)
                    {
                        try
                        {
                            String[] pathSplit = configFile.Split('\\');
                            string templateName = pathSplit[pathSplit.Count() - 1];
                            templateName = templateName.Substring(0, templateName.IndexOf("."));
                            Template template = templates.Find(t => t.Name == templateName);
                            if (template != null)
                            {
                                try
                                {
                                    IDictionary<string, string> settings = new Dictionary<string, string>();
                                    string stringifiedTemplateSettings = System.IO.File.ReadAllText(configFile);
                                    settings = Format.FormatPrintingSettignsJson(stringifiedTemplateSettings);
                                    template.TemplateSettings = settings;
                                }
                                catch (Exception)
                                {
                                    template.TemplateSettings = new Dictionary<string, string>();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //Log: Ha fallado la obtencion de una configuracion
                        }
                    }

                    //Return List Uploading Files
                    return templates;
                }
                else
                {
                    throw new System.IO.DirectoryNotFoundException($"No se logró el acceso a la carpeta: {originPath}");
                }
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (GenericErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GenericErrorException(ex.Message);
            }
        }

        #endregion IPrintController Implementation
    }
}
