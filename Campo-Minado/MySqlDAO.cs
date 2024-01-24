using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    internal class MySqlDAO
    {

        public static string SqlInsertScore = "INSERT INTO scores (nomePlayer, tempoBomba, tempoJogado, dificuldade, tamanhoCampo, quantidadeBombas) VALUES " +
                                               "(@nomePlayer, @tempoBomba, @tempoJogado, @dificuldade, @tamanhoCampo, @quantidadeBombas);";
        public static void GravarScore(List<Score> score)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(SqlInsertScore);

            mySqlCommand.Connection = new MySqlConnection("server=localhost;database=campo_minado;user=campo_minado;password=campMine@25");

            mySqlCommand.Connection.Open();

            foreach (var scoreItem in score)
            {
                mySqlCommand.Parameters.Clear();

                mySqlCommand.Parameters.AddWithValue("@nomePlayer", scoreItem.Nome);
                mySqlCommand.Parameters.AddWithValue("@tempoBomba", scoreItem.TempoBomba);
                mySqlCommand.Parameters.AddWithValue("@tempoJogado", scoreItem.TempoJogado);
                mySqlCommand.Parameters.AddWithValue("@dificuldade", scoreItem.Dificuldade);
                mySqlCommand.Parameters.AddWithValue("@tamanhoCampo", scoreItem.Campo);
                mySqlCommand.Parameters.AddWithValue("@quantidadeBombas", scoreItem.Bombas);
                
                mySqlCommand.ExecuteNonQuery();

            }

            mySqlCommand.Connection.Close();

        }


        public static List<Score> LerScore()
        {
            return new List<Score>();
        }


    }
}
