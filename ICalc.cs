internal interface ICalc
{
    void Addition(double number);

    void Substraction(double number);

    void Multiplication(double number);

    void Division(double number);
    event EventHandler<OperandChancedEventArgs> GetResult;

}