using System;
using System.Windows.Forms;

namespace MicroOndasDigital
{


    public partial class Form1 : Form
    {
        private MicroOndasService microOndasService;

        public Form1()
        {
            InitializeComponent();
            microOndasService = new MicroOndasService();
            CarregarProgramasPreDefinidos();
            CarregarProgramasCustomizados();
        }

        private void CarregarProgramasPreDefinidos()
        {
            var programas = microOndasService.ObterProgramasPreDefinidos();
            foreach (var programa in programas)
            {
                comboBoxProgramas.Items.Add(programa.Nome);
            }
        }

        private void CarregarProgramasCustomizados()
        {
            var programas = microOndasService.ObterProgramasCustomizados();
            foreach (var programa in programas)
            {
                comboBoxProgramas.Items.Add(programa.Nome);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            int tempo = int.Parse(txtTempo.Text);
            int potencia = int.Parse(txtPotencia.Text);
            try
            {
                microOndasService.IniciarAquecimento(tempo, potencia);
                AtualizarStatus();
            }
            catch (MicroOndasException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPausarCancelar_Click(object sender, EventArgs e)
        {
            microOndasService.PausarCancelar();
            AtualizarStatus();
        }

        private void btnIniciarRapido_Click(object sender, EventArgs e)
        {
            microOndasService.IniciarRapido();
            AtualizarStatus();
        }

        private void comboBoxProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomePrograma = comboBoxProgramas.SelectedItem.ToString();
            try
            {
                if (microOndasService.ObterProgramasPreDefinidos().Any(p => p.Nome == nomePrograma))
                {
                    microOndasService.SelecionarProgramaPreDefinido(nomePrograma);
                }
                else
                {
                    microOndasService.SelecionarProgramaCustomizado(nomePrograma);
                }
                AtualizarCampos();
            }
            catch (MicroOndasException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AtualizarCampos()
        {
            var programa = microOndasService.ObterProgramasPreDefinidos().FirstOrDefault(p => p.Nome == comboBoxProgramas.SelectedItem.ToString()) ??
                        microOndasService.ObterProgramasCustomizados().FirstOrDefault(p => p.Nome == comboBoxProgramas.SelectedItem.ToString());
            if (programa != null)
            {
                txtTempo.Text = (programa.Tempo / 60).ToString() + ":" + (programa.Tempo % 60).ToString("D2");
                txtPotencia.Text = programa.Potencia.ToString();
                txtTempo.Enabled = false;
                txtPotencia.Enabled = false;
            }
            else
            {
                txtTempo.Enabled = true;
                txtPotencia.Enabled = true;
            }
        }

        private void AtualizarStatus()
        {
            lblStatus.Text = microOndasService.ObterStatusAquecimento();
        }

        private void btnAdicionarPrograma_Click(object sender, EventArgs e)
        {
            string nome = txtNomePrograma.Text;
            string alimento = txtAlimento.Text;
            int tempo = int.Parse(txtTempoPrograma.Text);
            int potencia = int.Parse(txtPotenciaPrograma.Text);
            string caractere = txtCaractere.Text;
            string instrucoes = txtInstrucoes.Text;

            try
            {
                var novoPrograma = new ProgramaAquecimento(nome, alimento, tempo, potencia, caractere, instrucoes);
                microOndasService.AdicionarProgramaCustomizado(novoPrograma);
                CarregarProgramasCustomizados();
                MessageBox.Show("Programa adicionado com sucesso!");
            }
            catch (MicroOndasException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
