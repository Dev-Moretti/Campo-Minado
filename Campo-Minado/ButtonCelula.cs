using System.Windows.Controls;

namespace Campo_Minado
{
    internal class ButtonCelula : Button
    {
        private int Linha;
        private int Coluna;

        public ButtonCelula(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public int GetLinha()
        {
            return Linha;
        }
        public int GetColuna()
        {
            return Coluna;
        }
    }
}
