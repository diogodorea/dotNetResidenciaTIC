﻿    class Program
    {
        static void Main(string[] args)
        {
            List<(string, int)> inventario = new List<(string, int)> {};

            Console.WriteLine("Sistema Gerenciamento Estoque");
            Console.WriteLine("---------------------------");

            while (true) {
                Console.WriteLine("1. Visualizar Inventario");
                Console.WriteLine("2. Adicionar Item");
                Console.WriteLine("3. Remover Item");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                int escolha;
                if (int.TryParse(Console.ReadLine(), out escolha))
                {
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
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }

        static void VisualizarInventario(List<(string, int)> inventario) {
            Console.WriteLine("Inventario:");
            foreach (var item in inventario) {
                Console.WriteLine($"{item.Item1}: {item.Item2}");
            }
        }

        static void AdicionarItem(List<(string, int)> inventory) {
            Console.Write("Digite o nome do item: ");
            string itemName = Console.ReadLine();

            Console.Write("Digite a quantidade: ");
            int quantity;
            if (int.TryParse(Console.ReadLine(), out quantity)) {
                inventory.Add((itemName, quantity));
                Console.WriteLine("Item adicionado com sucesso.");
            }
            else {
                Console.WriteLine("Quantidade invalida, item não adicionado.");
            }
        }

        static void RemoverItem(List<(string, int)> inventory) {
            Console.Write("Digite o nome do item: ");
            string itemName = Console.ReadLine();

            var item = inventory.FirstOrDefault(i => i.Item1.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item.Item1 != null) {
                inventory.Remove(item);
                Console.WriteLine("Item removido com sucesso.");
            }
            else {
                Console.WriteLine("Item nao encontrado no inventario.");
            }
        }
    }
