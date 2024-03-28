class BancoDeDados {

    //Inicializar variáveis
    public static string itemSalvar;
    public static int linhaSobrescrever;
    public static int indiceNovoProduto;
    public static int tamanhoArray = 5;
    static bool problemaArquivo = false;
    static string caminhoDoc = "C:\\Users\\guigu\\Programação\\GameStore\\DadosSalvos.txt";
    public static bool listaVazia = false;
    static Estoque tratarEstoque = new Estoque();
    public static int qtItensListados;
    static StreamReader sr = new StreamReader(caminhoDoc);
    static StreamWriter sw = new StreamWriter(caminhoDoc);

    public static void VerificarBanco(){
        StreamReader sr = new StreamReader(caminhoDoc);
        string line = sr.ReadLine()!;

        foreach(var num in line.Split(':')){
            if(int.TryParse(num, out qtItensListados)){
                if(qtItensListados != 0){
                    listaVazia = false; 
                } else {
                    listaVazia = true;
                }
            }
        }
    }

    public static void LerBanco(){
        try{
            string line = sr.ReadLine()!;

            while(line != null){
                Console.WriteLine(line);
                line = sr.ReadLine()!;
            }
            sr.Close();
        } 
        catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static void escreverBanco(){
        string[] arquivo = File.ReadAllLines(caminhoDoc);
        string indiceItem = arquivo[arquivo.Length - 1];
        string texto = indiceItem + "-";
        
        try{
            for (int i = 0; i < Estoque.nomeProdutos.Length; i++)
            {
                if (Estoque.nomeProdutos[i] != null)
                {
                    itemSalvar = $" {Estoque.listaTipoProdutos[i]} | {Estoque.nomeProdutos[i]} | {Estoque.corProdutos[i]} | {Estoque.modeloProdutos[i]} | R${Estoque.listaValores[i]} | {Estoque.listaQtProdutos[i]} Unidades no estoque\n";
                }
            }
            
            sw.WriteLine(texto + itemSalvar);

        }catch(Exception e){
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}    