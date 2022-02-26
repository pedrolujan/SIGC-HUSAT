using System.Collections.Generic;

namespace selferviceSIGC.Model.Api.Response
{
    public class SetAvailableTemplatesResponse : BaseResponse
    {
        public IEnumerable<string> AvailableTemplateNames { get; set; } = new List<string>();
    }
}