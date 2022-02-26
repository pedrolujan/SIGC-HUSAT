
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports FontAwesome.WPF
Imports System.Reflection


Public Class clsModeloVista

    Public Property Icons() As ObservableCollection(Of IconDescription)
        Get
            Return m_Icons
        End Get
        Set
            m_Icons = Value
        End Set
    End Property
    Private m_Icons As ObservableCollection(Of IconDescription)

    Public Sub New()
        Icons = New ObservableCollection(Of IconDescription)()

        Dim icons__1 = [Enum].GetValues(GetType(FontAwesomeIcon)).Cast(Of FontAwesomeIcon)().Where(Function(t) t <> FontAwesomeIcon.None).OrderBy(Function(t) t, New IconComparer())

        For Each icon In icons__1
            Dim memberInfo = GetType(FontAwesomeIcon).GetMember(icon.ToString()).FirstOrDefault()

            If memberInfo Is Nothing Then
                Continue For
            End If
            ' alias
            For Each cat In memberInfo.GetCustomAttributes(GetType(IconCategoryAttribute), False).Cast(Of IconCategoryAttribute)()
                Dim desc = memberInfo.GetCustomAttributes(GetType(DescriptionAttribute), False).Cast(Of DescriptionAttribute)().First()
                Dim id = memberInfo.GetCustomAttributes(GetType(IconIdAttribute), False).Cast(Of IconIdAttribute)().FirstOrDefault()
                Icons.Add(New IconDescription() With {
                        .Category = cat.Category,
                        .Description = desc.Description,
                        .Icon = icon,
                        .Id = If(id Is Nothing, Nothing, id.Id)
                })
            Next

        Next
    End Sub

    Public Class IconComparer
        Implements IComparer(Of FontAwesomeIcon)

        Public Function Compare(x As FontAwesomeIcon, y As FontAwesomeIcon) As Integer Implements IComparer(Of FontAwesomeIcon).Compare
            Return [String].Compare(x.ToString(), y.ToString(), System.StringComparison.InvariantCultureIgnoreCase)
        End Function

    End Class

End Class

Public Class IconDescription
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set
            m_Description = Value
        End Set
    End Property
    Private m_Description As String

    Public Property Icon() As FontAwesomeIcon
        Get
            Return m_Icon
        End Get
        Set
            m_Icon = Value
        End Set
    End Property
    Private m_Icon As FontAwesomeIcon

    Public Property Category() As String
        Get
            Return m_Category
        End Get
        Set
            m_Category = Value
        End Set
    End Property
    Private m_Category As String

    Public Property Id() As String
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As String

End Class
