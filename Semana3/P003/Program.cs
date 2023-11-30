using System.Diagnostics;

class Program
    {
        static void VisualizarInventario(List<(int, string, int, float)> inventario) {
            Console.WriteLine("Inventario:");
            Console.WriteLine($"CODIGO: NOME: QUANTIDADE: VALOR");
            
            foreach (var item in inventario) {
                Console.WriteLine($"{item.Item1} : {item.Item2} : {item.Item3} : {item.Item4}");
            }
        }

        static void AdicionarItem(List<(int, string, int, float)> inventario) {
            
            Console.Write("Digite o codigo do item: ");
            int itemCodigo = int.Parse(Console.ReadLine());
            //to do: validar se codigo ja existe, codigo nao pode ser 0;

            Console.Write("Digite o nome do item: ");
            string itemName = Console.ReadLine();

            Console.WriteLine("Digite o valor: ");
            float valor = float.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade: ");
            int quantidade;

            try{
                quantidade = int.Parse(Console.ReadLine());
                inventario.Add((itemCodigo, itemName, quantidade, valor));
                Console.WriteLine("Item adicionado com sucesso.");
            }
            catch (Exception e){
                Console.WriteLine("Quantidade invalida, item não adicionado.");
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        static void RemoverItem(List<(int, string, int, float)> inventory) {
            Console.Write("Digite o nome do item: ");
            string itemName = Console.ReadLine();
            var item = inventory.FirstOrDefault(i => i.Item2.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item.Item1 != null) {
                inventory.Remove(item);
                Console.WriteLine("Item removido com sucesso.");
            }
            else {
                Console.WriteLine("Item nao encontrado no inventario.");
            }
        }

        static void ConsultarItem(List<(int, string, int, float)> inventario) {
            Console.Write("Digite o codigo do item: ");
            string itemCodigo = Console.ReadLine();
            try{
                var itemaux = inventario.FirstOrDefault(i => i.Item1.ToString().Equals(itemCodigo));
                if (itemaux.Item1 == 0) {
                    throw new Exception("Item nao encontrado no inventario Teste.");
                }
                Console.WriteLine($"CODIGO: NOME: QUANTIDADE: VALOR");
                Console.WriteLine($"{itemaux.Item1}: {itemaux.Item2}: {itemaux.Item3}: {itemaux.Item4}");
            }
            catch (Exception e){
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        static void AtualizarEstoque(List<(int, string, int, float)> inventario) {
            Console.Write("Digite o codigo do item: ");
            int itemCodigo = int.Parse(Console.ReadLine());
            var item = inventario.FirstOrDefault(i => i.Item1 == itemCodigo);
            if (item.Item1 == 0) {
                Console.WriteLine("Item nao encontrado no inventario.");
                return;
            }

            Console.Write("Digite a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (item.Item3 + quantidade < 0) {
                Console.WriteLine("Quantidade nao permitida devido ao estoque atual.");
                Console.WriteLine($"Estoque atual: {item.Item3}");
                
                return;
            }

            inventario.Remove(item);
            inventario.Add((item.Item1, item.Item2, item.Item3+quantidade, item.Item4));
            Console.WriteLine("Estoque atualizado com sucesso.");
        }

        static void ValorTotalInventario(List<(int, string, int, float)> inventario) {
            float valorTotal = 0;
            foreach (var item in inventario) {
                valorTotal += item.Item3 * item.Item4;
            }
            Console.WriteLine($"Valor total do inventario: {valorTotal}");
        }

        static void Main(string[] args)
        {
            List<(int, string, int, float)> inventario = new ();

            Console.WriteLine("Sistema Gerenciamento Estoque");
            Console.WriteLine("---------------------------");

            while (true) {
                Console.WriteLine("1. Visualizar Inventario");
                Console.WriteLine("2. Adicionar Item");
                Console.WriteLine("3. Remover Item");
                Console.WriteLine("4. Consultar Item");
                Console.WriteLine("5. Atualizar Estoque");
                Console.WriteLine("6. Relatorios");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");
  
                try{
                    int escolha = int.Parse(Console.ReadLine());
                    switch (escolha) {
                        case 1:
                            VisualizarInventario(inventario);
                            break;
                        case 2:
                            AdicionarItem(inventario);
                            break;
                        case 3:
                            RemoverItem(inventario);
                            break;
                        case 4:
                            ConsultarItem(inventario);
                            break;
                        case 5:
                            AtualizarEstoque(inventario);
                            break;
                        case 6:
                            Relatorios(inventario);
                            break;
                        case 7:
                            Console.WriteLine("Saindo do sistema...");
                            return;
                        default:
                            Console.WriteLine("Opção invalida, digite um valor numerico correspondente de 1 a 7.");
                            break;
                    }
                }
                catch (Exception e){
                    Console.WriteLine("Erro: " + e.Message);
                    Console.WriteLine("Opção invalida, digite um valor numerico.");
                    continue;
                }
                 Console.WriteLine();
            }
        }


        public static void Relatorios(List<(int, string, int, float)> inventario) {
            Console.WriteLine("Relatorios:");
            Console.WriteLine("1. Produtos por estoque minimo");
            Console.WriteLine("2. Produtos entre minimo e maximo quantidade");
            Console.WriteLine("3. Itens com estoque zerado");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha uma opção: ");

            try{
                int escolha = int.Parse(Console.ReadLine());
                switch (escolha) {
                    case 1:
                        Console.WriteLine($"Informe o estoque minimo: ");
                        int estoqueMinimo = int.Parse(Console.ReadLine());
                        foreach (var item in inventario.Where(i => i.Item3 > estoqueMinimo)) {
                            Console.WriteLine($"{item.Item2} : {item.Item3} : {item.Item4}");
                        }
                        
                        break;
                    /*
                    case 2:
                        ItensEstoqueNegativo(inventario);
                        break;
                    case 3:
                        ItensEstoqueZerado(inventario);
                        break;
                    case 4:
                        ItensMaisCaros(inventario);
                        break;
                        */
                }
            }
            catch (Exception e){
                Console.WriteLine("Erro: " + e.Message);
                Console.WriteLine("Opção invalida, digite um valor numerico.");
            }
        }
    }
