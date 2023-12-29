using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Campo_Minado
{
    internal class Scores
    {
        private string Nome;
        private DateTime TempoLimite;
        private DateTime TempoJogo;
        private DIFICULDADE Dificuldade;
        private int Campo;
        private List<string> listScores;
        private string FilePath = $"{System.Environment.CurrentDirectory.ToString()}\\Scores\\Score.txt";

        public Scores(string nome, DateTime tempoLimite, DateTime tempoJogo, DIFICULDADE dificuldade, int campo)
        {
            this.Nome = nome;
            this.TempoLimite = tempoLimite;
            this.TempoJogo = tempoJogo;
            this.Dificuldade = dificuldade;
            this.Campo = campo;
            GravaScore();
        }

        public void GravaScore()
        {
            string score = $"{Nome}-{TempoLimite}-{TempoJogo}-{Dificuldade}-{Campo}";

            try
            {
                if (File.Exists(FilePath))
                {
                    listScores = File.ReadAllLines(FilePath).ToList();
                    listScores.Add(score);
                    File.WriteAllLines(FilePath, listScores);
                }
                else
                {
                    listScores.Add(score);
                    File.WriteAllLines(FilePath, listScores);
                }
            }
            catch( Exception e )
            {

            }
        }


    }
}
