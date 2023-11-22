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
