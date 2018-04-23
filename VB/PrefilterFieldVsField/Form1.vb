Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Data.Filtering

Namespace PrefilterFieldVsField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			SetupPivot(pivotGridControl1)

			pivotGridControl1.Prefilter.Criteria = New OperandProperty("ActualSale") > New OperandProperty("ForecastSale")
		End Sub

		Private Sub SetupPivot(ByVal grid As PivotGridControl)
			Dim Table As New DataTable()
			Table.Columns.Add("Category Name", GetType(String))
			Table.Columns.Add("Product Name", GetType(String))
			Table.Columns.Add("Year", GetType(Integer))
			Table.Columns.Add("ForecastSale", GetType(Single))
			Table.Columns.Add("ActualSale", GetType(Single))
			Table.Columns.Add("Quantity", GetType(Integer))
			Table.Columns.Add("Employee Name", GetType(String))

			Table.Rows.Add(New Object() { "Beverages", "Chai", 1995, 5000, 5070.60, 319, Nothing })
			Table.Rows.Add(New Object() { "Beverages", "Chai", 1996, 6000, 6295.50, 399, Nothing })
			Table.Rows.Add(New Object() { "Beverages", "Ipoh Coffee", 1995, 11000, 10034.90, 228, Nothing })
			Table.Rows.Add(New Object() { "Beverages", "Ipoh Coffee", 1996, 8000, 8560.60, 216, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Chocolade", 1995, 1500, 1282.01, 130, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Chocolade", 1996, 800, 886.70, 8, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Scottish Longbreads", 1995, 4000, 3909.00, 380, Nothing })
			Table.Rows.Add(New Object() { "Confections", "Scottish Longbreads", 1996, 4000, 4175.00, 354, Nothing })

			grid.DataSource = New BindingSource(Table, "")

			grid.Fields.Add("Category Name", PivotArea.RowArea)
			grid.Fields.Add("Product Name", PivotArea.RowArea)
			grid.Fields.Add("Year", PivotArea.FilterArea)
			grid.Fields.Add("ForecastSale", PivotArea.DataArea)
			grid.Fields.Add("ActualSale", PivotArea.DataArea)
			grid.Fields.Add("Employee Name", PivotArea.FilterArea)
			grid.Fields("Year").Width = 70
			grid.Fields("ForecastSale").CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			grid.Fields("ForecastSale").CellFormat.FormatString = "c"
			grid.Fields("ActualSale").CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			grid.Fields("ActualSale").CellFormat.FormatString = "c"
		End Sub
	End Class
End Namespace
