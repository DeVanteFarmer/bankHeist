// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // 1. Print the message "Plan Your Heist!"
        Console.WriteLine("Plan Your Heist!");

        // 2. Create a list to store multiple team members
        List<TeamMember> team = new List<TeamMember>();

        while (true)
        {
            // 3. Prompt the user to enter a team member's name and save that name.
            string? name = null;
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Enter team member's name (or press ENTER to finish): ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    if (name == "") break;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }
            }
            if (name == "") break; // Exit loop if the user presses ENTER without a name

            // 4. Prompt the user to enter a team member's skill level and save that skill level with the name.
            int skillLevel;
            Console.Write("Enter team member's skill level: ");
            while (!int.TryParse(Console.ReadLine(), out skillLevel) || skillLevel <= 0)
            {
                Console.Write("Please enter a valid positive integer for skill level: ");
            }

            // 5. Prompt the user to enter a team member's courage factor and save that courage factor with the name.
            decimal courageFactor;
            Console.Write("Enter team member's courage factor (0.0 - 2.0): ");
            while (!decimal.TryParse(Console.ReadLine(), out courageFactor) || courageFactor < 0.0m || courageFactor > 2.0m)
            {
                Console.Write("Please enter a valid decimal between 0.0 and 2.0 for courage factor: ");
            }

            // Create a team member object and add it to the list
            TeamMember member = new TeamMember(name, skillLevel, courageFactor);
            team.Add(member);
        }

        // 6. Display a message containing the number of members of the team.
        Console.WriteLine($"\nThere are {TeamMember.Count} members on your team");

        // 7. Display the team members' information.
        Console.WriteLine("\nTeam Members Information:");
        foreach (var member in team)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Skill Level: {member.SkillLevel}");
            Console.WriteLine($"Courage Factor: {member.CourageFactor}");
        }
    }
}

// Class to store team member's details
public class TeamMember
{
    public static int Count { get; private set; } = 0; // Static property to track count
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public decimal CourageFactor { get; set; }

    public TeamMember(string name, int skillLevel, decimal courageFactor)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace", nameof(name));
        }
        Name = name;
        SkillLevel = skillLevel;
        CourageFactor = courageFactor;
        Count++;
    }
}







