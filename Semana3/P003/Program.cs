    class Program
    {
        static void Main(string[] args)
        {
            List<(int, string, int, float)> inventario = new List<(int, string, int, float)> {};

            Console.WriteLine("Sistema Gerenciamento Estoque");
            Console.WriteLine("---------------------------");

            while (true) {
                Console.WriteLine("1. Visualizar Inventario");
                Console.WriteLine("2. Adicionar Item");
                Console.WriteLine("3. Remover Item");
                Console.WriteLine("4. Consultar Item");
                Console.WriteLine("5. Sair");
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
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Opção invalida, digite um valor numerico correspondente de 1 a 5.");
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

        static void VisualizarInventario(List<(int, string, int, float)> inventario) {
            Console.WriteLine("Inventario:");
            Console.WriteLine($"CODIGO: NOME: QUANTIDADE: VALOR");
            
            foreach (var item in inventario) {
                Console.WriteLine($"{item.Item1}: {item.Item2}: {item.Item3}: {item.Item4}");
            }
        }

        static void AdicionarItem(List<(int, string, int, float)> inventario) {
            
            Console.Write("Digite o codigo do item: ");
            int itemCodigo = int.Parse(Console.ReadLine());

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

        static void ConsultarItem(List<(int, string, int, float)> inventario) {
            Console.Write("Digite o codigo do item: ");
            string itemCodigo = Console.ReadLine();
            try{
                var item = inventario.FirstOrDefault(i => i.Item1.ToString().Equals(itemCodigo));
                if (item.Item1 == 0) {
                    throw new Exception("Item nao encontrado no inventario Teste.");
                }
                Console.WriteLine($"CODIGO: NOME: QUANTIDADE: VALOR");
                Console.WriteLine($"{item.Item1}: {item.Item2}: {item.Item3}: {item.Item4}");
            }
            catch (Exception e){
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
    }
