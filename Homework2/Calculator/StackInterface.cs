using System;

namespace Calculator
{
    interface IStack
    {
        void Push(double value);

        double Pop();

        bool IsEmpty();

        void DeleteStack();
    }
}
