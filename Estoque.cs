using Game_Store;

public class Estoque{
    // Inicializar variáveis
    static bool listaCheia = false;
    static bool itemExcluido = false;
    static BancoDeDados bancoDados = new BancoDeDados();

    // Inicializar Listas
    public static string[] nomeProdutos = new string[BancoDeDados.tamanhoArray];
    public static double[] listaValores = new double[BancoDeDados.tamanhoArray];
    public static int[] listaQtProdutos = new int[BancoDeDados.tamanhoArray];
    public static string[] listaTipoProdutos = new string[BancoDeDados.tamanhoArray];
    public static string[] corProdutos = new string[BancoDeDados.tamanhoArray];
    public static string[] modeloProdutos = new string[BancoDeDados.tamanhoArray];

    public static void NovoProduto()
    {
        Console.WriteLine("\n________ Adicionar Produto ________\n");

        if(BancoDeDados.indiceNovoProduto >= nomeProdutos.Length){
            listaCheia = true;
            Console.WriteLine("A lista de produtos está cheia. Deseja excluir um item?");
            Console.WriteLine("\n[1] Excluir produto");
            Console.WriteLine("[2] Listar produtos");
            Console.WriteLine("[3] Voltar ao menu");

            Console.Write("\nDigite um número para escolher: \n");

            int opcaoMenu = int.Parse(Console.ReadLine()!);

            switch (opcaoMenu)
            {
                case 1:
                    RemoverProdutos();
                    break;
                case 2:
                    ListarProdutos();
                    break;
                case 3:
                    Program.ExibirMenu();
                    break;
            }
        } else {
            //Diminuir o índice caso algum item tenha sido excluído
            if(itemExcluido == true){
                BancoDeDados.indiceNovoProduto--;
                itemExcluido = false;
            }

            //Capturar produto
            Console.Write("Informe o nome do produto: ");
            string nomeProduto = Console.ReadLine()!;
            nomeProdutos[BancoDeDados.indiceNovoProduto] = nomeProduto;

            Console.Write("Informe o valor do produto: ");
            double valorProduto = double.Parse(Console.ReadLine()!);
            listaValores[BancoDeDados.indiceNovoProduto] = valorProduto;

            Console.Write("Informe o tipo do produto: ");
            string tipoProduto = Console.ReadLine()!;
            listaTipoProdutos[BancoDeDados.indiceNovoProduto] = tipoProduto;

            Console.Write("Informe a cor do produto: ");
            string cor = Console.ReadLine()!;
            corProdutos[BancoDeDados.indiceNovoProduto] = cor;

            Console.Write("Informe o modelo do produto: ");
            string modelo = Console.ReadLine()!;
            modeloProdutos[BancoDeDados.indiceNovoProduto] = modelo;

            BancoDeDados.escreverBanco();

            Console.WriteLine("\nProduto adicionado com sucesso!");
            BancoDeDados.indiceNovoProduto++;

            Thread.Sleep(2000);
            Console.WriteLine("\n----------------------------------------------------\n");
            Console.WriteLine("Ajudo em algo mais?\n");
            Program.ExibirMenu();
        }
    }

    public static void ListarProdutos()
    {
        BancoDeDados.VerificarBanco();
        
        if (BancoDeDados.listaVazia == true)
        {
            Console.WriteLine("\nNão há produto registrado. Deseja adicionar um item?");
            PerguntaAddProduto();
        }
        else
        {
            Console.WriteLine("\n________ Lista de Produtos ________\n");
            BancoDeDados.LerBanco();
            //FalarLista();

            Thread.Sleep(2000);
            Console.WriteLine("\n----------------------------------------------------\n");
            
            if(listaCheia == true){
                Console.WriteLine("Deseja excluir um item?");
                Program.ExibirMenu();
            } else{
                Console.WriteLine("Ajudo em algo mais?\n");
                Program.ExibirMenu();
            }
        }
    }

    public static void RemoverProdutos()
    {
        Console.WriteLine("\n________ Remover Produto ________\n");

        if (nomeProdutos[0] == null){
            Console.WriteLine("Não há produto registrado. Deseja adicionar um item?");
            PerguntaAddProduto();
        } 
        else{
            Console.WriteLine("Qual produto deseja remover?\n");
            FalarLista();
        }

        Console.Write("\nDigite um número para escolher: ");
        int itemExcluir = int.Parse(Console.ReadLine()!) - 1;

        if (itemExcluir >= 0 && itemExcluir < nomeProdutos.Length && nomeProdutos[itemExcluir] != null)
        {
            // Criar vetores auxiliares contendo lista atualizada
            string[] listaProdAux = new string[nomeProdutos.Length];
            double[] listaValoresAux = new double[listaValores.Length];
            int[] listaQtProdAux = new int[listaQtProdutos.Length];
            string[] listaTipoProdAux = new string[listaTipoProdutos.Length];
            string[] listaCorAux = new string[corProdutos.Length];
            string[] listaModeloAux = new string[modeloProdutos.Length];

            // Copiar para vetores auxiliares, excluindo o item
            int auxIndex = 0;
            for (int i = 0; i < nomeProdutos.Length; i++)
            {
                if (i != itemExcluir && nomeProdutos[i] != null)
                {
                    listaProdAux[auxIndex] = nomeProdutos[i];
                    listaValoresAux[auxIndex] = listaValores[i];
                    listaQtProdAux[auxIndex] = listaQtProdutos[i];
                    listaTipoProdAux[auxIndex] = listaTipoProdutos[i];
                    listaCorAux[auxIndex] = corProdutos[i];
                    listaModeloAux[auxIndex] = modeloProdutos[i];
                    auxIndex++;
                }
            }

            // Atualizar vetores principais com os vetores auxiliares
            nomeProdutos = listaProdAux;
            listaValores = listaValoresAux;
            listaQtProdutos = listaQtProdAux;
            listaTipoProdutos = listaTipoProdAux;
            corProdutos = listaCorAux;
            modeloProdutos = listaModeloAux;

            // Exibir a lista atualizada
            Console.WriteLine("\nLista Atualizada:");
            FalarLista();

        Console.WriteLine("\nItem excluído com sucesso!");
        itemExcluido = true;
        } 
        else{
            Console.WriteLine("Índice inválido. Nenhum produto foi removido.");
        }

        Thread.Sleep(2000);
        Console.WriteLine("\n----------------------------------------------------\n");
        Console.WriteLine("Ajudo em algo mais?\n");
        Program.ExibirMenu();
    }

