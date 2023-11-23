public class Tarefa
{
    
    private static int nextId = 1;
    public DateTime dtCriacao;
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Vencimento { get; set; }
    public bool Concluida { get; set; }

    public Tarefa() {
        this.Id = nextId++;
        this.dtCriacao = DateTime.Now;
    }
}

public class GerenciadorTarefas {
    
    private List<Tarefa> listaTarefas;

    public GerenciadorTarefas() {
        listaTarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa) {
        listaTarefas.Add(tarefa);
    }
    
    public void ListarTarefas() {
        foreach (Tarefa tarefa in listaTarefas) {
            Console.WriteLine($"ID: {tarefa.Id} - Título: {tarefa.Titulo} - Descrição: {tarefa.Descricao} - Vencimento: {tarefa.Vencimento.Day}/{tarefa.Vencimento.Month}/{tarefa.Vencimento.Year} - Concluída: {tarefa.Concluida.ToString().Replace("True","Sim").Replace("False","Não")}");
        }
    }

    public void ListarTarefasConcluidas() {
        foreach (Tarefa tarefa in listaTarefas)
        {
            if (tarefa.Concluida)
            {
                Console.WriteLine($"ID: {tarefa.Id} - Título: {tarefa.Titulo} - Descrição: {tarefa.Descricao} - Vencimento: {tarefa.Vencimento.Day}/{tarefa.Vencimento.Month}/{tarefa.Vencimento.Year} - Concluída: {tarefa.Concluida.ToString().Replace("True","Sim").Replace("False","Não")}");
            }
        }
    }
    public void ListarTarefasPendentes() {
        foreach (Tarefa tarefa in listaTarefas)
        {
            if (!tarefa.Concluida)
            {
                Console.WriteLine($"ID: {tarefa.Id} - Título: {tarefa.Titulo} - Descrição: {tarefa.Descricao} - Vencimento: {tarefa.Vencimento.Day}/{tarefa.Vencimento.Month}/{tarefa.Vencimento.Year} - Concluída: {tarefa.Concluida.ToString().Replace("True","Sim").Replace("False","Não")}");
            }
        }
    }

    public void RemoverTarefa(int id)
    {
        Tarefa tarefa = listaTarefas.Find(t => t.Id == id);
        if (tarefa != null)
        {
            listaTarefas.Remove(tarefa);
        }
    }

    public void AtualizarTarefa(int id, Tarefa novaTarefa) {
        Tarefa tarefa = listaTarefas.Find(t => t.Id == id);
        if (tarefa != null)
        {
            tarefa.Titulo = novaTarefa.Titulo;
            tarefa.Descricao = novaTarefa.Descricao;
            tarefa.Concluida = novaTarefa.Concluida;
            tarefa.Vencimento = novaTarefa.Vencimento;
        }
    }

    public void LocalizarPalavraChave(string keyword) {
        foreach (Tarefa tarefa in listaTarefas)
        {
            if (tarefa.Titulo.Contains(keyword) || tarefa.Descricao.Contains(keyword)) {
                Console.WriteLine($"ID: {tarefa.Id} - Título: {tarefa.Titulo} - Descrição: {tarefa.Descricao} - Vencimento: {tarefa.Vencimento.Day}/{tarefa.Vencimento.Month}/{tarefa.Vencimento.Year} - Concluída: {tarefa.Concluida}");
            } else {
                Console.WriteLine("Nenhuma tarefa encontrada");
            }
        }
    }

    public void Estatisticas() {
            int totalTarefas = listaTarefas.Count;
            int totalConcluidas = listaTarefas.Count(t => t.Concluida);
            int totalPendentes = listaTarefas.Count(t => !t.Concluida);
            DateTime menorData = listaTarefas.Min(t => t.dtCriacao);
            DateTime maiorData = listaTarefas.Max(t => t.dtCriacao);
            Console.WriteLine($"Total de tarefas: {totalTarefas}");
            Console.WriteLine($"Total de tarefas concluídas: {totalConcluidas}");
            Console.WriteLine($"Total de tarefas pendentes: {totalPendentes}");
            Console.WriteLine($"Data da tarefa mais antiga: {menorData}");
            Console.WriteLine($"Data da tarefa mais recente: {maiorData}");
        }
}

