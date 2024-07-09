# Micro-ondas Digital

Este projeto é uma simulação de um micro-ondas digital desenvolvido em C#. Ele permite o aquecimento de alimentos com diversas funcionalidades, incluindo aquecimento rápido, programas pré-definidos, e a possibilidade de adicionar programas customizados.

## Funcionalidades Implementadas

### Nível 1 - Funcionalidades Básicas
1. **Iniciar Aquecimento**: O usuário pode definir o tempo e a potência para aquecer alimentos.
2. **Aquecimento Rápido**: Um modo de aquecimento rápido pré-configurado.
3. **Pausar/Cancelar Aquecimento**: Permite pausar ou cancelar o aquecimento em andamento.

### Nível 2 - Funcionalidades Intermediárias
4. **Acrescentar Tempo**: Adiciona tempo extra ao aquecimento atual.
5. **Iniciar Programa Pré-definido**: O usuário pode selecionar entre programas pré-definidos para aquecer diferentes tipos de alimentos.

### Nível 3 - Funcionalidades Avançadas
6. **Adicionar Programa Customizado**: Permite que o usuário crie e adicione seus próprios programas de aquecimento customizados. 
   - **Nome do Programa**: O usuário pode definir um nome para o programa.
   - **Tipo de Alimento**: O usuário especifica o tipo de alimento.
   - **Tempo**: O usuário define o tempo de aquecimento.
   - **Potência**: O usuário define a potência de aquecimento.
   - **Caractere de Aquecimento**: O usuário escolhe um caractere que representa o processo de aquecimento (deve ser único e não pode ser um ponto).
   - **Instruções**: O usuário pode adicionar instruções específicas para o programa.

## Como o Projeto Atende aos Requisitos até o Nível 3

### Funcionalidade
O projeto cobre todas as funcionalidades requeridas até o nível 3, incluindo a capacidade de iniciar aquecimentos com parâmetros personalizados, usar programas pré-definidos e adicionar programas customizados com informações detalhadas.

### Robustez
O projeto inclui tratamento de erros para entradas inválidas, como valores fora dos limites permitidos para tempo e potência, bem como caracteres de aquecimento inválidos. Isso garante que o programa lide adequadamente com possíveis erros de usuário.

### Usabilidade
Para melhorar a usabilidade, especialmente na adição de programas customizados, foram incluídas instruções adicionais para o usuário, detalhando o que deve ser preenchido em cada campo. Isso ajuda a evitar erros e garante que os programas sejam configurados corretamente.

## Estrutura do Projeto

### Diretório `MicroondasDigital.Core`
Contém a lógica principal do micro-ondas, incluindo as classes para controle do aquecimento e definição dos programas.

### Diretório `MicroondasDigital.ConsoleApp`
Contém a interface de linha de comando para interação do usuário com o micro-ondas. É onde as opções de menu são apresentadas e as entradas do usuário são processadas.

### Principais Arquivos
- `Microondas.cs`: Classe principal que gerencia as operações do micro-ondas.
- `ProgramaAquecimento.cs`: Classe que define um programa de aquecimento, incluindo tempo, potência, e instruções.
- `ProgramasPreDefinidos.cs`: Classe estática que armazena programas de aquecimento pré-definidos.
- `Program.cs`: Classe que contém a interface de linha de comando para o usuário interagir com o micro-ondas.

## Executando o Projeto

Para executar o projeto, você precisa ter o .NET Framework instalado. Navegue até o diretório `MicroondasDigital.ConsoleApp` e execute o seguinte comando:

```sh
dotnet run
