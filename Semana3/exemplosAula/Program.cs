#region 
//exercicio 1
(String, int) GetTupla (String nome, int idade) {
    return (nome, idade);
}
Console.WriteLine($"Digite um nome e uma idade: ");
var (nome, idade) = GetTupla(Console.ReadLine(), int.Parse(Console.ReadLine()));
Console.WriteLine($"Nome: {nome}, Idade: {idade}");
#endregion

#region
List<(String nome, int idade)> lista = new ();
lista.Add(("João", 20));
lista.Add(("Maria", 30));
lista.Add(("José", 40));
lista.Add(("Pedro", 50));

var



#endregion