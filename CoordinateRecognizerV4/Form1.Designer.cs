using System;
using System.IO;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Tesseract;

namespace CoordinateRecognizerV4
{
    public partial class Form1 : Form
    {
        private GMapControl gMapControl;

        public Form1()
        {
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap()
        {
            gMapControl = new GMapControl();
            gMapControl.Dock = DockStyle.Fill;
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.Position = new PointLatLng(0, 0); // Initial center of the map
            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 10;
            gMapControl.OnMarkerClick += gMapControl_OnMarkerClick;

            Controls.Add(gMapControl);
        }

        private void ProcessImagesButton_Click(object sender, EventArgs e)
        {
            string folderPath = FolderPathTextBox.Text;

            if (Directory.Exists(folderPath))
            {
                gMapControl.Overlays.Clear(); // Clear existing markers

                using (var engine = new TesseractEngine("./tessdata/tessdata", "eng", EngineMode.Default))
                {
                    var imageFiles = Directory.GetFiles(folderPath, "*.png");

                    foreach (var imagePath in imageFiles)
                    {
                        //ResultTextBox.Text += $"Processing image: {Path.GetFileName(imagePath)}\n";

                        using (var img = Pix.LoadFromFile(imagePath))
                        {
                            using (var page = engine.Process(img))
                            {
                                var text = page.GetText();
                                ResultTextBox.Text += $"Extracted Text from {Path.GetFileName(imagePath)}:\n{text}\n\n";

                                double longitude, latitude;
                                if (TryParseCoordinates(text, out longitude, out latitude))
                                {
                                    // Add a marker to the map
                                    GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
                                    GMapOverlay markersOverlay = new GMapOverlay("markers");
                                    markersOverlay.Markers.Add(marker);
                                    gMapControl.Overlays.Add(markersOverlay);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ResultTextBox.Text = "Invalid folder path. Please enter a valid path.";
            }
        }

        private bool TryParseCoordinates(string text, out double latitude, out double longitude)
        {
            // Initialize values
            latitude = 0.0;
            longitude = 0.0;

            // Split the text by newline characters to get individual lines
            string[] lines = text.Split('\n');
            string[] lines2 = new string[2] { lines[0], lines[1] };

            for (int i = 0; i < lines2.Count(); i++)
            {
                if (lines2[i].Contains(" "))
                {
                    lines2[i] = lines2[i].Replace(" ", ",");
                }
                if (lines2[i].Contains("."))
                {
                    lines2[i] = lines2[i].Replace(".", ",");
                }
            }


            // Try to parse latitude and longitude
            if (lines2.Count() == 2 && double.TryParse(lines2[0], out latitude) && double.TryParse(lines2[1], out longitude))
            {
                // Successfully parsed, return true
                return true;
            }


            // Parsing failed
            return false;
        }


        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // Handle marker click event (if needed)
            MessageBox.Show($"Marker clicked at {item.Position.Lat}, {item.Position.Lng}");
        }
    }
}
