using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

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
            int fonte = 0;

            if (campoMinado.GetCampoX() == 10)
            {
                tCelula = 50;
                fonte = 30;
                CampoMinado.Height = 580;
                CampoMinado.Width = 560;
            }
            if (campoMinado.GetCampoX() == 20)
            {
                tCelula = 30;
                fonte = 20;
                CampoMinado.Height = 680;
                CampoMinado.Width = 660;
            }
            if (campoMinado.GetCampoX() == 30)
            {
                tCelula = 25;
                fonte = 18;
                CampoMinado.Height = 830;
                CampoMinado.Width = 810;
            }
            if (campoMinado.GetCampoX() == 40)
            {
                tCelula = 22;
                fonte = 15;
                CampoMinado.Height = 960;
                CampoMinado.Width = 940;
            }

            Button celula = new ButtonCelula(linha, coluna);
            celula.Width = tCelula;
            celula.Height = tCelula;
            celula.Background = Brushes.ForestGreen;
            celula.BorderBrush = Brushes.Black;
            //celula.Content = campoMinado.Get(linha,coluna);
            celula.Content = "";
            celula.FontSize = fonte;
            celula.SetValue(Grid.RowProperty, linha);
            celula.SetValue(Grid.ColumnProperty, coluna);
            celula.Click += BTCelula_Click;
            celula.MouseRightButtonDown += MouseRightButton;

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

        private void VoltaInicio()
        {
            MainWindow menuIniciar = new MainWindow();
            this.Close();
            menuIniciar.Show();
        }

        private void BTCelula_Click(object sender, RoutedEventArgs e) 
        {
            ButtonCelula BTCel = (ButtonCelula)sender;

            if (campoMinado.IsBomba(BTCel.GetLinha(), BTCel.GetColuna()))
            {
                EndGame endGame = new EndGame(1);
                
                endGame.Owner = this;

                endGame.ShowDialog();

                ViewBombasDerrota();

                VoltaInicio();
            }
            else 
            {
                MostrarCelulas(BTCel.GetLinha(), BTCel.GetColuna());
            }
        }

        private void MostrarCelulas(int linha, int coluna)
        {
            if (!campoMinado.IsBomba(linha, coluna) && Celulas[linha, coluna].Content == "")
            {

                if (campoMinado.TemAlgo(linha, coluna))
                {
                    Celulas[linha, coluna].Content = campoMinado.Get(linha, coluna);
                    Celulas[linha, coluna].Background = Brushes.SkyBlue;
                }
                else
                {
                    Celulas[linha, coluna].Content = " ";
                    Celulas[linha, coluna].Background = Brushes.Gray;
                }

                if (campoMinado.TemAlgo(linha, coluna))
                {
                    return;
                }
                else
                {
                    if (linha - 1 >= 0 && coluna - 1 >= 0)
                    {
                        MostrarCelulas(linha - 1, coluna - 1);
                    }

                    if (linha - 1 >= 0)
                    {
                        MostrarCelulas(linha - 1, coluna);
                    }

                    if (linha - 1 >= 0 && coluna + 1 < campoMinado.GetCampoX())
                    {
                        MostrarCelulas(linha - 1, coluna + 1);
                    }

                    if (coluna - 1 >= 0)
                    {
                        MostrarCelulas(linha , coluna - 1);
                    }

                    if (coluna + 1 < campoMinado.GetCampoX())
                    {
                        MostrarCelulas(linha , coluna + 1);
                    }

                    if (linha + 1 < campoMinado.GetCampoX() && coluna - 1 >= 0)
                    {
                        MostrarCelulas(linha + 1, coluna - 1);
                    }

                    if (linha + 1 < campoMinado.GetCampoX())
                    {
                        MostrarCelulas(linha + 1, coluna);
                    }

                    if (linha + 1 < campoMinado.GetCampoX() && coluna + 1 < campoMinado.GetCampoX())
                    {
                        MostrarCelulas(linha + 1, coluna + 1);
                    }
                }
            }
        }

        private void ViewBombasDerrota()
        {
            for (int linha = 0; linha < campoMinado.GetCampoX(); linha++)
            {
                for(int coluna = 0; coluna < campoMinado.GetCampoX(); coluna++) 
                {
                    if(campoMinado.IsBomba(linha, coluna))
                    {
                        Celulas[linha, coluna].Content = "*";
                        Celulas[linha, coluna].Background = Brushes.Red;
                    }
                    else if (campoMinado.TemAlgo(linha, coluna))
                    {
                        Celulas[linha, coluna].Content = campoMinado.Get(linha, coluna);
                        Celulas[linha, coluna].Background= Brushes.Gray;
                    }
                    else
                    {
                        Celulas[linha, coluna].Content = " ";
                        Celulas[linha, coluna].Background = Brushes.Silver;
                    }
                }
            }
        }

        private void MouseRightButton(object sender, MouseButtonEventArgs e)
        {
            ButtonCelula celula = (ButtonCelula)sender;
            if (celula.Content == "")
            {
                celula.Content = "P";
                celula.Background = Brushes.Yellow;
            }
            else if (celula.Content == "P")
            {
                celula.Content = "";
                celula.Background = Brushes.ForestGreen;
            }
        }


    }
}
