namespace MicroondasDigital.Core.Interfaces
{
    public interface IMicroondas
    {
        void IniciarAquecimento(int tempoSegundos, int potencia);
        void PausarOuCanclearAquecimento();
        void IniciarAquecimentoRapido();
        void AcrescentarTempo();
    }
}
