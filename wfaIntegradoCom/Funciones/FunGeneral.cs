using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaUtil;
using CapaNegocio;
using CapaEntidad;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones.Models;
using wfaIntegradoCom.Funciones.Helper;
using Newtonsoft.Json;
using wfaIntegradoCom.Funciones.Enum;
using Siticone.UI.WinForms;
using System.Globalization;
using System.Drawing;
using Guna.UI.WinForms;
using System.Text.RegularExpressions;
using Microsoft.Reporting.WinForms;
using RJCodeAdvance.RJControls;
using System.IO;

namespace wfaIntegradoCom.Funciones
{
    public class FunGeneral
    {
        static clsUtil objUtil = new clsUtil();
        public static Boolean fnLlenarTablaCod(ComboBox cboCombo, String cCodTab)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static void fnThemaAFormularios(SiticonePanel sPanel)
        {
            sPanel.FillColor = ColorThemas.PanelPadre;
            //sPanel.BackColor = ColorThemas.PanelPadre;
            // codigo para buscar tab control
            var pTabControl = sPanel.Controls.OfType<TabControl>();
            foreach (TabControl tb in pTabControl)
            {
                tb.BackColor = ColorThemas.PanelPadre;
                
                var tbPage = tb.Controls.OfType<TabPage>();
                foreach (TabPage tp in tbPage)
                {
                    tp.BackColor = ColorThemas.BarraAccesoDirectos;
                    tp.ForeColor = ColorThemas.FuenteControles;
                    var SComboBox = tp.Controls.OfType<SiticoneComboBox>();

                    foreach (SiticoneComboBox scmb in SComboBox)
                    {
                        scmb.BackColor = ColorThemas.PanelPadre;
                        scmb.FillColor = ColorThemas.BarraAccesoDirectos;
                        scmb.ForeColor = ColorThemas.FuenteControles;
                    }

                    //panel dentro de tabPage

                    var pnh=tp.Controls.OfType<SiticonePanel>();
                    foreach (SiticonePanel pn in pnh)
                    {
                        pn.BackColor = ColorThemas.PanelPadre;

                        var lblpnh = pn.Controls.OfType<SiticoneLabel>();
                        foreach (SiticoneLabel stl in lblpnh)
                        {
                            stl.ForeColor = ColorThemas.FuenteControles;
                        }
                        var lblpnhf=pn.Controls.OfType<Label>();
                        foreach (Label lbl in lblpnhf)
                        {
                            lbl.ForeColor = ColorThemas.FuenteControles;
                            if (lbl.Tag== "error")
                            {
                                lbl.ForeColor = Color.Red;
                            }
                        }

                        var stCheck=pn.Controls.OfType<SiticoneCheckBox>();
                        foreach (SiticoneCheckBox chk in stCheck)
                        {
                            chk.ForeColor= ColorThemas.FuenteControles;
                            if (chk.Tag== "important")
                            {
                                chk.ForeColor = Variables.ColorEmpresa;
                            }
                        }
                    }

                    var SDatPickerIn = tp.Controls.OfType<SiticoneDateTimePicker>();
                    foreach (SiticoneDateTimePicker scmb in SDatPickerIn)
                    {
                        scmb.BackColor = ColorThemas.PanelPadre;
                        scmb.FillColor = ColorThemas.BarraAccesoDirectos;
                        scmb.ForeColor = ColorThemas.FuenteControles;
                    }

                    var pbTp = tp.Controls.OfType<PictureBox>();
                    foreach (PictureBox p in pbTp)
                    {
                        p.BackColor = ColorThemas.BarraAccesoDirectos;
                    }

                    var pbbt = tp.Controls.OfType<SiticoneCircleButton>();
                    foreach (SiticoneCircleButton bt in pbbt)
                    {
                        bt.BackColor = ColorThemas.BarraAccesoDirectos;
                    }

                    var stch = tp.Controls.OfType<SiticoneCheckBox>();
                    foreach (SiticoneCheckBox ch in stch)
                    {
                        ch.BackColor = ColorThemas.BarraAccesoDirectos;
                        ch.ForeColor = ColorThemas.FuenteControles;
                    }

                    var sLavel = tp.Controls.OfType<SiticoneLabel>();
                    foreach (SiticoneLabel lbl in sLavel)
                    {
                        lbl.ForeColor = ColorThemas.FuenteControles;
                    }
                    var lavel = tp.Controls.OfType<Label>();
                    foreach (Label lbl in lavel)
                    {
                        lbl.ForeColor = ColorThemas.FuenteControles;
                    }

                    var sdgvtp = tp.Controls.OfType<SiticoneDataGridView>();
                    foreach (SiticoneDataGridView dg in sdgvtp)
                    {
                        dg.BackgroundColor = ColorThemas.BarraAccesoDirectos;
                        dg.ThemeStyle.RowsStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                        //dg.DefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                        dg.RowsDefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                        //dg.ThemeStyle.BackColor= ColorThemas.BarraAccesoDirectos;
                        dg.ThemeStyle.AlternatingRowsStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                        dg.ThemeStyle.RowsStyle.ForeColor = ColorThemas.FuenteControles;
                    }

                    var vGrouptp = tp.Controls.OfType<SiticoneGroupBox>();
                    foreach (SiticoneGroupBox sgb in vGrouptp)
                    {
                        sgb.FillColor = ColorThemas.BarraAccesoDirectos;

                        var gDatPickerIn = sgb.Controls.OfType<SiticoneDateTimePicker>();
                        foreach (SiticoneDateTimePicker scmb in gDatPickerIn)
                        {
                            scmb.BackColor = ColorThemas.PanelPadre;
                            scmb.FillColor = ColorThemas.FondoControles;
                            scmb.ForeColor = ColorThemas.FuenteControles;
                        }

                        var vgLavel = sgb.Controls.OfType<SiticoneLabel>();
                        foreach (SiticoneLabel lbl in vgLavel)
                        {
                            lbl.ForeColor = ColorThemas.FuenteControles;
                        }
                        var lvel = sgb.Controls.OfType<Label>();
                        foreach (Label l in lvel)
                        {
                            l.BackColor = sgb.FillColor;
                            l.ForeColor = ColorThemas.FuenteControles;
                        }

                        var sdgvG = sgb.Controls.OfType<SiticoneDataGridView>();
                        foreach (SiticoneDataGridView dg in sdgvG)
                        {
                            dg.BackgroundColor = ColorThemas.PanelPadre;
                            dg.ThemeStyle.RowsStyle.BackColor = ColorThemas.FondoControles;
                            //dg.DefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                            dg.RowsDefaultCellStyle.BackColor = ColorThemas.FondoControles;
                            //dg.ThemeStyle.BackColor= ColorThemas.BarraAccesoDirectos;
                            dg.ThemeStyle.AlternatingRowsStyle.BackColor = ColorThemas.FondoControles;
                            dg.ThemeStyle.RowsStyle.ForeColor = ColorThemas.FuenteControles;
                        }

                        var dgvG = sgb.Controls.OfType<DataGridView>();
                        foreach (DataGridView dg in dgvG)
                        {
                            dg.BackgroundColor = ColorThemas.BarraAccesoDirectos;
                            dg.RowsDefaultCellStyle.ForeColor = ColorThemas.FuenteControles;
                            dg.RowTemplate.DefaultCellStyle.ForeColor = ColorThemas.FuenteControles;

                            dg.RowHeadersDefaultCellStyle.BackColor = ColorThemas.PanelPadre;
                            dg.ColumnHeadersDefaultCellStyle.ForeColor = ColorThemas.FuenteControles;

                            dg.ColumnHeadersDefaultCellStyle.BackColor = ColorThemas.FondoControles;
                            dg.RowsDefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                        }

                        var grbint= sgb.Controls.OfType<GroupBox>();
                        foreach (GroupBox gb in grbint)
                        {
                            gb.BackColor = ColorThemas.BarraAccesoDirectos;
                            gb.ForeColor = ColorThemas.FuenteControles;

                            var lblg = gb.Controls.OfType<Label>();
                            foreach (Label lbl in lblg)
                            {
                                lbl.ForeColor = ColorThemas.FuenteControles;
                            }

                            var rb= gb.Controls.OfType<GunaRadioButton>();
                            foreach (GunaRadioButton r in rb)
                            {
                                r.ForeColor = ColorThemas.FuenteControles;
                            }
                        }

                        var sSep = sgb.Controls.OfType<SiticoneSeparator>();
                        foreach (SiticoneSeparator sp in sSep)
                        {
                            sp.BackColor = ColorThemas.BarraAccesoDirectos;
                        }

                        var pb=sgb.Controls.OfType<PictureBox>();
                        foreach (PictureBox p in pb)
                        {
                            if (p.Tag is null)
                            {
                                p.BackColor = ColorThemas.BarraAccesoDirectos;
                            }
                            else
                            {
                                if (p.Tag.ToString() == "pbBuscar")
                                {
                                    p.BackColor = ColorThemas.FondoControles;
                                }
                                else
                                {
                                    p.BackColor = ColorThemas.BarraAccesoDirectos;
                                }
                            }
                            
                            
                        }
                        var sch = sgb.Controls.OfType<SiticoneCheckBox>();
                        foreach (SiticoneCheckBox lbl in sch)
                        {
                            lbl.BackColor = sgb.FillColor;
                            lbl.ForeColor = ColorThemas.FuenteControles;
                        }
                    }
                    var rpViwer = tp.Controls.OfType<ReportViewer>();
                    foreach (ReportViewer rv in rpViwer)
                    {
                        rv.BackColor = ColorThemas.FondoControles;
                        rv.ForeColor = ColorThemas.FuenteControles;
                    }
                }

                
            }

            var pimage = sPanel.Controls.OfType<PictureBox>();
            foreach (PictureBox pb in pimage)
            {
                if (pb.Tag.ToString() == "pbBuscar")
                {
                    pb.BackColor = ColorThemas.FondoControles;
                }
                else
                {
                    pb.BackColor = ColorThemas.PanelPadre;
                }

            }
            var spn1 = sPanel.Controls.OfType<SiticonePanel>();
            foreach (SiticonePanel pn1 in spn1)
            {
                pn1.FillColor = ColorThemas.PanelPadre;
                pn1.ForeColor = ColorThemas.FuenteBotones;
                var SComboBox = pn1.Controls.OfType<SiticoneComboBox>();
                foreach (SiticoneComboBox scmb in SComboBox)
                {
                    scmb.BackColor = ColorThemas.PanelPadre;
                    scmb.FillColor = ColorThemas.FondoControles;
                    scmb.ForeColor = ColorThemas.FuenteControles;
                }

                var SDatPickerIn = pn1.Controls.OfType<SiticoneDateTimePicker>();
                foreach (SiticoneDateTimePicker scmb in SDatPickerIn)
                {
                    scmb.BackColor = ColorThemas.PanelPadre;
                    scmb.FillColor = ColorThemas.FondoControles;
                    scmb.ForeColor = ColorThemas.FuenteControles;
                }


                var sLavel = pn1.Controls.OfType<SiticoneLabel>();
                foreach (SiticoneLabel lbl in sLavel)
                {
                    lbl.ForeColor = ColorThemas.FuenteControles;
                }
                var lavel = pn1.Controls.OfType<Label>();
                foreach (Label lbl in lavel)
                {
                    lbl.ForeColor = ColorThemas.FuenteControles;
                }

                var pimagein = pn1.Controls.OfType<PictureBox>();
                foreach (PictureBox pb in pimagein)
                {
                    pb.BackColor = ColorThemas.PanelPadre;

                }


                var dgvG = pn1.Controls.OfType<DataGridView>();
                foreach (DataGridView dg in dgvG)
                {
                    dg.BackgroundColor = ColorThemas.BarraAccesoDirectos;
                    dg.RowsDefaultCellStyle.ForeColor = ColorThemas.FuenteControles;
                    dg.RowTemplate.DefaultCellStyle.ForeColor = ColorThemas.FuenteControles;

                    dg.RowHeadersDefaultCellStyle.BackColor = ColorThemas.PanelPadre;
                    dg.ColumnHeadersDefaultCellStyle.ForeColor = ColorThemas.FuenteControles;

                    dg.ColumnHeadersDefaultCellStyle.BackColor = ColorThemas.FondoControles;
                    dg.RowsDefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                }
            }

            //codigo para buscar groupBox
            var grb = sPanel.Controls.OfType<GroupBox>();
            foreach (GroupBox grp in grb)
            {
                grp.ForeColor = ColorThemas.FuenteControles;
                grp.BackColor = ColorThemas.BarraAccesoDirectos;
            }

            var vGroupBox = sPanel.Controls.OfType<SiticoneGroupBox>();
            foreach (SiticoneGroupBox sgb in vGroupBox)
            {
                sgb.FillColor = ColorThemas.BarraAccesoDirectos;
                sgb.BackColor = ColorThemas.PanelPadre;

                var gDatPickerIn = sgb.Controls.OfType<SiticoneDateTimePicker>();
                foreach (SiticoneDateTimePicker scmb in gDatPickerIn)
                {
                    scmb.BackColor = ColorThemas.PanelPadre;
                    scmb.FillColor = ColorThemas.FondoControles;
                    scmb.ForeColor = ColorThemas.FuenteControles;
                }

                var vgLavel = sgb.Controls.OfType<SiticoneLabel>();
                foreach (SiticoneLabel lbl in vgLavel)
                {
                    lbl.ForeColor = ColorThemas.FuenteControles;
                }
                var lavel = sgb.Controls.OfType<Label>();
                foreach (Label lbl in lavel)
                {
                    if (lbl.Tag is null)
                    {
                        lbl.BackColor = sgb.FillColor;
                    }
                    else if (lbl.Tag.ToString()== "lblPanel")
                    {
                        lbl.BackColor = ColorThemas.FondoControles;

                    }
                    else
                    {
                        lbl.BackColor = sgb.FillColor;    
                    }
                    lbl.ForeColor = ColorThemas.FuenteControles;
                }
                var dgvG = sgb.Controls.OfType<DataGridView>();
                foreach (DataGridView dg in dgvG)
                {
                    dg.BackgroundColor = ColorThemas.BarraAccesoDirectos;
                    dg.RowsDefaultCellStyle.ForeColor = ColorThemas.FuenteControles;
                    dg.RowTemplate.DefaultCellStyle.ForeColor= ColorThemas.FuenteControles;

                    dg.RowHeadersDefaultCellStyle.BackColor= ColorThemas.PanelPadre;    
                    dg.ColumnHeadersDefaultCellStyle.ForeColor= ColorThemas.FuenteControles; 
                    
                    dg.ColumnHeadersDefaultCellStyle.BackColor=ColorThemas.FondoControles; 
                    dg.RowsDefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                    //dg.ThemeStyle.BackColor= ColorThemas.BarraAccesoDirectos;
                    //dg.ThemeStyle.AlternatingRowsStyle.BackColor = ColorThemas.FondoControles;
                    //dg.ThemeStyle.RowsStyle.ForeColor = ColorThemas.FuenteControles;
                }

                var pb = sgb.Controls.OfType<PictureBox>();
                foreach (PictureBox p in pb)
                {
                    p.BackColor = ColorThemas.BarraAccesoDirectos;
                }

                var chk = sgb.Controls.OfType<CheckBox>();
                foreach (CheckBox hc in chk)
                {
                    hc.BackColor = ColorThemas.BarraAccesoDirectos;
                    hc.ForeColor=ColorThemas.FuenteControles;   
                }

                var sBut = sgb.Controls.OfType<SiticoneButton>();
                foreach (SiticoneButton bt in sBut)
                {
                    bt.BackColor = ColorThemas.BarraAccesoDirectos;
                }
            }
            //codigo para buscar datagridview
            var sdgv = sPanel.Controls.OfType<SiticoneDataGridView>();
            foreach (SiticoneDataGridView dg in sdgv)
            {
                dg.BackgroundColor = ColorThemas.PanelPadre;
                dg.ThemeStyle.RowsStyle.BackColor = ColorThemas.FondoControles;
                //dg.DefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
                dg.RowsDefaultCellStyle.BackColor = ColorThemas.FondoControles;
                //dg.ThemeStyle.BackColor= ColorThemas.BarraAccesoDirectos;
                dg.ThemeStyle.AlternatingRowsStyle.BackColor = ColorThemas.FondoControles;
                dg.ThemeStyle.RowsStyle.ForeColor = ColorThemas.FuenteControles;
            }

            //codigo para buscar label
            var vLabel = sPanel.Controls.OfType<SiticoneLabel>();
            foreach (SiticoneLabel lbl in vLabel)
            {
                lbl.ForeColor = ColorThemas.FuenteControles;
            }
            var label = sPanel.Controls.OfType<Label>();
            foreach (Label lbl in label)
            {
                lbl.ForeColor = ColorThemas.FuenteControles;
            }

            //codigo para buscar SitiConetexbox
            var stexbox = sPanel.Controls.OfType<SiticoneTextBox>();
            foreach (SiticoneTextBox txt in stexbox)
            {
                txt.BackColor = ColorThemas.PanelPadre;
                txt.FillColor = ColorThemas.FondoControles;
                txt.ForeColor = ColorThemas.FuenteControles;
            }
            var sCmbox = sPanel.Controls.OfType<SiticoneComboBox>();
            foreach (SiticoneComboBox scmb in sCmbox)
            {
                scmb.BackColor = ColorThemas.PanelPadre;
                scmb.FillColor = ColorThemas.FondoControles;
                scmb.ForeColor = ColorThemas.FuenteControles;
            }

            var SDatPicker = sPanel.Controls.OfType<SiticoneDateTimePicker>();
            foreach (SiticoneDateTimePicker scmb in SDatPicker)
            {
                scmb.BackColor = ColorThemas.PanelPadre;
                scmb.FillColor = ColorThemas.FondoControles;
                scmb.ForeColor = ColorThemas.FuenteControles;
            }

            var sCheck = sPanel.Controls.OfType<SiticoneCheckBox>();
            foreach (SiticoneCheckBox scmb in sCheck)
            {
                scmb.ForeColor = ColorThemas.FuenteControles;
            }
        }
        public static Tuple<Boolean, String> fnValidarFechaPasandoDia(SiticoneDateTimePicker dt, PictureBox pb, Label lbl, Int32 tipoCon, Int32 numDias)
        {
            Boolean estado = false;
            String msg = "";
            DateTime fechaProxSeguimiento = Variables.gdFechaSis;
            DateTime ddt = Variables.gdFechaSis.AddDays(numDias).AddHours((23 - Variables.gdFechaSis.Hour));
            if (tipoCon == 0)
            {
                dt.MinDate = ddt;
                dt.MaxDate = Variables.gdFechaSis.AddMinutes(10);
            }
            else
            {
                if (dt.Value.Day < Variables.gdFechaSis.Day)
                {
                    DialogResult dialg = MessageBox.Show("La seleccion en menor a la fecha actual, deseas fijarla?", "Avisoo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialg != DialogResult.Yes)
                    {
                        dt.Value = Variables.gdFechaSis;
                    }
                }

                lbl.Text = msg;
                pb.Image = Properties.Resources.ok;
            }
            return Tuple.Create(estado, msg);
        }
        public static List<DetalleVenta> fnObtenerDetalleVenta(Int32 idTrandiaria,Int32 idTipoTarifa)
        {
            BLDocumentoVenta bLDocumentoVenta = new BLDocumentoVenta();
            try
            {
                return bLDocumentoVenta.blbuscarDetalleVenta(idTrandiaria, idTipoTarifa);

            }
            catch (Exception ex)
            {

                return new List<DetalleVenta>();
            }
        }
        public static List<ReporteBloque> fnBuscarCajasDashboard(Int32 tipoCon)
        {
            BLDocumentoVenta bLDocumentoVenta = new BLDocumentoVenta();
            try
            {
                return bLDocumentoVenta.blbuscarCajasDashboard(tipoCon);

            }
            catch (Exception ex)
            {

                return new List<ReporteBloque>();
            }
        }
        public static Tuple<Boolean, String> fnValidarFechaPago(SiticoneDateTimePicker dt, PictureBox pb, Int32 tipoCon)
        {
            Boolean estado = false;
            String msg = "";
            DateTime ddt= Variables.gdFechaSis.AddDays(-2).AddDays(2).AddHours((23 - Variables.gdFechaSis.Hour));
            if (tipoCon==0)
            {
                dt.MinDate = Variables.gdFechaSis.AddDays(-2);
                dt.MaxDate = ddt;
            }
            else
            {
                if (dt.Value.Day<Variables.gdFechaSis.Day && dt.Value.Day> Variables.gdFechaSis.AddDays(-4).Day)
                {
                    DialogResult dialg = MessageBox.Show("La seleccion en menor a la fecha actual, deseas fijarla?","Avisoo!!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                    if (dialg!=DialogResult.Yes)
                    {
                        dt.Value = Variables.gdFechaSis;
                    }
                }
                else
                {
                    dt.MinDate = Variables.gdFechaSis.AddYears(-5);
                    dt.MaxDate = ddt;
                }
            }
            estado = true;
            msg = "";
            
            pb.Image = Properties.Resources.ok;
            return Tuple.Create(estado, msg);
        }

        
        public static Boolean fnLlenarTablaCodTipoCon(ComboBox cboCombo, String cCodTab,Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCodTipoCon(cCodTab,buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static List<Cargo> fnLlenarTablaCodTipoConReturnLista(ComboBox cboCombo, String cCodTab,Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCodTipoConReturnLista(cCodTab,buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return lstTablaCod;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return lstTablaCod;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static String generarCorrelativoDocumento(Int32 numero)
        {
            return numero.ToString().PadLeft(8, '0');

        }

        //public static 
        public static List<Cargo> fnLlenarTablaCodTipoConDT(String cCodTab,Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCodTipoConDT(cCodTab,buscar);
         

                return lstTablaCod;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return lstTablaCod;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static Boolean fnLlenarCboSegunTablaTipoCon(ComboBox cboCombo, String nomCampoId,String nomCampoNombre,String nomTabla,String nomEstado,String condicionDeEstado, Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blLlenarCboSegunTablaTipoCon( nomCampoId,  nomCampoNombre,  nomTabla,  nomEstado,  condicionDeEstado,  buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                if (cboCombo.Name== "cboFiltraIngresos")
                {
                    Int32 i = 0;
                   
                    foreach (Cargo it in lstTablaCod)
                    {
                        if (it.cCodTab== "16")
                        {
                            lstTablaCod[i].cCodTab = "-16";
                            lstTablaCod[i].cNomTab = "GPS";
                        }
                        i++;
                    }
                    lstTablaCod.Add(new Cargo
                    {
                        cCodTab = "16",
                        cNomTab = "CAJA CHICA"
                    });
                }
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static List<Cargo> fnLlenarCboSegunTablaTipoConReturnLista(ComboBox cboCombo, String nomCampoId,String nomCampoNombre,String nomTabla,String nomEstado,String condicionDeEstado, Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blLlenarCboSegunTablaTipoCon( nomCampoId,  nomCampoNombre,  nomTabla,  nomEstado,  condicionDeEstado,  buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                
                cboCombo.DataSource = lstTablaCod;

                return lstTablaCod;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return lstTablaCod;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }


        //llenar combobox de la instalacion
        public static Boolean fnLlenarAccesorios(ComboBox cboCombo, Int32 cCodTab)
        {
            BLAccesorio objTablaCod = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            List<Accesorios> lstTablaCod = new List<Accesorios>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverAccesorio(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember ="idAccesorio";
                cboCombo.DisplayMember ="cAccesorio";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        public static Boolean fnLlenarTablaCodValor(ComboBox cboCombo, String cCodTab)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cValor";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCodValor", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        public static Cargo[] fnDevolverParametro(String pcCodTab)
        {
            BLCargo objCargo = new BLCargo();
            Cargo[] arrParametro = new Cargo[1];
            clsUtil objUtil = new clsUtil();
            
            try {
                arrParametro = objCargo.blDevolverTablaCod(pcCodTab).ToArray();
                return arrParametro;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("fnValidaTipoDato", "GetFechaHoraFormato", ex.Message);
                return null;
            }
            finally
            {
                objCargo = null;
                arrParametro = null;
                objUtil = null;
            }
        }

        public static String GetFechaHoraFormato(DateTime pdFecha, Int32 piFormato)
        {
            String sFecSis;
            String sDia, sMes, sAnio;
            String sHoraActual = (DateTime.Now.TimeOfDay.ToString());
            sFecSis = "";
            clsUtil objUtil = new clsUtil();
            try
            {

                switch (piFormato)
                {
                    case 1:       //Presentación        dd//mm/yyyy           
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sDia + "/" + sMes + "/" + sAnio;
                        break;
                    case 5:       //Fecha corta              
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "/" + sMes + "/" + sDia;
                        break;
                    case 2:       //Registro en Base  FechaHora   
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + sMes + sDia + " " + sHoraActual.Substring(0, 12);
                        break;
                    case 3:       //yyyy-mm-dd hh:mm:ss                         

                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "-" + sMes + "-" + sDia;

                        sFecSis = sFecSis + " " + sHoraActual.Substring(0, 12);
                        break;
                    case 4:

                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "-" + sMes + "-" + sDia + " " + pdFecha.Hour + ":" + pdFecha.Minute + ":" + pdFecha.Second + "." + pdFecha.Millisecond.ToString().PadLeft(3, '0');
                        break;
                    case 6:       //Presentación        dd//mm/yyyy           
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sDia + "/" + sMes + "/" + sAnio+" "+sHoraActual.Substring(0, 12);;
                        break;
                }

                return sFecSis;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("fnValidaTipoDato", "GetFechaHoraFormato", ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public static Int32 fnVerificarApertura(Int32 idUsuario)
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            BLDocumentoVenta objApertura = new BLDocumentoVenta();
            Int32 num = 0;
            try
            {
                Variables.lstCuardreCaja = objApertura.blVerificarApertura(FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3), Variables.idSucursal, idUsuario);

                if (Variables.lstCuardreCaja.Count != 0)
                {
                    num = Variables.lstCuardreCaja[0].idOperacion;
                }
                else
                {
                    Variables.lstCuardreCaja.Add(new CuadreCaja
                    {
                        idOperacion = 0,
                        Detalle = "",
                        importeSaldo = 0

                    });
                }
                return num;
            }
            catch (Exception ex)
            {
                bResul = false;
                objUtil.gsLogAplicativo("frmAperturaCaja", "fnVerificarApertura", ex.Message);
                return num;
            }

        }
        public static List<CuadreCaja> fnVerificarAperturaAnterior(DateTime dt,Int32 idUsuario)
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            BLDocumentoVenta objApertura = new BLDocumentoVenta();
            Int32 num = 0;
            try
            {
                Variables.lstCuardreCaja= objApertura.blVerificarApertura(FunGeneral.GetFechaHoraFormato(dt, 5), Variables.idSucursal, idUsuario);
                if (Variables.lstCuardreCaja.Count!=0)
                {
                    num= Variables.lstCuardreCaja[0].idOperacion;
                }
                else
                {
                    Variables.lstCuardreCaja.Add(new CuadreCaja
                    {
                        idOperacion=0,
                        Detalle="",
                        importeSaldo=0

                    });
                }
                return Variables.lstCuardreCaja;
            }
            catch (Exception ex)
            {
                bResul = false;
                objUtil.gsLogAplicativo("frmAperturaCaja", "fnVerificarApertura", ex.Message);
                return new List<CuadreCaja>();
            }

        }
        public static List<ReporteBloque> fnBuscarImporteCierreAnterior(Int32 idUsuario,Int32 tipoCon)
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            BLDocumentoVenta objApertura = new BLDocumentoVenta();
            try
            {
                return objApertura.blBuscarImporteCierreAnterior(FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5), Variables.idSucursal, idUsuario,  tipoCon);
               
            }
            catch (Exception ex)
            {
                bResul = false;
                objUtil.gsLogAplicativo("frmAperturaCaja", "fnVerificarApertura", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public static void fnVerificarFechaSistema(Form[] children)
        {
            if (Variables.gdFechaSis.Date != DateTime.Now.Date)
            {
                Variables.gdFechaSis = DateTime.Now;
                var arrayFormOpens = Application.OpenForms;

                if (arrayFormOpens != null)
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name.Trim() != "MDIParent1")
                            frm.Close();
                    }
                }
            }
        }
        public static void cbos_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        public static IList<PrintingTemplate> GetPrintingTemplates(IList<string> templatesList)
        {
            try
            {

                string originPath = Application.StartupPath + "\\Template";
                //Validate Path
                if (System.IO.Directory.Exists(originPath))
                {
                    //Initialize Uploading Files list
                    List<PrintingTemplate> templates = new List<PrintingTemplate>();

                    //Get files path in directory
                    String[] templateFiles = System.IO.Directory.GetFiles(originPath, "*.xml");
                    String[] configFiles = System.IO.Directory.GetFiles(originPath, "*.config");
                    int intContador = 0;
                    //Look into templates files
                    foreach (String templateFile in templateFiles)
                    {
                        intContador = intContador + 1;
                        try
                        {
                            String[] pathSplit = templateFile.Split('\\');
                            string templateName = pathSplit[pathSplit.Count() - 1];
                            templateName = templateName.Substring(0, templateName.IndexOf("."));
                            if (templatesList.FirstOrDefault(t => t == templateName) != null)
                            {
                                PrintingTemplate currentTemplate = new PrintingTemplate()
                                {
                                    Id = templateName,
                                    Name = templateName,
                                    StringifiedTemplate = System.IO.File.ReadAllText(templateFile),
                                };

                                templates.Add(currentTemplate);
                            }
                        }
                        catch (Exception)
                        {
                            //Log: Ha fallado la obtencion de este template
                            //No hacemos  nada con este template
                        }
                    }

                    //Look into config files
                    foreach (String configFile in configFiles)
                    {
                        try
                        {
                            String[] pathSplit = configFile.Split('\\');
                            string templateName = pathSplit[pathSplit.Count() - 1];
                            templateName = templateName.Substring(0, templateName.IndexOf("."));
                            PrintingTemplate template = templates.Find(t => t.Name == templateName);
                            if (template != null)
                            {
                                try
                                {
                                    IDictionary<string, string> settings = new Dictionary<string, string>();
                                    string stringifiedTemplateSettings = System.IO.File.ReadAllText(configFile);
                                    settings = Format.FormatPrintingServiceStringifiedJson(stringifiedTemplateSettings);
                                    template.TemplateSettings = settings;
                                }
                                catch (Exception)
                                {
                                    template.TemplateSettings = new Dictionary<string, string>();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //Log: Ha fallado la obtencion de una configuracion
                        }
                    }

                    //Return List Uploading Files
                    return templates;
                }
                else
                {
                    throw new System.IO.DirectoryNotFoundException($"No se logró el acceso a la carpeta: {originPath}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void fnImprimirVoucher(PrintRequest printRequest)
        {
           var response = ApiHelper.Post<PrintRequest>("http://localhost:8085/api/Print/PrintDocument", printRequest, "Application/json", null, null);
        }

        /// <summary>
        /// Obtiene la imagen de la ruta y lo devuelve en base64
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetLogo(string filename)
        {
            try
            {

                try
                {
                    string originPath = Application.StartupPath + "\\Template";
                    byte[] imageArray = System.IO.File.ReadAllBytes(originPath + "\\" + filename);
                    string logoBase64 = Convert.ToBase64String(imageArray);
                    return logoBase64;
                }
                catch (Exception)
                {
                    return "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static OrderResponse fnSaveOrder(OrderRequest orderRequest)
        {
            OrderResponse orderResponse = new OrderResponse();
            try
            {
                var response = ApiHelper.Post<OrderRequest>("http://localhost:8085/api/Order/SaveOrder", orderRequest, "Application/json", null, null);
                //orderResponse = response;
                if (response != null && response.Item1.ToString() == "OK")
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(response.Item2);
                }
                else
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(response.Item2);
                    orderResponse.Status = 400;
                }
            }catch(Exception ex)
            {
                //objUtil.gsLogAplicativo("FunGeneral", "fnSaveOrder", ex.Message);
                orderResponse.Message = "Error Interno de lado de la Aplicacion";
                orderResponse.Status = 500;
            }
            return orderResponse;
        }

        public static OrderResponse fnGetOrderxCodigo(string Codigo)
        {
            OrderResponse orderResponse = new OrderResponse();
            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("Codigo", Codigo);
                var order = ApiHelper.Get("http://localhost:8085/api/Order/getOrderxCodigo", pairs, null);
                if (order != null && order.Item1.ToString() == "OK")
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(order.Item2);
                }
                else
                {
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(order.Item2);
                    orderResponse.Status = 400;
                }
            }
            catch(Exception ex)
            {
                //objUtil.gsLogAplicativo("FunGeneral", "fnGetOrderxCodigo", ex.Message);
                orderResponse.Message = "Error Interno de lado de la Aplicacion";
                orderResponse.Status = 500;
            }
            return orderResponse;
        }


        public static GenericListResponse<Pedido> fnGeAllorEspecificOrder(string Codigo)
        {
            GenericListResponse<Pedido> genericListResponse = new GenericListResponse<Pedido>();
            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("Codigo", Codigo);
                var order = ApiHelper.Get("http://localhost:8085/api/Order/fnGeAllorEspecificOrder", pairs, null);
                if (order != null && order.Item1.ToString() == "OK")
                {
                    genericListResponse = JsonConvert.DeserializeObject<GenericListResponse<Pedido>>(order.Item2);
                }
                else
                {
                    genericListResponse = JsonConvert.DeserializeObject<GenericListResponse<Pedido>>(order.Item2);
                    genericListResponse.Status = 400;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnGeAllorEspecificOrder", ex.Message);
                genericListResponse.Message = "Error Interno de lado de la Aplicacion";
                genericListResponse.Status = 500;
            }
            return genericListResponse;
        }

        public static string fnGetEnumDescription(int intEstado)
        {
            string strEstado = "";
            switch (intEstado)
            {
                case (int)StateOrder.Pendiente:
                    strEstado = "Pendiente";
                    break;
                case (int)StateOrder.Procesado:
                    strEstado = "Procesado";
                    break;
                case (int)StateOrder.Cancelado:
                    strEstado = "Cancelado";
                    break;
                case (int)StateOrder.Entregado:
                    strEstado = "Entregado";
                    break;
                default:
                    break;
            }

            return strEstado;
        }

        public static Boolean fnRegistrarAccionDiaria(String descrip,Boolean estado,Int32 idOpera,String fechaOperacion)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                return  objTablaCod.blRegistrarAccionDiaria( descrip,  estado,  idOpera,  fechaOperacion);
               

                 
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCodValor", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }
        }
        public static Color fnDevolVerColorTransparente(Int32 alfa, Color colr)
        {
            return Color.FromArgb(alfa, colr);
        }

        public   static List<Ciclo> fnLlenarCiclo(Int32 idCiclo, SiticoneComboBox cbo, Boolean buscar)
        {
            BLCiclo objCiclo = new BLCiclo();
            clsUtil objUtil = new clsUtil();
            List<Ciclo> lstCiclo = new List<Ciclo>();

            try
            {
                lstCiclo = objCiclo.blDevolverCiclo(idCiclo, buscar);

                cbo.ValueMember = "IdCiclo";
                cbo.DisplayMember = "Dia";
                cbo.DataSource = lstCiclo;
                return lstCiclo;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return lstCiclo;
            }
        }

        public static DateTime fnUpdateFechas(DateTime dt)
        {
            return  dt.AddHours(-dt.Hour).AddMinutes(-dt.Minute).AddSeconds(-dt.Second).AddHours(Variables.gdFechaSis.Hour).AddMinutes(Variables.gdFechaSis.Minute).AddSeconds(Variables.gdFechaSis.Second);
        }
        public static Byte[] fnObtenerQRDefecto()
        {
            String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");

            return imageBytes;
            
        }
        public static Int32 fnBuscarAccionDiaria(Int32 idOpera, string fechaOperacion)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                return objTablaCod.blBuscarAccionDiaria(idOpera, fechaOperacion);



            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCodValor", ex.Message);
                return 0;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }
        }
        public static Int32 fnValidarDatosExistentes(String txtPlaca, String txtPlaca2, Int16 pnTipoCon,String Procedimiento)
        {
            BLValidarDatosExistentes objDatosDuplicados = new BLValidarDatosExistentes();
            clsUtil objUtil = new clsUtil();
            Int32 validarDatos = 0;
            try
            {
                validarDatos = objDatosDuplicados.blDevolverDatosExistentes(txtPlaca, txtPlaca2, pnTipoCon, Procedimiento);
                return validarDatos;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return validarDatos;
            }
            finally
            {
            }
        }

        public static string FormatearCadenaTitleCase(String str)
        {
            str = str is null ? "" : str;
            String dat = str.ToLower();
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dat); ;
        }

        public static List<Items> fnListarItemsVenta()
        {
            BLCargo objTablaCod = new BLCargo();
            try
            {

                return objTablaCod.blListarItems();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DetalleCronograma fnObtenerDatosCuotaUltimoCronograma(Int32 idContrato)
        {
            BLCargo objTablaCod = new BLCargo();
            try
            {

                return objTablaCod.blObtenerDatosCuotaUltimoCronograma( idContrato);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Double fnLimpiarDescuentos(String PrecioADescontarStr)
        {
            Double PrecioADescontar = 0;
            String str = "";
            //Double PrecioADescontar = Convert.ToDouble(dgvCronograma.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value);
            string patron = @"(?:- *)?\d+(?:\/\d+)?";
            //string patron = @"(?:\.\d+)?,\d+(?:\.\d+)?";
            Regex regex = new Regex(patron);
            Int32 i = 0;
            Int32 countt = regex.Matches(PrecioADescontarStr).Count;

            foreach (Match m in regex.Matches(PrecioADescontarStr))
            {
                if (countt > 1 && i== countt-1 && Convert.ToInt32(m.Value)==0)
                {
                    break;
                }
                str += Convert.ToDouble(m.Value);
                
                i++;
            }
            PrecioADescontar = Convert.ToDouble(str);
            return PrecioADescontar;
        }
        public static void cbo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        public static Boolean fnLlenarUsuarioPorCargo(ComboBox cboCombo, String cCodCargo, Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverUsuarioPorCargo(cCodCargo, buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        public static String fnFormatearPrecio(String simbolo,Double Precio,Int32 lnTipoCon)
        {
            String srt = "";
            if (lnTipoCon == -1)
            {
                srt =String.Format("{0:#,##0.00}", Precio);

            }
            else if (lnTipoCon==0)
            {
                srt = simbolo+String.Format("{0:#,##0.00}", Precio);

            }else if (lnTipoCon==1)
            {

                srt = $"{simbolo} {string.Format("{0:0.00}", Precio)}";
            }
            else if (lnTipoCon==2)
            {
                srt = $"{string.Format("{0:0.00}", Precio)}";

            }
            return srt;
        }

        public static List<ReporteBloque> fnBuscarOtrosIngresos(Busquedas bs )
        {
            BLCaja bLCaja = new BLCaja();
            try
            {
                return bLCaja.blBuscarOtrosIngresos(bs);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static String fnFormatearPrecioDC(String simbolo,Decimal Precio,Int32 lnTipoCon)
        {
            String srt = "";
            if (lnTipoCon == -1)
            {
                srt =String.Format("{0:#,##0.00}", Precio);

            }
            else if (lnTipoCon==0)
            {
                srt = simbolo+String.Format("{0:#,##0.00}", Precio);

            }else if (lnTipoCon==1)
            {

                srt = $"{simbolo} {string.Format("{0:0.00}", Precio)}";
            }
            else if (lnTipoCon==2)
            {
                srt = $"{string.Format("{0:0.00}", Precio)}";

            }
            return srt;
        }
        public static Personal fnObtenerUsuarioActual()
        {
            BLVentaGeneral blVG = new BLVentaGeneral();
            clsUtil objUtil = new clsUtil();
            Boolean bResult;
            Personal cUsuario = new Personal();
            try
            {
                cUsuario = blVG.blObtenerUsuarioActual(Variables.gnCodUser);

                return cUsuario;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return cUsuario;
            }
            finally
            {
                objUtil = null;
            }
        }
        public static List<Personal> fnObtenerUsuariosPersonal(Int32 idUsuario)
        {
            BLVentaGeneral blVG = new BLVentaGeneral();
            clsUtil objUtil = new clsUtil();
            Boolean bResult;
            List<Personal> lst = new List<Personal>();
            try
            {
                lst = blVG.blObtenerUsuariosPersonal(idUsuario);

                return lst;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return lst;
            }
            finally
            {
                objUtil = null;
            }
        }

        public static List<Moneda> fnLLenarMoneda(ComboBox cbo, Int32 idMoneda, Boolean buscar)
        {
            BLMoneda objMoneda = new BLMoneda();
            clsUtil objUtil = new clsUtil();
            List<Moneda> lstMoneda=new List<Moneda>();

            try
            {
                lstMoneda = objMoneda.blDevolverMoneda(idMoneda, buscar);
                cbo.ValueMember = "idMoneda";
                cbo.DisplayMember = "cNombre";
                cbo.DataSource = lstMoneda;

                return lstMoneda;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return lstMoneda;
            }
            finally
            {
                lstMoneda = null;
            }
        }

    }
}
