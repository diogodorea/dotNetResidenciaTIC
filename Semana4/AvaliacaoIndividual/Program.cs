public abstract class Pessoa
{
    private string _cpf;
    private static Dictionary<string, Pessoa> _cpfs = new Dictionary<string, Pessoa>();

    public string Nome { get; set; }

    public string Cpf
    {
        get { return _cpf; }
        set
        {
            if (value != null && value.Length == 11 && value.Trim().Length == 11)
            {
                if (!_cpfs.ContainsKey(value)) 
                {
                    if (_cpf != null)
                    {
                        _cpfs.Remove(_cpf); 
                    }

                    _cpfs[value] = this; 
                    _cpf = value;
                }
                else
                {
                    throw new ArgumentException("CPF já existe.");
                }
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

public class Advogado : Pessoa
{
    private string _cna;
    private static Dictionary<string, Advogado> _cnaList = new Dictionary<string, Advogado>();

    public string CNA
    {
        get { return _cna; }
        set
        {
            if (value != null && value.Length > 0)
            {
                if (!_cnaList.ContainsKey(value))
                {
                    if (_cna != null)
                    {
                        _cnaList.Remove(_cna);
                    }

                    _cnaList[value] = this;
                    _cna = value;
                }
                else
                {
                    throw new ArgumentException("CNA já existe.");
                }
            }
            else
            {
                throw new ArgumentException("CNA deve ser válido.");
            }
        }
    }

    public Advogado(string nome, string cpf, DateTime dataNascimento, string CNA) : base(nome, cpf, dataNascimento)
    {

    }
}

public class Cliente : Pessoa {
    public string profissao { get; set; }
    public string Ecivil { get; set; }
    public Cliente(string nome, string cpf, DateTime dataNascimento, string ecivil, string profissao, string Ecivil) : base(nome, cpf, dataNascimento) {
    }
}

public class Program {
    public static void Main(string[] args) {
        List<Advogado> advogados = new List<Advogado>();
        List<Cliente> clientes = new List<Cliente>();
        advogados.Add(new Advogado("João", "12345678901", new DateTime(1990, 1, 1),"456798"));
        advogados.Add(new Advogado("Maria", "12345978901", new DateTime(1990, 1, 1),"456798"));
        clientes.Add(new Cliente("José", "12345678985", new DateTime(1990, 1, 1), "Programador", "sim", "Casado"));
        clientes.Add(new Cliente("Ana", "98765432158", new DateTime(1990, 1, 1), "Engenheiro", "Não", "Solteiro"));
        
        foreach (var advogado in advogados) {
            Console.WriteLine($"Advogado: {advogado.Nome} - {advogado.Cpf} - {advogado.DataNascimento} - {advogado.CNA}");        
        }
        
        foreach (var cliente in clientes) {     
            Console.WriteLine($"Cliente: {cliente.Nome} - {cliente.Cpf} - {cliente.DataNascimento} - {cliente.profissao} - {cliente.Ecivil}");
            
        }

        int idadeA = 10, idadeB = 30;

        var advogadoEntreIdades = advogados.Where(a => a.DataNascimento.Year >= idadeA && a.DataNascimento.Year <= idadeB);
        foreach var (advogado in advogadoEntreIdades) {
            Console.WriteLine($"Advogado: {advogado.Nome} - {advogado.Cpf} - {advogado.DataNascimento} - {advogado.CNA}");        
        }
    



    }
}