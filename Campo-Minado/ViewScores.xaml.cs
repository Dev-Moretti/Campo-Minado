﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para ViewScores.xaml
    /// </summary>
    public partial class ViewScores : Window
    {
        public ViewScores()
        {
            InitializeComponent();
        }

        public void PosicoesScore()
        {
            Scores score = new Scores();
            List<string> listScore = new List<string>();
            List<string> listTemp = score.GetListScores();
            
            foreach(string linha in listTemp)
            {
                string[] dados = linha.Split(',');



            }
        }








    }
}
