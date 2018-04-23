using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;

namespace MapPieItem {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a layer to show vector items.
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mapControl1.Layers.Add(itemsLayer);

            // Create a storage to provide data for the vector layer.
            MapItemStorage storage = new MapItemStorage();
            itemsLayer.Data = storage;

            // Create a pie with several segments.
            MapPie pie = new MapPie();
            pie.Size = 200;
            pie.Segments.Add(new PieSegment() { Argument = "A", Value = 100 });
            pie.Segments.Add(new PieSegment() { Argument = "B", Value = 50 });
            pie.Segments.Add(new PieSegment() { Argument = "C", Value = 120 });
            storage.Items.Add(pie);

            // Provide color indexes to bubbles as attributes.
            int i = 0;
            foreach (PieSegment segment in pie.Segments) {
                segment.Attributes.Add(new MapItemAttribute() { Name = "Color", Value = i });
                i++;
            }

            // Create a colorizer to provide colors for bubble items.
            ColorIndexColorizer colorizer = new ColorIndexColorizer();
            itemsLayer.Colorizer = colorizer;

            // Add colors to the colorizer.
            colorizer.ColorItems.Add(new ColorizerColorTextItem() { Color = Color.Coral, Text = "Category A" });
            colorizer.ColorItems.Add(new ColorizerColorTextItem() { Color = Color.Orange, Text = "Category B" });
            colorizer.ColorItems.Add(new ColorizerColorTextItem() { Color = Color.LightBlue, Text = "Category C" });

            // Load color indexes from bubbles via the 'Color' attribute
            colorizer.ColorIndexProvider = new PieSegmentAttributeToColorIndexProvider() { AttributeName = "Color" };


            // Show a color legend.
            mapControl1.Legends.Add(new ColorListLegend() { Layer = itemsLayer });

        }
    }
}
