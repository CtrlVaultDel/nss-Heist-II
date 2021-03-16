using System;
namespace HeistII
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is breaking into the vault. Decreased vault lock {SkillLevel} points.");
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has opened the vault!");
            }
        }
        public LockSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }
    }
}