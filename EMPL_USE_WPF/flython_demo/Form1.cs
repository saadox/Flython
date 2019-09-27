using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace flython_demo
{
    public partial class Form1 : Form
    {
        /*
         * HAD LMETHOD (JSON) GHATKHDEM M3A SCRIPT LI  TAY9ELB 3LA AIRPORTS BY COUNTRY => 20 AIRPORT MAX PER COUNTRY
         * AIRPORT OBJECT HAS PROPERTIES BY THIS ORDER : NAME - ADDRESS - LATTITUDE - LONGITUDE - RATES
         * FILE : Morocco.txt HIYA OUTPUT MN SCRIPT PYTHON LI 9ADIT EACH LINE FIHA : {ind:{}} => (nested dictionaries)
         * SO FHAD EXMPL .NET GHI BACH TCHOF HOW TO MANAGE THE DATA LI GHANREJA3HALIK B PYTHON
         * NEXT GHANDIR EXMPL .NET WINFORM KIFCH TIMPLEMENTI CHI METHOD BACH T EXECUTER SCRIPT PYTHON W TREJE3LIK OUTPUT DIRECT L WPF DYALK
         * 
         * 
         */

        public Form1 ( )
        {
            InitializeComponent();
        }
        List<airport> airports = new List<airport>();

        #region off-test
        //string test = "0:{'name': 'Charles de Gaulle Airport', 'adress': '95700 Roissy-en-France, France', 'lat': '49.0096906', 'lng': '2.5479245', 'rating': '3.3'}";
        //MessageBox.Show(test.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries)[0]);
        #endregion


        private void Form1_Load (object sender, EventArgs e)
        {
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            try
            {
                using (StreamReader s = new StreamReader("Morocco.txt"))
                {
                    string tmp = "";

                    while ((tmp = s.ReadLine()) != null)
                    {
                        string t = tmp.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries)[1]; // {....}
                        // hadi hiya lmohima asat >  Desirializi 1 Json string into wa7d class object 
                        airports.Add(JsonConvert.DeserializeObject<airport>(t));
                    }
                    s.Close();
                }

                foreach (var item in airports)
                {
                    dgv.Rows.Add(new object[] { item.name, item.adress,item.lat,item.lng,item.rating });
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                Environment.Exit(Environment.ExitCode);
            }

        }
    }
}
