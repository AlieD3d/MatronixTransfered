using System;
using System.Linq;

class Program
{
    public static void Main()
    {
        var A = new SelfEdu.Matrix();
        A.Read();
        var B = new SelfEdu.Matrix();
        B.Read();
        A.MultiplyMatrix(B);
        Console.WriteLine();
        A.Write();
    }
}