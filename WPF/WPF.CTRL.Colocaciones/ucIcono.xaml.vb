
Imports FontAwesome.WPF

Public Class ucIcono

    Public strIconoSeleccionado As String = ""

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub FilterText_OnTextChanged(sender As Object, e As TextChangedEventArgs)
        CollectionViewSource.GetDefaultView(lwvIcono.ItemsSource).Refresh()
    End Sub

    Private Sub CollectionViewSource_Filter(sender As Object, e As FilterEventArgs)

        Dim Icon As IconDescription = CType(e.Item, IconDescription)

        If (Icon Is Nothing) Then Return
        e.Accepted = Icon.Description.ToLower().Contains(txtFiltro.Text.ToLower())

    End Sub

    Private Sub lwvIcono_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles lwvIcono.SelectionChanged

        Dim icdIcono As IconDescription = Nothing
        Dim intIdIcono As Integer = 0

        strIconoSeleccionado = ""

        If e.OriginalSource IsNot Nothing Then

            Dim lvwListaIcono As ListView = CType(e.OriginalSource, ListView)

            If lvwListaIcono.SelectedItem IsNot Nothing Then

                icdIcono = CType(lvwListaIcono.SelectedItem, IconDescription)
                intIdIcono = Convert.ToInt32(icdIcono.Icon)
                strIconoSeleccionado = "&#x" & intIdIcono.ToString("X") & ";"

            End If

        End If

    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        txtFiltro.Focus()
    End Sub
End Class
