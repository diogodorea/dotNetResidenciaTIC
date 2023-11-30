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

    public Advogado(string nome, string cpf, DateTime dataNascimento, string CNA) : base(nome, cpf, dataNascimento) {
        this.CNA = CNA;
    }
}

public class Cliente : Pessoa {
    public string profissao { get; set; }
    public string Ecivil { get; set; }
    public Cliente(string nome, string cpf, DateTime dataNascimento, string ecivil, string profissao, string Ecivil) : base(nome, cpf, dataNascimento) {
        this.profissao = profissao;
        this.Ecivil = Ecivil;
    }
}

public class Program {
    public static void Main(string[] args) {
        List<Advogado> advogados = new List<Advogado>();
        List<Cliente> clientes = new List<Cliente>();
        advogados.Add(new Advogado("João", "12345678901", new DateTime(2010, 1, 1),"456798"));
        advogados.Add(new Advogado("Maria", "12345978901", new DateTime(1990, 1, 1),"455798"));
        clientes.Add(new Cliente("José", "12345678985", new DateTime(2010, 1, 1), "Programador", "sim", "Casado"));
        clientes.Add(new Cliente("Ana", "98765432158", new DateTime(1990, 1, 1), "Engenheiro", "Não", "Solteiro"));
        
        foreach (var advogado in advogados) {
            Console.WriteLine($"Advogado: {advogado.Nome} - {advogado.Cpf} - {advogado.DataNascimento} - {advogado.CNA}");        
        }
        
        foreach (var cliente in clientes) {     
            Console.WriteLine($"Cliente: {cliente.Nome} - {cliente.Cpf} - {cliente.DataNascimento} - {cliente.profissao} - {cliente.Ecivil}");
            
        }

        int idadeA = 10, idadeB = 30;
        Console.WriteLine($"Digite um estado civil: ");
        string estadoCivil = Console.ReadLine();
        Console.WriteLine($"Digite uma profissão: ");
        string profissao = Console.ReadLine();
        
        
        var advogadoEntreIdades = advogados.Where(a => DateTime.Now.Year - a.DataNascimento.Year >= idadeA && DateTime.Now.Year - a.DataNascimento.Year <= idadeB);
        var clienteEntreIdades = clientes.Where(a => DateTime.Now.Year - a.DataNascimento.Year >= idadeA && DateTime.Now.Year - a.DataNascimento.Year <= idadeB);
        var clienteEstadocivil = clientes.Where(a => a.Ecivil == estadoCivil);
        var clienteOrdemAlfabetica = clientes.OrderBy(a => a.Nome);
        var clienteProfissao = clientes.Where(a => a.profissao == profissao);
        var aniversariantesCliente = clientes.Where(a => a.DataNascimento.Month == DateTime.Now.Month);
        var anivesariantesAdvogado = advogados.Where(a => a.DataNascimento.Month == DateTime.Now.Month);

        foreach (var advogado in advogadoEntreIdades) {
            Console.WriteLine($"Advogado: {advogado.Nome}");        
        }

        foreach (var cliente in clienteEntreIdades) {
            Console.WriteLine($"Cliente: {cliente.Nome}");        
        }

        Console.WriteLine($"Clientes com estado civil {estadoCivil}:");
        foreach (var cliente in clienteEstadocivil) {
            Console.WriteLine($"Cliente: {cliente.Nome} - {cliente.Ecivil}");        
        }

        foreach (var cliente in clienteOrdemAlfabetica) {
            Console.WriteLine($"Cliente: {cliente.Nome}");        
        }

        Console.WriteLine($"Clientes com profissão {profissao}:");
        foreach (var cliente in clienteProfissao) {
            Console.WriteLine($"Cliente: {cliente.Nome} - {cliente.profissao}");        
        }

        foreach (var cliente in aniversariantesCliente) {
            Console.WriteLine($"Cliente: {cliente.Nome} - {cliente.DataNascimento}");        
        }

        foreach (var advogado in anivesariantesAdvogado) {
            Console.WriteLine($"Advogado: {advogado.Nome} - {advogado.DataNascimento}");        
        }
        
    }
}