public class Veiculo {
    public string Cor { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public int IdadeVeiculo {
        get {
        return DateTime.Now.Year - Ano;
        }
        }

    public void toString (){
        Console.WriteLine("Cor: {0}", Cor);
        Console.WriteLine("Modelo: {0}", Modelo);
        Console.WriteLine("Ano: {0}", Ano);
    
    }
}

public class Program {
    public static void Main(string[] args)
    {
        var carro = new Veiculo();
        carro.Cor = "Azul";
        carro.Modelo = "Fusca";
        carro.Ano = 1970;
        var moto = new Veiculo();
        moto.Cor = "Vermelha";
        moto.Modelo = "Honda";
        moto.Ano = 2010;
        var caminhao = new Veiculo();
        caminhao.Cor = "Branco";
        caminhao.Modelo = "Mercedes";
        caminhao.Ano = 2015;
        
        carro.toString();
        moto.toString();
        caminhao.toString();
        carro.IdadeVeiculo();
    }
}