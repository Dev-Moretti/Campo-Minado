using System;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;


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

            CarregaConfig();
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
            else if (Jx20.IsChecked ?? false)
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

            MenuConfigDAO dao = new MenuConfigDAO();

            List<MenuConfig> listMenuConfigs = new List<MenuConfig>();

            TEMPO time = (TEMPO)CBTempo.SelectedIndex;


            MenuConfig menuConfig = new MenuConfig(campo, dificuldade, time, nomePlayer);

            listMenuConfigs.Add(menuConfig);

            dao.GravarConfig(listMenuConfigs);

            campoMinado.Show();

            this.Close();

        }

        private void BTScore_Click(object sender, RoutedEventArgs e)
        {
            ViewScores scores = new ViewScores();

            scores.Show();

            this.Close();
        }

        private void CarregaConfig()
        {
            MenuConfig menuConfig = new MenuConfig();

            CBDificuldade.SelectedIndex = menuConfig.GetDificuldadeConfig();

            CBTempo.SelectedIndex = menuConfig.GetTempoBombaConfig();

            int campo = menuConfig.GetCampoConfig();

            if (campo == 10)
            {
                Jx10.IsChecked = true;
            }
            else if (campo == 20)
            {
                Jx20.IsChecked = true;
            }
            else if (campo == 30)
            {
                Jx30.IsChecked = true;
            }
            else if (campo == 40)
            {
                Jx40.IsChecked = true;
            }
            else
            {
                Jx10.IsChecked = true;
            }

            TBPlayerName.Text = menuConfig.GetNomePlayerConfig();
        }

    }
}
