namespace DelegateMathOperationnApp
{
    delegate void MathOper(int num1, int num2);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MultiCasting Delegates");
            Console.WriteLine("-----------------------");
            MathOper mo;
            mo = Add;
            mo += Sub;
            mo += Multi;
            mo += Mod;
            mo(10, 2);
        }
        static void Add(int num1, int num2)
        {
            var res = num1 + num2;
            Console.WriteLine("Addition is " + res);
        }
        static void Sub(int num1, int num2)
        {
            var res = num1 - num2;
            Console.WriteLine($"Subtraction is {res}");
        }
        static void Multi(int num1, int num2)
        {
            var res = num1 * num2;
            Console.WriteLine("Multiplication is " + res);
        }
        static void Mod(int num1, int num2)
        {
            var res = num1 / num2;
            Console.WriteLine("Division is " + res);

        }
    }
}
