
using System.Runtime.Serialization;

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
    public void Addition(int number)
    {
        try
        {
            Result += number;
        }
        catch
        {
            throw new CalculateOperationCauseOverflowException("Превышение допустимого числа");
        }
    }

    public void Substraction(int number)
    {
        try
        {
            Result -= number;
        }
        catch
        {
            throw new CalculateOperationCauseOverflowException("Превышение допустимого числа");
        }
    }
    public void Multiplication(int number)
    {
        try
        {
            Result *= number;
        }
        catch
        {
            throw new CalculateOperationCauseOverflowException("Превышение допустимого числа");
        }
    }

    public void Division(int number)
    {
        try
            {
                if (number != 0)
                    Result /= number;
                else
                    throw new CalculatorDivideByZeroException("На 0 делить нельзя!");
            }
            catch
            {
                throw new CalculateOperationCauseOverflowException("Превышение допустимого числа");
            }
    }

    [Serializable]
    private class CalculateOperationCauseOverflowException : Exception
    {
        public CalculateOperationCauseOverflowException()
        {
        }

        public CalculateOperationCauseOverflowException(string? message) : base(message)
        {
        }

        public CalculateOperationCauseOverflowException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CalculateOperationCauseOverflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

[Serializable]
internal class CalculatorDivideByZeroException : Exception
{
    public CalculatorDivideByZeroException()
    {
    }

    public CalculatorDivideByZeroException(string? message) : base(message)
    {
    }

    public CalculatorDivideByZeroException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CalculatorDivideByZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}