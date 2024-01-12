using System.Collections.Generic;

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
                Campo = (item.Campo);
                Dificuldade = item.Dificuldade;
                TempoBomba = item.TempoBomba;
                NomePlayer = item.NomePlayer;
            }
        }

        public dynamic GetCampoConfig()
        {
            CaregarDao();

            return Campo;
        }
        public int GetDificuldadeConfig()
        {
            CaregarDao();

            return Dificuldade.GetHashCode();

        }
        public int GetTempoBombaConfig()
        {
            CaregarDao();

            return TempoBomba.GetHashCode();
        }
        public string GetNomePlayerConfig()
        {
            CaregarDao();

            return NomePlayer;
        }


    }
}
