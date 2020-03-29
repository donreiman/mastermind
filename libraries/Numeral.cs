using System;

namespace mastermind.libraries 
{
    public class Numeral 
    {
        public string FourDigitString;
        public Numeral(string fourDigitString) 
        {
            FourDigitString = fourDigitString;
        }

        public Numeral() 
        {
            FourDigitString = string.Empty;
            Random random = new Random();
            for (var i = 0; i < 4; i++)
            {
                FourDigitString += random.Next(1, 6).ToString();
            }
        }
    }
}