    public static void AlterarValor()
    {
        if (nomeProdutos[0] == null){
            Console.WriteLine("\nNão há produto registrado. Deseja adicionar um item?");
            PerguntaAddProduto();
        } 
        else{
            Console.WriteLine("\n________ Alterar valor ________\n");

            Console.WriteLine("Qual produto deseja alterar o valor?\n");
            FalarLista();
        }

        Console.Write("\nDigite um número para escolher: ");
        int itemEscolhido = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("\nDigite o novo valor: ");
        double novoValor = double.Parse(Console.ReadLine()!);

        listaValores[itemEscolhido] = novoValor;

        Console.WriteLine("\nValor do item: " + nomeProdutos[itemEscolhido] + " - Atualizado com sucesso!");

        Thread.Sleep(2000);
        Console.WriteLine("\n----------------------------------------------------\n");
        
        Console.WriteLine("Ajudo em algo mais?\n");
        Program.ExibirMenu();
    }

    public static void AtualizarEstoque()
    {
        if (nomeProdutos[0] == null){
            Console.WriteLine("Não há produto registrado. Deseja adicionar um item?");
            PerguntaAddProduto();
        } 
        else{
            Console.WriteLine("\n________ Atualizar estoque ________\n");
            Console.WriteLine("Deseja adicionar ou retirar do estoque?\n");
            Console.WriteLine("[1] Adicionar");
            Console.WriteLine("[2] Retirar");
            Console.WriteLine("[0] Voltar ao menu");

            Console.Write("\nDigite um número para escolher: ");
            int opcaoMenu = int.Parse(Console.ReadLine()!);
            
            switch (opcaoMenu)
            {
                case 1:
                    AdicionarEstoque();
                    break;
                case 2:
                    RetirarEstoque();
                    break;
                case 0:
                    Program.ExibirMenu();
                    break;
            }

            Thread.Sleep(2000);
            Console.WriteLine("\nEstoque atualizado com sucesso!");

            Thread.Sleep(2000);
            Console.WriteLine("\n----------------------------------------------------\n");
            Console.WriteLine("Ajudo em algo mais?\n");
            Program.ExibirMenu();
        }
    }    

    public static void AdicionarEstoque()
    {
        Console.WriteLine("\nQual produto deseja adicionar ao estoque?\n");
        FalarLista();

        Console.Write("\nDigite um número para escolher: ");
        int itemEscolhidoAdd = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("\nDigite quantos itens deseja incluir: ");
        int itensAdicionados = int.Parse(Console.ReadLine()!);

        listaQtProdutos[itemEscolhidoAdd] = listaQtProdutos[itemEscolhidoAdd] + itensAdicionados;
    }

    public static void RetirarEstoque()
    {
        Console.WriteLine("Qual produto deseja reduzir o estoque?\n");
        FalarLista();

        Console.Write("\nDigite um número para escolher: ");
        int itemEscolhidoAdd = int.Parse(Console.ReadLine()!) - 1;

        Console.Write("\nDigite quantos itens deseja retirar: ");
        int itensAdicionados = int.Parse(Console.ReadLine()!);

        listaQtProdutos[itemEscolhidoAdd] = listaQtProdutos[itemEscolhidoAdd] - itensAdicionados;
    }

    public static void PerguntaAddProduto()
    {
        Console.WriteLine("\n[1] Adicionar produto");
        Console.WriteLine("[2] Listar produtos");
        Console.WriteLine("[3] Voltar ao menu");

        Console.Write("\nDigite um número para escolher: ");

        int opcaoMenu = int.Parse(Console.ReadLine()!);

        switch (opcaoMenu)
        {
            case 1:
                NovoProduto();
                break;
            case 2:
                ListarProdutos();
                break;
            case 3:
                Program.ExibirMenu();
                break;
        }
    }

    public static void FalarLista()
    {
        for (int i = 0; i < nomeProdutos.Length; i++)
            {
                if (nomeProdutos[i] != null)
                {
                    Console.Write((i + 1) + ") " + listaTipoProdutos[i]);
                    Console.Write(" - " + nomeProdutos[i]);
                    Console.Write(" - " + corProdutos[i]);
                    Console.Write(" - " + modeloProdutos[i]);
                    Console.Write(" - R$" + listaValores[i]);
                    Console.Write(" - " + listaQtProdutos[i] + " Unidades no estoque\n");
                }
            }
    }
}