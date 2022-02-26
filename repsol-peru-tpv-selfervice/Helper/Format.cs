using PrintingController.Models;
using selferviceSIGC.Model.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repsol_peru_tpv_selfervice.Helper
{
    public class Format
    {
        /// <exception cref="FormatException"></exception>
        internal static IList<Template> FormatControllerTemplateList(IList<PrintingTemplate> templatesList)
        {
            try
            {
                return templatesList.Select(c => new Template()
                {
                    Id = c.Id,
                    StringifiedTemplate = c.StringifiedTemplate,
                    TemplateSettings = c.TemplateSettings
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new selferviceSIGC.Exceptions.FormatException(ex);
            }
        }
    }
}
