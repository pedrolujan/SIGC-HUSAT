using selferviceSIGC.Core.Business;
using selferviceSIGC.Exceptions;
using selferviceSIGC.Helper;
using selferviceSIGC.Model.Api.Request;
using selferviceSIGC.Model.Api.Response;
using selferviceSIGC.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace repsol_peru_tpv_selfervice.Controller
{
    public class OrderController: ApiController
    {

        private IOrderService orderService;

        public OrderController(IOrderService porderService)
        {
            orderService = porderService;
        }

        [HttpPost]
        [Route("api/Order/SaveOrder")]
        public IHttpActionResult SaveOrder([FromBody]OrderRequest request)
        {
            OrderResponse orderResponse = null;
            bool blnResultado = false;

            try
            {
                //validamos la entrada
                Validation.ValidatSetOrderRequest(request);
                blnResultado = orderService.fnSaveOrder(request.order);

                orderResponse = new OrderResponse()
                {
                    Status = blnResultado ? 200 : 208,
                    Message = blnResultado ?  "OK" : "Ha Ocurrido un error al guardar",
                };
            }
            catch (ValidationException ex)
            {
                orderResponse = new OrderResponse()
                {
                    Status = 402,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                orderResponse = new OrderResponse()
                {
                    Status = 500,
                    Message = ex.Message,
                };
            }

            return Ok(orderResponse);

        }

        [HttpGet]
        [Route("api/Order/getOrderxCodigo")]
        public IHttpActionResult getOrderxCodigo(string Codigo)
        {
            OrderResponse orderResponse = null;
            string strResultado = string.Empty;
            try
            {
                //validamos la entrada
                strResultado = orderService.fnGetOrderxCodigo(Codigo);

                orderResponse = new OrderResponse()
                {
                    Status = strResultado == "SI" ? 200 : strResultado == "NO" ?201: 405,
                    Message = strResultado == "NO" ? "OK" : strResultado
                };
            }
            catch (ValidationException ex)
            {
                orderResponse = new OrderResponse()
                {
                    Status = 402,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                orderResponse = new OrderResponse()
                {
                    Status = 500,
                    Message = ex.Message,
                };
            }

            return Ok(orderResponse);

        }

        [HttpGet]
        [Route("api/Order/fnGeAllorEspecificOrder")]
        public IHttpActionResult fnGeAllorEspecificOrder(string Codigo)
        {
            GenericListResponse<Pedido> orderResponse = null;
            string strResultado = string.Empty;
            try
            {
                //validamos la entrada
                var lstPedido = orderService.fnGeAllorEspecificOrder(Codigo);

                orderResponse = new GenericListResponse<Pedido>
                {
                    data = lstPedido,
                    Status = 200,
                    Message = "OK"
                };
            }
            catch (Exception ex)
            {
                orderResponse = new GenericListResponse<Pedido>
                {
                    data = null,
                    Status = 500,
                    Message = ex.Message,
                };
            }

            return Ok(orderResponse);

        }
    }
}
