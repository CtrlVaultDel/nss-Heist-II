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

            // Create a new bank object
            Bank bank = new Bank();

            // Print out details about the bank
            // Determines the most and least secure areas
            Console.WriteLine();
            if (bank.AlarmScore >= bank.SecurityGuardScore && bank.AlarmScore >= bank.VaultScore)
            {
                Console.WriteLine("Most Secure: Alarm");
                if (bank.VaultScore >= bank.SecurityGuardScore)
                {
                    Console.WriteLine("Least Secure: Security");
                }
                else
                {
                    Console.WriteLine("Least Secure: Vault");
                }
            }
            else if (bank.SecurityGuardScore >= bank.AlarmScore && bank.SecurityGuardScore >= bank.VaultScore)
            {
                Console.WriteLine("Most Secure: Security");
                if (bank.AlarmScore >= bank.VaultScore)
                {
                    Console.WriteLine("Least Secure: Vault");
                }
                else
                {
                    Console.WriteLine("Least Secure: Alarm");
                }
            }
            else
            {
                Console.WriteLine("Most Secure: Vault");
                if (bank.SecurityGuardScore >= bank.AlarmScore)
                {
                    Console.WriteLine("Least Secure: Alarm");
                }
                else
                {
                    Console.WriteLine("Least Secure: Security");
                }
            }

            // Prepare a list for the crew that will be used for the heist
            Console.WriteLine();
            List<IRobber> crew = new List<IRobber>();

            bool crewReady = false;
            int percentageRemaining = 100;
            int totalHacking = 0;
            int totalLockpicking = 0;
            int totalMuscle = 0;

            while (!crewReady)
            {
                // Print out the entire roster of potential crewmembers
                Console.WriteLine($"=== Full roster ({rolodex.Count}) ===");
                int indexer = 0;
                foreach (IRobber robber in rolodex)
                {
                    Console.WriteLine($"Option: {indexer}");
                    Console.WriteLine($"Name: {robber.Name}");
                    Console.WriteLine($"Specialty: {robber.Specialty}");
                    Console.WriteLine($"Skill Level: {robber.SkillLevel}");
                    Console.WriteLine($"Percentage Cut: {robber.PercentageCut}");
                    Console.WriteLine();
                    indexer++;
                }

                Console.WriteLine("Current Stats of Crew");
                Console.WriteLine($"Percentage of cut remaining: {percentageRemaining}");
                Console.WriteLine($"Total Hacking: {totalHacking}");
                Console.WriteLine($"Total Lockpicking: {totalLockpicking}");
                Console.WriteLine($"Total Muscle: {totalMuscle}");
                Console.WriteLine();

                bool isMember = false;
                int memberChoice = 0;

                while (!isMember)
                {
                    Console.WriteLine("Please add a new crewmember by entering their related number or enter nothing to continue.");
                    string initialResponse = Console.ReadLine();

                    // Check if the user entered a blank response. Break out if so
                    if (initialResponse == "")
                    {
                        crewReady = true;
                        break;
                    }

                    isMember = Int32.TryParse(initialResponse, out memberChoice);
                    if (isMember && memberChoice <= rolodex.Count - 1 && memberChoice >= 0)
                    {
                        if (percentageRemaining - rolodex[memberChoice].PercentageCut >= 0)
                        {
                            // Add the member to the crew
                            crew.Add(rolodex[memberChoice]);

                            // Remove their cut of the pay from the remaining percentage
                            percentageRemaining -= rolodex[memberChoice].PercentageCut;

                            // Add the crewmember's skill to the appropriate specialty
                            if (rolodex[memberChoice].Specialty == "Hacker")
                            {
                                totalHacking += rolodex[memberChoice].SkillLevel;
                            }
                            else if (rolodex[memberChoice].Specialty == "LockSpecialist")
                            {
                                totalLockpicking += rolodex[memberChoice].SkillLevel;
                            }
                            else
                            {
                                totalMuscle += rolodex[memberChoice].SkillLevel;
                            }

                            // Remove the chosen member from the original rolodex list
                            rolodex.RemoveAt(memberChoice);
                        }
                        else
                        {
                            // If there is not enough pay to give to the member, remove them from the original list
                            Console.WriteLine($"There is not enough of a cut for {rolodex[memberChoice].Name} to take.");
                            rolodex.RemoveAt(memberChoice);
                        }
                    }
                    else
                    {
                        isMember = false;
                    }
                }
            }

            // Update the bank's security scores based off the current crew abilities
            foreach (IRobber robber in crew)
            {
                robber.PerformSkill(bank);
                Console.WriteLine();
            }

            if (bank.IsSecure)
            {
                Console.WriteLine("The heist was a success!");
                Console.WriteLine($"Total money earned: ${String.Format("{0:n}", bank.CashOnHand * 1.0f)}");
                foreach (IRobber robber in crew)
                {
                    Console.WriteLine($"{robber.Name} took home ${String.Format("{0:n}", (robber.PercentageCut * 1.0f / 100) * bank.CashOnHand)}");
                }
                Console.WriteLine($"You took home ${String.Format("{0:n}", (percentageRemaining * 1.0f / 100) * bank.CashOnHand)}");
            }
            else
            {
                Console.WriteLine("The heist failed!");
            }
        }
    }
}
