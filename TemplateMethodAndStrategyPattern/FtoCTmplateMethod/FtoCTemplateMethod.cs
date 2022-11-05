using System;
using System.IO;

public class FtoCTemplateMethod : Application 
{
    private TextReader input = Console.In;
    private TextWriter output = Console.Out;

    public static void Main(string[] args)
    {
        new FtoCTemplateMethod().Run();
    }

    protected override void Init()
    {
        input = Console.In;
        output = Console.Out;
    }

    protected override void Idle()
    {
            string? fahrString =  input.ReadLine();
            if (fahrString == null || fahrString.Length == 0) 
                SetDone();
            else 
            {
                double fahr = Double.Parse(fahrString);
                double celcius = 5.0/9.0*(fahr - 32);
                output.WriteLine("F={0}, C={1}", fahr, celcius);
            }
    }

    protected override void Cleanup()
    {
        output.WriteLine("ftoc exit");;
    }
}