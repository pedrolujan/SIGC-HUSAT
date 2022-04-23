using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public Cliente() { }
        public Int32 idCliente { get; set; }
        public String cCliente { get; set; }
        public String cApePat { get; set; }
        public String cApeMat { get; set; }
        public String cTipoDoc { get; set; }
        public String cNombre { get; set; }
        public String cDocumento { get; set; }
        public String cDireccion { get; set; }
        public DateTime dFecNac { get; set; }
        public Int32 cTipPers { get; set; }
        public Int32 cTiDo { get; set; }
        public String cTelFijo { get; set; }
        public String cTelCelular { get; set; }
        public Boolean bEstado { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public Int32 idUsuario { get; set; }
        public Int32 idZona { get; set; }
        public Int32 idDep { get; set; }
        public Int32 idProv { get; set; }
        public Int32 idDist { get; set; }
        public String cCorreo { get; set; }
        public String cEmpresa { get; set; }
        public String cContactoNom1 { get; set; }
        public String cContactoCel1 { get; set; }
        public String cContactoNom2 { get; set; }
        public String cContactoCel2 { get; set; }
        public TipoDocumento clsTD { get; set; }
        public TipoCliente clsTC { get; set; }
        public String ubigeo { get; set; }
        public Int32 idVentaGen { get; set; }
        public String codigoVentaGen { get; set; }
        public String idReferencia { get; set; }
        public String cNomDep { get; set; }
        public String cNomProv { get; set; }
        public String cNomDist { get; set; }
        public Vehiculo vehiculo { get; set; }







        public Cliente(Int32 pnidCliente, String pcCliente, String pcDocumento, Int32 pcTiDo,String pcTelefono, Boolean pbEstado)
        {
            idCliente = pnidCliente;
            cCliente = pcCliente;
            cTiDo = pcTiDo;
            cDocumento = pcDocumento;
            cTiDo = pcTiDo;
            cTelCelular = pcTelefono;
            bEstado = pbEstado;
        }
        public Cliente(Int32 pnidCliente, String pcCliente)
        {
            idCliente = pnidCliente;
            cCliente = pcCliente;
        }

        public Cliente(String pcDocumento,Boolean pbEstado)
        {
            cDocumento = pcDocumento;
            bEstado = pbEstado;
        }
        public Cliente(Int32 pnidCliente, String pcCliente, Boolean pbEstado)
        {
            idCliente = pnidCliente;
            cCliente = pcCliente;
            bEstado = pbEstado;
        }

        public Cliente(Int32 pnidCliente, String pcApePat, String pcApeMat, String pcNombre, 
              String pcDireccion, DateTime pdFecNac,Int32 pcTipPers, Int32 pcTiDo, 
              String pcTelFijo, String pcTelCelular, Boolean pbEstado,Int32 pcidDep, 
              Int32 pcidProv, Int32 pcidDist,String pcNrDocumento,String pcContactoNom1, 
              String pcContactoNom2,String pcContactoCel1, String pcContactoCel2, 
              String pcEmpresa, String pcCorreo)
        {
            idCliente = pnidCliente;
            cApePat = pcApePat;
            cApeMat = pcApeMat;
            cNombre = pcNombre;
            cDireccion = pcDireccion;
            dFecNac = pdFecNac;
            cTipPers = pcTipPers;
            cTiDo = pcTiDo;
            cTelFijo = pcTelFijo;
            cTelCelular = pcTelCelular;
            bEstado = pbEstado;
            idDep = pcidDep;
            idProv = pcidProv;
            idDist = pcidDist;
            cDocumento = pcNrDocumento;
            cContactoNom1 = pcContactoNom1;
            cContactoNom2 = pcContactoNom2;
            cContactoCel1 = pcContactoCel1;
            cContactoCel2 = pcContactoCel2;
            cEmpresa = pcEmpresa;
            cCorreo = pcCorreo;
        }

      
    }

}


