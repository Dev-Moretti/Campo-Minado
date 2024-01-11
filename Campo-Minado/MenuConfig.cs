using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    internal class MenuConfig
    {
        public int Campo { get; set; }
        public DIFICULDADE Dificuldade { get; set; }
        public TEMPO TempoBomba { get; set; }
        public string NomePlayer { get; set; }

        public MenuConfig(int campo, DIFICULDADE dificuldade, TEMPO tempoBomba, string nomePlayer)
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
                Campo = item.Campo;
                Dificuldade = item.Dificuldade;
                TempoBomba = item.TempoBomba;
                NomePlayer = item.NomePlayer;
            }
        }

        public int GetCampo()
        {
            CaregarDao();

            return Campo;
        }
        public int GetDificuldade()
        {
            CaregarDao();

            return Dificuldade.GetHashCode();

        }
        public int GetTempoBomba()
        {
            CaregarDao();

            return TempoBomba.GetHashCode();
        }
        public string GetNomePlayer()
        {
            CaregarDao();

            return NomePlayer;
        }


    }
}
