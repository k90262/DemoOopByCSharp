using System;
using System.IO;

public class FtoCStrategy : Application {
    private TextReader input;
    private TextWriter output;
    private bool isDone = false;
    public static void Main(string[] args)
    {
        (new ApplicationRunner(new FtoCStrategy())).Run();    
    }

    public void Init()
    {
        input = Console.In;
        output = Console.Out;
    }

    public bool Done()
    {
        return isDone;
    }

    public void Idle()
    {
        string? fahrString =  input.ReadLine();
        if (fahrString == null || fahrString.Length == 0) 
            isDone = true;
        else 
        {
            double fahr = Double.Parse(fahrString);
            double celcius = 5.0/9.0*(fahr - 32);
            output.WriteLine("F={0}, C={1}", fahr, celcius);
        }
    }

    public void Cleanup()
    {
        output.WriteLine("ftoc exit");
    }

}