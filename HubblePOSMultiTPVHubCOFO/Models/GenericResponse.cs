using HubFirebase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubFirebase.Models
{
    public class GenericResponse<T> : BaseResponse
    {
        public T obj { get; set; }
        public int eventSource { get; set; }
        public int evenType { get; set; }
        public string key { get; set; }

    }
}
