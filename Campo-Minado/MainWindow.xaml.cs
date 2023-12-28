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

            nomePlayer = TBPlayerName.Text;

            ViewCampoMinado campoMinado = new ViewCampoMinado(campo, dificuldade, tempoLimite, nomePlayer);
            
            //campoMinado.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            campoMinado.Show();

            this.Close();
        }
    }
}
