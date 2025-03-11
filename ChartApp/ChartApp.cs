using CsvHelper;
using System.Globalization;

namespace ChartApp
{
    public partial class ChartApp : Form
    {
        private string _filePath = "";
        private string _rawFile = "";
        private List<WeatherEvent> _events = new List<WeatherEvent>();

        public ChartApp()
        {
            InitializeComponent();

        }

        private void LoadData()
        {
            // loads the data into the label to display

            lblDisplay.Text = "";

            for (int i = 0; i < _events.Count; i++)
            {
                lblDisplay.Text += _events[i].ToString() + "\n";
            }


        }

        private void DrawGraph()
        {
            // horizontal - ID - 1 to N
            // vertical - Temp - 0 to 150
            // TODO: add dynamic ranges to the app
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(blackBrush);
            Graphics g = this.CreateGraphics();

            int startX = 150;
            int startY = 10;
            int sizeX = 300;
            int sizeY = 300;

            Point topLeft = new Point(startX, startY);
            Point topRight = new Point(startX + sizeX, startY);
            Point bottomLeft = new Point(startX, startY + sizeY);
            Point bottomRight = new Point(startX + sizeX, startY + sizeY);

            //Draw Graph
            g.DrawLine(blackPen, topLeft, bottomLeft);
            g.DrawLine(blackPen, bottomLeft, bottomRight);

            //Draw x hashes
            int xStep = sizeX/10;

            //Draw Y hashes
            int numHashesY = 10;
            int yStep = (sizeY - startY)/10;

            int tempStep = (150 - 50) / numHashesY;

            for (int i = 0; i < numHashesY; i++)
            {
                Point pt1 = new Point(startX - 10, startY + (yStep * i));
                Point pt2 = new Point(startX, startY + (yStep * i));
                Point textPt = new Point(startX - 40, startY + (yStep * i));

                Point pt3 = new Point(startX + (xStep * i), sizeY + 10);
                Point pt4 = new Point(startX + (xStep * i), sizeY + 20);

                string label = (150 - (tempStep * i)).ToString();

                g.DrawLine(blackPen, pt1, pt2);
                g.DrawLine(blackPen, pt3, pt4);
                g.DrawString(label, new Font(FontFamily.GenericMonospace, 10.0f), blackBrush, textPt);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // open a file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // set the properties on the fileDialog
                openFileDialog.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "Data");
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

                // open the file dialog and do something
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // process the file information
                    _filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        _events = csv.GetRecords<WeatherEvent>().ToList();
                        LoadData();
                    }
                    //{
                    //_rawFile = reader.ReadToEnd();
                    //while (reader.Peek() >= 0)
                    //{
                    //_lines.Add(reader.ReadLine());
                    //}
                    //}
                    //MessageBox.Show(_filePath);
                }
            }
        }

        private void ChartApp_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph();
        }
    }
}
