using System;
namespace HeistII
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased alarm {SkillLevel} points.");
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }
        public Hacker(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            Specialty = "Hacker";
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
    }
}