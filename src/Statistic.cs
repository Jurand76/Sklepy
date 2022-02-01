using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;

namespace shops
{
    public class Statistic
    {
        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public Statistic()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 4:
                        return 'A';

                    case var d when d >= 3:
                        return 'B';

                    case var d when d >= 2:
                        return 'C';

                    case var d when d >= 1:
                        return 'D';

                    default:
                        return 'E';


                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}