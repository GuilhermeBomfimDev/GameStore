class BancoDeDados {

    //Inicializar variáveis
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
        
        Console.WriteLine(qtItensListados);
        Console.WriteLine(listaVazia);
        Console.ReadLine();
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
        string line = sr.ReadLine()!;

        foreach(var num in line.Split(':')){
            if(int.TryParse(num, out qtItensListados)){
                
            }
        }

        sw.WriteLine();
    }
}