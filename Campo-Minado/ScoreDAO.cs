using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Campo_Minado
{
    internal class ScoreDAO
    {
        
        private string path;

        public ScoreDAO(string path)
        {
            this.path = path;
        }

        public ScoreDAO()
        {
            this.path = $"{System.Environment.CurrentDirectory}\\Score.txt";
        }

        public bool GravarListScore(List<Score> listScore)
        {
            try
            {
                File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(listScore));
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Score> LerListaScore()
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Score>>(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                return new List<Score>();
            }
        }


    }
}
