using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KSHDotNetTrainingInPersonBatch1.BPISample.WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //var response = client.GetAsync("https://localhost:7241/api/BirdsController/Bird_list").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    string json = response.Content.ReadAsStringAsync().Result;
            //    var result = JsonConvert.DeserializeObject<Tbl_Bird[]>(json);

            //    dataGridView1.AutoGenerateColumns = false;
            //    dataGridView1.DataSource = result;
            //}

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient(handler);
            var response = client.GetAsync("https://localhost:7241/api/BirdsController/Bird_list").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<BirdsResponseModel>(json);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = result;
            }
        }

    }

    public class BirdsResponseModel
    {
        public Tbl_Bird[] Tbl_Bird { get; set; }
    }

    public class Tbl_Bird
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
