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
    public partial class AddParty : Form
    {
        public AddParty()
        {
            InitializeComponent();
        }

        private void AddPartyButton_Click(object sender, EventArgs e)
        {
            if (!PartyNameTextBox.Text.Equals("") && !PartyDetailsTextBox.Text.Equals(""))
            {
                string Hosting = ConfigurationManager.AppSettings["DefineHostingRoute"];
                PartyClass PartyClassObject = new PartyClass(PartyNameTextBox.Text, PartyDetailsTextBox.Text);
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri(Hosting);
                HttpResponseMessage response = clint.PostAsJsonAsync("api/parties", PartyClassObject).Result;
                MessageBox.Show("New Party Is Added Succefully");
                PartyNameTextBox.Text = "";
                PartyDetailsTextBox.Text = "";
                Utils utilsObject = new Utils();
                utilsObject.backToAdmin(this);
            }
            else
            {
                MessageBox.Show("All Fields Should Be Filled");
            }
        }
    }
}
