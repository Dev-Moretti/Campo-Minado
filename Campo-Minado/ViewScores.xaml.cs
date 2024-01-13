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

            ExibeScoreOrganizado();
        }

        private void BTVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BTListar_Click(object sender, RoutedEventArgs e)
        {
            ExibeScoreOrganizado();
        }

        private void ExibeScoreSimples(List<Score> listScore)
        {
            GScores.Items.Clear();

            foreach (Score pontos in listScore)
            {
                GScores.Items.Add(pontos);
            }
        }


        private void ExibeScoreOrganizado()
        {
            GScores.Items.Clear();

            ScoreDAO scoreDao = new ScoreDAO();

            Score score = new Score();

            List<Score> listScore = scoreDao.LerListaScore();

            int? fCampo = CampoSelecionado();

            DIFICULDADE? fDificuldade = DificuldadeSelecionada(); 

            TimeSpan? fTempo = TempoSelecionado();

            ExibeScoreSimples(score.OrdenarLista(listScore, fCampo, fDificuldade, fTempo));

        }

        private DIFICULDADE? DificuldadeSelecionada()
        {
            if (RDIniciante.IsChecked == true)
            {
                return DIFICULDADE.Iniciante;
            }
            if (RDNormal.IsChecked == true)
            {
                return DIFICULDADE.Normal;
            }
            if (RDDificil.IsChecked == true)
            {
                return DIFICULDADE.Dificil;
            }
            if (RDEpico.IsChecked == true)
            {
                return DIFICULDADE.Epico;
            }
            return null;
        }
        private int? CampoSelecionado()
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

            return null;
        }
        private TimeSpan? TempoSelecionado()
        {
            if (RDTempo1Minuto.IsChecked == true)
            {
                return TimeSpan.FromMinutes(1);
            }
            if (RDTempo2Minutos.IsChecked == true)
            {
                return TimeSpan.FromMinutes(2);
            }
            if (RDTempo3Minutos.IsChecked == true)
            {
                return TimeSpan.FromMinutes(3);
            }
            if (RDTempo4Minutos.IsChecked == true)
            {
                return TimeSpan.FromMinutes(4);
            }
            if (RDTempo5Minutos.IsChecked == true)
            {
                return TimeSpan.FromMinutes(5);
            }

            return null;
        }

    }
}
