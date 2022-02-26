Imports WPF.Themes
Imports System.Windows.Markup
Imports System.ServiceModel

Public Class ucOpcion

    Private lintIdCodigoGeneral As Integer = 0
    Private lintIdAcceso As Integer = 0
    Private llstAcceso As List(Of DCAccesoProceso) = Nothing
    Public llstPedido As List(Of DCPedido)

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(ByVal pintCodigoGeneral As Integer, ByVal pintIdTipoProceso As Integer, ByVal pintIdAplicacion As Integer, ByVal plstRol As List(Of Integer), ByVal pintIdAcceso As Integer, ByVal pintIdNivel As Integer, ByVal pintIdUsuario As Integer, ByVal pblnSecuencial As Boolean, ByVal pintIdProceso As Integer, ByVal pblnIsAlert As Boolean, plstPedido As List(Of DCPedido))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ApplyTheme("WhistlerBlue")
        lintIdCodigoGeneral = pintCodigoGeneral
        lintIdAcceso = pintIdAcceso
        llstPedido = plstPedido
        fnCargarAcordion(pintIdAplicacion, plstRol, pintIdNivel, pintIdTipoProceso, pintCodigoGeneral, lintIdAcceso, pintIdUsuario, pblnSecuencial, pintIdProceso, pblnIsAlert)

    End Sub

    Public Sub fnCargarAlertRealTime(intIdActividad As Integer, objPedido As DCPedido)
        Dim grDinamico As Grid
        Dim txbPedido As TextBlock
        Dim strTexto As String
        Dispatcher.Invoke(Function()
                              Dim intIdActividadAcordion As Integer
                              Dim intTotalPedidos As Integer = 0

                              For Each item As AccordionItem In acdPrincipal.Items
                                  intIdActividadAcordion = Convert.ToInt32(item.ToolTip)
                                  If intIdActividadAcordion = intIdActividad Then
                                      fnInsertDeleteRealTime(item, objPedido, intTotalPedidos)
                                      grDinamico = CType(item.Header, Grid)
                                      txbPedido = CType(grDinamico.Children(1), TextBlock)
                                      If txbPedido.Text.IndexOf("(") > 0 Then
                                          strTexto = txbPedido.Text.Substring(0, txbPedido.Text.IndexOf("(") - 1)
                                      Else
                                          strTexto = txbPedido.Text
                                      End If

                                      txbPedido.Text = strTexto & " (" & intTotalPedidos.ToString() & ")"
                                      'item.Content = item.Content & " (" & intTotalPedidos.ToString() & ")"
                                      Exit For
                                  End If

                              Next
                          End Function)
    End Sub

    Private Function fnVerificarPedido(objPedido As DCPedido, tvwDinamicoSelector As TreeView) As TreeViewItem
        Dim codigo As String
        Dim itemHallado As TreeViewItem = Nothing

        For Each item As TreeViewItem In tvwDinamicoSelector.Items
            codigo = Convert.ToString(item.ToolTip)
            If objPedido.Codigo = codigo Then
                itemHallado = item
                Return itemHallado
                Exit For
            End If
        Next

        Return itemHallado
    End Function

    Private Sub fnInsertDeleteRealTime(pitem As AccordionItem, objPedido As DCPedido, ByRef intTotalPedido As Integer)
        Dim tvwDinamicoSelector As TreeView = TryCast(pitem.Content, TreeView)
        Dim codigo As String = 0
        Dim tviDinamico As TreeViewItem = Nothing
        Dim spLista As StackPanel = Nothing
        Dim lblTitulo As Label = Nothing
        Dim xaml As String = ""
        Dim uieNombreIcono As UIElement = Nothing
        Dim strImage As String = "&#xF071;"
        Dim itemHallado As TreeViewItem = Nothing

        'Dim context As New ParserContext
        'context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation")
        'context.XmlnsDictionary.Add("WpfTools", "clr-namespace:WpfTools;assembly=WpfTools")

        If objPedido.Codigo.Trim().Length > 0 Then

            If tvwDinamicoSelector IsNot Nothing Then

                itemHallado = fnVerificarPedido(objPedido, tvwDinamicoSelector)

                If itemHallado Is Nothing And objPedido.EventType = EventType.InsertUpdate Then
                    tviDinamico = New TreeViewItem()
                    spLista = New StackPanel
                    lblTitulo = New Label
                    spLista.Orientation = Orientation.Horizontal

                    'xaml = ("<Image  Width='16' Height='16' Source='{WpfTools:ImageFromFont Text = " & strImage & ", FontFamily=/WPF.RCSUserControl;component/Resources/#FontAwesome, Brush=Gold}'></Image>") 'Gold/CornflowerBlue/FireBrick/Orange
                    'uieNombreIcono = New UIElement
                    'uieNombreIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                    'spLista.Children.Add(uieNombreIcono)

                    lblTitulo.Content = "=> " + objPedido.Codigo
                    lblTitulo.Margin = New Thickness(5, 2, 0, 0)
                    spLista.Children.Add(lblTitulo)
                    spLista.VerticalAlignment = VerticalAlignment.Center
                    tviDinamico.Header = spLista
                    tviDinamico.Name = "tviprueba"
                    tviDinamico.ToolTip = objPedido.Codigo
                    tviDinamico.ExpandSubtree()
                    tvwDinamicoSelector.Items.Add(tviDinamico)
                ElseIf itemHallado IsNot Nothing And objPedido.EventType = EventType.Delete Then
                    tvwDinamicoSelector.Items.Remove(itemHallado)
                End If
                intTotalPedido = tvwDinamicoSelector.Items.Count()
            Else
                tvwDinamicoSelector = New TreeView()
                tviDinamico = New TreeViewItem()
                spLista = New StackPanel
                lblTitulo = New Label
                spLista.Orientation = Orientation.Horizontal

                'xaml = ("<Image  Width='16' Height='16' Source='{WpfTools:ImageFromFont Text = " & strImage & ", FontFamily=/WPF.RCSUserControl;component/Resources/#FontAwesome, Brush=Gold}'></Image>") 'Gold/CornflowerBlue/FireBrick/Orange
                'uieNombreIcono = New UIElement
                'uieNombreIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                'spLista.Children.Add(uieNombreIcono)

                lblTitulo.Content = "=> " + objPedido.Codigo
                lblTitulo.Margin = New Thickness(5, 2, 0, 0)
                spLista.Children.Add(lblTitulo)
                spLista.VerticalAlignment = VerticalAlignment.Center
                tviDinamico.Header = spLista
                tviDinamico.Name = "tvi" & "prueba"
                tviDinamico.ToolTip = objPedido.Codigo
                tviDinamico.ExpandSubtree()
                tvwDinamicoSelector.Items.Add(tviDinamico)
                pitem.Content = tvwDinamicoSelector
                intTotalPedido = tvwDinamicoSelector.Items.Count()
            End If
        End If
    End Sub

    Private Sub fnPosicionarNodo(ByVal objProcesoPendiente As DCAccesoProceso)

        Dim intIdActividad As Integer = 0
        Dim intIdActividadAcordion As Integer = 0
        Dim blnSeleccionar As Boolean = False

        If objProcesoPendiente IsNot Nothing Then

            intIdActividad = objProcesoPendiente.intIDComponente

            For Each item As AccordionItem In acdPrincipal.Items

                intIdActividadAcordion = Convert.ToInt32(item.ToolTip)

                If intIdActividadAcordion = intIdActividad Then

                    item.IsSelected = True
                    item.Focus()
                    Exit For

                Else

                    item.IsSelected = True
                    item.Focus()

                    fnPosiconarseNodoTreeview(item, intIdActividad, blnSeleccionar)

                    If blnSeleccionar = True Then
                        Exit For
                    End If

                End If

            Next

        End If

    End Sub

    Private Sub fnPosiconarseNodoTreeview(ByVal paiDinamicoSelec As AccordionItem, ByVal pintIdProcesoOpcion As Integer, ByRef pblnSeleccionarAcordion As Boolean)

        Dim tvwDinamicoSelector As TreeView = TryCast(paiDinamicoSelec.Content, TreeView)
        Dim intIdProcesoOpcionTreeview As Integer = 0

        If tvwDinamicoSelector IsNot Nothing Then

            For Each item As TreeViewItem In tvwDinamicoSelector.Items

                intIdProcesoOpcionTreeview = Convert.ToInt32(item.ToolTip)

                If pintIdProcesoOpcion = intIdProcesoOpcionTreeview Then
                    item.Focusable = True
                    item.Focus()
                    item.IsSelected = True
                    pblnSeleccionarAcordion = True
                    Exit For
                End If

                If item.Items.Count > 1 Then
                    fnPosiconarseNodoTreeviewHijo(item, pintIdProcesoOpcion, pblnSeleccionarAcordion)
                End If

            Next

        End If

    End Sub

    Private Sub fnPosiconarseNodoTreeviewHijo(ByVal ptviDinamico As TreeViewItem, ByVal pintIdProcesoOpcion As Integer, ByRef pblnSeleccionarAcordion As Boolean)

        Dim intIdProcesoOpcionTreeview As Integer = 0

        For Each item As TreeViewItem In ptviDinamico.Items

            intIdProcesoOpcionTreeview = Convert.ToInt32(item.ToolTip)

            If pintIdProcesoOpcion = intIdProcesoOpcionTreeview Then
                item.Focusable = True
                item.Focus()
                item.IsSelected = True
                pblnSeleccionarAcordion = True
                Exit For
            End If

            If item.Items.Count > 1 Then
                fnPosiconarseNodoTreeviewHijo(item, pintIdProcesoOpcion, pblnSeleccionarAcordion)
            End If

        Next

    End Sub

    Private Sub fnLLenarhijo(ByVal ptvwdinamico As TreeView, ByVal plstAcceso As List(Of DCAccesoProceso), ByVal ptviDinamico As TreeViewItem, ByVal pintIdOpcionSup As Integer, ByVal pblnSecuencial As Boolean)
        Dim lstOpcionHijo As List(Of DCAccesoProceso) = Nothing
        Dim tviHijo As TreeViewItem = Nothing
        Dim spLista As StackPanel = Nothing
        Dim lblTitulo As Label = Nothing
        Dim xaml As String = ""
        Dim uieNombreIcono As UIElement = Nothing
        Dim uieProcesoIcono As UIElement = Nothing

        lstOpcionHijo = plstAcceso.FindAll(Function(x) x.intIDOpcionSup = pintIdOpcionSup)

        If lstOpcionHijo.Count > 0 Then

            Dim context As New ParserContext
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation")
            context.XmlnsDictionary.Add("WpfTools", "clr-namespace:WpfTools;assembly=WpfTools")

            For Each objOpcion As DCAccesoProceso In lstOpcionHijo

                tviHijo = New TreeViewItem
                spLista = New StackPanel
                lblTitulo = New Label
                spLista.Orientation = Orientation.Horizontal

                xaml = ("<Image  Width='16' Height='16' Source='{WpfTools:ImageFromFont Text = " & objOpcion.strImage & ", FontFamily=/WPF.RCSUserControl;component/Resources/#FontAwesome, Brush=" & objOpcion.strColorImage & "}'></Image>") 'Gold/CornflowerBlue/FireBrick/Orange
                uieNombreIcono = New UIElement
                uieNombreIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                spLista.Children.Add(uieNombreIcono)

                If pblnSecuencial = True Then
                    xaml = ("<Image  Width='12' Height='12' Margin='10,0,0,0' Source='{WpfTools:ImageFromFont Text = " & objOpcion.strProcesoIcono & ", FontFamily=/WPF.RCSUserControl;component/Resources/#FontAwesome, Brush=" & objOpcion.strProcesoColor & "}'></Image>") 'Gold/CornflowerBlue/FireBrick/Orange
                    uieProcesoIcono = New UIElement
                    uieProcesoIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                    spLista.Children.Add(uieProcesoIcono)
                End If

                lblTitulo.Content = objOpcion.strNombre
                spLista.Children.Add(lblTitulo)
                tviHijo.Header = spLista
                tviHijo.Name = "tvi" & objOpcion.intIDOpcion.ToString
                tviHijo.DataContext = objOpcion.intIdRegla
                tviHijo.Tag = objOpcion.strRutaFormulario
                tviHijo.ToolTip = objOpcion.intIDComponente
                tviHijo.ExpandSubtree()
                ptviDinamico.Items.Add(tviHijo)
                fnLLenarhijo(ptvwdinamico, lstOpcionHijo, tviHijo, objOpcion.intIDOpcion, pblnSecuencial)

            Next

        End If

    End Sub

    Private Function fnListarAccesoProceso() As List(Of DCAccesoProceso)

        Dim lstOpcion As New List(Of DCAccesoProceso)
        Dim objOpcion As New DCAccesoProceso

        objOpcion.blnEsPadre = True
        objOpcion.blnOperatividad = False
        objOpcion.intIDAcceso = 1
        objOpcion.blnVisibleMDI = True
        objOpcion.intIDComponente = 1
        objOpcion.intidFormulario = 1
        objOpcion.intIDModulo = 1
        objOpcion.intIDOpcion = 1
        objOpcion.intIDOpcionSup = 0
        objOpcion.intIdRegla = 1
        objOpcion.intTipo = 1
        objOpcion.strColorImage = "Gold"
        objOpcion.strDescripcion = "Alerta de Pedidos"
        objOpcion.strImage = "&#xF071;"
        objOpcion.strNombre = "Alerta de Pedido"
        objOpcion.strProcesoColor = "white"
        objOpcion.strProcesoIcono = ""
        objOpcion.strRutaFormulario = ""

        lstOpcion.Add(objOpcion)

        objOpcion = New DCAccesoProceso
        objOpcion.blnEsPadre = True
        objOpcion.blnOperatividad = False
        objOpcion.intIDAcceso = 2
        objOpcion.blnVisibleMDI = True
        objOpcion.intIDComponente = 1
        objOpcion.intidFormulario = 2
        objOpcion.intIDModulo = 1
        objOpcion.intIDOpcion = 2
        objOpcion.intIDOpcionSup = 0
        objOpcion.intIdRegla = 2
        objOpcion.intTipo = 1
        objOpcion.strColorImage = "Green"
        objOpcion.strDescripcion = "Alerta de Cobros"
        objOpcion.strImage = "&#xF0D6;"
        objOpcion.strNombre = "Alerta de Cobro"
        objOpcion.strProcesoColor = ""
        objOpcion.strProcesoIcono = ""
        objOpcion.strRutaFormulario = ""

        lstOpcion.Add(objOpcion)

        Return lstOpcion
    End Function

    Private Sub fnCargarHijoAlert(grdDinamico As Grid, ByRef tvwDinamico As TreeView, lstPedido As List(Of DCPedido))
        Dim tviDinamico As TreeViewItem = Nothing
        Dim spLista As StackPanel = Nothing
        Dim lblTitulo As Label = Nothing
        Dim xaml As String = ""
        Dim uieNombreIcono As UIElement = Nothing
        Dim uieProcesoIcono As UIElement = Nothing
        Dim tvwDinamicoHijo As TreeView

        If lstPedido.Count > 0 Then
            tvwDinamicoHijo = New TreeView
            Dim intcontador As Integer = 0

            For Each objOpcionHijo As DCPedido In lstPedido
                tviDinamico = New TreeViewItem()
                spLista = New StackPanel
                lblTitulo = New Label
                spLista.Orientation = Orientation.Horizontal

                lblTitulo.Content = objOpcionHijo.Codigo
                lblTitulo.Margin = New Thickness(5, 2, 0, 0)
                spLista.Children.Add(lblTitulo)
                spLista.VerticalAlignment = VerticalAlignment.Center
                tviDinamico.Header = spLista
                tviDinamico.Name = "tvi" & intcontador.ToString()
                tviDinamico.ToolTip = objOpcionHijo.Codigo
                tviDinamico.ExpandSubtree()
                tvwDinamicoHijo.Items.Add(tviDinamico)
                intcontador = intcontador + 1
            Next

        Else
            tvwDinamicoHijo = Nothing
        End If

        tvwDinamico = tvwDinamicoHijo

    End Sub

    Public Sub fnCargarAcordion(ByVal pintIdAplicacion As Integer, ByVal plstRol As List(Of Integer), ByVal pintIdNivel As Integer, ByVal pintIdTipoProceso As Integer, ByVal pintCodigoGeneral As Integer, ByVal pintIdAcceso As Integer, pintIdUsuario As Integer, ByVal pblnSecuencial As Boolean, ByVal pintIdProceso As Integer, ByVal pblnAlert As Boolean)

        Dim lstOpcion As New List(Of DCAccesoProceso)
        Dim lstOpcionHijo As New List(Of DCAccesoProceso)
        Dim aiDinamico As AccordionItem = Nothing
        Dim txbItem As TextBlock = Nothing
        Dim txbItem2 As TextBlock = Nothing
        Dim grdDinamico As Grid = Nothing
        Dim gridRow As RowDefinition = Nothing
        Dim gridCol1 As ColumnDefinition = Nothing
        Dim gridCol2 As ColumnDefinition = Nothing
        Dim gridCol3 As ColumnDefinition = Nothing
        Dim gridRow1 As RowDefinition = Nothing
        Dim tvwDinamico As TreeView = Nothing
        Dim tviDinamico As TreeViewItem = Nothing
        Dim intFila As Integer = 0
        Dim spLista As StackPanel = Nothing
        Dim lblTitulo As Label = Nothing
        Dim xaml As String = ""
        Dim uieNombreIcono As UIElement = Nothing
        Dim uieProcesoIcono As UIElement = Nothing
        Dim context As New ParserContext
        Dim objProcesoPendiente As DCAccesoProceso = Nothing

        Try
            acdPrincipal.Items.Clear()
            llstAcceso = fnListarAccesoProceso()

            If llstAcceso IsNot Nothing Then

                If llstAcceso.Count > 0 Then

                    lstOpcion = llstAcceso.FindAll(Function(x) x.intIDOpcionSup = 0)
                    objProcesoPendiente = llstAcceso.Find(Function(x) x.strProcesoColor = "IndianRed" And x.blnEsPadre = False)
                    acdPrincipal.Items.Clear()
                    context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation")
                    context.XmlnsDictionary.Add("WpfTools", "clr-namespace:WpfTools;assembly=WpfTools")

                    For Each objOpcion As DCAccesoProceso In lstOpcion

                        grdDinamico = New Grid
                        gridRow = New RowDefinition
                        gridCol1 = New ColumnDefinition
                        gridCol2 = New ColumnDefinition
                        gridCol3 = New ColumnDefinition
                        gridCol1.Width = GridLength.Auto
                        gridCol2.Width = GridLength.Auto
                        gridCol3.Width = GridLength.Auto
                        gridCol2.Name = "grc" & objOpcion.intIDOpcion.ToString
                        gridCol2.DataContext = objOpcion.intIdRegla
                        gridCol2.Tag = objOpcion.strRutaFormulario
                        gridCol2.ToolTip = objOpcion.intIDComponente
                        grdDinamico.HorizontalAlignment = HorizontalAlignment.Left
                        grdDinamico.VerticalAlignment = VerticalAlignment.Center
                        grdDinamico.ColumnDefinitions.Add(gridCol1)
                        grdDinamico.ColumnDefinitions.Add(gridCol2)
                        grdDinamico.ColumnDefinitions.Add(gridCol3)
                        gridRow1 = New RowDefinition()
                        gridRow1.Height = GridLength.Auto
                        grdDinamico.RowDefinitions.Add(gridRow1)

                        xaml = ("<Image  Width='32' Height='32'  Source='{WpfTools:ImageFromFont Text = " & objOpcion.strImage & ", FontFamily=/WPF.CTRL.Colocaciones;component/Resources/#FontAwesome, Brush=" & objOpcion.strColorImage & "}'></Image>") 'RoyalBlue/Goldenrod/Brown/DarkOrange
                        uieNombreIcono = New UIElement
                        uieNombreIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                        grdDinamico.Children.Add(uieNombreIcono)
#Disable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
                        grdDinamico.SetColumn(uieNombreIcono, 0)
#Enable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia

                        If pblnSecuencial = True Then

                            xaml = ("<Image  Width='16' Height='16' Margin='5,0,0,0'  Source='{WpfTools:ImageFromFont Text =" & objOpcion.strProcesoIcono & ", FontFamily=/WPF.CTRL.Colocaciones;component/Resources/#FontAwesome, Brush=" & objOpcion.strProcesoColor & "}'></Image>") 'RoyalBlue/Goldenrod/Brown/DarkOrange
                            uieProcesoIcono = New UIElement
                            uieProcesoIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                            grdDinamico.Children.Add(uieProcesoIcono)

#Disable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
                            grdDinamico.SetColumn(uieProcesoIcono, 1)
#Enable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia

                        End If

                        txbItem = New TextBlock
                        txbItem.Text = objOpcion.strNombre
                        txbItem.Padding = New Thickness(2, 10, 0, 0)
                        grdDinamico.Children.Add(txbItem)

#Disable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
                        grdDinamico.SetColumn(txbItem, 2)
#Enable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia

                        If (pblnAlert And objOpcion.intIDOpcion = 1) Then
                            tvwDinamico = New TreeView
                            fnCargarHijoAlert(grdDinamico, tvwDinamico, llstPedido)
                        Else
                            lstOpcionHijo = llstAcceso.FindAll(Function(x) x.intIDOpcionSup = objOpcion.intIDOpcion)

                            If lstOpcionHijo.Count > 0 Then

                                tvwDinamico = New TreeView

                                For Each objOpcionHijo As DCAccesoProceso In lstOpcionHijo

                                    tviDinamico = New TreeViewItem()
                                    spLista = New StackPanel
                                    lblTitulo = New Label
                                    spLista.Orientation = Orientation.Horizontal

                                    xaml = ("<Image  Width='16' Height='16' Source='{WpfTools:ImageFromFont Text = " & objOpcionHijo.strImage & ", FontFamily=/WPF.CTRL.Colocaciones;component/Resources/#FontAwesome, Brush=" & objOpcionHijo.strColorImage & "}'></Image>") 'Gold/CornflowerBlue/FireBrick/Orange
                                    uieNombreIcono = New UIElement
                                    uieNombreIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                                    spLista.Children.Add(uieNombreIcono)

                                    If pblnSecuencial = True Then
                                        xaml = ("<Image  Width='12' Height='12' Margin='10,0,0,0' Source='{WpfTools:ImageFromFont Text = " & objOpcionHijo.strProcesoIcono & ", FontFamily=/WPF.CTRL.Colocaciones;component/Resources/#FontAwesome, Brush=" & objOpcionHijo.strProcesoColor & "}'></Image>") 'Gold/CornflowerBlue/FireBrick/Orange
                                        uieProcesoIcono = New UIElement
                                        uieProcesoIcono = TryCast(XamlReader.Parse(xaml, context), UIElement)
                                        spLista.Children.Add(uieProcesoIcono)
                                    End If

                                    lblTitulo.Content = objOpcionHijo.strNombre
                                    lblTitulo.Margin = New Thickness(5, 2, 0, 0)
                                    spLista.Children.Add(lblTitulo)
                                    spLista.VerticalAlignment = VerticalAlignment.Center
                                    tviDinamico.Header = spLista
                                    tviDinamico.Name = "tvi" & objOpcionHijo.intIDOpcion.ToString
                                    tviDinamico.DataContext = objOpcionHijo.intIdRegla
                                    tviDinamico.Tag = objOpcionHijo.strRutaFormulario
                                    tviDinamico.ToolTip = objOpcionHijo.intIDComponente
                                    tviDinamico.ExpandSubtree()
                                    tvwDinamico.Items.Add(tviDinamico)
                                    fnLLenarhijo(tvwDinamico, llstAcceso, tviDinamico, objOpcionHijo.intIDOpcion, pblnSecuencial)

                                Next

                            Else

                                tvwDinamico = Nothing

                            End If
                        End If

                        aiDinamico = New AccordionItem
                        aiDinamico.Name = "aiDinamico" & intFila
                        aiDinamico.Header = grdDinamico
                        aiDinamico.Content = tvwDinamico
                        aiDinamico.ToolTip = 1
                        aiDinamico.VerticalAlignment = VerticalAlignment.Center
                        acdPrincipal.Items.Add(aiDinamico)
                        intFila = intFila + 1

                    Next

                    If objProcesoPendiente IsNot Nothing Then
                        fnPosicionarNodo(objProcesoPendiente)
                    End If

                End If

            End If

        Catch ex As CommunicationException

            'lobjSRVConfig.FinalizarErr()
            MessageBox.Show("Fallo en la comunicación con el Servicio", "Aviso Importante", MessageBoxButton.OK, MessageBoxImage.Error)

        Catch ex As TimeoutException

            'lobjSRVConfig.FinalizarErr()
            MessageBox.Show("Se agoto el tiempo de respuesta de la operación.", "Aviso Importante", MessageBoxButton.OK, MessageBoxImage.Error)

        Catch ex As Exception

            'lobjSRVConfig.FinalizarErr()
            MessageBox.Show("Error no controlado. Comunicar a TI", "Aviso Importante", MessageBoxButton.OK, MessageBoxImage.Error)

        End Try

    End Sub

End Class
