using PrintingController.Exceptions;
using PrintingController.Models;
using repsol_peru_tpv_selfervice.Helper;
using selferviceSIGC.Core.Business;
using selferviceSIGC.Helper;
using selferviceSIGC.Model.Api.Request;
using selferviceSIGC.Model.Api.Response;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace selferviceSIGC.Controller
{
    public class PrintController: ApiController
    {

        private IPrintService _printService;

        public PrintController(IPrintService printService)
        {
            _printService = printService;
        }

        [HttpPost]
        [Route("api/Print/PrintDocument")]
        public IHttpActionResult PrintDocument([FromBody]PrintRequest request)
        {
            PrintResponse genericResponse = null;

            try
            {
                //validamos la entrada
                Validation.ValidatePrintRequest(request);
                _printService.Print(request.Identity, request.StringifiedDocumentData, request.NumberOfCopies, request.TargetPrinterName, request.PaperWidth, request.TemplateName, request.CommandsList);

                genericResponse = new PrintResponse()
                    {
                        Status = 200,
                        Message = "Ok",
                    };
                }
            catch (Exceptions.SelfServicesException loadException)
            {
                genericResponse = new PrintResponse()
                {
                    Status = 400,
                    Message = loadException.Message,
                };

            }
            catch (ValidationException ex)
                {
                genericResponse = new PrintResponse()
                    {
                        Status = 400,
                        Message = ex.Message,
                    };
                }
                catch (ParsingException ex)
                {
                genericResponse = new PrintResponse()
                    {
                        Status = 400,
                        Message = ex.Message,
                    };
                }
                catch (PrintingErrorException ex)
                {
                genericResponse =  new PrintResponse()
                    {
                        Status = 400,
                        Message = ex.Message,
                    };
                }
                catch (GenericErrorException ex)
                {
                genericResponse =  new PrintResponse()
                    {
                        Status = 400,
                        Message = ex.Message,
                    };
                }
                catch (Exception ex)
                {
                genericResponse =  new PrintResponse()
                    {
                        Status = 500,
                        Message = ex.Message,
                    };
                }

                return Ok(genericResponse);

        }

        [HttpPost]
        [Route("api/Print/setTemplate")]
        public IHttpActionResult setTemplate([FromBody]SetAvailableTemplatesRequest request)
        {
            SetAvailableTemplatesResponse setAvailableTemplates=null;
            try
            {
                Validation.ValidateSetAvailableTemplatesRequest(request, nameof(request));
                IList<Template> templates = Format.FormatControllerTemplateList(request.Templates);
                _printService.SetTemplates(templates);

                //generamos la respuesta
                setAvailableTemplates= new SetAvailableTemplatesResponse()
                {
                    Status = 200,
                    Message = "Ok",
                };
            }
            catch (Exceptions.SelfServicesException loadException)
            {
                setAvailableTemplates = new SetAvailableTemplatesResponse()
                {
                    Status = 400,
                    Message = loadException.Message,
                };

            }
            catch (ValidationException ex)
            {
                setAvailableTemplates = new SetAvailableTemplatesResponse()
                {
                    Status = 400,
                    Message = ex.Message,
                };
            }
            catch (Exceptions.ValidationException ex)
            {
                setAvailableTemplates = new SetAvailableTemplatesResponse()
                {
                    Status = 400,
                    Message = ex.Message,
                };
            }
            catch (BadTemplateException ex)
            {
                setAvailableTemplates= new SetAvailableTemplatesResponse()
                {
                    Status = 400,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                //generamos la respuesta
                setAvailableTemplates= new SetAvailableTemplatesResponse()
                {
                    Status = 500,
                    Message = ex.Message,
                };
            }

            return Ok(setAvailableTemplates);

        }

        [HttpPost]
        [Route("api/Print/SetPrintingSettings")]
        public SetPrintingSettingsResponse SetPrintingSettings(SetPrintingSettingsRequest request)
        {
            try
            {
                Validation.ValidateSetPrintingSettingsRequest(request, nameof(request));
                _printService.SetSettings(request.PrintingSettings);

                return new SetPrintingSettingsResponse()
                {
                    Status = 200,
                    Message = "Ok",
                };
            }
            catch (ValidationException ex)
            {
                return new SetPrintingSettingsResponse()
                {
                    Status = 400,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                return new SetPrintingSettingsResponse()
                {
                    Status = 500,
                    Message = ex.Message,
                };
            }
        }

    }
}
