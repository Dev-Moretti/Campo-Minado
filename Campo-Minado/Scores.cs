﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Campo_Minado
{
    internal class Scores
    {
        private string Nome;
        private TimeSpan TempoBomba;
        private TimeSpan TempoJogado;
        private DIFICULDADE Dificuldade;
        private int Campo;
        private List<string> listScores = new List<string>();
        private string FilePath = $"{System.Environment.CurrentDirectory.ToString()}\\Scores\\Score.txt";

        public Scores() 
        {
        }

        public Scores(string nome, TimeSpan tempoBomba, TimeSpan tempoJogado, DIFICULDADE dificuldade, int campo)
        {
            Campo = campo;
            Nome = nome;
            TempoBomba = tempoBomba;
            Dificuldade = dificuldade;
            GravaScore();
        }

        public void SetTimeJogado(TimeSpan tempoJogado)
        {
            TempoJogado = tempoJogado;
        }

        public void GravaScore()
        {
            string score = $"{Nome},{TempoBomba.TotalMinutes / 60000},{TempoJogado.Minutes}:{TempoJogado.TotalSeconds},{Dificuldade.ToString()},{Campo.ToString()}--";

            try
            {
                if (File.Exists(FilePath))
                {
                    listScores = File.ReadAllLines(FilePath).ToList();
                   
                    if (listScores.Count >= 0)
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
