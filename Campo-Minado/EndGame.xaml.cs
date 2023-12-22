using System;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        private string msg1 = "Você pisou em uma bomba!!";
        private string msg2 = "Você encontrou todas as bombas!!";

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

            //this.Top = (double)WindowStartupLocation.CenterOwner;
            //this.Left = (double)WindowStartupLocation.CenterOwner;

            //this.Show();
            //this.WindowStartupLocation = WindowStartupLocation.Manual;

            //for (int i = 0; i < 5; i++)
            //{
            //    this.Left += 5;
            //    this.Top += 5;
            //    System.Threading.Thread.Sleep(50);
            //    this.Left -= 5;
            //    this.Top -= 5;
            //    System.Threading.Thread.Sleep(50);
            //    this.Left += 5;
            //    this.Top += 5;
            //    System.Threading.Thread.Sleep(50);
            //    this.Left -= 5;
            //    this.Top -= 5;
            //}
        }

        private void BTInicio(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
