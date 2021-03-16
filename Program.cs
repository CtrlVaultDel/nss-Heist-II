using System;
using System.Collections.Generic;

namespace HeistII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>();

            // Instantiate Hackers & add them to rolodex list
            Hacker anonymous = new Hacker("Anonymous", 15, 50);
            Hacker neo = new Hacker("Neo", 70, 35);

            rolodex.Add(anonymous);
            rolodex.Add(neo);

            // Instantiate Lockpickers & add them to rolodex list
            LockSpecialist houdini = new LockSpecialist("Harry Houdini", 60, 50);
            LockSpecialist linus = new LockSpecialist("Linus Yale", 40, 30);

            rolodex.Add(houdini);
            rolodex.Add(linus);

            // Instantiate Muscle & add them to rolodex list
            Muscle hogan = new Muscle("Hulk Hogan", 50, 25);
            Muscle cena = new Muscle("John Cena", 60, 25);

            rolodex.Add(hogan);
            rolodex.Add(cena);

            // Display how many members there are 
            Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex.");

            bool addingMember = true;

            // Make a list of the possible specialties
            List<string> specialties = new List<string>();
            specialties.Add("1) Hacker: (Disables alarms)");
            specialties.Add("2) Muscle: (Disables guards)");
            specialties.Add("3) Lock Specialist: (Cracks vault)");

            // Allow user to input new members if they want to
            while (addingMember)
            {
                // Local variables
                string memberName;
                int memberSkill = 0;
                int memberCut = 0;

                // Name
                Console.Write("Enter a new member - (Empty if you want to skip): ");
                memberName = Console.ReadLine();
                if (memberName == "")
                {
                    break;
                }
                Console.WriteLine();

                // Skill Level
                bool choseSkill = false;
                while (!choseSkill)
                {
                    memberSkill = 0;
                    Console.Write($"Enter the skill level (0-100) for {memberName}: ");
                    string tempMemberSkill = Console.ReadLine();
                    choseSkill = Int32.TryParse(tempMemberSkill, out memberSkill);
                    if (memberSkill < 0 || memberSkill > 100)
                    {
                        choseSkill = false;
                    }
                }

                // Percentage Cut
                bool choseCut = false;
                while (!choseCut)
                {
                    memberCut = 0;
                    Console.Write($"Enter the percentage cut (0-100) for {memberName}: ");
                    string tempMemberCut = Console.ReadLine();
                    choseCut = Int32.TryParse(tempMemberCut, out memberCut);
                    if (memberCut < 0 || memberCut > 100)
                    {
                        choseCut = false;
                    }
                }

                // Specialty
                bool choseSpecialty = false;
                while (!choseSpecialty)
                {
                    Console.WriteLine("Choose one of the following specialties (1,2,3)");
                    foreach (string specialty in specialties)
                    {
                        Console.WriteLine(specialty);
                    }
                    string stringMemberSpecialty = Console.ReadLine();

                    // If the user chooses an appropriate option, continue 
                    // and prepare the program to break out of the while loop
                    if (stringMemberSpecialty == "1" || stringMemberSpecialty == "2" || stringMemberSpecialty == "3")
                    {
                        choseSpecialty = true;

                        // Convert response to an integer
                        int intMemberSpecialty = Int32.Parse(stringMemberSpecialty);

                        // 
                        if (intMemberSpecialty == 1)
                        {
                            Hacker newPerson = new Hacker(memberName, memberSkill, memberCut);
                            rolodex.Add(newPerson);
                        }
                        else if (intMemberSpecialty == 2)
                        {
                            Muscle newPerson = new Muscle(memberName, memberSkill, memberCut);
                            rolodex.Add(newPerson);
                        }
                        else
                        {
                            LockSpecialist newPerson = new LockSpecialist(memberName, memberSkill, memberCut);
                            rolodex.Add(newPerson);
                        }
                    }
                }
                Console.WriteLine($"There are now {rolodex.Count} members");
            }
            Console.WriteLine("=== Full roster ===");
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"Name: {robber.Name}");
                Console.WriteLine($"Specialty: {robber.GetType().Name}");
                Console.WriteLine($"Skill Level: {robber.SkillLevel}");
                Console.WriteLine($"Percentage Cut: {robber.PercentageCut}");
                Console.WriteLine();
            }
        }
    }
}
