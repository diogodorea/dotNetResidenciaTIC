public abstract class Pessoa
{
    private string _cpf;

    public string Nome { get; set; }

    public string Cpf
    {
        get { return _cpf; }
        set
        {
            if (value != null && value.Length == 11 && value.Trim().Length == 11)
            {
                _cpf = value;
            }
            else
            {
                throw new ArgumentException("CPF deve conter 11 caracteres alfanuméricos.");
            }
        }
    }

    public DateTime DataNascimento { get; set; }

    public Pessoa(string nome, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
    }
}


public class Advogado : Pessoa {
    public string CNA { get; set; }

    public Advogado(string nome, string cpf, DateTime dataNascimento) : base(nome, cpf, dataNascimento) {
        
    }
}

public class Cliente : Pessoa {
    public string profissao { get; set; }
    public string Ecivil { get; set; }
    public Cliente(string nome, string cpf, DateTime dataNascimento, string ecivil) : base(nome, cpf, dataNascimento) {
    }
}

public class Program {
    public static void Main(string[] args) {
        List<Advogado> advogados = new List<Advogado>();
        List<Cliente> clientes = new List<Cliente>();
        advogados.Add(new Advogado("João", "12345678901", new DateTime(1990, 1, 1)));
        advogados.Add(new Advogado("Maria", "98765432163", new DateTime(1990, 1, 1)));
        clientes.Add(new Cliente("José", "12345678985", new DateTime(1990, 1, 1), "Casado"));
        clientes.Add(new Cliente("Ana", "98765432158", new DateTime(1990, 1, 1), "Solteiro"));
        
        foreach (var advogado in advogados) {
            Console.WriteLine($"Advogado: {advogado.Nome} - {advogado.Cpf} - {advogado.DataNascimento} - {advogado.CNA}");        
        }
        
        foreach (var cliente in clientes) {     
            Console.WriteLine($"Cliente: {cliente.Nome} - {cliente.Cpf} - {cliente.DataNascimento} - {cliente.Ecivil}");
            
        }
    }
}