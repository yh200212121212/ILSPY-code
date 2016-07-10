using System;
namespace ClassLibrary1
{
    interface IPaperSize
    {
        event EventHandler Add;
        string D { get; }
        void Dispose();
        void Drawtest(System.Drawing.Graphics g, System.Drawing.Pen p, PaperTest.PaperSize.PaperMode papermode1, int x, int y);
        bool Equals(object obj);
        bool Equals(object obj, PaperTest.PaperSize.PaperMode pm);
        int GetHashCode();
        int Getlenght(PaperTest.PaperSize.PaperMode paperMode1, PaperTest.PaperSize.SizeMode sizeMode1);
        IntPtr Getpapersizeptr { get; set; }
        PaperTest.PaperSize.Pointx Getpointx(PaperTest.PaperSize.PaperMode papermode1);
        int Getwidth(PaperTest.PaperSize.PaperMode papermode1, PaperTest.PaperSize.SizeMode sizeMode1);
        void PaperSize_Add(object sender, EventArgs e);
        void PaperSize_Remove(object sender, EventArgs e);
        event EventHandler Remove;
        int Size { get; }
        string ToString();
        bool Writewidghtandlenght(PaperTest.PaperSize.PaperMode pm, PaperTest.PaperSize.SizeMode sm);
    }
}
