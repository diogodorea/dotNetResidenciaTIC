public class Veiculo {
    public string Cor { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }

      
    public Veiculo(string cor, string modelo, int ano) {
        Cor = cor;
        Modelo = modelo;
        Ano = ano;
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
        var carro = new Veiculo("Azul", "Fusca", 1970);
        var moto = new Veiculo("Vermelha", "CG", 2010);
        var caminhao = new Veiculo("Branco", "Mercedes", 2015);
        
        carro.toString();
        moto.toString();
        caminhao.toString();
    }
}