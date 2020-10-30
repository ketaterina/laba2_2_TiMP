using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;


namespace laba2_2_TiMP
{
    class Program
    {
        #region КОНСТАНТЫ
        const string entryPointTheFunc = "TheFunc";
        const string entryPointFuncName = "FuncName";

        const string pathToLib0 = "Resources/Lib.dll";
        const string pathToLib1 = "Resources/Lib2-2-1.dll";
        const string pathToLib2 = "Resources/Lib2-2-2.dll";
        const string pathToLib3 = "Resources/Lib2-2-3.dll";
        const string pathToLib3_1 = "Resources/Lib2-2-3-1.dll";
        const string pathToLib3_2 = "Resources/Lib2-2-3-2.dll";
        #endregion

        #region ImportDLL
        #region DLL Lib
        [DllImport(pathToLib0, CallingConvention = CallingConvention.Cdecl, EntryPoint = entryPointTheFunc)]
        static public extern double TheFunc0(double x);


        [DllImport(pathToLib0, CallingConvention = CallingConvention.StdCall, EntryPoint = entryPointFuncName)]
        static public extern IntPtr FuncName0();
        #endregion

        #region DLL Lib1
        [DllImport(pathToLib1, CallingConvention = CallingConvention.Cdecl, EntryPoint = entryPointTheFunc)]
        static public extern double TheFunc1(double x);


        [DllImport(pathToLib1, CallingConvention = CallingConvention.StdCall, EntryPoint = entryPointFuncName)]
        static public extern IntPtr FuncName1();
        #endregion

        #region DLL Lib2
        [DllImport(pathToLib2, CallingConvention = CallingConvention.Cdecl, EntryPoint = entryPointTheFunc)]
        static public extern double TheFunc2(double x);


        [DllImport(pathToLib2, CallingConvention = CallingConvention.StdCall, EntryPoint = entryPointFuncName)]
        static public extern IntPtr FuncName2();
        #endregion

        #region DLL Lib3
        [DllImport(pathToLib3, CallingConvention = CallingConvention.Cdecl, EntryPoint = entryPointTheFunc)]
        static public extern double TheFunc3(double x);


        [DllImport(pathToLib3, CallingConvention = CallingConvention.StdCall, EntryPoint = entryPointFuncName)]
        static public extern IntPtr FuncName3();
        #endregion

        #region DLL Lib3_1
        [DllImport(pathToLib3_1, CallingConvention = CallingConvention.Cdecl, EntryPoint = entryPointTheFunc)]
        static public extern double TheFunc3_1(double x);


        [DllImport(pathToLib3_1, CallingConvention = CallingConvention.StdCall, EntryPoint = entryPointFuncName)]
        static public extern IntPtr FuncName3_1();
        #endregion

        #region DLL Lib3_2
        [DllImport(pathToLib3_2, CallingConvention = CallingConvention.Cdecl, EntryPoint = entryPointTheFunc)]
        static public extern double TheFunc3_2(double x);


        [DllImport(pathToLib3_2, CallingConvention = CallingConvention.StdCall, EntryPoint = entryPointFuncName)]
        static public extern IntPtr FuncName3_2();
        #endregion
        #endregion
        
        private static Func<double, double>[] arrTheFunc = new Func<double, double>[]
            {TheFunc0, TheFunc1, TheFunc2, TheFunc3, TheFunc3_1, TheFunc3_2};

        private static Func<IntPtr>[] arrFuncName = new Func<IntPtr>[]
           {FuncName0, FuncName1, FuncName2, FuncName3, FuncName3_1, FuncName3_2};


        static void Main(string[] args)
        {
            Console.WriteLine($"Функции на выбор:{Environment.NewLine}0.TheFunc0{Environment.NewLine}" +
                $"1.TheFunc1{Environment.NewLine}" + $"2.TheFunc2{Environment.NewLine}3.TheFunc3{ Environment.NewLine}" +
                $"4.TheFunc3_1{Environment.NewLine}5.TheFunc3_2{Environment.NewLine}6.Выход");
            
            while (true)
            {
                try
                {
                    Console.Write($"{Environment.NewLine}Выбор функции №");
                    int selectedFunc = Convert.ToInt32(Console.ReadLine());
                    GetPointXY(arrTheFunc[selectedFunc]);
                    string nameFunc = Marshal.PtrToStringAnsi(arrFuncName[selectedFunc]());
                    Application.Run(new Graph(GetPointXY(arrTheFunc[selectedFunc]), nameFunc));
                }
                catch(System.BadImageFormatException)
                {
                    Console.WriteLine("Библиотеку загрузить не удалось");
                }
                catch (System.EntryPointNotFoundException)
                {
                    Console.WriteLine("Функции не найдены.");
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                }
            }
        }
        static private Dictionary<double, double> GetPointXY(Func<double, double> func)
        {
            Dictionary<double, double> coefDictXY = new Dictionary<double, double>();
            for(double x = 0; x <= 10; x++)
            {
                coefDictXY.Add(x, func(x));
            }
            return coefDictXY;
        }
    }
}
