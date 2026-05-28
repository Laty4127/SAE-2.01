using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SAE_2._01_Interface
{
    public partial class MainWindow : Window
    {
        private Border fondSelectionne;
        private Border cadreSelectionne;
        private Border jetonSelectionne;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Les paramètres ont été sauvegardés.",
                "Validation",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            SliderIcones.Value = 100;
            SliderTextes.Value = 100;
            SliderSonGeneral.Value = 100;
            SliderMusique.Value = 100;
            SliderEffets.Value = 100;
            CbCorrection.SelectedIndex = 0;

            ResetSelection();
        }

        private void ResetSelection()
        {
            if (fondSelectionne != null)
            {
                fondSelectionne.BorderBrush = Brushes.Transparent;
                fondSelectionne.BorderThickness = new Thickness(0);
                fondSelectionne = null;
            }

            if (cadreSelectionne != null)
            {
                cadreSelectionne.BorderBrush = Brushes.LightGray;
                cadreSelectionne.BorderThickness = new Thickness(1);
                cadreSelectionne = null;
            }

            if (jetonSelectionne != null)
            {
                jetonSelectionne.BorderBrush = Brushes.LightGray;
                jetonSelectionne.BorderThickness = new Thickness(1);
                jetonSelectionne = null;
            }
        }

        private void ChoixFond_Click(object sender, MouseButtonEventArgs e)
        {
            Border b = (Border)sender;

            if (fondSelectionne != null)
            {
                fondSelectionne.BorderBrush = Brushes.Transparent;
                fondSelectionne.BorderThickness = new Thickness(0);
            }

            fondSelectionne = b;

            fondSelectionne.BorderBrush = Brushes.DodgerBlue;
            fondSelectionne.BorderThickness = new Thickness(3);
        }

        private void ChoixCadre_Click(object sender, MouseButtonEventArgs e)
        {
            Border b = (Border)sender;

            if (cadreSelectionne != null)
            {
                cadreSelectionne.BorderBrush = Brushes.LightGray;
                cadreSelectionne.BorderThickness = new Thickness(1);
            }

            cadreSelectionne = b;

            cadreSelectionne.BorderBrush = Brushes.DarkRed;
            cadreSelectionne.BorderThickness = new Thickness(3);
        }

        private void ChoixJetons_Click(object sender, MouseButtonEventArgs e)
        {
            Border b = (Border)sender;

            if (jetonSelectionne != null)
            {
                jetonSelectionne.BorderBrush = Brushes.LightGray;
                jetonSelectionne.BorderThickness = new Thickness(1);
            }

            jetonSelectionne = b;

            jetonSelectionne.BorderBrush = Brushes.DarkGreen;
            jetonSelectionne.BorderThickness = new Thickness(3);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Voulez-vous enregistrer les modifications ?",
                "Confirmation",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                BtnValider_Click(sender, e);
                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Retourner au menu ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}