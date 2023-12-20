using System;

namespace Campo_Minado
{
    internal class CampoMinado
    {
        private int Campo;
        private DIFICULDADE Dificuldade;
        private int[,] Matriz;

        public CampoMinado(int campo, DIFICULDADE dificuldade)
        {
            Campo = campo;
            Dificuldade = dificuldade;
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
            int bombas = 0;

            if (Dificuldade == DIFICULDADE.Iniciante)
            {
                bombas = Campo / 2;
            }
            else if (Dificuldade == DIFICULDADE.Normal)
            {
                bombas = Campo;
            }
            else if (Dificuldade == DIFICULDADE.Dificil)
            {
                bombas = Campo * 3;
            }
            else if (Dificuldade == DIFICULDADE.Epico)
            {
                bombas = Campo * 5;
            }

            for (int i = 0; i <= bombas; i++)
            {
                do
                {
                    l = rand.Next(0, Campo - 1);
                    c = rand.Next(0, Campo - 1);

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

        public int Get(int linha, int coluna)
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
    }
}
