using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Model.Api.Response
{
    public class GenericListResponse<T>:BaseResponse
    {
        public List<T> data { get; set; }
    }
}
