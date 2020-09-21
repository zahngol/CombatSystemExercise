using System;

namespace CombatSystemExample
{
    // Manage all of the print strings needed for the game
    static class Print
    {
        private static readonly string[] fightNouns = { "bloodshed", "ruckus", "brouhaha", "tussle" };
        private static readonly string[] deathAdverbs = { "valiantly", "boldly", "heroically", "fearlessly" };
        private static readonly string[] combatAdjectives = { "gloriously", "bloody", "magnificent", "grisly" };

        public static void BeginFighting() => Console.WriteLine("Let the " + fightNouns[new Random().Next(fightNouns.Length)] + " begin!");
        public static void CharacterDealsDamage(Character character) => Console.WriteLine("! - " + character.Name + " " + character.Weapon.Verb + " " + character.Target.Name + " with his " + character.Weapon.Name + " for " + character.Weapon.Damage + " damage");
        public static void CharacterWins(Character character) => Console.WriteLine(character.Name + " is the new champion!");
        public static void CharacterDied(Character character) => Console.WriteLine("X - " + character.Name + " has died " + deathAdverbs[new Random().Next(deathAdverbs.Length)] + " in " + combatAdjectives[new Random().Next(combatAdjectives.Length)] + " combat.");
        public static void CharacterDiedVictorious() => Console.WriteLine("Alas, he'll never lay hands on The Grail.");
        public static void AnyKeyToExit() => Console.WriteLine("Press any key to exit...");
    }
}