
internal class Calc : ICalc
{
    public event EventHandler<OperandChancedEventArgs> GetResult;
    private Stack<double> stack = new Stack<double>();
    private double Result {
        get 
        {
            return stack.Count() == 0 ? 0 : stack.Peek(); 
        } 
        set 
        {
            stack.Push(value); 
            RaiseEvent();
        } 
    }
   
    public void RaiseEvent()
    {
        GetResult.Invoke(this, new OperandChancedEventArgs(Result));
    }
    public void CancelLast() 
    {
        if (stack.Count > 0)
        {
            stack.Pop();
            RaiseEvent();
        }
    }
    public void Addition(double number)
    {
        Result += number;
    }

    public void Substraction(double number)
    {
        Result -= number;
    }
    public void Multiplication(double number)
    {
        Result *= number;
    }

    public void Division(double number)
    {
        Result /= number;
    }

}