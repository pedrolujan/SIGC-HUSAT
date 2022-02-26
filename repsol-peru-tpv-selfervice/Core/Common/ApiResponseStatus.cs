using System.ComponentModel;

namespace repsol_peru_tpv_selfervice.Core.Common
{
    public enum ApiResponseLatamStatuses
    {
        /// <summary>
        /// The successful
        /// <para> 200 : ApiResponseStatuses.Successful</para>
        /// </summary>
        [Description("Error en el proceso de inicio del Api de AutoServicio Local")]
        ErrorGeneric = 500,
        /// <summary>
        /// The successful
        /// <para> 200 : ApiResponseStatuses.Successful</para>
        /// </summary>
        [Description("successful")]
        Successful = 200,

        ///// <summary>
        ///// Article not found
        ///// <para> 150 : ApiResponseStatuses.ArticleNotFound</para>
        ///// </summary>
        //[Description("Es Socio LATAM pero aún no de la alianza Repsol Latam Pass.")]
        //ClienteLatamNotFound = 201,

        ///// <summary>
        ///// Article not loaded in the queue
        ///// <para> 151 : ApiResponseStatuses.ArticleNotLoaded</para>
        ///// </summary>
        //[Description("Bienvenido socio {{name}}, n° Socio {{code}}.")]
        //ClientWelcome = 202,

        ///// <summary>
        ///// Ticket con promociones
        ///// <para> 152 : ApiResponseStatuses.Ticket Promotion</para>
        ///// </summary>
        //[Description("Problemas de conexión, inténtelo más tarde.")]
        //ErrorConectivity = 400,

        ///// <summary>
        ///// The Validate Parameters
        ///// <para> 153 : ApiResponseStatuses.Ticket Not Promotion</para>
        ///// </summary>
        //[Description("Formato de número de documento no válido.")]
        //ErrorDocument = 401,

        ///// <summary>
        ///// The Validate Parameters
        ///// <para> 155 : ApiResponseStatuses.TicketNotLoaded</para>
        ///// </summary>
        //[Description("El documento no tiene una longitud correcta.")]
        //ErrorLengthDocument = 405,

        ///// <summary>
        ///// The Validate Parameters
        ///// <para> 156 : ApiResponseStatuses.TicketNotLoaded</para>
        ///// </summary>
        //[Description("Documento no existe")]
        //ErrorDocumentNotFound = 428,

        ///// <summary>
        ///// The unknown error
        ///// <para> 157 : ApiResponseStatuses.ApiSignature_NotMatch</para>
        ///// </summary>
        //[Description("El código de operador es obligatorio")]
        //ErrorOperator = 433,

        ///// <summary>
        ///// The ErrorGettingExtraData error
        ///// <para> 158 : ApiResponseStatuses.ErrorGettingExtraData</para>
        ///// </summary>
        //[Description("El tipo de documento no cumple el formato.")]
        //ErrorFormatDocument = 437,

        ///// <summary>
        ///// The ErrorSettingExtraData error
        ///// <para> 159 : ApiResponseStatuses.ErrorSettingExtraData</para>
        ///// </summary>
        //[Description("El tipo de documento no existe.")]
        //ErrorTypeDocument = 438,

        ///// <summary>
        ///// The unknown error
        ///// <para> 160 : ApiResponseStatuses.ApiSignature_NotMatch</para>
        ///// </summary>
        //[Description("El tipo de documento es obligatorio.")]
        //ErrorRequeridDocument = 439,

        ///// <summary>
        ///// Error in method setAllTankGaugeDataHistory
        ///// <para> 161 : ApiResponseStatuses.TankGAugeHistoryError</para>
        ///// </summary>
        //[Description("No se encuentra autorizado para realizar consultas al servicio.")]
        //ErrorAuthorization = 440,


    }
}
