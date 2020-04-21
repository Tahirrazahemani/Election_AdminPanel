using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPTProject_AdminPanel
{
    public partial class AddArea : Form
    {
        public AddArea()
        {
            InitializeComponent();
        }

        private void AddAreaButton_Click(object sender, EventArgs e)
        {
            string Hosting = ConfigurationManager.AppSettings["DefineHostingRoute"];
           
            if (!AreaNameTextBox.Text.Equals("") && !AreaDetailTextBox.Text.Equals(""))
            {
                AreaClass AreaDtoObject = new AreaClass(AreaNameTextBox.Text, AreaDetailTextBox.Text);
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri(Hosting);
                HttpResponseMessage response = clint.PostAsJsonAsync("api/areas", AreaDtoObject).Result;
                MessageBox.Show("New Area Is Added Succefully");
                Utils utilsObject = new Utils();
                AreaNameTextBox.Text = "";
                AreaDetailTextBox.Text = "";
                utilsObject.backToAdmin(this);
            }
            else
            {
                MessageBox.Show("All Fields Should Be Filled");
            }
        }
    }
}
