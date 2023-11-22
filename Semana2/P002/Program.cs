public class Tarefa
{
    
    private static int nextId = 1;
    public DateTime dtCriacao = DateTime.Now;
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Vencimento { get; set; }
    public bool Concluida { get; set; }

    public Tarefa() {
        this.Id = nextId++;
        this.Vencimento = DateTime.Now;
    }
}

public class GerenciadorTarefas
{
    private List<Tarefa> listaTarefas;

    public GerenciadorTarefas() {
        listaTarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa) {
        listaTarefas.Add(tarefa);
    }
    
    public void ListarTarefas() {
        foreach (Tarefa tarefa in listaTarefas) {
            Console.WriteLine($"ID: {tarefa.Id} - Título: {tarefa.Titulo} - Descrição: {tarefa.Descricao} - Concluída: {tarefa.Concluida}");
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
        }
    }
}