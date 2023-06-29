using CapaConexion;
using CapaEntidad;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class DAControlPagos
    {
        clsUtil objUtil = null;
        public DataTable daBuscarCronograma(Boolean habilitarfechas,Boolean chkIncump, String dtFechaIni, String dFechaFin, String pcBuscar,Int32 tipoCon, Int32 TipConPaginacion, Int32 numPagina,String estadoPago,Int32 idCiclo)
        {
            SqlParameter[] pa = new SqlParameter[10];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = habilitarfechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = dtFechaIni };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = dFechaFin };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = pcBuscar };
                pa[4] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = idCiclo };
                pa[5] = new SqlParameter("@estadoDetCronograma", SqlDbType.VarChar, 8) { Value = estadoPago };
                pa[6] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[7] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[8] = new SqlParameter("@TipoConPagina", SqlDbType.Int) { Value = TipConPaginacion };
                pa[9] = new SqlParameter("@chkIncumplimiento", SqlDbType.Int) { Value = chkIncump };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronograma", pa);


                return dtResult;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public List<Reporte> daBuscarReporte(Busquedas cls)
        {
            SqlParameter[] pa = new SqlParameter[9];
            DataSet dtMenu = new DataSet();
            DataView dvCantidad = new DataView();
            DataView dvImporte = new DataView();
            DataView dvCorteCantidad = new DataView();
            DataView dvCorteImporte = new DataView();
            clsConexion objCnx = null;
            List<Reporte> lst = new List<Reporte>();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = cls.chkActivarFechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = cls.dtFechaIni };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = cls.dtFechaFin };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = cls.cBuscar };
                pa[4] = new SqlParameter("@tipoReporte", SqlDbType.VarChar, 15) { Value = cls.cod1 };
                pa[5] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = cls.cod3 };
                pa[6] = new SqlParameter("@estadoDetCronograma", SqlDbType.VarChar, 8) { Value = cls.cod2 };
                pa[7] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = cls.tipoCon };
                pa[8] = new SqlParameter("@chkIncumplimiento", SqlDbType.Int) { Value = cls.cod4 };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarReporteRecaudacion", pa);
                dvCantidad = new DataView(dtMenu.Tables[0]);
                dvImporte = new DataView(dtMenu.Tables[1]);
                dvCorteCantidad = new DataView(dtMenu.Tables[2]);
                dvCorteImporte = new DataView(dtMenu.Tables[3]);
                Int32 y = 0;
                Int32 sumColumn = 0;
                foreach (DataRowView dt in dvCantidad)
                {
                    
                    lst.Add(new Reporte
                    {
                        numero = y + 1,
                        coddAux1 = cls.cod1== "TRRC0001"?dt["cDia"].ToString(): CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt["cDia"].ToString())),
                        nombreAux1=cls.cod1== "TRRC0001"?"Ciclo":"Mes",
                        coddAux2 = dt["PAGO_PENDIENTE"].ToString(),
                        ImporteAux2 = 0,
                        coddAux3 = dt["VENCIDO"].ToString(),
                        ImporteAux3=0,
                        coddAux4 = dt["CORTE"].ToString(),
                        ImporteAux4=0,
                        coddAux5 = dt["CUOTA_PAGADA"].ToString(),
                        ImporteAux5=0,
                        coddAux6="0",
                        ImporteAux6=0,
                        indicadorDes = 0,
                        nombreIndicador="",
                        ImporteTotalFilas = 0,
                        TotalFilas = 0,
                        indiceCrecimientoImporte=0,
                        indiceCrecimientoRow=0 


                    }) ;

                  
                        y++;
                }

                ///////
                Int32 j = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    foreach (DataRowView dt in dvCorteCantidad)
                    {
                        String mesAct = cls.cod1 == "TRRC0001" ? dt["cDia"].ToString() : CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt["cDia"].ToString()));
                        if (lst[i].coddAux1 == mesAct)
                        {
                            lst[i].coddAux6 = Convert.ToString(dt["CORTE"]).ToString();
                        }

                        j++;
                    }
                    ///////
                    Int32 jj = 0;
                    foreach (DataRowView dt in dvCorteImporte)
                    {
                        String mesAct = cls.cod1 == "TRRC0001" ? dt["cDia"].ToString() : CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt["cDia"].ToString()));
                        if (lst[i].coddAux1 == mesAct)
                        {
                            lst[i].ImporteAux6 = Convert.ToDouble(dt["CORTE"]);

                        }

                        jj++;
                    }
                }
                

                Int32 yy = 0;
                double imporTotal=0;
                foreach (DataRowView dt in dvImporte)
                {

                    sumColumn = Convert.ToInt32(lst[yy].coddAux2) + Convert.ToInt32(lst[yy].coddAux3) + Convert.ToInt32(lst[yy].coddAux5) + Convert.ToInt32(lst[yy].coddAux6);

                    lst[yy].ImporteAux2 = Convert.ToDouble(dt["PAGO_PENDIENTE"]);
                    lst[yy].ImporteAux3 = Convert.ToDouble(dt["VENCIDO"]);
                    lst[yy].ImporteAux4 = Convert.ToDouble(dt["CORTE"]);
                    lst[yy].ImporteAux5 = Convert.ToDouble(dt["CUOTA_PAGADA"]);

                    imporTotal = lst[yy].ImporteAux2 + lst[yy].ImporteAux3 + lst[yy].ImporteAux5 + lst[yy].ImporteAux6;

                    lst[yy].ImporteTotalFilas = imporTotal;
                    lst[yy].TotalFilas = sumColumn;

                    if (yy==0)
                    {
                        lst[yy].indiceCrecimientoImporte = cls.cod1 == "TRRC0001"?0:((lst[yy].ImporteAux5 / lst[yy].ImporteAux5) - 0) * 100;
                        lst[yy].indiceCrecimientoRow = cls.cod1 == "TRRC0001"?0:((Convert.ToDouble(lst[yy].coddAux5) / Convert.ToDouble(lst[yy].coddAux5)) - 0) * 100;
                        
                    }
                    else
                    {
                        lst[yy].indiceCrecimientoImporte = cls.cod1 == "TRRC0001"?0:((lst[yy].ImporteAux5 / lst[yy-1].ImporteAux5) - 1) * 100;
                        lst[yy].indiceCrecimientoRow = cls.cod1 == "TRRC0001"?0:((Convert.ToDouble(lst[yy].coddAux5) / Convert.ToDouble(lst[yy-1].coddAux5)) - 1) * 100;

                    }
                    lst[yy].indiceCrecimientoRowGraficos = (lst[yy].ImporteAux5 * 100) / lst[yy].ImporteTotalFilas;
                    lst[0].SumImporteAux2 += lst[yy].ImporteAux2;
                    lst[0].SumImporteAux3 += lst[yy].ImporteAux3;
                    lst[0].SumImporteAux4 += lst[yy].ImporteAux4;
                    lst[0].SumImporteAux5 += lst[yy].ImporteAux5;
                    lst[0].SumImporteAux6 += lst[yy].ImporteAux6;
                   

                    lst[yy].indiceCrecimientoRowGraficos =(Double) decimal.Round(Convert.ToDecimal(lst[yy].indiceCrecimientoRowGraficos), 2);

                    yy++;
                    lst[0].SumRowsImporteTotalFilas += imporTotal;
                    lst[0].SumRowsTotalFilas += sumColumn;
                }
                //lst[0].SumRowsAux6 = SumRowPago;

                //for (int i = 0; i < lst.Count; i++)
                //{
                //    double indica = (double)Convert.ToInt32(lst[i].coddAux6) * 100;
                //    indica = Double.IsInfinity(indica) ? 0 : indica;

                //    lst[i].indicadorDes = decimal.Round(SumRowPago !=0?Convert.ToDecimal(indica) / lst[0].SumRowsAux6:0,2);
                //    lst[i].nombreIndicador = decimal.Round(lst[i].indicadorDes,2) + "%";
                //}
                return lst;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public Tuple< List<Reporte>, List<Reporte>> daBuscarReporteComisiones(Busquedas cls)
        {
            SqlParameter[] pa = new SqlParameter[7];
            DataSet ds = new DataSet();
            DataTable dtRep1 = new DataTable();
            DataTable dtRep2 = new DataTable();
            
            clsConexion objCnx = null;
            List<Reporte> lst = new List<Reporte>();
            List<Reporte> lst2 = new List<Reporte>();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = cls.chkActivarFechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = cls.dtFechaIni };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = cls.dtFechaFin };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = cls.cBuscar };
                pa[4] = new SqlParameter("@tipoContrato", SqlDbType.Int) { Value = cls.cod1 };
                pa[5] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = cls.cod2 };
                pa[6] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = cls.idUsuario };
                objCnx = new clsConexion("");

                ds = objCnx.EjecutarProcedimientoDS("uspBuscarReporteComisiones", pa);

                dtRep1 = ds.Tables[0];
                dtRep2 = ds.Tables[1];
                Int32 y = 0;
                Int32 sumColumn = 0;
                foreach (DataRow dt in dtRep1.Rows)
                {
                    
                    lst.Add(new Reporte
                    {
                        numero = y + 1,
                        nombreAux1= dt["cUser"].ToString(),
                        nombreAux2 = dt["cTipoPlan"].ToString(),
                        nombreAux3 = dt["cPlan"].ToString(),
                        ImporteAux3 = Convert.ToDouble(dt["ImporteTotal"]),
                        ImporteAux4 = Convert.ToDouble(dt["ImportePagado"]),
                        ImporteAux5 = Convert.ToDouble(dt["importeDescontado"]),
                        ImporteAux6 = Convert.ToDouble(dt["ImporteTotalSinIgv"]),
                        ImporteAux7 = Convert.ToDouble(dt["ImportePagadoSinIgv"]),
                        ImporteAux8 = Convert.ToDouble(dt["importeComision"]),
                        ImporteAux9 = Convert.ToDouble(dt["importeIgv"]),


                    }) ;

                  
                        y++;
                }
                y = 0;
                Double numTotal = 0;
                foreach (DataRow dt in dtRep2.Rows)
                {
                    numTotal += (Convert.ToInt32(dt["Anual"].ToString()) + Convert.ToInt32(dt["Mensual"].ToString()));
                    
                }
                Double contador= 0;
                foreach (DataRow dt in dtRep2.Rows)
                {
                    contador = (Convert.ToInt32(dt["Anual"].ToString()) + Convert.ToInt32(dt["Mensual"].ToString()));
                    Double porcentaje = (contador / numTotal) * 100;
                    lst2.Add(new Reporte
                    {
                        
                        numero = y + 1,
                        nombreAux1 = dt["Usuario"].ToString(),
                        nombreAux2 = dt["Anual"].ToString(),
                        nombreAux3 = dt["Mensual"].ToString(),
                        ImporteAux3 = Convert.ToDouble(dt["ImporteTotal"]),
                        indiceCrecimientoRowGraficos = porcentaje


                    }) ;

                    y++;
                }


                //for (int i = 0; i < lst.Count; i++)
                //{
                //    double indica = (double)Convert.ToInt32(lst[i].coddAux6) * 100;
                //    indica = Double.IsInfinity(indica) ? 0 : indica;

                //    lst[i].indicadorDes = decimal.Round(SumRowPago !=0?Convert.ToDecimal(indica) / lst[0].SumRowsAux6:0,2);
                //    lst[i].nombreIndicador = decimal.Round(lst[i].indicadorDes,2) + "%";
                //}
                return Tuple.Create(lst,lst2);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public List<Reporte> daBuscarReporteRenovaciones(Busquedas cls)        
        {
            SqlParameter[] pa = new SqlParameter[9];
            DataSet dtMenu = new DataSet();
            DataView dvCantidad = new DataView();
            DataView dvImporte = new DataView();
            DataView dvCantidadRenovado = new DataView();
            DataView dvImporteRenovado = new DataView();

            clsConexion objCnx = null;
            List<Reporte> lst = new List<Reporte>();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = cls.chkActivarFechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = cls.dtFechaIni };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = cls.dtFechaFin };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = cls.cBuscar };
                pa[4] = new SqlParameter("@tipoReporte", SqlDbType.VarChar, 15) { Value = cls.cod1 };
                pa[5] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = cls.cod2 };
                pa[6] = new SqlParameter("@estadoDetCronograma", SqlDbType.VarChar, 8) { Value = cls.cod3 };
                pa[7] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = cls.tipoCon };
                pa[8] = new SqlParameter("@chkIncumplimiento", SqlDbType.Int) { Value = cls.cod3 };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarReporteRenovacion", pa);
                dvCantidad = new DataView(dtMenu.Tables[0]);
                dvImporte = new DataView(dtMenu.Tables[1]);
                dvCantidadRenovado = new DataView(dtMenu.Tables[2]);
                dvImporteRenovado = new DataView(dtMenu.Tables[3]);
                Int32 y = 0;
                Int32 SumRowPago = 0;
                Int32 totalRows = 0;
                foreach (DataRowView dt in dvCantidad)
                {
                    SumRowPago += Convert.ToInt32(dt["FINALIZADO"]);
                    
                    lst.Add(new Reporte
                    {

                        numero = y + 1,
                        coddAux1 = cls.cod1 == "TRRN0001" ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt["mes"].ToString())) : dt["mes"].ToString(),
                        nombreAux1 = cls.cod1 == "TRRN0001" ? "Mes" : "Tipo de Plan",
                        coddAux2 = dt["VIGENTE"].ToString(),
                        coddAux3 = dt["RENOVADO"].ToString(),
                        coddAux4 = dt["FINALIZADO"].ToString(),
                        strIndicador = dt["mes"].ToString(),
                        TotalFilas = totalRows,
                        indicadorDes = 0
                    }) ;
                    
                    y++;
                }

                ///////
                ///
                

                Int32 j = 0;
               
                for (int ii = 0; ii < lst.Count; ii++)
                {
                    
                    foreach (DataRowView dt in dvCantidadRenovado)
                    {
                        String mesAct = cls.cod1 == "TRRN0001" ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt["mes"].ToString())) : dt["mes"].ToString();
                        if (lst[ii].coddAux1 == mesAct)
                        {
                            lst[ii].coddAux3 = Convert.ToString(dt["RENOVADO"]).ToString();
                        }

                        j++;
                    }
                    ///////
                    Int32 jj = 0;
                    foreach (DataRowView dt in dvImporteRenovado)
                    {
                        String mesAct = cls.cod1 == "TRRN0001" ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dt["mes"].ToString())) : dt["mes"].ToString();
                        if (lst[ii].coddAux1 == mesAct)
                        {
                            lst[ii].ImporteAux3 = Convert.ToDouble(dt["RENOVADO"]);

                        }

                        jj++;
                    }

                    
                 

                }
                int i = 0;
                Double imporTotal = 0;
                foreach (DataRowView dt in dvImporte)
                {
                    imporTotal = Convert.ToDouble(dt["VIGENTE"]) + lst[i].ImporteAux3 + Convert.ToDouble(dt["FINALIZADO"]);

                    lst[i].ImporteAux2 = Convert.ToDouble(dt["VIGENTE"]);
                    lst[i].ImporteAux4 = Convert.ToDouble(dt["FINALIZADO"]);

                    lst[i].ImporteTotalFilas = imporTotal;

                    if (i == 0)
                    {
                        lst[i].indiceCrecimientoImporte = cls.cod1 == "TRRN0002" ? 0 : ((lst[i].ImporteAux2 / lst[i].ImporteAux2) - 0) * 100;
                        lst[i].indiceCrecimientoRow = cls.cod1 == "TRRN0002" ? 0 : ((Convert.ToDouble(lst[i].ImporteAux2) / Convert.ToDouble(lst[i].ImporteAux2)) - 0) * 100;

                    }
                    else
                    {
                        lst[i].indiceCrecimientoImporte = cls.cod1 == "TRRN0002" ? 0 : ((lst[i].ImporteAux2 / lst[i - 1].ImporteAux2) - 1) * 100;
                        lst[i].indiceCrecimientoRow = cls.cod1 == "TRRN0002" ? 0 : ((Convert.ToDouble(lst[i].ImporteAux2) / Convert.ToDouble(lst[i - 1].ImporteAux2)) - 1) * 100;

                    }
                    lst[i].indiceCrecimientoImporte = Double.IsNaN(lst[i].indiceCrecimientoImporte) == true ? 0 : lst[i].indiceCrecimientoImporte;
                    lst[i].indiceCrecimientoRow = Double.IsNaN(lst[i].indiceCrecimientoRow) == true ? 0 : lst[i].indiceCrecimientoRow;

                    lst[i].indiceCrecimientoRowGraficos = (lst[i].ImporteAux3 * 100) / (lst[i].ImporteAux2+ lst[i].ImporteAux4);
                    lst[i].indiceCrecimientoImporte = Double.IsNaN(lst[i].indiceCrecimientoRowGraficos) == true ? 0 : lst[i].indiceCrecimientoImporte;
                    lst[0].SumImporteAux2 += lst[i].ImporteAux2;
                    lst[0].SumImporteAux3 += lst[i].ImporteAux3;
                    lst[0].SumImporteAux4 += lst[i].ImporteAux4;

                    lst[i].indiceCrecimientoRowGraficos = lst[i].indiceCrecimientoImporte == 0 ? 0 : (Double)decimal.Round(Convert.ToDecimal(lst[i].indiceCrecimientoRowGraficos), 2);


                    lst[0].SumRowsImporteTotalFilas += imporTotal;

                    totalRows = Convert.ToInt32(lst[i].coddAux2) + Convert.ToInt32(lst[i].coddAux3) + Convert.ToInt32(lst[i].coddAux4);
                    lst[i].TotalFilas = totalRows;
                    lst[0].SumRowsTotalFilas += totalRows;

                    i++;
                }


                return lst;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public Tuple<List<Reporte>, List<Reporte>> daBuscarReporteVentas(Busquedas cls)
        {
            SqlParameter[] pa = new SqlParameter[11];
            DataSet dtMenu = new DataSet();
            

            clsConexion objCnx = null;
            
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = cls.chkActivarFechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = cls.dtFechaIni };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = cls.dtFechaFin };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = cls.cBuscar };
                pa[4] = new SqlParameter("@tipoReporte", SqlDbType.VarChar, 15) { Value = cls.cod1 };
                pa[5] = new SqlParameter("@tipoFiltro", SqlDbType.VarChar, 15) { Value = cls.cod2 };
                pa[6] = new SqlParameter("@anio", SqlDbType.Int) { Value = cls.cod3 };
                pa[7] = new SqlParameter("@mes", SqlDbType.Int) { Value = cls.cod4 };
                pa[8] = new SqlParameter("@FiltroIngreso", SqlDbType.Int) { Value = cls.cod5 };
                pa[9] = new SqlParameter("@rbIGV", SqlDbType.Bit) { Value = cls.chkActivarDia };
                pa[10] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = cls.tipoCon };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarReporteVentas", pa);

                var res = fnValidarReporteVentas(cls.cod1, cls.cod2,cls.cod3,dtMenu);



                return Tuple.Create(res.Item1, res.Item2);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        private Tuple<List<Reporte>, List<Reporte>> fnValidarReporteVentas(String tipoReporte,String codigoFiltro,String cod3,DataSet dtMenu)
        {
            DataView dvActual = new DataView();
            DataView dvAnterior = new DataView();
            List<Reporte> lstActual = new List<Reporte>();
            List<Reporte> lstAnterior = new List<Reporte>();

            dvActual = new DataView(dtMenu.Tables[0]);
            dvAnterior = new DataView(dtMenu.Tables[1]);
            DataTable dt = GenerateTransposedTable(dtMenu.Tables[0]);
            if(codigoFiltro== "TRFV0001")
            {
                for (int i = 1; i <=12; i++)
                {
                    lstActual.Add(new Reporte
                    {
                        coddAux1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i),
                        nombreAux1 = "Mes",
                        coddAux2 = "0",
                        nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3)),
                        ImporteAux2 = Convert.ToDouble("0")

                    });

                    lstAnterior.Add(new Reporte
                    {
                        coddAux1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i),
                        nombreAux1 = "Mes",
                        coddAux2 = "0",
                        nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3) - 1),
                        ImporteAux2 = Convert.ToDouble("0")

                    });

                }

                foreach (DataRowView dr in dvActual)
                {
                    for (int i = 0; i < lstActual.Count; i++)
                    {
                        String codigo2 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dr["mes"].ToString()));
                        if (lstActual[i].coddAux1 == codigo2)
                        {
                            //lstActual[i].nombreAux1 = codigo2;
                            lstActual[i].coddAux2 = dr["unidades"].ToString();
                            lstActual[i].nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3));
                            lstActual[i].ImporteAux2 = Convert.ToDouble(dr["importe"]);
                            break;
                        }


                    }
                }
                foreach (DataRowView dr in dvAnterior)
                {
                    String codigo2 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dr["mes"].ToString()));
                    for (int i = 0; i < lstActual.Count; i++)
                    {
                        if (lstActual[i].coddAux1 == codigo2)
                        {
                            //lstAnterior[i].nombreAux1 = codigo2;
                            lstAnterior[i].coddAux2 = dr["unidades"].ToString();
                            lstAnterior[i].nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3) - 1);
                            lstAnterior[i].ImporteAux2 = Convert.ToDouble(dr["importe"]);
                            break;
                        }


                    }
                }
            }
            else if (codigoFiltro== "TRFV0002")
            {
                if (dvActual.Count > dvAnterior.Count)
                {
                    foreach (DataRowView dr in dvActual)
                    {
                        lstActual.Add(new Reporte
                        {
                            coddAux1 = dr["mes"].ToString(),
                            nombreAux1 =  "Operacion",
                            coddAux2 = dr["unidades"].ToString(),
                            nombreAux2 = "AÑO: " + Convert.ToInt32(cod3),
                            ImporteAux2 = Convert.ToDouble(dr["importe"])

                        });

                        lstAnterior.Add(new Reporte
                        {
                            coddAux1 = dr["mes"].ToString(),
                            nombreAux1 =  "Operacion",
                            coddAux2 = "0",
                            nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3) - 1),
                            ImporteAux2 = Convert.ToDouble("0")

                        });
                    }
                }
                else if (dvActual.Count < dvAnterior.Count)
                {
                    foreach (DataRowView dr in dvAnterior)
                    {
                        lstAnterior.Add(new Reporte
                        {
                            coddAux1 =  dr["mes"].ToString(),
                            nombreAux1 = "Operacion",
                            coddAux2 = dr["unidades"].ToString(),
                            nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3) - 1),
                            ImporteAux2 = Convert.ToDouble(dr["importe"])

                        });

                        lstActual.Add(new Reporte
                        {
                            coddAux1 = dr["mes"].ToString(),
                            nombreAux1 =  "Operacion",
                            coddAux2 = "0",
                            nombreAux2 = "AÑO: " + Convert.ToInt32(cod3),
                            ImporteAux2 = Convert.ToDouble("0")

                        });
                    }

                }
                else
                {
                    foreach (DataRowView dr in dvActual)
                    {
                        lstActual.Add(new Reporte
                        {
                            coddAux1 = dr["mes"].ToString(),
                            nombreAux1 = "Operacion",
                            coddAux2 = dr["unidades"].ToString(),
                            nombreAux2 = "AÑO: " + Convert.ToInt32(cod3),
                            ImporteAux2 = Convert.ToDouble(dr["importe"])

                        });

                    }
                    foreach (DataRowView dr in dvAnterior)
                    {
                        lstAnterior.Add(new Reporte
                        {
                            coddAux1 = dr["mes"].ToString(),
                            nombreAux1 = "Operacion",
                            coddAux2 = dr["unidades"].ToString(),
                            nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3) - 1),
                            ImporteAux2 = Convert.ToDouble(dr["importe"])

                        });
                    }
                }

                if (dvActual.Count > dvAnterior.Count)
                {

                    foreach (DataRowView dr in dvAnterior)
                    {
                        String codigo2 = dr["mes"].ToString();
                        for (int i = 0; i < lstActual.Count; i++)
                        {
                            if (lstActual[i].coddAux1 == codigo2)
                            {
                                //lstAnterior[i].nombreAux1 = codigo2;
                                lstAnterior[i].coddAux2 = dr["unidades"].ToString();
                                lstAnterior[i].nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3) - 1);
                                lstAnterior[i].ImporteAux2 = Convert.ToDouble(dr["importe"]);
                                break;
                            }


                        }
                    }

                }
                else if (dvAnterior.Count > dvActual.Count)
                {

                    foreach (DataRowView dr in dvActual)
                    {
                        for (int i = 0; i < lstActual.Count; i++)
                        {
                            String codigo2 = dr["mes"].ToString();
                            if (lstActual[i].coddAux1 == codigo2)
                            {
                                //lstActual[i].nombreAux1 = codigo2;
                                lstActual[i].coddAux2 = dr["unidades"].ToString();
                                lstActual[i].nombreAux2 = "AÑO: " + (Convert.ToInt32(cod3));
                                lstActual[i].ImporteAux2 = Convert.ToDouble(dr["importe"]);
                                break;
                            }


                        }
                    }
                }
            }

            if (tipoReporte== "TRRV0002")
            {
                for (int i = 0; i < lstAnterior.Count; i++)
                {
                    lstAnterior[i].indiceCrecimientoRow = ((Convert.ToDouble(lstAnterior[i].coddAux2) / Convert.ToDouble(lstActual[i].coddAux2)) - 1) * 100;
                    lstAnterior[i].indiceCrecimientoImporte = ((Convert.ToDouble(lstAnterior[i].ImporteAux2) / Convert.ToDouble(lstActual[i].ImporteAux2)) - 1) * 100;
                }
            }
            else
            {
                for (int i = 0; i < lstAnterior.Count; i++)
                {
                    lstAnterior[i].indiceCrecimientoRow = ((Convert.ToDouble(lstActual[i].coddAux2) / Convert.ToDouble(lstAnterior[i].coddAux2)) - 1) * 100;
                    lstAnterior[i].indiceCrecimientoImporte = ((Convert.ToDouble(lstActual[i].ImporteAux2) / Convert.ToDouble(lstAnterior[i].ImporteAux2)) - 1) * 100;
                }
            }

           
           return Tuple.Create(lstActual,lstAnterior);
        }
        private DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Se agregan las columnas haciendo un ciclo para cada fila

            // El encabezado de la primera columna es el mismo. 
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // El encabezado para las demas columnas
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Se agregan las columnas por cada renglón        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }
        public DataTable daBuscarCronogramaEspecifico(Int32 idCron, Int32 idCont, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = idCron };
                pa[1] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = idCont };
                pa[2] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };
                objCnx = new clsConexion("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaEspecifico", pa);


                return dtResult;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public Boolean daCambiarEstadoCronograma(Int32 idCron,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = idCron };
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };
                objCnx = new clsConexion("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspcambiarEstadoCronograma", pa);


                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public Boolean daGuardarPagoCuotas(ControlPagos clsCPC, List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[23];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            String xmlTrandiaria = clsUtil.Serialize(clsCPC.listaPagosTrandiaria);
            String xmlDetalleVenta = clsUtil.Serialize(clsCPC.listaDetalleVenta);
            String xmlDocumentoVenta = clsUtil.Serialize(lstDV);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = clsCPC.claseCronograma.idCronograma };
                pa[1] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = clsCPC.claseCronograma.idContrato };
                pa[2] = new SqlParameter("@idDetalleCronograma", SqlDbType.Int) { Value = clsCPC.claseDetalleCronograma.idDetalleCronograma };
                pa[3] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = clsCPC.fechaRegistro };
                pa[4] = new SqlParameter("@dFechaVenta", SqlDbType.DateTime) { Value = clsCPC.fechaVenta };
                pa[5] = new SqlParameter("@dFechaPago", SqlDbType.DateTime) { Value = clsCPC.fechaPago };
                pa[6] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsCPC.idUsuario };
                pa[7] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmlDocumentoVenta };
                pa[8] = new SqlParameter("@xmlDetalleVenta", SqlDbType.Xml) { Value = xmlDetalleVenta };
                pa[9] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml) { Value = xmlTrandiaria };
                pa[10] = new SqlParameter("@TotalCuota", SqlDbType.Money) { Value = clsCPC.listaPagosTrandiaria[0].cantAPagar };
                pa[11] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = clsCPC.listaPagosTrandiaria[0].idMoneda };
                pa[12] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = clsCPC.idCiclo };
                pa[13] = new SqlParameter("@IGVPrecio", SqlDbType.Money) { Value = lstDV[0].xmlDocumentoVenta[0].nIGV };
                pa[14] = new SqlParameter("@IdTarifa", SqlDbType.Int) { Value = clsCPC.claseTarifa.IdTarifa };

                pa[15] = new SqlParameter("@dPeriodoInicio", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.periodoInicio };
                pa[16] = new SqlParameter("@dPeriodoFinal", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.periodoFinal };
                pa[17] = new SqlParameter("@dFechaVencimiento", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.fechaVencimiento };
                pa[18] = new SqlParameter("@dFechaEmision", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.fechaEmision };

                pa[19] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[20] = new SqlParameter("@ImgQr", SqlDbType.Image) { Value = clsCPC.byteQr };
                pa[21] = new SqlParameter("@CodCorrelativo", SqlDbType.VarChar, 13) { Value = clsCPC.CodCorrelativoFactura };
                pa[22] = new SqlParameter("@cCodEstadoPP", SqlDbType.VarChar, 13) { Value = clsCPC.listaPagosTrandiaria[0].cEstadoPP };
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarPagoCuotas", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                clsCPC = null;
                lstDV = null;
                tipoCon = 0;
            }
        }

        public Boolean daGuardarPagoCuotasPorDocumento(ControlPagos clsCPC, List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[21];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            String xmlTrandiaria = clsUtil.Serialize(clsCPC.listaPagosTrandiaria);
            String xmlDetalleVenta = clsUtil.Serialize(clsCPC.listaDetalleVenta);
            String xmlDetalleCronograma = clsUtil.Serialize(clsCPC.listaDetalleCronograma);
            String xmlDocumentoVenta = clsUtil.Serialize(lstDV);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = clsCPC.claseCronograma.idCronograma };
                pa[1] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = clsCPC.claseCronograma.idContrato };
                pa[2] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = clsCPC.fechaRegistro };
                pa[3] = new SqlParameter("@dFechaVenta", SqlDbType.DateTime) { Value = clsCPC.fechaPago };
                pa[4] = new SqlParameter("@dFechaPago", SqlDbType.DateTime) { Value = clsCPC.fechaPago };
                pa[5] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsCPC.idUsuario };
                pa[6] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmlDocumentoVenta };
                pa[7] = new SqlParameter("@xmlDetalleVenta", SqlDbType.Xml) { Value = xmlDetalleVenta };
                pa[8] = new SqlParameter("@xmlDetalleCronograma", SqlDbType.Xml) { Value = xmlDetalleCronograma };
                pa[9] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml) { Value = xmlTrandiaria };
                pa[10] = new SqlParameter("@TotalCuota", SqlDbType.Money) { Value = clsCPC.listaPagosTrandiaria[0].PagaCon };
                pa[11] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = clsCPC.listaPagosTrandiaria[0].idMoneda };
                pa[12] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = clsCPC.idCiclo };
                pa[13] = new SqlParameter("@IGVPrecio", SqlDbType.Money) { Value = lstDV[0].xmlDocumentoVenta[0].nIGV };
                pa[14] = new SqlParameter("@IdTarifa", SqlDbType.Int) { Value = clsCPC.claseTarifa.IdTarifa };
                pa[15] = new SqlParameter("@codVenta", SqlDbType.NVarChar,50) { Value = clsCPC.cCodVenta };
                pa[16] = new SqlParameter("@totalRow", SqlDbType.Int) { Value = clsCPC.listaDetalleCronograma.Count };

                pa[17] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[18] = new SqlParameter("@ImgQr", SqlDbType.Image) { Value = clsCPC.byteQr };
                pa[19] = new SqlParameter("@CodCorrelativo", SqlDbType.VarChar,13) { Value = clsCPC.CodCorrelativoFactura };
                pa[20] = new SqlParameter("@cCodEstadoPP", SqlDbType.VarChar, 8) { Value = clsCPC.listaPagosTrandiaria[0].cEstadoPP };
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarPagoCuotasPorDocumento", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                clsCPC = null;
                lstDV = null;
                tipoCon = 0;
            }
        }


        public Boolean daActualizarEstados(Int32 idDetCronograma,String estado,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idDetCronograma", SqlDbType.Int) { Value = idDetCronograma };
                pa[1] = new SqlParameter("@estado", SqlDbType.VarChar) { Value = estado };
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = tipoCon };

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarActualizacionEstados", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }
        public Boolean daActualizarEstadoCronograma(Int32 idCronograma)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = idCronograma };

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspActualizarEstadoCronograma", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }


        public List<DetalleCronograma> daBuscarCronogramaAutomatico(String dtFechaIni, String dFechaFin,String estadoPago, List<DetalleCronograma>lstCron ,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            List<DetalleCronograma> lstDetCron = new List<DetalleCronograma>();
            String xmlids= clsUtil.Serialize(lstCron);

            try
            {
                pa[0] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = dtFechaIni };
                pa[1] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = dFechaFin };
                pa[2] = new SqlParameter("@estado", SqlDbType.VarChar, 8) { Value = estadoPago };
                pa[3] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[4] = new SqlParameter("@XmlIds", SqlDbType.Xml) { Value = xmlids };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaAutomatico", pa);

                foreach (DataRow dr in dtResult.Rows)
                {
                    lstDetCron.Add(new DetalleCronograma
                    {
                        idDetalleCronograma=Convert.ToInt32(dr["idDetalleCronograma"]),
                        periodoInicio=Convert.ToDateTime(dr["periodoInicio"]),
                        periodoFinal=Convert.ToDateTime(dr["periodoFinal"]),
                        fechaVencimiento=Convert.ToDateTime(dr["fechaVencimiento"]),
                        //fechaPago=Convert.ToDateTime(dr["fechaPago"]),
                        cDiaCiclo=Convert.ToString(dr["cDia"]),
                        idCronograma= Convert.ToInt32(dr["idCronograma"])
                    });
                }

                return lstDetCron;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public List<DetalleCronograma> daBuscarCronogramaActualizarEstados(String dtFechaIni, String dFechaFin, String estadoPago, List<DetalleCronograma> lstCron, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            List<DetalleCronograma> lstDetCron = new List<DetalleCronograma>();
            String xmlids = clsUtil.Serialize(lstCron);

            try
            {
                pa[0] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = dtFechaIni };
                pa[1] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = dFechaFin };
                pa[2] = new SqlParameter("@estado", SqlDbType.VarChar, 8) { Value = estadoPago };
                pa[3] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[4] = new SqlParameter("@XmlIds", SqlDbType.Xml) { Value = xmlids };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaActualizarEstado", pa);

                foreach (DataRow dr in dtResult.Rows)
                {
                    lstDetCron.Add(new DetalleCronograma
                    {
                        idDetalleCronograma = Convert.ToInt32(dr["idDetalleCronograma"]),
                        periodoInicio = Convert.ToDateTime(dr["periodoInicio"]),
                        periodoFinal = Convert.ToDateTime(dr["periodoFinal"]),
                        fechaVencimiento = Convert.ToDateTime(dr["fechaVencimiento"]),
                        fechaPago = Convert.ToDateTime(dr["fechaPago"]),
                        cDiaCiclo = Convert.ToString(dr["cDia"]),
                        estado= Convert.ToString(dr["estado"]),
                        idCronograma = Convert.ToInt32(dr["idCronograma"])
                    });
                }

                return lstDetCron;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public List<DetalleCronograma> daBuscarCronogramaAutomaticoEspecifico(String dtFechaIni, String dFechaFin,String estado, List<DetalleCronograma> Datos,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            List<DetalleCronograma> lstDetCron = new List<DetalleCronograma>();
            String xmlIds = clsUtil.Serialize(Datos);
            try
            {
                pa[0] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = dtFechaIni };
                pa[1] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = dFechaFin };
                pa[2] = new SqlParameter("@estado", SqlDbType.NVarChar,8) { Value = estado };
                pa[3] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[4] = new SqlParameter("@XmlIds", SqlDbType.Xml) { Value = xmlIds };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaAutomatico", pa);

                foreach (DataRow dr in dtResult.Rows)
                {
                    lstDetCron.Add(new DetalleCronograma
                    {
                        idDetalleCronograma = Convert.ToInt32(dr["idDetalleCronograma"]),
                        periodoInicio = Convert.ToDateTime(dr["periodoInicio"]),
                        periodoFinal = Convert.ToDateTime(dr["periodoFinal"]),
                        fechaVencimiento = Convert.ToDateTime(dr["fechaVencimiento"]),
                        //fechaPago=Convert.ToDateTime(dr["fechaPago"]),
                        cDiaCiclo = Convert.ToString(dr["cDia"]),
                        idCronograma = Convert.ToInt32(dr["idCronograma"]),
                        estado=Convert.ToString(dr["estado"])
                    });
                }

                return lstDetCron;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public Int32 daContadorEstadosVencidos(Int32 idDetCronograma,String estado)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = idDetCronograma };
                pa[1] = new SqlParameter("@estado", SqlDbType.NVarChar,8) { Value = estado };

                objCnx = new clsConexion("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspBusacrContadorEstados", pa);
                foreach (DataRow dr in dtResult.Rows)
                {
                    numRows = Convert.ToInt32(dr["CantItems"]);
                }
                return numRows;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }

    }
}
