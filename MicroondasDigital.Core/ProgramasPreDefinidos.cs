using System;


namespace MicroondasDigital.Core
{
    public static class ProgramasPreDefinidos
    {
        public static readonly ProgramaAquecimento Pipoca = new ProgramaAquecimento
        {
            Nome = "Pipoca",
            Alimento = "Pipoca (de micro-ondas)",
            Tempo = 180, // 3 minutos em segundos
            Potencia = 7,
            Instrucoes = "Observar o barulho de estouros do milho..."
        };

        public static readonly ProgramaAquecimento Leite = new ProgramaAquecimento
        {
            Nome = "Leite",
            Alimento = "Leite",
            Tempo = 300, // 5 minutos em segundos
            Potencia = 5,
            Instrucoes = "Cuidado com aquecimento de líquidos..."
        };

        public static readonly ProgramaAquecimento CarnesDeBoi = new ProgramaAquecimento
        {
            Nome = "Carnes de boi",
            Alimento = "Carne em pedaço ou fatias",
            Tempo = 840, // 14 minutos em segundos
            Potencia = 4,
            Instrucoes = "Interrompa o processo na metade..."
        };

        public static readonly ProgramaAquecimento Frango = new ProgramaAquecimento
        {
            Nome = "Frango",
            Alimento = "Frango (qualquer corte)",
            Tempo = 480, // 8 minutos em segundos
            Potencia = 7,
            Instrucoes = "Interrompa o processo na metade..."
        };

        public static readonly ProgramaAquecimento Feijao = new ProgramaAquecimento
        {
            Nome = "Feijão",
            Alimento = "Feijão congelado",
            Tempo = 480, // 8 minutos em segundos
            Potencia = 9,
            Instrucoes = "Deixe o recipiente destampado..."
        };
    }
}
