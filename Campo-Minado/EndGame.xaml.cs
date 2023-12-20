using System.Reflection.Emit;
using System.Windows;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        public EndGame(string mensagem, int tipo)
        {
            InitializeComponent();

            ExibeTela(mensagem, tipo);
        }

        public void ExibeTela(string mensagem, int tipo)
        {
            EndGameMSG.Content = mensagem;
        }



    }
}
