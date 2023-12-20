using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para ViewCampoMinado.xaml
    /// </summary>
    public partial class ViewCampoMinado : Window
    {
        private CampoMinado campoMinado;
        private ButtonCelula[,] Celulas;

        internal ViewCampoMinado(int campo, DIFICULDADE dificuldade)
        {
            InitializeComponent();

            campoMinado = new CampoMinado(campo, dificuldade);
            
            campoMinado.GeraMatriz();

            CarregarCampoMinado();
        }

        private Button CriarCelula(int linha, int coluna)
        {
            int tCelula = 0;
            if (campoMinado.GetCampoX() == 10)
            {
                tCelula = 50;
                CampoMinado.Height = 580;
                CampoMinado.Width = 560;
            }
            if (campoMinado.GetCampoX() == 20)
            {
                tCelula = 30;
                CampoMinado.Height = 680;
                CampoMinado.Width = 660;
            }
            if (campoMinado.GetCampoX() == 30)
            {
                tCelula = 25;
                CampoMinado.Height = 830;
                CampoMinado.Width = 810;
            }
            if (campoMinado.GetCampoX() == 40)
            {
                tCelula = 22;
                CampoMinado.Height = 960;
                CampoMinado.Width = 940;
            }

            Button celula = new ButtonCelula(linha, coluna);
            celula.Width = tCelula;
            celula.Height = tCelula;
            //celula.Background = Brushes.GreenYellow;
            celula.BorderBrush = Brushes.Black;
            //celula.Content = campoMinado.Get(linha,coluna);
            celula.Content = "";
            celula.FontSize = 14;
            celula.SetValue(Grid.RowProperty, linha);
            celula.SetValue(Grid.ColumnProperty, coluna);
            celula.Click += BTCelula_Click;

            Celulas[linha, coluna] = (ButtonCelula)celula;

            return celula;
        }

        private void CarregarCampoMinado()
        {
            Celulas = new ButtonCelula[campoMinado.GetCampoX(), campoMinado.GetCampoX()];
            GCampoMinado.ColumnDefinitions.Clear();
            GCampoMinado.RowDefinitions.Clear();

            for (int i = 0; i < campoMinado.GetCampoX(); i++)
            {
                ColumnDefinition campoColumn = new ColumnDefinition();
                campoColumn.Width = GridLength.Auto;
                GCampoMinado.ColumnDefinitions.Add(campoColumn);
            }

            for (int i = 0; i < campoMinado.GetCampoX(); i++)
            {
                RowDefinition campoRow = new RowDefinition();
                campoRow.Height = GridLength.Auto;
                GCampoMinado.RowDefinitions.Add(campoRow);
            }

            for (int linha = 0; linha < campoMinado.GetCampoX(); linha++)
            {
                ColumnDefinition campoColumn = new ColumnDefinition();
                campoColumn.Width = GridLength.Auto;
                GCampoMinado.ColumnDefinitions.Add(campoColumn);

                RowDefinition campoRow = new RowDefinition();
                campoRow.Height = GridLength.Auto;
                GCampoMinado.RowDefinitions.Add(campoRow);

                for (int coluna = 0; coluna < campoMinado.GetCampoX(); coluna++) 
                {
                    Button BTcelula = CriarCelula(linha, coluna);

                    GCampoMinado.Children.Add(BTcelula);
                }
            }
        }

        private void ViewBombasDerota()
        {



            
            

        }

        private void VoltaInicio()
        {
            MainWindow menuIniciar = new MainWindow();
            this.Close();
            menuIniciar.Show();
        }

        private void MostrarCelula(int linha, int coluna)
        {
            if (!campoMinado.IsBomba(linha, coluna) && Celulas[linha, coluna].Content.ToString() == "")
            {
                Celulas[linha, coluna].Content = campoMinado.Get(linha, coluna);

                if (campoMinado.TemAlgo(linha, coluna))
                {
                    Celulas[linha, coluna].Content = campoMinado.Get(linha, coluna);
                }
                else
                {
                    Celulas[linha, coluna].Content = " ";
                }

                if (campoMinado.TemAlgo(linha, coluna))
                {
                    return;
                }
                else
                {
                    if (linha - 1 >= 0 && coluna - 1 >= 0)
                    {
                        MostrarCelula(linha - 1, coluna - 1);
                    }

                    if (linha - 1 >= 0 && coluna >= 0)
                    {
                        MostrarCelula(linha - 1, coluna);
                    }

                    if (linha - 1 >= 0 && coluna + 1 >= 0)
                    {
                        MostrarCelula(linha - 1, coluna + 1);
                    }

                    if (linha >= 0 && coluna - 1 >= 0)
                    {
                        MostrarCelula(linha , coluna - 1);
                    }

                    if (linha >= 0 && coluna >= 0)
                    {
                        MostrarCelula(linha , coluna);
                    }

                    if (linha >= 0 && coluna + 1 >= 0)
                    {
                        MostrarCelula(linha , coluna + 1);
                    }

                    if (linha + 1 >= 0 && coluna - 1 >= 0)
                    {
                        MostrarCelula(linha + 1, coluna - 1);
                    }

                    if (linha + 1 >= 0 && coluna >= 0)
                    {
                        MostrarCelula(linha + 1, coluna);
                    }

                    if (linha + 1 >= 0 && linha + 1 < 10 && coluna + 1 >= 0 )
                    {
                        MostrarCelula(linha + 1, coluna + 1);
                    }


                }
            }
        }



        private void BTCelula_Click(object sender, RoutedEventArgs e) 
        {
            ButtonCelula BTCel = (ButtonCelula)sender;

            if (campoMinado.IsBomba(BTCel.GetLinha(), BTCel.GetColuna()))
            {
                EndGame endGame = new EndGame(1);
                endGame.Owner = this;   
                endGame.ShowDialog();

                ViewBombasDerota();

                VoltaInicio();
            }
            else 
            {
                MostrarCelula(BTCel.GetLinha(), BTCel.GetColuna());
            }

            //EndGame endGame = new EndGame("Você encontrou todas as bombas!!", 2);


        }





    }
}
