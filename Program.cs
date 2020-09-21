using System.Collections.Generic;

namespace CombatSystemExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create all of the characters with randomly assigned weapons
            List<Character> characters = Generate.Characters(Generate.Weapons());

            Print.BeginFighting();

            // Tell each character to begin fighting, using the list of all characters as possible targets
            foreach (Character character in characters)
            {
                character.BeginFight(characters);
            }
        }
    }
}
