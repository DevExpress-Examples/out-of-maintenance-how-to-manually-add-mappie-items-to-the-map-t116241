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
            VectorItemsLayer itemsLayer = new VectorItemsLayer() {
                Data = CreateData(),
                Colorizer = CreateColorizer()
            };
            mapControl1.Layers.Add(itemsLayer);
    
            // Show a color legend.
            mapControl1.Legends.Add(new ColorListLegend() { Layer = itemsLayer });
        }


        // Create a storage to provide data for the vector layer.
        private IMapDataAdapter CreateData() {
            MapItemStorage storage = new MapItemStorage();

            // Create a pie with several segments.
            MapPie pie = new MapPie();
            pie.Size = 200;
            pie.Segments.Add(new PieSegment() { Argument = "A", Value = 100 });
            pie.Segments.Add(new PieSegment() { Argument = "B", Value = 50 });
            pie.Segments.Add(new PieSegment() { Argument = "C", Value = 120 });
            storage.Items.Add(pie);

            return storage;
        }

        // Create a colorizer to provide colors for bubble items.    
        private MapColorizer CreateColorizer() {
            KeyColorColorizer colorizer = new KeyColorColorizer();

            // Add colors to the colorizer.
            colorizer.Colors.Add(Color.Coral);
            colorizer.Colors.Add(Color.Orange);
            colorizer.Colors.Add(Color.LightBlue);

            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "A", Name = "Category A" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "B", Name = "Category B" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "C", Name = "Category C" });

            // Load color indexes from bubbles via the 'Color' attribute
            colorizer.ItemKeyProvider = new ArgumentItemKeyProvider();

            return colorizer;
        }
    }

}
