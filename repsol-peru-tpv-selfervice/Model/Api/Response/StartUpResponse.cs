using selferviceSIGC.Model.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Model.Api.Response
{
    public class StartUpResponse
    {
        [DisplayName("nsucursal")]
        public int Sucural { get; set; }

    }
}
