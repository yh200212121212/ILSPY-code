using System;
using PaperTest;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new PaperSize();
            string text = "显示A4纸宽度";
            string text2 = "显示A4纸宽度";
            Console.WriteLine(text);
            Console.WriteLine("A4纸宽{0}厘米",p.Getwidth(PaperTest.PaperSize.PaperMode.A4,PaperSize.SizeMode.Cm));
            Console.WriteLine(text2);
            Console.WriteLine("A4纸长{0}厘米",p.Getlenght(PaperSize.PaperMode.A4,PaperSize.SizeMode.Cm));
            Console.ReadKey(true);
        }
    }
}
