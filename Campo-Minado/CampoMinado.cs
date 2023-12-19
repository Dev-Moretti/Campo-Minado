using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    internal class CampoMinado
    {
        private int Campo;
        private DIFICULDADE Dificuldade;

        public CampoMinado(int campo, DIFICULDADE dificuldade) 
        {
            Campo = campo;
            Dificuldade = dificuldade;

        }

        public int GetCampoX()
        {
            return Campo;
        }


    }
}
