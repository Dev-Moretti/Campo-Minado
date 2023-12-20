using System.Reflection.Emit;
using System.Windows;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        private string msg1 = "Você pisou em uma bomba!!";
        private string msg2 = "Você encotrou todas as bombas!!";

        public EndGame(int tipo)
        {
            InitializeComponent();

            ViewMensagem(tipo);
        }

        private void ViewMensagem(int tipo)
        {
            if (tipo == 1)
            {
                EndGameMSG.Content = msg1;
            }
            if (tipo == 2)
            {
                EndGameMSG.Content = msg2;
            }
        }

        private void BTInicio(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
