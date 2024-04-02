using System.Text;
using Game_Store;

class BancoDeDados {

    //Inicializar variáveis
    static int indice = 0;
    public static int indiceNovoProduto;
    public static int tamanhoArray = 5;
    static string caminhoDoc = "C:\\Users\\guigu\\Programação\\GameStore\\DadosSalvos.txt";
    public static bool listaVazia = false;

    public static void VerificarBanco()
    {
        try{
            StreamReader sr = new StreamReader(caminhoDoc);
            string line = sr.ReadLine()!;

            if(line == null){
                listaVazia = true;
            } else {
                listaVazia = false;
                MontarListas();
            }
            sr.Close();
        }
        catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);
            Console.ReadLine();
        }
    }

    public static void LerBanco()
    {
        try{
            VerificarBanco();
            if(listaVazia == true){
                Console.WriteLine("O seu estoque está vazio\n");
                Estoque.PerguntaAddProduto();
            } else{
                StreamReader sr = new StreamReader(caminhoDoc);
                string line = sr.ReadLine()!;

                while(line != null){
                    Console.WriteLine(line);
                    line = sr.ReadLine()!;
                }
                sr.Close();
            }
        } 
        catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static void EscreverBanco()
    {
        try
        {
            VerificarBanco();
            string[] arquivo = File.ReadAllLines(caminhoDoc);
            if(listaVazia == true){
                indice = 1;
            } else{
                indice += 1;
            }
            
            string texto = indice + " - ";

            for (int i = 0; i < Estoque.nomeProdutos.Length - 1; i++)
            {
                if (i == indice - 1)
                {
                    string itemSalvar = $" {Estoque.listaTipoProdutos[i]} | {Estoque.nomeProdutos[i]} | {Estoque.corProdutos[i]} | {Estoque.modeloProdutos[i]} | R${Estoque.listaValores[i]} | {Estoque.listaQtProdutos[i]} Unidades no estoque";

                    using (StreamWriter sw = new StreamWriter(caminhoDoc, true)) // Abrindo o arquivo no modo de adição (append)
                    {
                    sw.Write(texto + itemSalvar + "\n");
                    }

                    itemSalvar = "";
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static void AlterarDadosBanco()
    {
        try
        {
            VerificarBanco(); // Verificar se o banco de dados está vazio
            if (listaVazia)
            {
                Console.WriteLine("O seu estoque está vazio\n");
                Estoque.PerguntaAddProduto();
                return; // Saia do método se o estoque estiver vazio
            }

            indice = 1;
            string texto = indice + " - ";
            string itemSalvar = "";

            using (StreamWriter sw = new StreamWriter(caminhoDoc, false)) // Abrindo o arquivo no modo de adição (append)
            {
                for (int i = 0; i < Estoque.nomeProdutos.Length - 1; i++)
                {
                    if (Estoque.nomeProdutos[i] != null)
                    {
                        if(i == Estoque.itemEscolhido && Estoque.inValorAlterado == true){
                            itemSalvar = $"{Estoque.listaTipoProdutos[i]} | {Estoque.nomeProdutos[i]} | {Estoque.corProdutos[i]} | {Estoque.modeloProdutos[i]} | R${Estoque.listaValores[i]} | {Estoque.listaQtProdutos[i]} Unidades no estoque";

                            Estoque.inValorAlterado = false;
                        } else{
                            itemSalvar = $"{Estoque.listaTipoProdutos[i]} | {Estoque.nomeProdutos[i]} | {Estoque.corProdutos[i]} | {Estoque.modeloProdutos[i]} | R${Estoque.listaValores[i]} | {Estoque.listaQtProdutos[i]} Unidades no estoque";
                        }

                        sw.Write(texto + itemSalvar + "\n");
                        itemSalvar = "";
                        texto = indice + 1 + " - ";
                    }
                }    
            }
        }    
        catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static void MontarListas()
    {
        StreamReader sr = new StreamReader(caminhoDoc);
        string[] listaEstoque = new string[tamanhoArray];

        for (int i = 0; i < listaEstoque.Length; i++)
        {
            string line = sr.ReadLine();
            string[] partes = line.Split(" | ");

            // Verifique se há partes suficientes após a divisão
            if (partes.Length >= 5)
            {
                Estoque.listaTipoProdutos[i] = partes[0];
                Estoque.nomeProdutos[i] = partes[1];
                Estoque.corProdutos[i] = partes[2];
                Estoque.modeloProdutos[i] = partes[3];
                Estoque.listaValores[i] = partes[4];
                Estoque.listaQtProdutos[i] = partes[5];
            }
            else
            {
                Console.WriteLine("Erro: A linha não contém dados suficientes.");
            }
        }

        sr.Close(); // Não se esqueça de fechar o StreamReader após usá-lo
    }
}
