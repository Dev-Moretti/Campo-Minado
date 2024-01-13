using System;
using System.Collections.Generic;
using System.Security.RightsManagement;

namespace Campo_Minado
{
    public class Score : IComparable<Score>
    {
        public string Nome { get; set; }
        public TimeSpan TempoBomba { get; set; }
        public TimeSpan TempoJogado { get; set; }
        public DIFICULDADE Dificuldade { get; set; }
        public int Campo { get; set; }
        public int Bombas { get; set; }

        public Score() 
        {

        }

        public Score(string nome, TimeSpan tempoBomba, TimeSpan tempoJogado, DIFICULDADE dificuldade, int campo, int quantidadeBombas)
        {
            Nome = nome;
            TempoBomba = tempoBomba;
            TempoJogado = tempoJogado;
            Dificuldade = dificuldade;
            Campo = campo;
            Bombas = quantidadeBombas;
        }

        public int CompareTo(Score other)
        {
            if(this.TempoJogado > other.TempoJogado)
            {
                return 1;
            }
            else if (this.TempoJogado < other.TempoJogado)
            {
                return -1;
            }

            return 0;
        }

        public List<Score> OrdenarLista(List<Score> listScore, int? btcampo, DIFICULDADE? btdificuldade, TimeSpan? bttempo)
        {
            List<Score> listTemp = new List<Score>();

            foreach (Score item in listScore)
            {
                if (btcampo != null && !item.Campo.Equals(btcampo))
                {
                    continue;
                }

                if (btdificuldade != null && !item.Dificuldade.Equals(btdificuldade))
                {
                    continue;
                }

                if (bttempo != null && !item.TempoBomba.Equals(bttempo))
                {
                    continue;
                }

                listTemp.Add(item);
            }

            listTemp.Sort();

            return listTemp;
        }

    }
}
