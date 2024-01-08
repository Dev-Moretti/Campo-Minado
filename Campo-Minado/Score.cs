using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Campo_Minado
{
    public class Score
    {
        public string Nome { get; set; }
        public TimeSpan TempoBomba{get; set;}
        public TimeSpan TempoJogado{get; set;}
        public DIFICULDADE Dificuldade{get; set;}
        public int Campo{get; set;}
        public int Bombas{get; set;}
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



    }
}
