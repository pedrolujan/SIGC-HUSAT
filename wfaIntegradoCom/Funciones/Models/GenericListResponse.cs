using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaIntegradoCom.Funciones.Models
{
    public class GenericListResponse<T>:BaseResponse
    {
        public List<T> data { get; set; }
    }
}
