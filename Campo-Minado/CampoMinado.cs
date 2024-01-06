using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Xml;

namespace Campo_Minado
{
    internal class CampoMinado
    {
        private int Campo;
        private DIFICULDADE Dificuldade;
        private int[,] Matriz;
        private List<Point> Bandeiras;
        private int Bombas;
        private string NomePlayer;
        private TimeSpan TempoBomba;
        private TimeSpan TempoJogou;


        public CampoMinado(int campo, DIFICULDADE dificuldade, string nomePlayer, TimeSpan tempoBomba)
        {
            Campo = campo;
            Dificuldade = dificuldade;
            NomePlayer = nomePlayer;
            TempoBomba = tempoBomba;
        }

        public int GetCampoX()
        {
            return Campo;
        }

        public void GeraMatriz()
        {
            Matriz = new int[Campo, Campo];

            Random rand = new Random();
            int l = 0;
            int c = 0;
            Bombas = 0;

            if (Dificuldade == DIFICULDADE.Iniciante)
            {
                Bombas = Campo / 2;
            }
            else if (Dificuldade == DIFICULDADE.Normal)
            {
                Bombas = Campo;
            }
            else if (Dificuldade == DIFICULDADE.Dificil)
            {
                Bombas = Campo * 3;
            }
            else if (Dificuldade == DIFICULDADE.Epico)
            {
                Bombas = Campo * 5;
            }

            Bandeiras = new List<Point>();

            for (int i = 0; i < Bombas; i++)
            {
                do
                {
                    l = rand.Next(0, Campo -1);
                    c = rand.Next(0, Campo -1);

                } while (Matriz[l, c] == -1);

                this.Matriz[l, c] = -1;

                if (l - 1 >= 0 && c - 1 >= 0)
                {
                    if (Matriz[l - 1, c - 1] > -1)
                    {
                        Matriz[l - 1, c - 1]++;
                    }
                }

                if (l - 1 >= 0)
                {
                    if (Matriz[l - 1, c] > -1)
                    {
                        Matriz[l - 1, c]++;
                    }
                }

                if (l - 1 >= 0 && c + 1 < Campo)
                {
                    if (Matriz[l - 1, c + 1] > -1)
                    {
                        Matriz[l - 1, c + 1]++;
                    }
                }

                if (c - 1 >= 0)
                {
                    if (Matriz[l, c - 1] > -1)
                    {
                        Matriz[l, c - 1]++;
                    }
                }

                if (c + 1 < Campo)
                {
                    if (Matriz[l, c + 1] > -1)
                    {
                        Matriz[l, c + 1]++;
                    }
                }

                if (l + 1 < Campo && c - 1 >= 0)
                {
                    if (Matriz[l + 1, c - 1] > -1)
                    {
                        Matriz[l + 1, c - 1]++;
                    }
                }

                if (l + 1 < Campo)
                {
                    if (Matriz[l + 1, c] > -1)
                    {
                        Matriz[l + 1, c]++;
                    }
                }

                if (l + 1 < Campo && c + 1 < Campo)
                {
                    if (Matriz[l + 1, c + 1] > -1)
                    {
                        Matriz[l + 1, c + 1]++;
                    }
                }
            }
        }

        public int GetMatriz(int linha, int coluna)
        {
            return Matriz[linha, coluna];
        }

        public bool IsBomba(int linha, int coluna)
        {
             return Matriz[linha, coluna] == -1;
        }
               
        public bool TemAlgo(int linha, int coluna)
        {
            return Matriz[linha, coluna] != 0;
        }

        public void addBandeira(int linha, int coluna)
        { 
            Point p = new Point(linha, coluna);
            Bandeiras.Add(p);
        }

        public void RemoveBandeira(int linha, int coluna)
        {
            Point p;

            for (int i = 0; i < Bandeiras.Count; i++)
            {
                p = Bandeiras.ElementAt(i);
                
                if (p.X == linha && p.Y == coluna)
                {
                    Bandeiras.Remove(p);
                }
            }
        }

        public bool CheckBandeira()
        {
            if (Bandeiras.Count != Bombas)
            {
                return false;
            }

            Point p;

            for(int i = 0; i < Bombas; i++)
            {
                p = Bandeiras.ElementAt(i);
                if(!IsBomba((int)p.X, (int)p.Y))
                {
                    return false;
                }
            }

            return true;
        }

        public string GetNomePlayer()
        {
            return NomePlayer;
        }

        public TimeSpan GetTempoBomba()
        {
            return TempoBomba; 
        }

        public void SetTempoJogou(TimeSpan tempo)
        {
            TempoJogou = tempo;
        }

        public TimeSpan GetTempoJogou()
        {
            return TempoJogou;
        }

        public DIFICULDADE GetDificuldade()
        {
            return Dificuldade;
        }

    }
}