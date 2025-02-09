
Menu();

static void Menu(){
    Console.Clear();
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir Arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("3 - Editar arquivo existente");
    Console.WriteLine("4 - Sair");
    short option = short.Parse(Console.ReadLine());

    switch(option){
        case 1: Open(); break;
        case 2: Create(); break;
        case 3: Edit(); break;
        case 4: Environment.Exit(0); break;
        default: Menu(); break;
    }
}

static void Open(){
    Console.Clear();
    Console.WriteLine("Informe o caminho completo do arquivo a ser aberto:");
    
    var path = Console.ReadLine();
    using(var file = new StreamReader(path)){
        while(!file.EndOfStream){
            Console.WriteLine(file.ReadLine());
        }
    }

    Console.ReadLine();
    Menu();
}

static void Create(){
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo ('s' para sair)");
    Console.WriteLine("--------------------------------------");
    string text = "";

    do{
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while(Console.ReadKey().Key != ConsoleKey.S);

    Console.Clear();
    Console.WriteLine("Infome o caminho completo do arquivo que deseja criar:");

    var path = Console.ReadLine();

    using(var file = new StreamWriter(path)){
        file.Write(text);
    }

    Console.WriteLine("Arquivo {0} salvo com sucesso", path);
    Console.ReadLine();
    Menu();
}

static void Edit(){
    Console.Clear();
    Console.WriteLine("Digite o caminho completo do arquivo a ser editado:");
    var path = Console.ReadLine();
    string text = "";
    
    Console.WriteLine("Texto original:");
    using(var fileReader = new StreamReader(path)){
        while(!fileReader.EndOfStream){
            Console.WriteLine(fileReader.ReadLine());
        }
    }
    Console.WriteLine("Digite o novo texto: (Digite ESC para salvar)");
    do{
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while(Console.ReadKey().Key != ConsoleKey.Escape);

    Console.WriteLine("Salvo com sucesso.");
    Console.ReadKey();
}

static void Save(string text){
    Console.Clear();
    Console.WriteLine("Infome o caminho completo do arquivo que deseja criar:");

    var path = Console.ReadLine();

    using(var file = new StreamWriter(path)){
        file.Write(text);
    }

    Console.WriteLine("Arquivo {0} salvo com sucesso", path);
    Console.ReadLine();
    Menu();
}