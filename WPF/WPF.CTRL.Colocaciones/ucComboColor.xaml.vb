Imports System.Reflection

Public Class ucComboColor
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        fnLLenarColorCombo()

    End Sub

    Private Sub fnLLenarColorCombo()
        Dim t As Type = GetType(System.Windows.Media.Brushes)
        Dim colors() As PropertyInfo = t.GetProperties()
        Dim item As ComboBoxItem = Nothing
        Dim txtColName As TextBlock = Nothing
        Dim rectColor As Rectangle = Nothing
        Dim converter As New BrushConverter()
        Dim brush_Renamed As Brush = Nothing
        For Each pColor As PropertyInfo In colors

            Dim stkPnl As New StackPanel()
            'stkPnl.Width = cboColor.Width
            stkPnl.Orientation = Orientation.Horizontal

            txtColName = New TextBlock
            txtColName.Text = pColor.Name
            txtColName.Width = 100
            txtColName.Height = 20
            rectColor = New Rectangle

            brush_Renamed = TryCast(converter.ConvertFromString(pColor.Name), Brush)
            rectColor.StrokeThickness = 6
            rectColor.Fill = brush_Renamed
            rectColor.Width = 60

            stkPnl.Children.Add(txtColName)
            stkPnl.Children.Add(rectColor)
            item = New ComboBoxItem
            item.Content = stkPnl

            cboColor.Items.Add(item)
        Next pColor
        'Dim t As Type = GetType(System.Windows.Media.Brushes)
        'Dim colors() As PropertyInfo = t.GetProperties()
        'cboColor = New ComboBox
        'cboColor.ItemsSource = colors
    End Sub

End Class
