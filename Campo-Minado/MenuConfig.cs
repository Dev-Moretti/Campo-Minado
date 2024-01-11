using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    internal class MenuConfig
    {
        private int Campo;
        private DIFICULDADE Dificuldade;
        private TimeSpan TempoBomba;
        private string NomePlayer;

        public MenuConfig(int campo, DIFICULDADE dificuldade, TimeSpan tempoBomba, string nomePlayer)
        {
            Campo = campo;
            Dificuldade = dificuldade;
            TempoBomba = tempoBomba;
            NomePlayer = nomePlayer;
        }

        public MenuConfig() { }

        public void CaregarDao()
        {
            MenuConfigDAO dao = new MenuConfigDAO();

            List<MenuConfig> listDao = dao.GetMenuConfigs();

            foreach (MenuConfig item in listDao)
            {
                item.Campo = Campo;
                item.Dificuldade = Dificuldade;
                item.TempoBomba = TempoBomba;
                item.NomePlayer = NomePlayer;
            }
        }

        public int GetCampo()
        {
            CaregarDao();

            return Campo;
        }
        public DIFICULDADE GetDificuldade()
        {
            CaregarDao();

            return Dificuldade;
        }
        public TimeSpan GetTempoBomba()
        {
            CaregarDao();

            return TempoBomba;
        }
        public string GetNomePlayer()
        {
            CaregarDao();

            return NomePlayer;
        }


    }
}
