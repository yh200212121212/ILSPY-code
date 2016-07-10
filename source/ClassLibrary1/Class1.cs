#region 纸张类
#region defines
#define WIN32
#endregion
#region usings
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using LogHelper;
#endregion
#region Paperclass
namespace PaperTest
{
    #region 测试c#新关键字
    public class Testnameof : ClassLibrary1.ITestnameof
    {
        private readonly Type _t;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="t">typeof获取type</param>
        public Testnameof(Type t)
        {
            this._t = t;
        }
        /// <summary>
        /// 测试c#新关键字
        /// </summary>
        /// <returns>名称</returns>
        public virtual string NameOf()
        {
            return this._t.FullName;
        }

        string ClassLibrary1.ITestnameof.NameOf()
        {
            return this.NameOf();
        }
    }
    #endregion   
    #region 纸张测试类
    public class PaperSize : ClassLibrary1.IPaperSize, IDisposable
    {
        private Logfile _l;
        public PaperSize()
        {
        }

        public PaperSize(string path)
        {
            _l=new Logfile(path);
        }
        private  readonly  FileStream _fs = new FileStream("E:\\tester-1.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite,2048,false);
        private  int _maxByteLenght = 100;
        public virtual  void PaperSize_Remove(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void WriteLog(string message, string title, string path)
        {
            L= new Logfile(path);
            L.Log(message, title);
        }
        public  virtual  void PaperSize_Add(object sender, EventArgs e)
        {
            return;
        }
        public static  PaperSize Getit { 
            get { return new PaperSize(); }
        }
        #region 实现
        /// <summary>
        /// 数据对结构
        /// </summary>
        public struct Pointx
        {
            /// <summary>
            /// 长和宽
            /// </summary>
            private readonly int _widght;
            private readonly int _lenght;
            /// <summary>
            /// 初始化
            /// </summary>
            /// <param name="widght">宽度</param>
            /// <param name="lenght">长度</param>
            public Pointx(int widght, int lenght)
            {
                this._lenght = lenght;
                this._widght = widght;
            }
            public int Getwidght
            {
                get
                {
                    return this._widght;
                }
            }
            public int Getlenght
            {
                get
                {
                    return this._lenght;
                }
            }
            public unsafe Pointx* Getptr {
                get {
                Pointx p = new Pointx();
                Pointx* k = &p;
                return k;  
            } 
            }
        }
        /// <summary>
        /// 纸模式
        /// </summary>
        public enum PaperMode
        {
            A3 = 0,
            A4 = 1,
            A5 = 2,
            B4 = 3,
            A0 = 4
        }
        /// <summary>
        /// 单位模式
        /// </summary>
        public enum SizeMode
        {
            Mm = 0,
            Cm = 1,
            M =  2
        }
        /// <summary>
        /// 纸张定义
        /// </summary>
        internal  const int A3Length = 420;
        internal const int A3Width = 297;
        internal const int A4Length = 297;
        internal const int A4Width = 210;
        internal const int A5Length = 210;
        internal const int A5Width = 148;
        internal const int B4Length = 353;
        internal const int B4Width = 250;
        internal const int A0Length = 1189;
        internal const int A0Width = 841;
        internal readonly Pointx A3 = new Pointx(A3Width, A3Length);
        internal readonly Pointx A4 = new Pointx(A4Width, A4Length);
        internal readonly Pointx A5 = new Pointx(A5Width, A5Length);
        internal readonly Pointx B4 = new Pointx(B4Width, B4Length);
        internal readonly Pointx A0 = new Pointx(A0Width, A0Length);
        //length 长度
        //width  宽度
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <param name="paperMode1">纸模式</param>
        /// <param name="sizeMode1">尺寸单位模式</param>
        /// <returns></returns>
        public int Getlenght(PaperMode paperMode1, SizeMode sizeMode1)
        {
            switch (sizeMode1)
            {
                case SizeMode.Mm:
                    switch (paperMode1)
                    {
                        case PaperMode.A3:
                            return A3Length;
                        case PaperMode.A4:
                            return A4Length;
                        case PaperMode.A5:
                            return A5Length;
                        case PaperMode.B4:
                            return B4Length;
                        case PaperMode.A0:
                            return A0Length;
                        default:
                            throw new ArgumentException(typeof(PaperSize).FullName);
                    }

                case SizeMode.Cm:
                    switch (paperMode1)
                    {
                        case PaperMode.A3:
                            return A3Length / 10;
                        case PaperMode.A4:
                            return A4Length / 10;
                        case PaperMode.A5:
                            return A5Length / 10;
                        case PaperMode.B4:
                            return B4Length / 10;
                        case PaperMode.A0:
                            return A0Length / 10;
                        default:
                            throw new ArgumentException(typeof(PaperSize).FullName);
                    }
                case SizeMode.M:
                    switch (paperMode1)
                    {
                        case PaperMode.A3:
                            return A3Length / 1000;
                        case PaperMode.A4:
                            return A4Length / 1000;
                        case PaperMode.A5:
                            return A5Length / 1000;
                        case PaperMode.B4:
                            return B4Length / 1000;
                        case PaperMode.A0:
                            return A0Length / 1000;
                        default:
                            throw new ArgumentException(typeof(PaperSize).FullName);
                    }
                default:
                    throw new ArgumentException(typeof(PaperSize).FullName);
            }
        }
        /// <summary>
        /// 获取宽度
        /// </summary>
        /// <param name="papermode1">纸模式</param>
        /// <param name="sizeMode1">尺寸单位模式</param>
        /// <returns></returns>
        public virtual int Getwidth(PaperMode papermode1, SizeMode sizeMode1)
        {
            switch (sizeMode1)
            {
                case SizeMode.Mm:
                    switch (papermode1)
                    {
                        case PaperMode.A3:
                            return A3Width;
                        case PaperMode.A4:
                            return A4Width;
                        case PaperMode.A5:
                            return A5Length;
                        case PaperMode.B4:
                            return B4Width;
                        case PaperMode.A0:
                            return A0Width;
                        default:
                            throw new ArgumentException(typeof(PaperSize).FullName);
                    }
                case SizeMode.Cm:
                    switch (papermode1)
                    {
                        case PaperMode.A3:
                            return A3Width / 10;
                        case PaperMode.A4:
                            return A4Width / 10;
                        case PaperMode.A5:
                            return A5Length / 10;
                        case PaperMode.B4:
                            return B4Width / 10;
                        case PaperMode.A0:
                            return A0Width / 10;
                        default:
                            throw new ArgumentException(typeof(PaperSize).FullName);
                    }
                case SizeMode.M:
                    switch (papermode1)
                    {
                        case PaperMode.A3:
                            return A3Width / 1000;
                        case PaperMode.A4:
                            return A4Width / 1000;
                        case PaperMode.A5:
                            return A5Length / 1000;
                        case PaperMode.B4:
                            return B4Width / 1000;
                        case PaperMode.A0:
                            return A0Width / 1000;
                        default:
                            throw new ArgumentException(typeof(PaperSize).FullName);
                    }
                default:
                    throw new ArgumentException(typeof(PaperSize).FullName);
            }
        }
        /// <summary>
        /// 获取point
        /// </summary>
        /// <param name="papermode1">纸模式</param>
        /// <returns>对象</returns>
        public virtual Pointx Getpointx(PaperMode papermode1)
        {
            switch (papermode1)
            {
                case PaperMode.A3:
                    return A3;
                case PaperMode.A4:
                    return A4;
                case PaperMode.A5:
                    return A5;
                case PaperMode.B4:
                    return B4;
                case PaperMode.A0:
                    return A0;
                default:
                    throw new ArgumentException(typeof(PaperSize).FullName);
            }
        }
        /// <summary>
        /// 用指定绘画对象画出纸张样图
        /// </summary>
        /// <param name="g">绘画对象</param>
        /// <param name="p">笔</param>
        /// <param name="papermode1">纸模式</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Drawtest(Graphics g, Pen p, PaperMode papermode1,int x,int y)
        {
            if (g==null && p==null)
            {
                throw new ArgumentException("error");
            }
            else
            {
                 if (x == 0 && y == 0)
            {
                throw new ArgumentException("one of Argument is 0!");
            }
                 else
                 {
                    Rectangle r;
            switch (papermode1)
            {
                case PaperMode.A3:
                    r = new Rectangle(x, y, Getwidth(PaperMode.A3, SizeMode.Mm), Getlenght(PaperMode.A3, SizeMode.Mm));
                    break;
                case PaperMode.A4:
                    r = new Rectangle(x, y, Getwidth(PaperMode.A4, SizeMode.Mm), Getlenght(PaperMode.A4, SizeMode.Mm));
                    break;
                case PaperMode.A5:
                    r = new Rectangle(x, y, Getwidth(PaperMode.A5, SizeMode.Mm), Getlenght(PaperMode.A5, SizeMode.Mm));
                    break;
                case PaperMode.B4:
                    r = new Rectangle(x, y, Getwidth(PaperMode.B4, SizeMode.Mm), Getlenght(PaperMode.B4, SizeMode.Mm));
                    break;
                case PaperMode.A0:
                    r = new Rectangle(x, y, Getwidth(PaperMode.A0, SizeMode.Mm), Getlenght(PaperMode.A0, SizeMode.Mm));
                    break;
                default:
                    r = new Rectangle(0, 0, 0, 0);
                    break;
            }
            if (r != new Rectangle(0, 0, 0, 0))
            {
                g.DrawRectangle(p, r);
            }
            else
            {
                g.DrawPie(p, r, 5.5f, 8.5f);
            }     
                 }
            }
        }
        /// <summary>
        /// 获取当前对象指针
        /// </summary>
        public virtual unsafe IntPtr Getpapersizeptr
        {
            get
            {
                void* i = (void*)(0x80097009);
                int offest = unchecked((int)0x80097009);
                IntPtr n = new IntPtr(i);
                IntPtr.Add(n, offest);
                return n;
            }
            set
            {
                value = new IntPtr((void*)unchecked(0x8009409));
            }
        }
        /// <summary>
        /// 获取计算机位数，此为支持基础代码，不应在代码中直接使用
        /// </summary>
        public virtual int Size
        {
            get
            {
#if WIN32
                return 4;
#else 
                return 8;
#endif
            }
        }
        /// <summary>
        /// 写数据到文件
        /// </summary>
        /// <param name="pm"></param>
        /// <param name="sm"></param>
        /// <returns></returns>
        public  bool Writewidghtandlenght(PaperMode pm,SizeMode sm)
        {
            string a = "长度：";
            string d;
            string b = "宽度: ";
            switch (sm)
            {
                case SizeMode.Mm:
                j:
                    {
                        d = "毫米";
                    }
                    break;
                case SizeMode.Cm:
                    d = "厘米";
                    break;
                case SizeMode.M:
                    d = "米";
                    break;
                default:
                    goto j;
            }
            string s = a + Getlenght(pm, sm).ToString() + d + "\n" + b + Getwidth(pm, sm).ToString() + d + "\n";
            char[] c = s.ToCharArray();
            byte[] buffer = new byte[_maxByteLenght];
            buffer=System.Text.Encoding.UTF8.GetBytes(c);
                    _fs.Write(buffer, 0, buffer.Length);
                    _fs.Flush();
            if (_fs.ReadByte()==-1)
	       {
		    return true;
	        }
            return false;
            }       
        #endregion
        #region 运算符定义
        public static bool operator ==(PaperSize left, PaperSize right) { return left == right; }
        public static bool operator !=(PaperSize left, PaperSize right) { return left != right; }
        public static PaperSize operator +(PaperSize left, PaperSize right) { return left + right; }
        public static PaperSize operator -(PaperSize left, PaperSize right) { return left - right; }
        public virtual bool Equals(object obj, PaperMode pm)
        {
            if (obj is int)
            {
                return Getpointx(pm).Equals(obj);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return typeof(PaperSize).FullName;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion
        #region 释放资源
        ~PaperSize()
        {
            Dispose(true);
        }
        #endregion
        #region 实现接口
        void ClassLibrary1.IPaperSize.Drawtest(Graphics g, Pen p, PaperSize.PaperMode papermode1,int x,int y)
        {
            this.Drawtest(g, p, papermode1,x,y);
        }

        bool ClassLibrary1.IPaperSize.Equals(object obj)
        {
            return this.Equals(obj);
        }

        bool ClassLibrary1.IPaperSize.Equals(object obj, PaperSize.PaperMode pm)
        {
            return this.Equals(obj, pm);
        }

        int ClassLibrary1.IPaperSize.GetHashCode()
        {
            return this.GetHashCode();
        }

        int ClassLibrary1.IPaperSize.Getlenght(PaperSize.PaperMode paperMode1, PaperSize.SizeMode sizeMode1)
        {
            return this.Getlenght(paperMode1, sizeMode1);
        }

       unsafe  IntPtr  IPaperSize.Getpapersizeptr { 
            get { 
                return this.Getpapersizeptr; 
            }
            set { 
            value=new IntPtr((void*)unchecked(0x7777f5d3));
            }
        }
        PaperSize.Pointx ClassLibrary1.IPaperSize.Getpointx(PaperSize.PaperMode papermode1)
        {
            return this.Getpointx(papermode1);
        }

        int ClassLibrary1.IPaperSize.Getwidth(PaperSize.PaperMode papermode1, PaperSize.SizeMode sizeMode1)
        {
            return Getwidth(papermode1, sizeMode1);
        }

        int ClassLibrary1.IPaperSize.Size
        {
            get { return this.Size; }
        }
        string ClassLibrary1.IPaperSize.ToString()
        {
           
            return this.ToString();
        }
        public string D { 
            get {
            Debug.Print("test {0}", new int[2] { 1, 3 });
            return Debug.Listeners.ToString();
        }
        }

        public Logfile L
        {
            get
            {
                return _l;
            }

            set
            {
                _l = value;
            }
        }

        event EventHandler ClassLibrary1.IPaperSize.Add
      {
          add { return; }
          remove { }
      }

     
       event EventHandler ClassLibrary1.IPaperSize.Remove
      {
          add { }
          remove { }
      }
      void ClassLibrary1.IPaperSize.PaperSize_Add(object sender, EventArgs e)
      {
        
      }

      void ClassLibrary1.IPaperSize.PaperSize_Remove(object sender, EventArgs e)
      {
         
      }
        #region 资源清理
        public void Dispose()
      {
          Dispose(true);
      }
        protected  virtual void Dispose(bool b)
        {
            if (b)
            {
                 _fs.Close();
                 _fs.Dispose();
                 GC.SuppressFinalize(this);
                 return;
            }
            else
            {
                GC.SuppressFinalize(typeof(PaperSize));
                GC.SuppressFinalize(this);
                return;
                
            }
        }
        #endregion     
        #endregion
        #region 事件
        public virtual  event EventHandler Add
      {
          add { Console.WriteLine("ADD"); }
          remove { Console.WriteLine("REMOVE"); }
      }
      public virtual  event EventHandler Remove
      {
          add {  }
          remove { }
      }
        #endregion

    }
    }

    #endregion
    #region 测试特征
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class MyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        internal  readonly string positionalString;
        internal readonly int NameInt;
        // This is a positional argument
        public MyAttribute(string positionalString,int nameInt)
        {
            this.positionalString = positionalString;
            this.NameInt = nameInt;
            // TODO: Implement code here
            
        }

        public string PositionalString
        {
            get { return positionalString; }
        }

        // This is a named argument
        public int NamedInt {
            get { return this.NameInt; }
            set { value = this.NameInt; }
        }
    }
#endregion
    #region 字典类仿
[Serializable()]
    public class D<TKey, TVaule> : Dictionary<TKey, TVaule>
{
    protected D(SerializationInfo info, StreamingContext context):base(info,context) {  }
    public D() { }
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}
#region Listtest
public sealed  class L<T> : List<T>, IList<T>
{
    readonly List<T> _ll = new List<T>();
    int IList<T>.IndexOf(T item)
    {
        return _ll.IndexOf(item);
    }

    void IList<T>.Insert(int index, T item)
    {
       _ll.Insert(index, item);
    }

    void IList<T>.RemoveAt(int index)
    {
        _ll.RemoveAt(index);
    }

    T IList<T>.this[int index]
    {
        get
        {
           return new List<T>()[index];
        }
        set { value = this[index]; }
    }

    void ICollection<T>.Add(T item)
    {
        _ll.Add(item);
    }

    void ICollection<T>.Clear()
    {
        _ll.Clear();
    }

    bool ICollection<T>.Contains(T item)
    {
        return _ll.Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
       _ll.CopyTo(array, arrayIndex);
    }

    int ICollection<T>.Count
    {
        get { return _ll.Count; }
    }

    bool ICollection<T>.IsReadOnly
    {
        get { return false; }
    }

    bool ICollection<T>.Remove(T item)
    {
        return _ll.Remove(item);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new Enumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return new Enumerator();
    }
}
#endregion
#endregion
#endregion
#endregion