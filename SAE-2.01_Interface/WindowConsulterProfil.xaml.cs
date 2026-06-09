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

namespace SAE_2._01_Interface
{
    /// <summary>
    /// Logique d'interaction pour WindowConsulterProfil.xaml
    /// </summary>
    public partial class WindowConsulterProfil : Window
    {
        public WindowConsulterProfil()
        {
            InitializeComponent();
        }

        private bool editionNom = false;


        private async void BtnModifierNom_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            editionNom = !editionNom;
            TxtProfilNom.IsReadOnly = !editionNom;
            try
            {
                await app.GestionJoueur.Modifier(TxtProfilNom.Text, null);
                MessageBox.Show("Profil modifié avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du profil : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;

            app.GestionJoueur?.SeDeconnecter();
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowChangerPhoto changerPhoto = new WindowChangerPhoto();
            changerPhoto.ShowDialog();
        }

    }
}
