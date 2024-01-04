using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

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

        public Scores() 
        {
        }

        public Scores(string nome, DateTime tempoLimite, DateTime tempoJogo, DIFICULDADE dificuldade, int campo)
        {
            Nome = nome;
            TempoLimite = tempoLimite;
            TempoJogo = tempoJogo;
            Dificuldade = dificuldade;
            Campo = campo;
            
            GravaScore();
        }

        public void GravaScore()
        {
            string score = $"{Nome},{TempoLimite.ToString("mm/ss")},{TempoJogo.ToString("mm/ss")},{Dificuldade.ToString()},{Campo.ToString()}--";

            try
            {
                if (File.Exists(FilePath))
                {
                    listScores = File.ReadAllLines(FilePath).ToList();
                   
                    if (listScores.Count > 0)
                    {
                        listScores.Add(score);
                        File.WriteAllLines(FilePath, listScores);
                    }
                }
                else
                {
                    listScores.Add(score);
                    File.WriteAllLines(FilePath, listScores);
                }
            }
            catch( Exception e )
            {
                MessageBox.Show($"ERRO AO GRAVAR ARQUIVO: {e}", "ERRO!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public List<string> GetListScores()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    listScores = File.ReadAllLines(FilePath).ToList();

                    return listScores;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERRO AO LER ARQUIVO: {e}", "ERRO!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return listScores = new List<string>();
        }

        public int CalculoDeTempo()
        {
            return 0;
        }

    }
}
