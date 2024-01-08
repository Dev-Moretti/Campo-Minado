using System;
using System.Windows;

namespace Campo_Minado
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void BTIniciar_Click(object sender, RoutedEventArgs e)
        {
            DIFICULDADE dificuldade;
            TEMPO tempoLimite;
            TimeSpan tempoBomba;
            int campo = 0;
            string nomePlayer;

            if (Jx10.IsChecked ?? false)
            {
                campo = 10;
            }
            else if(Jx20.IsChecked ?? false)
            {
                campo = 20;
            }
            else if (Jx30.IsChecked ?? false) 
            {
                campo = 30;
            }
            else if (Jx40.IsChecked ?? false)
            {
                campo = 40;
            }

            dificuldade = (DIFICULDADE)CBDificuldade.SelectedIndex;

            tempoLimite = (TEMPO)CBTempo.SelectedIndex;

            if (tempoLimite == TEMPO.CincoMinut)
            {
                tempoBomba = TimeSpan.FromMinutes(5);
            }
            else if (tempoLimite == TEMPO.QuatroMinut)
            {
                tempoBomba = TimeSpan.FromMinutes(4);
            }
            else if (tempoLimite == TEMPO.TresMinut)
            {
                tempoBomba = TimeSpan.FromMinutes(3);
            }
            else if (tempoLimite == TEMPO.DoisMinut)
            {
                tempoBomba = TimeSpan.FromMinutes(2);
            }
            else if (tempoLimite == TEMPO.UmMinut)
            {
                tempoBomba = TimeSpan.FromMinutes(1);
            }
            else 
            {
                tempoBomba = TimeSpan.FromMinutes(4);
            }

            nomePlayer = TBPlayerName.Text;

            ViewCampoMinado campoMinado = new ViewCampoMinado(campo, dificuldade, tempoBomba, nomePlayer);

            campoMinado.Height = SystemParameters.MaximizedPrimaryScreenHeight;
            campoMinado.Width = SystemParameters.MaximizedPrimaryScreenWidth;
            campoMinado.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            campoMinado.Show();

            this.Close();
        }

        private void BTScore_Click(object sender, RoutedEventArgs e)
        {
            ViewScores scores = new ViewScores();
            scores.Show();
            this.Close();
        }
    }
}
