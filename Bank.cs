
namespace HeistII
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int ValutScore { get; set; }
        public int SecurityGuardScore { get; set; }
        private bool IsSecure;
    }
}