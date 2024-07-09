namespace MicroondasDigital.Core
{
    public class ProgramaAquecimento
    {
        public string Nome { get; set; } = string.Empty;
        public string Alimento { get; set; } = string.Empty;
        public int Tempo { get; set; } // em segundos
        public int Potencia { get; set; }
        public string Instrucoes { get; set; } = string.Empty;
        public string CaractereAquecimento { get; set; } = ".";
    }
}
