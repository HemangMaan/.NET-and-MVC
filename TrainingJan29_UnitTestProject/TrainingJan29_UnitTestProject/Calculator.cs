﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingJan29_UnitTestProject
{
    internal class Calculator
    {
        public int Add(int a,int b) => a + b;
        public int Divide(int a,int b) => b>0?a / b:0;
        public int Multiply(int a,int b) => a * b;
        public int Subtract(int a,int b) => a - b;
    }
}
