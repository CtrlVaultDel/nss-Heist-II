
namespace HeistII
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        private bool IsSecure
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
    }
}