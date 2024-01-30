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
        protected static string conectionString = "server=localhost;database=campo_minado;user=campo_minado;password=campMine@25";

        public void GravarScore(string nomePlayer, TimeSpan tempoBomba, TimeSpan tempoJogado, DIFICULDADE dificuldade, int campo, int bombas)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO scores (" +
                                              "nomePlayer, " +
                                              "tempoBomba, " +
                                              "tempoJogado, " +
                                              "dificuldade, " +
                                              "tamanhoCampo, " +
                                              "quantidadeBombas )" +
                                              "VALUES (" +
                                              "@nomePlayer, " +
                                              "@tempoBomba, " +
                                              "@tempoJogado, " +
                                              "@dificuldade, " +
                                              "@tamanhoCampo, " +
                                              "@quantidadeBombas );");

            mySqlCommand.Connection = new MySqlConnection(conectionString);

            mySqlCommand.Connection.Open();

            mySqlCommand.Parameters.Clear();

            mySqlCommand.Parameters.AddWithValue("@nomePlayer", nomePlayer);
            mySqlCommand.Parameters.AddWithValue("@tempoBomba", tempoBomba);
            mySqlCommand.Parameters.AddWithValue("@tempoJogado", tempoJogado);
            mySqlCommand.Parameters.AddWithValue("@dificuldade", dificuldade);
            mySqlCommand.Parameters.AddWithValue("@tamanhoCampo", campo);
            mySqlCommand.Parameters.AddWithValue("@quantidadeBombas", bombas);

            mySqlCommand.ExecuteNonQuery();

            mySqlCommand.Connection.Close();
        }

        public List<Score> LerScore()
        {
            MySqlCommand mySql = new MySqlCommand("SELECT * FROM scores;");

            mySql.Connection = new MySqlConnection(conectionString);
            mySql.Connection.Open();
            mySql.ExecuteNonQuery();
            mySql.Connection.Close();


            return new List<Score>();
        }


    }
}
