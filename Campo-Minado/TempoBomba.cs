using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    internal class TempoBomba
    {
        private DateTime TempoLimite;

        private DateTime TempoJogo;


        public TempoBomba(DateTime tempoLimite) 
        {
            TempoLimite = tempoLimite;
        }

        public DateTime GetTempoLimite()
        {
            return TempoLimite;
        }
        public DateTime GetTempoJogo()
        {
            return TempoJogo;
        }

        public void SetTempoJogo(DateTime tempoJogo)
        {
            TempoJogo = tempoJogo;
        }

    }
}
