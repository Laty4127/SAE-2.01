using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Librairie_Système;

namespace SAE_2._01_Interface
{
    /// <summary>
    /// Logique d'interaction pour WindowProfil.xaml
    /// </summary>
    public partial class WindowProfil : Window
    {
        public WindowProfil()
        {
            InitializeComponent();
        }

        bool ModeConnexion = false;
        
            
     
        private void HyperlinkConnexion_Click(object sender, RoutedEventArgs e)
        {
            ModeConnexion = true;

            TxtProfilTitre.Text = "Connexion";

            BtnModifier.Visibility = Visibility.Collapsed;

            StackPanelMDPConfirm.Visibility = Visibility.Collapsed;

            TxbConnexion.Visibility = Visibility.Collapsed;
            TxbInscription.Visibility = Visibility.Visible;
        }

        private void HyperlinkInscription_Click(object sender, RoutedEventArgs e)
        {
            ModeConnexion = false;

            TxtProfilTitre.Text = "Création du Profil";

            BtnModifier.Visibility = Visibility.Visible;

            StackPanelMDPConfirm.Visibility = Visibility.Visible;


            TxbConnexion.Visibility = Visibility.Visible;
            TxbInscription.Visibility = Visibility.Collapsed;
        }

        private async void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            TxbErreurProfilNom.Text = "";
            TxbErreurMDP.Text = "";
            TxbErreurMDPConfirm.Text = "";

            bool erreur = false;

            if (string.IsNullOrWhiteSpace(TxtProfilNom.Text))
            {
                TxbErreurProfilNom.Text = "Veuillez saisir un nom.";
                erreur = true;
            }
            if (string.IsNullOrWhiteSpace(PbMDP.Password) && app.GestionJoueur.JoueurCo == null)
            {
                TxbErreurMDP.Text = "Veuillez saisir un mot de passe.";
                erreur = true;
            }

            if (string.IsNullOrWhiteSpace(PbMDP.Password))
            {
                TxbErreurMDP.Text = "Veuillez saisir un mot de passe.";
                erreur = true;
            }

            if (TxtProfilNom.Text.Length < 3)
            {
                TxbErreurProfilNom.Text = "Le nom doit contenir au moins 3 caractères.";
                erreur = true;
            }

            if (PbMDP.Password.Length < 6)
            {
                TxbErreurMDP.Text = "Le mot de passe doit contenir au moins 6 caractères.";
                erreur = true;
            }

            if (!ModeConnexion)
            {
                if (PbMDP.Password != PbMDPConfirm.Password)
                {
                    TxbErreurMDPConfirm.Text = "Les mots de passe ne correspondent pas.";
                    erreur = true;
                }
            }

            if (!erreur)
            {
                
                if (app == null || app.GestionJoueur == null)
                {
                    MessageBox.Show("Erreur interne : gestionnaire de joueurs non initialisé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (ModeConnexion)
                    try
                    {
                        await app.GestionJoueur.SeConnecter(TxtProfilNom.Text, PbMDP.Password);
                        MessageBox.Show($"Bienvenue {app.GestionJoueur.JoueurCo?.PseudoJoueur}, Profil connecté avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la connexion : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                else
                    try
                    {
                        await app.GestionJoueur.Inscrire(TxtProfilNom.Text, PbMDP.Password);
                        MessageBox.Show("Profil créé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'inscription : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                WindowConsulterProfil profil = new WindowConsulterProfil();
                profil.Show();
                this.Close();
            }
        }

        private void BtnReinitialiser_Click(object sender, RoutedEventArgs e)
        {
            TxtProfilNom.Text = "";
            PbMDP.Password = "";
            PbMDPConfirm.Password = "";
            TxbErreurProfilNom.Text = "";
            TxbErreurMDP.Text = "";
            TxbErreurMDPConfirm.Text = "";
        }
        

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowChangerPhoto changerPhoto = new WindowChangerPhoto();
            changerPhoto.ShowDialog();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Retourner au menu ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow home = new MainWindow();
                home.Show();
                this.Close();
            }
        }
    }
}
