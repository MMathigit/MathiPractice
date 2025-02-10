class Hello
{
    static void Main()
    {   
        Console.WriteLine("Enter the number of times the test should print");
        int num = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= num; i++)
        {
            Console.WriteLine("Hello, Welcome");
        }
    }
}