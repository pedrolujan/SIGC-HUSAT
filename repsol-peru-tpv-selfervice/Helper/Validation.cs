using PrintingController.Exceptions;
using selferviceSIGC.Model.Api.Request;
using System;

namespace selferviceSIGC.Helper
{
    public class Validation
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

        internal static void ValidateSetAvailableTemplatesRequest(SetAvailableTemplatesRequest request, string paramName = null)
        {
            try
            {
                ValidateObjectNotNull(request, paramName);
                ValidateObjectNotNull(request.Templates, nameof(request.Templates));
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex);
            }
        }

        internal static void ValidatePrintRequest(PrintRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("El objeto de la solicitud es nulo.");
            }

            if (string.IsNullOrWhiteSpace(request.StringifiedDocumentData))
            {
                throw new ValidationException("El documento a imprimir no es válido (vacío / nulo / whitespaces).");
            }

            if (request.NumberOfCopies < 1)
            {
                throw new ValidationException("El número de copias solicitado no es válido (<1).");
            }

            // TargetPrinterName puede ser vacío
            //request.TargetPrinterName

            if (string.IsNullOrWhiteSpace(request.TemplateName))
            {
                throw new ValidationException("El nombre de template introducido no es válido (vacío / nulo / whitespaces).");
            }

            if (request.CommandsList.Count > 0)
            {
                foreach (string command in request.CommandsList)
                {
                    string[] commandSplited = command.Split(',');
                    for (int i = 0; i < commandSplited.Length; i++)
                    {
                        if (!int.TryParse(commandSplited[i], out int result))
                        {
                            throw new ValidationException("Commando invalido, debe de ser int separados por comas y se obtuvo " + commandSplited[i] + " de " + command);
                        }
                    }
                }
            }

            if (request.PaperWidth <= 0)
            {
                throw new ValidationException("El ancho del papel es incorrecto");
            }

        }

        /// <exception cref="ValidationException"></exception>
        internal static void ValidateSetPrintingSettingsRequest(SetPrintingSettingsRequest request, string paramName = null)
        {
            try
            {
                ValidateObjectNotNull(request, paramName);
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex);
            }
        }

        /// <exception cref="ValidatSetOrderRequest"></exception>
        internal static void ValidatSetOrderRequest(OrderRequest request, string paramName = null)
        {
            try
            {
                ValidateObjectNotNull(request, paramName);

                if (string.IsNullOrWhiteSpace(request.order.Codigo))
                {
                    throw new ValidationException("Objeto no contiene un código de Pedido");
                }

            }
            catch (Exception ex)
            {
                throw new ValidationException(ex);
            }
        }
    }
}
