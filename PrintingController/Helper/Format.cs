using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace PrintingController.Helper
{
    public class Format
    {
        /// <summary>
        /// Transforma un string de json en un diccionario (string, string)
        /// </summary>
        /// <param name="stringifiedJson"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        internal static IDictionary<string, string> FormatPrintingSettignsJson(string stringifiedJson)
        {
            try
            {
                IDictionary<string, object> dictionaryObject = new Dictionary<string, object>();
                var converter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
                dynamic dynamicObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(stringifiedJson, converter);
                dictionaryObject = (IDictionary<string, object>)dynamicObject;
                IDictionary<string, string> dictionary = dictionaryObject.ToDictionary(k => k.Key, k => k.Value == null ? "" : k.Value.ToString());
                return dictionary;
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message);
            }
        }
    }
}
