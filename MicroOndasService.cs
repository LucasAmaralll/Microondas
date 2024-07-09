public class MicroOndasService : IMicroOndasService
{
    private int tempo;
    private int potencia;
    private bool emAquecimento;
    private StringBuilder stringAquecimento;
    private List<ProgramaAquecimento> programasPreDefinidos;
    private List<ProgramaAquecimento> programasCustomizados;
    private ProgramaAquecimento programaAtual;
    private readonly string caminhoArquivoCustomizado = "programasCustomizados.json";

    public MicroOndasService()
    {
        tempo = 0;
        potencia = 10;
        emAquecimento = false;
        stringAquecimento = new StringBuilder();
        InicializarProgramasPreDefinidos();
        CarregarProgramasCustomizados();
    }

    private void InicializarProgramasPreDefinidos()
    {
        programasPreDefinidos = new List<ProgramaAquecimento>
        {
            new ProgramaAquecimento("Pipoca", "Pipoca (de micro-ondas)", 180, 7, "*", "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento."),
            new ProgramaAquecimento("Leite", "Leite", 300, 5, "#", "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras."),
            new ProgramaAquecimento("Carnes de boi", "Carne em pedaço ou fatias", 840, 4, "&", "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
            new ProgramaAquecimento("Frango", "Frango (qualquer corte)", 480, 7, "@", "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."),
            new ProgramaAquecimento("Feijão", "Feijão congelado", 480, 9, "%", "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.")
        };
    }

    private void CarregarProgramasCustomizados()
    {
        if (File.Exists(caminhoArquivoCustomizado))
        {
            var json = File.ReadAllText(caminhoArquivoCustomizado);
            programasCustomizados = JsonConvert.DeserializeObject<List<ProgramaAquecimento>>(json);
        }
        else
        {
            programasCustomizados = new List<ProgramaAquecimento>();
        }
    }

    private void SalvarProgramasCustomizados()
    {
        var json = JsonConvert.SerializeObject(programasCustomizados, Formatting.Indented);
        File.WriteAllText(caminhoArquivoCustomizado, json);
    }

    public List<ProgramaAquecimento> ObterProgramasPreDefinidos()
    {
        return programasPreDefinidos;
    }

    public List<ProgramaAquecimento> ObterProgramasCustomizados()
    {
        return programasCustomizados;
    }

    public void SelecionarProgramaPreDefinido(string nomePrograma)
    {
        programaAtual = programasPreDefinidos.FirstOrDefault(p => p.Nome == nomePrograma);
        if (programaAtual == null)
            throw new MicroOndasException("Programa de aquecimento não encontrado.");

        tempo = programaAtual.Tempo;
        potencia = programaAtual.Potencia;
        stringAquecimento.Clear();
    }

    public void SelecionarProgramaCustomizado(string nomePrograma)
    {
        programaAtual = programasCustomizados.FirstOrDefault(p => p.Nome == nomePrograma);
        if (programaAtual == null)
            throw new MicroOndasException("Programa de aquecimento não encontrado.");

        tempo = programaAtual.Tempo;
        potencia = programaAtual.Potencia;
        stringAquecimento.Clear();
    }

    public void IniciarAquecimento(int tempo, int potencia)
    {
        if (tempo < 1 || tempo > 120)
            throw new MicroOndasException("O tempo deve estar entre 1 segundo e 2 minutos.");
        
        if (potencia < 1 || potencia > 10)
            throw new MicroOndasException("A potência deve estar entre 1 e 10.");
        
        this.tempo = tempo;
        this.potencia = potencia;
        emAquecimento = true;
        stringAquecimento.Clear();

        // Simula o aquecimento
        Task.Run(() => Aquecer());
    }

    private void Aquecer()
    {
        string caractere = programaAtual != null ? programaAtual.CaractereAquecimento : ".";
        for (int i = 0; i < tempo; i++)
        {
            if (!emAquecimento) break;

            stringAquecimento.Append(new string(caractere, potencia));
            Thread.Sleep(1000); // Simula 1 segundo de aquecimento
        }

        if (emAquecimento)
            stringAquecimento.Append(" Aquecimento concluído");
    }

    public void PausarCancelar()
    {
        emAquecimento = !emAquecimento;
        if (!emAquecimento)
        {
            tempo = 0;
            potencia = 10;
            stringAquecimento.Clear();
            programaAtual = null;
        }
    }

    public string ObterStatusAquecimento()
    {
        return stringAquecimento.ToString();
    }

    public void IniciarRapido()
    {
        IniciarAquecimento(30, 10);
    }

    public void AdicionarProgramaCustomizado(ProgramaAquecimento programa)
    {
        if (programasCustomizados.Any(p => p.CaractereAquecimento == programa.CaractereAquecimento || p.Nome == programa.Nome))
            throw new MicroOndasException("Caractere de aquecimento ou nome do programa já utilizado.");

        programasCustomizados.Add(programa);
        SalvarProgramasCustomizados();
    }
}