class Program {

    static public bool ConverteSimNaoParaBoolean(string input) {
        if (input.ToLower() == "s" || input.ToLower() == "sim") {
            return true;
        } else if (input.ToLower() == "n" || input.ToLower() == "não") {
            return false;
        } else {
            throw new ArgumentException("Entrada inválida. Por favor, insira 's' ou 'n'.");
        }
}

    static void Main(string[] args)
    {
        GerenciadorTarefas gerenciador = new GerenciadorTarefas();
        int flag = 0;
        do
        {
            Console.WriteLine("Digite 1 para adicionar uma tarefa");
            Console.WriteLine("Digite 2 para listar as tarefas");
            Console.WriteLine("Digite 3 para remover uma tarefa");
            Console.WriteLine("Digite 4 para atualizar uma tarefa");
            Console.WriteLine("Digite 5 para listar as tarefas concluídas");
            Console.WriteLine("Digite 6 para listar as tarefas pendentes");
            Console.WriteLine("Digite 7 para localizar uma tarefa");
            Console.WriteLine("Digite 8 para ver as estatísticas");
            Console.WriteLine("Digite 0 para sair");
            flag = int.Parse(Console.ReadLine());

            switch (flag)
            {
                case 1:
                    Console.WriteLine("Digite o título da tarefa");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Digite a descrição da tarefa");
                    string descricao = Console.ReadLine();
                    Console.WriteLine("Digite a data de vencimento da tarefa (dd/mm/aaaa) Dia/Mes/Ano)");
                    DateTime vencimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.WriteLine("Digite se a tarefa está concluída? (Sim ou Não) (S ou N)");
                    bool concluida = ConverteSimNaoParaBoolean(Console.ReadLine());
                    gerenciador.AdicionarTarefa(new Tarefa() { Titulo = titulo, Descricao = descricao, Vencimento = vencimento, Concluida = concluida });
                    break;
                case 2:
                    gerenciador.ListarTarefas();
                    break;
                case 3:
                    Console.WriteLine("Digite o ID da tarefa que deseja remover");
                    int id = int.Parse(Console.ReadLine());
                    gerenciador.RemoverTarefa(id);
                    break;
                case 4:
                    Console.WriteLine("Digite o ID da tarefa que deseja atualizar");
                    int idAtualizar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o título da tarefa");
                    string novoTitulo = Console.ReadLine();
                    Console.WriteLine("Digite a descrição da tarefa");
                    string novaDescricao = Console.ReadLine();
                    Console.WriteLine("Digite a data de vencimento da tarefa (dd/mm/aaa) Dia/Mes/Ano)");
                    DateTime novaData = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.WriteLine("Digite se a tarefa está concluída? (Sim ou Não) (S ou N)");
                    bool novoConcluido = ConverteSimNaoParaBoolean(Console.ReadLine());
                    gerenciador.AtualizarTarefa(idAtualizar, new Tarefa() { Titulo = novoTitulo, Descricao = novaDescricao, Vencimento = novaData, Concluida = novoConcluido });
                    break;
                    case 5:
                    gerenciador.ListarTarefasConcluidas();
                    break;
                case 6:
                    gerenciador.ListarTarefasPendentes();
                    break;
                case 7:
                    Console.WriteLine("Digite uma palavra chave para localizar uma tarefa");
                    string palavraChave = Console.ReadLine();
                    gerenciador.LocalizarPalavraChave(palavraChave);
                    break;
                case 8:
                    gerenciador.Estatisticas();
                    break;             
                default:
                    break;
            }        
        } while (flag != 0);

    }
}