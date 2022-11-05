using System;
using System.IO;

public class FtoCRaw {
    public static void Main(string[] args)
    {
        bool done = false;
        while (!done)
        {
            string? fahrString =  Console.In.ReadLine();
            if (fahrString == null || fahrString.Length == 0) 
                done = true;
            else 
            {
                double fahr = Double.Parse(fahrString);
                double celcius = 5.0/9.0*(fahr - 32);
                Console.Out.WriteLine("F={0}, C={1}", fahr, celcius);
            }
        }
        Console.Out.WriteLine("ftoc exit");
    }
}