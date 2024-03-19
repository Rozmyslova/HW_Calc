internal interface ICalc
{
    void Addition(int number);

    void Substraction(int number);

    void Multiplication(int number);

    void Division(int number);
    event EventHandler<OperandChancedEventArgs> GetResult;

}