﻿using System;

namespace Calculator
{
    /// <summary>
    /// First-in-first-out container based on array
    /// </summary>
    public class StackArray : IStack
    {
        private double[] stack;
        private int top = -1;

        public StackArray()
           => stack = new double[100];

        public void Push(double value)
        {
            top++;
            if (top == stack.Length)
            {
                Array.Resize(ref stack, stack.Length * 2);
            }
            stack[top] = value;
        }

        public double Pop()
        {
            if (top < 0)
            {
                throw new InvalidOperationException();
            }
            double topValue = stack[top];
            top--;
            return topValue;
        }

        public bool Empty
            => top < 0;

        public void ClearStack()
        {
            Array.Clear(stack, 0, top + 1);
            top = -1;
        }
    }
}
