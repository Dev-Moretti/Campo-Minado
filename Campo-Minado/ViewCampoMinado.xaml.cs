﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        private Scores Score;
        internal ViewCampoMinado(int campo, DIFICULDADE dificuldade, TimeSpan tempoBomba, string nomePlayer)
        {
            InitializeComponent();

            campoMinado = new CampoMinado(campo, dificuldade, nomePlayer, tempoBomba);

            campoMinado.GeraMatriz();

            CarregarCampoMinado();
        }

        private Button CriarCelula(int linha, int coluna)
        {
            //int tCelula = 0;
            int fonte = 0;
            double alturaCelula = 0;

            if (SystemParameters.FullPrimaryScreenHeight > SystemParameters.FullPrimaryScreenWidth)
            {
                alturaCelula = (SystemParameters.FullPrimaryScreenWidth - 100) / campoMinado.GetCampoX();
            }
            else
            {
                alturaCelula = (SystemParameters.FullPrimaryScreenHeight - 100) / campoMinado.GetCampoX();
            }

            if (campoMinado.GetCampoX() == 10)
            {
                fonte = 30;
                //tCelula = 50;
                //CampoMinado.Height = 580;
                //CampoMinado.Width = 560;
            }
            if (campoMinado.GetCampoX() == 20)
            {
                fonte = 20;
                //tCelula = 30;
                //CampoMinado.Height = 680;
                //CampoMinado.Width = 660;
            }
            if (campoMinado.GetCampoX() == 30)
            {
                fonte = 18;
                //tCelula = 25;
                //.Height = 830;
                //CampoMinado.Width = 810;
            }
            if (campoMinado.GetCampoX() == 40)
            {
                fonte = 15;
                //tCelula = 22;
                //CampoMinado.Height = 960;
                //CampoMinado.Width = 940;
            }

            Button celula = new ButtonCelula(linha, coluna);
            celula.Width = alturaCelula;
            celula.Height = alturaCelula;
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
            //Button btVoltar = new Button();
            //btVoltar.

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
                if (GetContent(BTCel.GetLinha(), BTCel.GetColuna()) != "P")
                {
                    EndGame endGame = new EndGame(1);

                    endGame.Owner = this;

                    ViewBombasDerrota();

                    endGame.ShowDialog();

                    VoltaInicio();
                }
            }
            else
            {
                MostrarCelulas(BTCel.GetLinha(), BTCel.GetColuna());
            }
        }

        private void MostrarCelulas(int linha, int coluna)
        {

            if (!campoMinado.IsBomba(linha, coluna) && GetContent(linha, coluna) == "")
            {
                if (campoMinado.TemAlgo(linha, coluna))
                {
                    Celulas[linha, coluna].Content = campoMinado.GetMatriz(linha, coluna);
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
                        MostrarCelulas(linha, coluna - 1);
                    }

                    if (coluna + 1 < campoMinado.GetCampoX())
                    {
                        MostrarCelulas(linha, coluna + 1);
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

        private string GetContent(int linha, int coluna)
        {
            if (Celulas[linha, coluna].Content.GetType() == typeof(Image))
            {
                return "*";
            }
            else
            {
                return Celulas[linha, coluna].Content.ToString();
            }
        }

        private void ViewBombasDerrota()
        {
            for (int linha = 0; linha < campoMinado.GetCampoX(); linha++)
            {
                for (int coluna = 0; coluna < campoMinado.GetCampoX(); coluna++)
                {
                    if (campoMinado.IsBomba(linha, coluna))
                    {
                        if (GetContent(linha, coluna) == "P")
                        {
                            Celulas[linha, coluna].Background = Brushes.Yellow;
                        }
                        else
                        {
                            Celulas[linha, coluna].Background = Brushes.Red;
                        }

                        //Celulas[linha, coluna].Content = new (Properties.Resources.bomb1);

                        // Celulas[linha, coluna].Content = System.Drawing.Image.FromFile($"{System.Environment.CurrentDirectory.ToString()}"+"\\Figuras\\bomb.png");

                        Celulas[linha, coluna].Content = new Image
                        {
                            Source = new BitmapImage(new System.Uri($"{System.Environment.CurrentDirectory.ToString()}" + "\\Figuras\\bomb1.png")),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Stretch = Stretch.Fill
                        };
                    }
                    else if (campoMinado.TemAlgo(linha, coluna))
                    {
                        Celulas[linha, coluna].Content = campoMinado.GetMatriz(linha, coluna);
                        Celulas[linha, coluna].Background = Brushes.Gray;
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
            if (GetContent(celula.GetLinha(), celula.GetColuna()) == "")
            {
                celula.Content = "P";
                celula.Background = Brushes.Yellow;
                campoMinado.addBandeira(celula.GetLinha(), celula.GetColuna());

                if (campoMinado.CheckBandeira())
                {
                    EndGame endGame = new EndGame(2);

                    Score = new Scores(campoMinado.GetNomePlayer(), campoMinado.GetTempoBomba(), campoMinado.GetDificuldade(), campoMinado.GetCampoX()) ;

                    endGame.Owner = this;

                    ViewBombasDerrota();

                    endGame.ShowDialog();

                    VoltaInicio();
                }
            }
            else if (GetContent(celula.GetLinha(), celula.GetColuna()) == "P")
            {
                celula.Content = "";
                celula.Background = Brushes.ForestGreen;
                celula.BorderBrush = Brushes.Black;
                campoMinado.RemoveBandeira(celula.GetLinha(), celula.GetColuna());
            }
        }

        private void VisorTimer(TimeSpan tempoBomba)
        {
            //GVisorTimer.Text = 
        }
    }
}