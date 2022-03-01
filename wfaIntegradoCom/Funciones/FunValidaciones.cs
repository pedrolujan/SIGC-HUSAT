using Guna.UI.WinForms;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaIntegradoCom.Funciones
{
    public class FunValidaciones
    {

        public static Tuple<Boolean, String> fnValidarCombobox(SiticoneComboBox cbo, Label lbl, PictureBox img)
        {
            String msj;

            if (cbo.SelectedIndex == 0 || cbo.SelectedIndex == -1 || cbo.SelectedIndex == null)
            {
                img.Image = Properties.Resources.error;


                lbl.ForeColor = Variables.ColorError;

                msj = "Seleccione una opción";
                lbl.Text = msj;
                return Tuple.Create(false, msj);

            }
            else
            {

                img.Image = Properties.Resources.ok;

                lbl.ForeColor = Variables.ColorSuccess;
                msj = "";
                lbl.Text = msj;
                return Tuple.Create(true, msj);


            }
        }
        public static Tuple<Boolean, String> fnValidarTexbox(GunaTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num, String msjError)
        {
            String msj;

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = Properties.Resources.error;

                lbl.ForeColor = Variables.ColorError;
                msj = "Complete los datos (campo obligatorio)";
                lbl.Text = msj;

                return Tuple.Create(false, msj);

            }
            else if (maximo)
            {
                if (txt.Text.Length >= num)
                {
                    img.Image = Properties.Resources.ok;

                    lbl.ForeColor = Variables.ColorSuccess;
                    msj = "";
                    lbl.Text = msj;

                    return Tuple.Create(true, msj);

                }
                else
                {
                    img.Image = Properties.Resources.error;

                    lbl.ForeColor = Variables.ColorError;
                    msj = msjError;
                    lbl.Text = msj;

                    return Tuple.Create(false, msj);

                }
            }
            else
            {
                img.Image = Properties.Resources.ok;

                lbl.ForeColor = Variables.ColorSuccess;
                msj = "";
                lbl.Text = msj;

                return Tuple.Create(true, msj);
            }

        }

        public static void fnValidarTipografia(KeyPressEventArgs e, String tipo, Boolean mayusculas, Label lbl)
        {
            switch (tipo)
            {
                case "LETRAS":
                    if (mayusculas)
                    {
                        e.KeyChar = char.ToUpper(e.KeyChar);
                        if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                        {
                            e.Handled = false;



                        }
                        else
                        {
                            e.Handled = true;
                            lbl.Text = "Solo Letras";
                            lbl.ForeColor = Variables.ColorSuccess;
                        }
                    }
                    else
                    {
                        e.KeyChar = char.ToLower(e.KeyChar);
                        if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                        {
                            e.Handled = false;


                        }
                        else
                        {
                            e.Handled = true;
                            lbl.Text = "Solo Letras";
                            lbl.ForeColor = Variables.ColorSuccess;
                        }
                    }
                    break;

                case "NUMEROS":
                    if ((Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        lbl.Text = "Solo números";
                        lbl.ForeColor = Variables.ColorSuccess;
                    }
                    break;
                case "MONEDA":
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsNumber(e.KeyChar))
                         || (Char.IsControl(e.KeyChar) || (e.KeyChar == ',')))
                    {
                        e.Handled = false;
                    }

                    else
                    {
                        e.Handled = true;
                        lbl.Text = "Solo números y (,)";
                        lbl.ForeColor = Variables.ColorSuccess;
                    }
                    break;

                case "CORREO":
                    if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar))
                    || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar))
                    || (e.KeyChar == '@') || (e.KeyChar == '_') || (e.KeyChar == '.'))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        lbl.Text = "Solo letras, numeros y (@ _ .)";
                        lbl.ForeColor = Variables.ColorSuccess;
                    }
                    break;
                case "DIRECCION":
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    else
                    {

                        e.Handled = true;
                        lbl.Text = "Solo letras y números";
                        lbl.ForeColor = Variables.ColorSuccess;
                    }
                    break;
                case "LENUMCARAC":
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar) || (e.KeyChar == '.') || (e.KeyChar == ',') || (e.KeyChar == '-') || (e.KeyChar == '+')))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        lbl.Text = "Solo numeros, letras y (. , - +)";
                        lbl.ForeColor = Variables.ColorSuccess;
                    }
                    break;

            }

        }
        public static void fnValidarTipografia(KeyPressEventArgs e, String tipo, Boolean mayusculas)
        {
            switch (tipo)
            {
                case "LETRAS":
                    if (mayusculas)
                    {
                        e.KeyChar = char.ToUpper(e.KeyChar);
                        if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                        {
                            e.Handled = true;

                        }
                        else
                        {
                            e.Handled = false;

                        }
                    }
                    else
                    {
                        e.KeyChar = char.ToLower(e.KeyChar);
                        if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                        {
                            e.Handled = false;


                        }
                        else
                        {
                            e.Handled = true;

                        }
                    }
                    break;

                case "NUMEROS":
                    if ((Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;

                    }
                    break;
                case "MONEDA":
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsNumber(e.KeyChar))
                         || (Char.IsControl(e.KeyChar) || (e.KeyChar == '.')))
                    {
                        e.Handled = false;
                    }

                    else
                    {
                        e.Handled = true;


                    }
                    break;

                case "CORREO":
                    if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar))
                    || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar))
                    || (e.KeyChar == '@') || (e.KeyChar == '_') || (e.KeyChar == '.'))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;

                    }
                    break;
                case "DIRECCION":
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    else
                    {

                        e.Handled = true;

                    }
                    break;
                case "LENUMCARAC":
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar) || (e.KeyChar == '.') || (e.KeyChar == ',') || (e.KeyChar == '-') || (e.KeyChar == '+')))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;

                    }
                    break;

            }

        }

        public static void fnHabilitarBoton(SiticoneButton btn, Boolean estado)
        {
            btn.Enabled = estado;

        }

        public static void fnColorBotones(SiticoneButton btnNuevo, SiticoneButton btnEditar, SiticoneButton btnGuardar, SiticoneButton btnSalir)
        {
            btnNuevo.FillColor = Color.White;
            btnNuevo.BorderColor = Variables.ColorEmpresa;
            btnNuevo.ForeColor = Variables.ColorEmpresa;
            btnNuevo.Image = Properties.Resources.nuevo_base;

            btnNuevo.HoveredState.FillColor = Variables.ColorEmpresa;
            btnNuevo.HoveredState.Image = Properties.Resources.nuevo_hover;
            btnNuevo.HoveredState.ForeColor = Color.White;

            btnEditar.FillColor = Color.White;
            btnEditar.BorderColor = Variables.ColorEmpresa;
            btnEditar.ForeColor = Variables.ColorEmpresa;
            btnEditar.Image = Properties.Resources.editar_base;

            btnEditar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnEditar.HoveredState.Image = Properties.Resources.editar_hover;
            btnEditar.HoveredState.ForeColor = Color.White;

            btnGuardar.FillColor = Color.White;
            btnGuardar.BorderColor = Variables.ColorEmpresa;
            btnGuardar.ForeColor = Variables.ColorEmpresa;
            btnGuardar.Image = Properties.Resources.guardar_base;

            btnGuardar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnGuardar.HoveredState.Image = Properties.Resources.guardar_hover;
            btnGuardar.HoveredState.ForeColor = Color.White;

            btnSalir.FillColor = Color.White;
            btnSalir.BorderColor = Variables.ColorEmpresa;
            btnSalir.ForeColor = Variables.ColorEmpresa;
            btnSalir.Image = Properties.Resources.salir_base;

            btnSalir.HoveredState.FillColor = Variables.ColorEmpresa;
            btnSalir.HoveredState.Image = Properties.Resources.salir_hover;
            btnSalir.HoveredState.ForeColor = Color.White;

            btnNuevo.PressedColor = Color.White;
            btnEditar.PressedColor = Color.White;
            btnGuardar.PressedColor = Color.White;
            btnSalir.PressedColor = Color.White;

        }

        public static Tuple<Boolean, String> fnValidarTexboxs(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean obligatorio, Boolean letras, Boolean minimo, Int32 numMenor, Int32 numMayor, Int32 NumCaract, Int32 MaxLength, String msjError)
        {
            String msj;

            if (obligatorio)
            {
                if (letras)
                {

                    if (txt.Text == null || txt.Text.Trim() == "")
                    {
                        img.Image = Properties.Resources.error;

                        lbl.ForeColor = Variables.ColorError;
                        msj = "Complete los datos (campo obligatorio)";
                        lbl.Text = msj;
                        txt.FocusedState.BorderColor = Variables.ColorError;

                        return Tuple.Create(false, msj);

                    }
                    else
                    {

                        if (minimo)
                        {
                            txt.MaxLength = MaxLength;
                            if (txt.Text.Length >= numMenor && txt.Text.Length <= numMayor)
                            {
                                img.Image = Properties.Resources.ok;

                                lbl.ForeColor = Variables.ColorSuccess;
                                txt.FocusedState.BorderColor = Variables.ColorSuccess;

                                msj = "";
                                lbl.Text = msj;

                                return Tuple.Create(true, msj);

                            }
                            else
                            {
                                img.Image = Properties.Resources.error;

                                lbl.ForeColor = Variables.ColorError;
                                txt.FocusedState.BorderColor = Variables.ColorError;
                                msj = msjError;
                                lbl.Text = msj;

                                return Tuple.Create(false, msj);

                            }
                        }
                        else
                        {
                            img.Image = Properties.Resources.ok;

                            lbl.ForeColor = Variables.ColorSuccess;
                            txt.FocusedState.BorderColor = Variables.ColorSuccess;
                            msj = "";
                            lbl.Text = msj;

                            return Tuple.Create(true, msj);
                        }

                    }

                }
                else
                {

                    if (txt.Text == null || txt.Text.Trim() == "")
                    {
                        img.Image = Properties.Resources.error;

                        lbl.ForeColor = Variables.ColorError;
                        txt.FocusedState.BorderColor = Variables.ColorError;
                        msj = "Ingrese datos (campo obligatorio)";
                        lbl.Text = msj;

                        return Tuple.Create(false, msj);

                    }
                    else
                    {

                        if (minimo)
                        {
                            String texto = (txt.Text.Trim().ToString());
                            Int32 repetido = texto.Split(',').Length - 1;
                            if (repetido <= 1)
                            {
                                Double numCaja = Convert.ToDouble(texto);
                                txt.MaxLength = MaxLength;
                                if (numCaja >= numMenor & numCaja <= numMayor)
                                {
                                    img.Image = Properties.Resources.ok;
                                    txt.FocusedState.BorderColor = Variables.ColorSuccess;
                                    msj = "";
                                    lbl.Text = msj;

                                    return Tuple.Create(true, msj);

                                }
                                else
                                {
                                    img.Image = Properties.Resources.error;

                                    lbl.ForeColor = Variables.ColorError;
                                    txt.FocusedState.BorderColor = Variables.ColorError;
                                    msj = msjError;
                                    lbl.Text = msj;

                                    return Tuple.Create(false, msj);

                                }
                            }
                            else
                            {
                                img.Image = Properties.Resources.error;

                                lbl.ForeColor = Variables.ColorError;
                                txt.FocusedState.BorderColor = Variables.ColorError;
                                msj = "Ingrese correctamente el campo";
                                lbl.Text = msj;

                                return Tuple.Create(false, msj);
                            }

                        }
                        else
                        {

                            img.Image = Properties.Resources.ok;
                            txt.FocusedState.BorderColor = Variables.ColorSuccess;
                            msj = "";
                            lbl.Text = msj;

                            return Tuple.Create(true, msj);

                        }

                    }

                }
            }
            else
            {

                txt.MaxLength = MaxLength;
                if (txt.Text == null || txt.Text.Trim() == "")
                {
                    img.Image = null;
                    msj = "vacio (campo no obligatorio)";
                    lbl.Text = msj;
                    lbl.ForeColor = Variables.ColorSuccess;
                    txt.FocusedState.BorderColor = Variables.ColorSuccess;

                    return Tuple.Create(true, msj);
                }
                else
                {

                    if (txt.Text.Length > 0)
                    {
                        if (txt.Text.Length >= NumCaract)
                        {
                            img.Image = Properties.Resources.ok;
                            txt.FocusedState.BorderColor = Variables.ColorSuccess;
                            msj = "";
                            lbl.Text = msj;

                            return Tuple.Create(true, msj);

                        }
                        else
                        {
                            img.Image = Properties.Resources.error;
                            txt.FocusedState.BorderColor = Variables.ColorError;
                            msj = msjError;
                            lbl.Text = msj;
                            lbl.ForeColor = Variables.ColorError;


                            return Tuple.Create(false, msj);
                        }
                    }
                    else
                    {
                        img.Image = Properties.Resources.error;
                        txt.FocusedState.BorderColor = Variables.ColorError;
                        msj = "Ocurrió otro error";
                        lbl.Text = msj;
                        lbl.ForeColor = Variables.ColorError;
                        return Tuple.Create(false, msj);
                    }

                }
            }



        }

        public static Tuple<Boolean, String> fnValidarElementoExistente(SiticoneTextBox txt, Label lbl, PictureBox img, Int32 NumCaract, Int32 numResult, String msj)
        {
            if (numResult == 1)
            {
                img.Image = Properties.Resources.error;
                txt.FocusedState.BorderColor = Variables.ColorError;
                lbl.Text = msj;
                lbl.ForeColor = Variables.ColorError;
                return Tuple.Create(false, msj);
            }
            else
            {
                msj = "";
                img.Image = Properties.Resources.ok;
                txt.FocusedState.BorderColor = Variables.ColorError;
                lbl.Text = msj;
                lbl.ForeColor = Variables.ColorError;
                return Tuple.Create(true, msj);
            }

        }
        public static void fnValidarEstado(GunaWinSwitch sw, Label lbl)
        {
            if (sw.Checked == true)
            {

                lbl.Text = "Activado";
                lbl.ForeColor = Variables.ColorSuccess;
                sw.CheckedOnColor = Variables.ColorSuccess;


            }
            else
            {

                lbl.Text = "Desactivado";
                lbl.ForeColor = Variables.ColorError;
                sw.CheckedOffColor = Variables.ColorError;
            }
        }

        public static void fnMostrarCantidadBusquedas(SiticoneCircleButton btn, Label lbl, Int32 numero, Boolean estado, String msj)
        {
            btn.Text = Convert.ToString(numero);
            lbl.Text = msj;
            btn.Visible = estado;
            lbl.Visible = estado;

        }

        public static void fnFormatoCelular(KeyPressEventArgs e, SiticoneTextBox txt)
        {
            Int32 cursorPos = txt.Text.Length;


            if (cursorPos == 3 && !(Char.IsControl(e.KeyChar)))
            {
                txt.Text = txt.Text.Insert(cursorPos, "-");
                txt.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 7 && !(Char.IsControl(e.KeyChar)))
            {
                txt.Text = txt.Text.Insert(cursorPos, "-");
                txt.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 11 && !(Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static void fnColorBoton2(SiticoneButton btnNuevo,SiticoneButton btnGuardar)
        {
            btnNuevo.FillColor = Color.White;
            btnNuevo.BorderColor = Variables.ColorEmpresa;
            btnNuevo.ForeColor = Variables.ColorEmpresa;
            btnNuevo.Image = Properties.Resources.nuevo_base;

            btnNuevo.HoveredState.FillColor = Variables.ColorEmpresa;
            btnNuevo.HoveredState.Image = Properties.Resources.nuevo_hover;
            btnNuevo.HoveredState.ForeColor = Color.White;

            btnGuardar.FillColor = Color.White;
            btnGuardar.BorderColor = Variables.ColorEmpresa;
            btnGuardar.ForeColor = Variables.ColorEmpresa;
            btnGuardar.Image = Properties.Resources.guardar_base;

            btnGuardar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnGuardar.HoveredState.Image = Properties.Resources.guardar_hover;
            btnGuardar.HoveredState.ForeColor = Color.White;

            btnNuevo.PressedColor = Color.White;
            btnGuardar.PressedColor = Color.White;

        }
        public static void fnColorAceptarCancelar(SiticoneButton btnGuardar, SiticoneButton btnCancelar)
        {
            btnGuardar.FillColor = Color.White;
            btnGuardar.BorderColor = Variables.ColorEmpresa;
            btnGuardar.ForeColor = Variables.ColorEmpresa;
            btnGuardar.Image = Properties.Resources.guardar_base;

            btnGuardar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnGuardar.HoveredState.Image = Properties.Resources.guardar_hover;
            btnGuardar.HoveredState.ForeColor = Color.White;

            btnCancelar.FillColor = Color.White;
            btnCancelar.BorderColor = Variables.ColorEmpresa;
            btnCancelar.ForeColor = Variables.ColorEmpresa;
            btnCancelar.Image = Properties.Resources.atras_base;

            btnCancelar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnCancelar.HoveredState.Image = Properties.Resources.atras_hover;
            btnCancelar.HoveredState.ForeColor = Color.White;

            btnGuardar.PressedColor = Color.White;
            btnCancelar.PressedColor = Color.White;

        }
        public static void fnColorBtnGuardar(SiticoneButton btnGuardar)
        {
            btnGuardar.FillColor = Color.White;
            btnGuardar.BorderColor = Variables.ColorEmpresa;
            btnGuardar.ForeColor = Variables.ColorEmpresa;
            btnGuardar.Image = Properties.Resources.guardar_base;

            btnGuardar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnGuardar.HoveredState.Image = Properties.Resources.guardar_hover;
            btnGuardar.HoveredState.ForeColor = Color.White;

            btnGuardar.PressedColor = Color.White; 
            

        }
        public static void fnColorBotonEspecifico(SiticoneButton btnNuevo)
        {
            btnNuevo.FillColor = Color.White;
            btnNuevo.BorderColor = Variables.ColorEmpresa;
            btnNuevo.ForeColor = Variables.ColorEmpresa;
            btnNuevo.Image = Properties.Resources.nuevo_base;

            btnNuevo.HoveredState.FillColor = Variables.ColorEmpresa;
            btnNuevo.HoveredState.Image = Properties.Resources.nuevo_hover;
            btnNuevo.HoveredState.ForeColor = Color.White;
        }

        public static void fnColorTresBotones(SiticoneButton btnNuevo, SiticoneButton btnEditar, SiticoneButton btnGuardar)
        {
            btnNuevo.FillColor = Color.White;
            btnNuevo.BorderColor = Variables.ColorEmpresa;
            btnNuevo.ForeColor = Variables.ColorEmpresa;
            btnNuevo.Image = Properties.Resources.nuevo_base;

            btnNuevo.HoveredState.FillColor = Variables.ColorEmpresa;
            btnNuevo.HoveredState.Image = Properties.Resources.nuevo_hover;
            btnNuevo.HoveredState.ForeColor = Color.White;

            btnEditar.FillColor = Color.White;
            btnEditar.BorderColor = Variables.ColorEmpresa;
            btnEditar.ForeColor = Variables.ColorEmpresa;
            btnEditar.Image = Properties.Resources.editar_base;

            btnEditar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnEditar.HoveredState.Image = Properties.Resources.editar_hover;
            btnEditar.HoveredState.ForeColor = Color.White;

            btnGuardar.FillColor = Color.White;
            btnGuardar.BorderColor = Variables.ColorEmpresa;
            btnGuardar.ForeColor = Variables.ColorEmpresa;
            btnGuardar.Image = Properties.Resources.guardar_base;

            btnGuardar.HoveredState.FillColor = Variables.ColorEmpresa;
            btnGuardar.HoveredState.Image = Properties.Resources.guardar_hover;
            btnGuardar.HoveredState.ForeColor = Color.White;

            btnNuevo.PressedColor = Color.White;
            btnEditar.PressedColor = Color.White;
            btnGuardar.PressedColor = Color.White;

        }

        public static void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados, ComboBox cboPag, SiticoneCircleButton btnTotPag, SiticoneCircleButton btnNumFil, SiticoneCircleButton btnTotReg)
        {
            Int32 residuo;
            Int32 cantidadPaginas;
            residuo = totalRegistros % filas;
            if (residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }

            cboPag.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPag.Items.Add(i);

            }

            cboPag.SelectedIndex = 0;
            btnTotPag.Text = Convert.ToString(cantidadPaginas);
            btnNumFil.Text = Convert.ToString(totalResultados);
            btnTotReg.Text = Convert.ToString(totalRegistros);

        }

        public static Int32 fnObtenerIdDeComboBox(ComboBox cbo)
        {
            Int32 id = 0;
            id = Convert.ToInt32(cbo.SelectedValue ?? 0);
            return id;
        }
    }
}
