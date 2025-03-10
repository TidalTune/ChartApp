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
    }
}
