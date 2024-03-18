
internal class Program
{
    static void Main(string[] args)
    {
        GetRes();
    }

    static void GetRes()
    {
        ICalc calc = new Calc();

        Console.WriteLine("Добро пожаловать в наш калькулятор!");

        calc.GetResult += Calc_GetResalt;
        bool flag = true;
        while (flag)
        {
            try
            {
                Console.WriteLine("Что вы хотите сделать? 1 - выполнить расчет; 2 - выйти из программы.");
                int action = Convert.ToInt32(Console.ReadLine());
                if (action == 1)
                {
                    Console.Write("Введите число: ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите операцию (+, -, *, /): ");
                    string operation = Console.ReadLine();
                    switch (operation)
                    {
                        case "+":
                            calc.Addition(number);
                            break;
                        case "-":
                            calc.Substraction(number);
                            break;
                        case "*":
                            calc.Multiplication(number);
                            break;
                        case "/":
                            calc.Division(number);
                            break;
                        default:
                            Console.WriteLine("Нет такого пункта!");
                            break;
                    }
                }
                else if (action == 2)
                {
                    Console.WriteLine("Спасибо за визит!");
                    flag = false;
                }
                else 
                {
                    Console.WriteLine("Нет такого пункта!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void Calc_GetResalt(object? sender, OperandChancedEventArgs e)
    {
        Console.WriteLine(e.Operand);
    }

}
