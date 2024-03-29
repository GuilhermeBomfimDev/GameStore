namespace Game_Store;

class Program
{
    public static Estoque tratarEstoque = new Estoque();
    public static BancoDeDados bancoDados = new BancoDeDados();

    static void Main(string[] args)
    {
        Console.WriteLine(@"
      ________                             _________  __                           
     /  _____/ _____     _____    ____    /   _____/_/  |_   ____  _______   ____  
    /   \  ___ \__  \   /     \ _/ __ \   \_____  \ \   __\ /  _ \ \_  __ \_/ __ \ 
    \    \_\  \ / __ \_|  Y Y  \\  ___/   /        \ |  |  (  <_> ) |  | \/\  ___/ 
     \______  /(____  /|__|_|  / \___  > /_______  / |__|   \____/  |__|    \___  >
            \/      \/       \/      \/          \/                             \/ ");

        //Verificar lista se está preenchida ou vazia
        BancoDeDados.VerificarBanco();

        Console.WriteLine("\nBem vindo a Game Store!\n");
        Console.WriteLine("Escolha uma opção do menu:");
        ExibirMenu();
    }

    public static void ExibirMenu()
    {
        Console.WriteLine("[1] Novo produto");
        Console.WriteLine("[2] Listar produtos");
        Console.WriteLine("[3] Remover produtos");
        Console.WriteLine("[4] Alterar valor");
        Console.WriteLine("[5] Atualizar estoque");
        Console.WriteLine("[0] Sair");

        Console.Write("\nDigite um número para escolher: ");
        int opcaoMenu = int.Parse(Console.ReadLine()!);
        
        switch (opcaoMenu)
        {
            case 1:
                Estoque.NovoProduto();
                break;
            case 2:
                Estoque.ListarProdutos();
                break;
            case 3:
                Estoque.RemoverProdutos();
                break;
            case 4:
                Estoque.AlterarValor();
                break;
            case 5:
                Estoque.AtualizarEstoque();
                break;
            case 0:
                Console.WriteLine("\n----------------------------------\n");
                Console.WriteLine("Obrigado por acessar a Game Store!");
                return; // Sai do método Main e encerra o programa
            default:
                Console.WriteLine("\n----------------------------------------------------\n");
                Console.WriteLine("Opção inválida. Escolha um número dentro do menu:\n");
                ExibirMenu();
                break;
        }

    }  
}
