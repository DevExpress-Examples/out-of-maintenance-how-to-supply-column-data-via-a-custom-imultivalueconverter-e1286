Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering
Imports System.ComponentModel
Imports System.Windows.Input
Imports System.Globalization
Imports System.Windows.Markup
Imports System.Threading
Imports System.Windows.Data

Namespace MultiValueConverter

	Partial Public Class Window1
		Inherits Window
		Private list As BindingList(Of Order)

		Public Sub New()
			InitializeComponent()

			list = New BindingList(Of Order)()
			list.Add(New Order() With {.Item = "Salad", .Price = 6.99D, .Quantity = 1})
			list.Add(New Order() With {.Item = "Cheeseburger", .Price = 2.75D, .Quantity = 2})
			list.Add(New Order() With {.Item = "Cola", .Price = 1.50D, .Quantity = 1})

			grid1.DataSource = list
		End Sub
	End Class
	Public Class MyConverter
		Inherits MarkupExtension
		Implements IMultiValueConverter
		#Region "IValueConverter Members"
		Private Function IMultiValueConverter_Convert(ByVal values() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
			If values(0) Is DependencyProperty.UnsetValue OrElse values(1) Is DependencyProperty.UnsetValue Then
				Return Decimal.Zero
			End If
			Return Convert.ToDecimal(values(0)) * Convert.ToInt32(values(1))
		End Function
		Private Function ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
		#End Region

		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return Me
		End Function
	End Class

	Public Class Order
		Private privateItem As String
		Public Property Item() As String
			Get
				Return privateItem
			End Get
			Set(ByVal value As String)
				privateItem = value
			End Set
		End Property
		Private privatePrice As Decimal
		Public Property Price() As Decimal
			Get
				Return privatePrice
			End Get
			Set(ByVal value As Decimal)
				privatePrice = value
			End Set
		End Property
		Private privateQuantity As Integer
		Public Property Quantity() As Integer
			Get
				Return privateQuantity
			End Get
			Set(ByVal value As Integer)
				privateQuantity = value
			End Set
		End Property
	End Class
End Namespace
