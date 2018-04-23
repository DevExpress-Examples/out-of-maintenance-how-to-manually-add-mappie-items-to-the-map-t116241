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
            Dim itemsLayer As New VectorItemsLayer() With {.Data = CreateData(), .Colorizer = CreateColorizer()}
            mapControl1.Layers.Add(itemsLayer)

            ' Show a color legend.
            mapControl1.Legends.Add(New ColorListLegend() With {.Layer = itemsLayer})
        End Sub


        ' Create a storage to provide data for the vector layer.
        Private Function CreateData() As IMapDataAdapter
            Dim storage As New MapItemStorage()

            ' Create a pie with several segments.
            Dim pie As New MapPie()
            pie.Size = 200
            pie.Segments.Add(New PieSegment() With {.Argument = "A", .Value = 100})
            pie.Segments.Add(New PieSegment() With {.Argument = "B", .Value = 50})
            pie.Segments.Add(New PieSegment() With {.Argument = "C", .Value = 120})
            storage.Items.Add(pie)

            Return storage
        End Function

        ' Create a colorizer to provide colors for bubble items.    
        Private Function CreateColorizer() As MapColorizer
            Dim colorizer As New KeyColorColorizer()

            ' Add colors to the colorizer.
            colorizer.Colors.Add(Color.Coral)
            colorizer.Colors.Add(Color.Orange)
            colorizer.Colors.Add(Color.LightBlue)

            colorizer.Keys.Add(New ColorizerKeyItem() With {.Key = "A", .Name = "Category A"})
            colorizer.Keys.Add(New ColorizerKeyItem() With {.Key = "B", .Name = "Category B"})
            colorizer.Keys.Add(New ColorizerKeyItem() With {.Key = "C", .Name = "Category C"})

            ' Load color indexes from bubbles via the 'Color' attribute
            colorizer.ItemKeyProvider = New ArgumentItemKeyProvider()

            Return colorizer
        End Function
    End Class

End Namespace
