

namespace MicroondasDigital.Core
{
    public class ProgramaAquecimento
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; } // em segundos
        public int Potencia { get; set; }
        public string Instrucoes { get; set; }
    }
}
