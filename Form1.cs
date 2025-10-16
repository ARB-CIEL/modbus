using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace modbus
{
    public partial class Form1 : Form
    {
        // Socket - connexion
        private Socket socket;

        public Form1()
        {
            InitializeComponent();
        }

        // Évent
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                // Récup adrsse
                string adresseIP = textBoxAdresseIP.Text;

                // Affichage 
                textBoxStatut.Text += $"Connexion au serveur {adresseIP}\r\n";

                // Créer de socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Conversion d'adresse
                IPAddress ipAddress = IPAddress.Parse(adresseIP);

                // Création de endpoint
                IPEndPoint endPoint = new IPEndPoint(ipAddress, 502); // Port Modbus standard

                // Connexion au serveur
                socket.Connect(endPoint);

                // Affichage avec succès
                textBoxStatut.Text += "Connexion ok\r\n";

                // Défilement - automatique
                textBoxStatut.SelectionStart = textBoxStatut.Text.Length;
                textBoxStatut.ScrollToCaret();
            }
            catch (System.Net.Sockets.SocketException se)
            {
                // Erreur socket
                textBoxStatut.Text += "**Exception : Impossible de se connecter au serveur\r\n";
                textBoxStatut.Text += "Message : " + se.Message + "\r\n";

                // Défilement automatique
                textBoxStatut.SelectionStart = textBoxStatut.Text.Length;
                textBoxStatut.ScrollToCaret();
            }
            catch (System.Exception ex)
            {
                // Erreur 
                textBoxStatut.Text += "**Exception : Impossible de se connecter au serveur\r\n";
                textBoxStatut.Text += "Message : " + ex.Message + "\r\n";

                // Défilement automatique
                textBoxStatut.SelectionStart = textBoxStatut.Text.Length;
                textBoxStatut.ScrollToCaret();
            }
        }

        // event  déconnexion
        private void buttonDeconnexion_Click(object sender, EventArgs e)
        {
            try
            {
                // vérif de socket
                if (socket != null)
                {
                    // fermeture de connexion
                    socket.Close();

                    // affichage réussi
                    textBoxStatut.Text += "Déconnexion réussie\r\n";
                }
                else
                {
                    //aucun Aafichage 
                    textBoxStatut.Text += "Aucune connexion active\r\n";
                }

                // Défilement automatique
                textBoxStatut.SelectionStart = textBoxStatut.Text.Length;
                textBoxStatut.ScrollToCaret();
            }
            catch (System.Exception ex)
            {
                // Erreur de déconnexion
                textBoxStatut.Text += "**Exception lors de la déconnexion\r\n";
                textBoxStatut.Text += "Message : " + ex.Message + "\r\n";

                // Défilement automatique
                textBoxStatut.SelectionStart = textBoxStatut.Text.Length;
                textBoxStatut.ScrollToCaret();
            }
        }
    }
}
