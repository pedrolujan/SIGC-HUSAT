using selferviceSIGC.Exceptions;
using selferviceSIGC.Model.Api.Response;
using selferviceSIGC.Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace selferviceSIGC.Core.Business
{
    internal class StartUpService : SinglentonSelfService, IStartUpService
    {
        //private IlionProductsBC _ilionProductsBC;

        //public StartUpService()
        //{
        //    _ilionProductsBC = new IlionProductsBC();
        //}

        /// <summary>
        /// Validate basic data from TPV
        /// </summary>
        public void ValidateBasicData()
        {
            if (_singletonSelfService.idUser > 0)
                throw new SelfServicesException("idUser", 1);

            if (_singletonSelfService.idSucursal > 0)
                throw new SelfServicesException("idSucursal", 1);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StartUpResponse InitTpvSelfService()
        {
            StartUpResponse startUpResponse = new StartUpResponse();

            startUpResponse.Sucural = _singletonSelfService.idSucursal;

            return startUpResponse;
        }


        #region Private Method

       

        /// <summary>
        /// Validate mode Fueling
        /// </summary>
        private StartUpResponse ValidateTypeModeFueling()
        {
            return null;
        }


        /*
        /// <summary>
        /// Gets the special parameters configuration list from DataReader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private IEnumerable<GetParametersResponse> GetSpecialParametersConfigurationListFromReader(SqlCeDataReader reader)
        {
            return reader.Cast<IDataRecord>().Select(record => new GetParametersResponse()
            {
                Id = int.Parse(record["ID"].ToString()),
                Section = record["SECTION"].ToString(),
                Key = record["KEY"].ToString(),
                Value = record["VALUE"] != DBNull.Value ? record["VALUE"].ToString() : null,
                DefaultValue = record["DEFAULT_VALUE"] != DBNull.Value ? record["DEFAULT_VALUE"].ToString() : null,
                IsMandatory = Convert.ToBoolean(record["MANDATORY"]),
                DataType = Convert.ToInt32(record["DATATYPE"]),
                EntityId = record["ENTITY_ID"].ToString(),
            });
        }*/
        #endregion
    }

    internal class GetParametersResponse
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }
        public bool IsMandatory { get; set; }
        public int DataType { get; set; }
        public string EntityId { get; set; }
    }
}
