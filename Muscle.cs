using System;
namespace HeistII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is taking care of the security guards. Decreased security {SkillLevel} points.");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has knocked out all of the security guards!");
            }
        }
        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
    }
}