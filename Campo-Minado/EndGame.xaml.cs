﻿using System;
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
        private string msg1 = "Você pisou em uma bomba!";
        private string msg2 = "Você encontrou todas as bombas!";
        private string msg3 = "O tempo acabou e as bombas explodiram!";
        private string msg4 = "Partida abortada!";
        private ViewCampoMinado view;

        public EndGame(int tipo, ViewCampoMinado view)
        {
            InitializeComponent();
            
            ViewMensagem(tipo);

            this.view = view;
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
            if (tipo == 3)
            {
                EndGameMSG.Content = msg3;
            }
            if (tipo == 4)
            {
                EndGameMSG.Content = msg4;
            }
        }

        private void BTInicio_Click(object sender, RoutedEventArgs e)
        {
            VoltaInicio();
        }

        private void VoltaInicio()
        {
            MainWindow menuIniciar = new MainWindow();

            this.Close();

            menuIniciar.Show();

            this.view.Close();
        }

    }
}
