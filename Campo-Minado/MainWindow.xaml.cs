﻿using System.Windows;

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
            int campo = 0;
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

            ViewCampoMinado campoMinado = new ViewCampoMinado(campo, dificuldade);
            campoMinado.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            campoMinado.Show();

            this.Close();
        }
    }
}
