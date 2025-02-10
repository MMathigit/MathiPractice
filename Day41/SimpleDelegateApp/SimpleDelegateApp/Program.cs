namespace SimpleDelegateApp
{
    delegate void DPrintMessage(string name);
    internal class Program
    {

        static void Main(string[] args)
        {
            CaseStudy1();
            CaseStudy2();//multi cast Delegates
        }
        private static void CaseStudy1() {
            DPrintMessage x; //x expects a function
            x = PrintHello;
            x("Mathi");
            x = PrintGoodBye;
            x("Magal");


        }
        private static void CaseStudy2() {
            DPrintMessage x;
            x = PrintGoodBye;
            x += PrintGoodBye;
            x += PrintHello;
            x("Check1");
           
                }

        static void PrintHello(string name) {
            Console.WriteLine($"Hello {name}");
        }

        static void PrintGoodBye(string name)
        {
            Console.WriteLine($"GoodBye {name}");
        }
        void foo() { }
    }
}
