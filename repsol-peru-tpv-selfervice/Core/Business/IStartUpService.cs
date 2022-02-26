using selferviceSIGC.Model.Api.Response;

namespace selferviceSIGC.Core.Business
{
    public interface IStartUpService
    {
        /// <summary>
        /// Validate basic data from TPV
        /// </summary>
        void ValidateBasicData();


        /// <summary>
        /// Get Store Data
        /// </summary>
        /// <returns></returns>
        StartUpResponse InitTpvSelfService();

    }
}
