using selferviceSIGC.Core.Business;
using selferviceSIGC.Exceptions;
using selferviceSIGC.Model.Api.Response;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace selferviceSIGC.Controller
{
    public class StartUpController : ApiController
    {
        private IStartUpService _startUpService;

        public StartUpController(IStartUpService startUpService)
        {
            _startUpService = startUpService;
        }

        [HttpGet]
        [Route("api/startup")]
        public IHttpActionResult Get()
        {
            GenericResponse<StartUpResponse> genericResponse = new GenericResponse<StartUpResponse>();
            ErrorManager errorManager = new ErrorManager();

            try
            {
                _startUpService.ValidateBasicData();
                var startUp = _startUpService.InitTpvSelfService();
                genericResponse.Data = startUp;
                errorManager.Status = 200;
                errorManager.Message = "success";
            }
            catch(SelfServicesException loadException)
            {
                errorManager.Status = 400;
                errorManager.Message = "Error en la carga inicial de la aplicación";
                errorManager.Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorNumber = loadException.HResult,
                        Description = loadException.Message
                    }
                };

            }
            catch (Exception ex)
            {
                errorManager.Status = 500;
                errorManager.Message = "Error interno";
                errorManager.Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorNumber = ex.HResult,
                        Description = ex.Message
                    }
                };

            }
            finally
            {
                genericResponse.ErrorManager = errorManager;
            }

            return Ok(genericResponse);
        }
    }
}
