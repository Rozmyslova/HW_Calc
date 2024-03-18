using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OperandChancedEventArgs : EventArgs
{
    private double operand;
    private double result;

    public OperandChancedEventArgs(double result)
    {
        this.result = result;
    }

    public double Operand => operand;
}