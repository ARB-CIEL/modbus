using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace modbus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Événement - clic
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            // Récupération - adresse
            string adresseIP = textBoxAdresseIP.Text;

            // Affichage - message
            textBoxStatut.Text += $"Connexion au serveur {adresseIP}\r\n";

            // Défilement - automatique
            textBoxStatut.SelectionStart = textBoxStatut.Text.Length;
            textBoxStatut.ScrollToCaret();
        }
    }
}
