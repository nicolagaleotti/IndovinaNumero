using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Indovinello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int numeroCasuale = 0;
        int tentativi = 0;
        private void btnCalcola_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int difficolta = int.Parse(txtDifficolta.Text);
                if (difficolta < 1 || difficolta > 100)
                {
                    throw new Exception();
                }
                Random random = new Random();
                numeroCasuale = random.Next(1, difficolta + 1);
            }
            catch (Exception)
            {
                MessageBox.Show("Non puoi inserire lettere o valori diversi da un numero compreso tra 1 e 100");
                txtDifficolta.Text = "";
            }
        }

        private void btnIndovina_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tentativi++;
                if (numeroCasuale == 0)
                {
                    throw new Exception("Devi prima generare un numero random!");
                }
                int difficolta = int.Parse(txtDifficolta.Text);
                int numero = int.Parse(txtValore.Text);
                if (numero < 1 || numero > difficolta)
                {
                    throw new Exception();
                }
                if (numero == numeroCasuale)
                {
                    lblRisultato.Content = $"Il numero uscito è {numeroCasuale}. HAI VINTO con {tentativi} tentativi!";
                }
                else
                {
                    lblRisultato.Content = "HAI PERSO! Ritenta!";
                    txtValore.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Non puoi inserire lettere o valori fuori dal range tra 1 e N!)");
                txtValore.Text = "";
            }
        }
    }
}
