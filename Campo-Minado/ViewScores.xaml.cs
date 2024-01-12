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

            ExibeScoreSimples();
        }

        private void BTVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BTListar_Click(object sender, RoutedEventArgs e)
        {
            ExibeScoreSimples();

        }

        private void ExibeScoreSimples()
        {
            ScoreDAO scoreDao = new ScoreDAO();

            List<Score> listScore = scoreDao.LerListaScore();

            ExibeScoreOrganizado(listScore);

            GScores.Items.Clear();

            foreach (Score pontos in listScore)
            {
                GScores.Items.Add(pontos);
            }
        }


        private void ExibeScoreOrganizado(List<Score> listScore)
        {
            GScores.Items.Clear();

            int fCampo = CampoSelecionado();
            int fDificuldade = DificuldadeSelecionado();
            int fTempo = TempoSelecionado();
            int fOrdenar = OrdenarSelecionado();

            if (fCampo != 0 && fDificuldade != 0 && fTempo != 0 && fOrdenar != 0)
            {

            }


            
        }

        private int CampoSelecionado()
        {
            if (RBCampo10.IsChecked == true)
            {
                return 10;
            }
            if (RBCampo20.IsChecked == true)
            {
                return 20;
            }
            if (RBCampo30.IsChecked == true)
            {
                return 30;
            }
            if (RBCampo40.IsChecked == true)
            {
                return 40;
            }

            return 0;
        }
        private int DificuldadeSelecionado()
        {
            if (RDIniciante.IsChecked == true)
            {
                return 1;
            }
            if (RDNormal.IsChecked == true)
            {
                return 2;
            }
            if (RDDificil.IsChecked == true)
            {
                return 3;
            }
            if (RDEpico.IsChecked == true)
            {
                return 4;
            }

            return 0;
        }
        private int TempoSelecionado()
        {
            if (RDTempo1Minuto.IsChecked == true)
            {
                return 1;
            }
            if (RDTempo2Minutos.IsChecked == true)
            {
                return 2;
            }
            if (RDTempo3Minutos.IsChecked == true)
            {
                return 3;
            }
            if (RDTempo4Minutos.IsChecked == true)
            {
                return 4;
            }
            if (RDTempo5Minutos.IsChecked == true)
            {
                return 5;
            }

            return 0;
        }
        private int OrdenarSelecionado()
        {
            if (Decrescente.IsChecked == true)
            {
                return 1;
            }
            if (Decrescente.IsChecked == true)
            {
                return 2;
            }

            return 0;
        }






    }
}
