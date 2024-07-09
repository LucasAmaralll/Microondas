using System.Collections.Generic;

namespace MicroondasDigital.Core.Interfaces
{
    public interface IMicroondas
    {
        void IniciarAquecimento(int tempoSegundos, int potencia);
        void PausarOuCanclearAquecimento();
        void IniciarAquecimentoRapido();
        void AcrescentarTempo();
        void IniciarProgramaPreDefinido(ProgramaAquecimento programa);
        void AdicionarProgramaCustomizado(ProgramaAquecimento programa);
        List<ProgramaAquecimento> ObterProgramasCustomizados();
    }
}
