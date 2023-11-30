public abstract class Pessoa {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public Pessoa(string nome, string cpf, string telefone, string endereco, string email, string senha, string tipo) {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
        Email = email;
        Senha = senha;
        Tipo = tipo;
    }
    public Pessoa() { }
    public abstract void Cadastrar();
    public abstract void Listar();
    public abstract void Buscar(string busca);
    public abstract void Remover(string busca);
    public abstract void Editar(string busca);
}