using System.Text;
using Game_Store;

class BancoDeDados {

    //Inicializar variáveis
    public static string? itemSalvar;
    //public static int linhaSobrescrever;
    public static int indiceNovoProduto;
    public static int tamanhoArray = 5;
    //static bool problemaArquivo = false;
    static string caminhoDoc = "C:\\Users\\guigu\\Programação\\GameStore\\DadosSalvos.txt";
    public static bool listaVazia = false;
    //static Estoque tratarEstoque = new Estoque();
    public static int qtItens;

    public static void VerificarBanco()
    {
        try{
            StreamReader sr = new StreamReader(caminhoDoc);
            string line = sr.ReadLine()!;

            if(line == null){
                listaVazia = true;
            } else {
                listaVazia = false;
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

    public static void escreverBanco(){
        try
        {
            string indiceItem;
            string[] arquivo = File.ReadAllLines(caminhoDoc);
            if(listaVazia == false){
                indiceItem = arquivo[arquivo.Length - 1];
                Console.WriteLine("Arquivo maior que 0");

            } else{
                indiceItem = "1";
                Console.WriteLine("Arquivo vazio");
            }
            
            int indice = int.Parse(indiceItem);
            string texto = (indice) + " - ";
            
            StringBuilder produtosBuilder = new StringBuilder(); // Usando StringBuilder para uma concatenação eficiente

            for (int i = 0; i < Estoque.nomeProdutos.Length; i++)
            {
                if (Estoque.nomeProdutos[i] != null)
                {
                    string itemSalvar = $" {Estoque.listaTipoProdutos[i]} | {Estoque.nomeProdutos[i]} | {Estoque.corProdutos[i]} | {Estoque.modeloProdutos[i]} | R${Estoque.listaValores[i]} | {Estoque.listaQtProdutos[i]} Unidades no estoque\n";

                    produtosBuilder.Append(itemSalvar); // Acumulando as informações dos produtos
                }
            }

            using (StreamWriter sw = new StreamWriter(caminhoDoc, true)) // Abrindo o arquivo no modo de adição (append)
            {
                sw.WriteLine(texto + produtosBuilder.ToString());
            }

            indiceItem += 1;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}    