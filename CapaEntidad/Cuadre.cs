using Siticone.UI.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cuadre
    {

        public Cuadre(){}

        int _idTrandiaria = 0;

        public Int32 idTrandiaria { get { return _idTrandiaria; } set { _idTrandiaria = value; } }

        DateTime _FechaVenta ;
        public DateTime dFecha { get { return _FechaVenta; } set { _FechaVenta = value; } }

        String _Concepto = "";
        public String cNombreOperacion { get { return _Concepto; } set { _Concepto = value.Trim(); } }

        decimal _Ingreso = 0;
        public Decimal mIngreso { get { return _Ingreso; } set { _Ingreso = value; } }

        decimal _Salida = 0;
        public Decimal mSalida { get { return _Salida; } set { _Salida = value; } }

        decimal _Saldo = 0;
        public Decimal mSaldo { get { return _Saldo; } set { _Saldo = value; } }

        String _cUser = "";
        public String cUser { get { return _cUser; } set { _cUser = value.Trim(); } }

        Int32 _NroDoc = 0;
        public Int32 idDocumento { get { return _NroDoc; } set { _NroDoc = value; } }

         public Cuadre(int pidTrandiaria,DateTime pcFecha, string pcConcepto, decimal pnIngreso, Decimal pnSalida, Decimal pnSaldo, string pcUser, int pnNroDoc)
        {
            idTrandiaria = pidTrandiaria;
            dFecha = pcFecha;
            cNombreOperacion = pcConcepto;
            mIngreso=pnIngreso;
            mSalida=pnSalida;
            mSaldo=pnSaldo;
            cUser = pcUser;
            idDocumento=pnNroDoc;
        }


    }

    public class CuadreCaja
    {
        public CuadreCaja() { }

        public Decimal importeTotalIngresos { get; set; }
        public Decimal importeTotalEgresos{ get; set; }
        public Decimal importeSaldo{ get; set; }
        public Int32 idUsuario { get; set; }
        public Int32 idOperacion { get; set; }
        public Int32 idTrandiaria { get; set; }
        public Int32 idMoneda { get; set; }
        public DateTime fechaRegistro { get; set; }
        public String turno { get; set; }
        public String SimbloMon { get; set; }
        public String MonImporteSaldo { get; set; }
        public String Detalle { get; set; }
        
    }
    
}
