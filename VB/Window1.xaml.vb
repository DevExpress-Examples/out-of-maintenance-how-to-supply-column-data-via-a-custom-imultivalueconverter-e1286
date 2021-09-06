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
			list.Add(New Order() With {
				.Item = "Salad",
				.Price = 6.99D,
				.Quantity = 1
			})
			list.Add(New Order() With {
				.Item = "Cheeseburger",
				.Price = 2.75D,
				.Quantity = 2
			})
			list.Add(New Order() With {
				.Item = "Cola",
				.Price = 1.50D,
				.Quantity = 1
			})

			grid1.ItemsSource = list
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
		Private Function IMultiValueConverter_ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
		#End Region

		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return Me
		End Function
	End Class

	Public Class Order
		Public Property Item() As String
		Public Property Price() As Decimal
		Public Property Quantity() As Integer
	End Class
End Namespace
