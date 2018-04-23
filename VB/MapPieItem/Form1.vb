Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap

Namespace MapPieItem
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a layer to show vector items.
			Dim itemsLayer As New VectorItemsLayer()
			mapControl1.Layers.Add(itemsLayer)

			' Create a storage to provide data for the vector layer.
			Dim storage As New MapItemStorage()
			itemsLayer.Data = storage

			' Create a pie with several segments.
			Dim pie As New MapPie()
			pie.Size = 200
			pie.Segments.Add(New PieSegment() With {.Argument = "A", .Value = 100})
			pie.Segments.Add(New PieSegment() With {.Argument = "B", .Value = 50})
			pie.Segments.Add(New PieSegment() With {.Argument = "C", .Value = 120})
			storage.Items.Add(pie)

			' Provide color indexes to bubbles as attributes.
			Dim i As Integer = 0
			For Each segment As PieSegment In pie.Segments
				segment.Attributes.Add(New MapItemAttribute() With {.Name = "Color", .Value = i})
				i += 1
			Next segment

			' Create a colorizer to provide colors for bubble items.
			Dim colorizer As New ColorIndexColorizer()
			itemsLayer.Colorizer = colorizer

			' Add colors to the colorizer.
			colorizer.ColorItems.Add(New ColorizerColorTextItem() With {.Color = Color.Coral, .Text = "Category A"})
			colorizer.ColorItems.Add(New ColorizerColorTextItem() With {.Color = Color.Orange, .Text = "Category B"})
			colorizer.ColorItems.Add(New ColorizerColorTextItem() With {.Color = Color.LightBlue, .Text = "Category C"})

			' Load color indexes from bubbles via the 'Color' attribute
			colorizer.ColorIndexProvider = New PieSegmentAttributeToColorIndexProvider() With {.AttributeName = "Color"}


			' Show a color legend.
			mapControl1.Legends.Add(New ColorListLegend() With {.Layer = itemsLayer})

		End Sub
	End Class
End Namespace
