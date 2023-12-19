using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Campo_Minado
{
    /// <summary>
    /// Lógica interna para ViewCampoMinado.xaml
    /// </summary>
    public partial class ViewCampoMinado : Window
    {
        private CampoMinado campoMinado;

        internal ViewCampoMinado(int campo, DIFICULDADE dificuldade)
        {
            InitializeComponent();
            this.campoMinado = new CampoMinado(campo, dificuldade);
            CarregarCampoMinado();
        }

        private void CarregarCampoMinado()
        {
            int tCelula = 0;
            if(campoMinado.GetCampoX() == 10)
            {
                tCelula = 50;
                CampoMinado.Height = 580;
                CampoMinado.Width = 560;
            }
            if (campoMinado.GetCampoX() == 20)
            {
                tCelula = 30;
                CampoMinado.Height = 680;
                CampoMinado.Width = 660;
            }
            if (campoMinado.GetCampoX() == 30)
            {
                tCelula = 25;
                CampoMinado.Height = 830;
                CampoMinado.Width = 810;
            }
            if (campoMinado.GetCampoX() == 40)
            {
                tCelula = 22;
                CampoMinado.Height = 960;
                CampoMinado.Width = 940;
            }

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

            for (int i = 0; i < campoMinado.GetCampoX(); i++)
            {
                ColumnDefinition campoColumn = new ColumnDefinition();
                campoColumn.Width = GridLength.Auto;
                GCampoMinado.ColumnDefinitions.Add(campoColumn);

                RowDefinition campoRow = new RowDefinition();
                campoRow.Height = GridLength.Auto;
                GCampoMinado.RowDefinitions.Add(campoRow);

                for (int j = 0; j < campoMinado.GetCampoX(); j++) 
                {
                    Button BTcelula = new Button();
                    BTcelula.Width = tCelula;
                    BTcelula.Height = tCelula;
                    BTcelula.Content = "B";
                    BTcelula.FontSize = 14;
                    BTcelula.SetValue(Grid.RowProperty, i);
                    BTcelula.SetValue(Grid.ColumnProperty, j);

                    GCampoMinado.Children.Add(BTcelula);
                }


            }

        }




    }
}
