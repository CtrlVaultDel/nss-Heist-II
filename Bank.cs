using System;
namespace HeistII
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure
        {
            get
            {
                if (CashOnHand <= 0 && AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private int RandomValue()
        {
            Random rnd = new Random();
            int randomValue = rnd.Next(0, 101);
            return randomValue;
        }
        private int RandomCash()
        {
            Random rnd = new Random();
            int randomCash = rnd.Next(50000, 1000001);
            return randomCash;
        }
        public Bank()
        {
            CashOnHand = RandomCash();
            AlarmScore = RandomValue();
            VaultScore = RandomValue();
            SecurityGuardScore = RandomValue();
        }
    }
}