using System;

namespace TrainingJan27
{
    public class Intrest
    {
        public double SimpleIntrest(double principal,double rate,double time)
        {
            return principal * (1 + rate * time);
        }
        public double discount(double amount,double discount)
        {
            return amount * discount/100;
        }
    }
}
