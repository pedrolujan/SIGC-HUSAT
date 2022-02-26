using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubFirebase
{
   public class ValidationHelper
    {
        /// <summary>
        /// Valida que el objeto pasado como parámetro no sea nulo, opcionalmente podemos pasar el nombre del parámetro
        /// </summary>
        /// <param name="obj">Objeto a comprobar</param>
        /// <param name="paramName">Nombre del parámetro</param>
        /// <exception cref="ValidationException"></exception>
        internal static void ValidateObjectNotNull(object obj, string paramName = null)
        {
            if (obj is null)
            {
                throw new ValidationException($"El objeto {paramName} no puede ser nulo.");
            }
        }
    }
}
