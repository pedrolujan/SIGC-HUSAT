using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Model.Api.Response
{
    public class ErrorManager
    {
        /// <summary>
        /// Status code from response
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Message from response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Errors list
        /// </summary>
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        /// <summary>
        /// Assign error code 
        /// </summary>
        public int ErrorNumber { get; set; }

        /// <summary>
        /// Error description
        /// </summary>
        public string Description { get; set; }
    }
}
