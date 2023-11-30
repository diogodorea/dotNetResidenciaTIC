public abstract class Pessoa {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public Pessoa() { }
  
}

public class Advogado : Pessoa{

    String CNA { get; set; }

    public Advogado(string cNA)
    {
        CNA = cNA;
    }
}

public class Cliente : Pessoa{

    String Ecivil { get; set; }

    public Cliente(string ecivil)
    {
        Ecivil = ecivil;
    }

    String Profissão { get; set; }

}

public class Program {
    public static void Main(string[] args) {
        List<Advogado> advogados = new List<Advogado>();
        List<Cliente> clientes = new List<Cliente>();
        advogados.Add(new Advogado("123456789")) : base("João", "123456789", new DateTime(1990, 1, 1));

        
    }
}