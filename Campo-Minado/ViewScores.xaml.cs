using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para ViewScores.xaml
    /// </summary>
    public partial class ViewScores : Window
    {
        public string Nome;
        public TimeSpan TempoBomba;
        public TimeSpan TempoJogado;
        public DIFICULDADE Dificuldade;
        public int Campo;
        public int Bombas;


        public ViewScores()
        {
            InitializeComponent();
            PosicoesScore();
        }

        public void PosicoesScore()
        {
            try
            {
                ScoreDAO scoreDao = new ScoreDAO();

                List<Score> listScore = scoreDao.LerListaScore();

                foreach (Score pontos in listScore)
                {
                    GScores.Items.Add(pontos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro {ex}", "Erro",MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                MainWindow main = new MainWindow();
                main.Show();
            }

        }

        private void BTVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void BTListar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
