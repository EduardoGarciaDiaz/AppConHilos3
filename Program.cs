namespace AppConHilos3;

class Program
{
}

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }

    public Persona (String nombre, int edad, string sexo)
    {
        this.Nombre = nombre;
        this.Edad = edad;
        this.Sexo = sexo;
    }

    static void TareaDeFondoConParametro(Object? stateInfo)
    {
        if (stateInfo == null) 
        {
            return;
        }

        //Obtenemos el hilo actual
        Thread currentThread = Thread.CurrentThread;
        // Imprimimos el tipo
        Console.WriteLine("Es un thread background: {0}", currentThread.IsBackground);

        Persona data = (Persona)stateInfo;
        Console.WriteLine($"Hola {data.Nombre} desde ThreadPool.");
        Thread.Sleep(1000);
    }

    static void Main(string [] args)
    {
        // Crea un objeto y lo envía el hilo de trabajo de ThreadPool
        Persona p = new Persona("Eduardo García", 21, "Hombre");
        ThreadPool.QueueUserWorkItem(TareaDeFondoConParametro, p);

        //Esta instrucción es necesaria para que no termine el programa
        Console.ReadKey();
    }
}
