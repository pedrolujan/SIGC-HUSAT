using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoCliente
    {
        public TipoCliente(){}

        // Abreviatura TC referente a TipoCliente
        public Int32 TCid { get; set; }
        public String TCnombre { get; set; }
        public Int32 TCidUsuario { get; set; }
        public DateTime TCfechaRegistro { get; set; }
        public Boolean TCestado { get; set; }

        public TipoCliente(Int32 peTCid,String peTCnombre,Boolean peTCestado)
        {
            TCid = peTCid;
            TCnombre = peTCnombre;
            TCestado = peTCestado;
        }

    }

    public class TipoDocumento : TipoCliente
    {
        public TipoDocumento() { } 

        //Abreviatura TD referente a TipoDocumento
        public Int32 TDid { get; set; }
        public String TDnombre { get; set; }
        public Int32 TDidUsuario { get; set; }
        public DateTime TDfechaRegistro { get; set; }
        public Boolean TDestado { get; set; }
        public Int32 TDmaxCaracteres { get; set; }
        public Boolean TDcarcObligatorio { get; set; }
        public String TDcaracter { get; set; }

        public TipoDocumento(Int32 peTDid, String peTDnombre, Int32 peTDmaxCaract, Boolean peTDestado,Boolean peTDcarObligatorio,String peTDcaracter)
        {
            TDid = peTDid;
            TDnombre = peTDnombre;
            TDmaxCaracteres = peTDmaxCaract;
            TDestado = peTDestado;
            TDcarcObligatorio = peTDcarObligatorio;
            TDcaracter = peTDcaracter;
        }
        public static TipoDocumento fnObtenerTipoDocumentoSeleccionado(Int32 idTD, List<TipoDocumento> lstTD)
        {
            foreach (TipoDocumento doc in lstTD)
            {
                if (doc.TDid == idTD)
                {
                    return doc;
                }
            }
            return new TipoDocumento();
        }
    }
}
