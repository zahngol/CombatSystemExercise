using System;
using System.Collections.Generic;

namespace CombatSystemExample
{
    // Manage the manually created sets of weapons and characters
    static class Generate
    {
        public static List<Weapon> Weapons()
        {
            List<Weapon> weapons = new List<Weapon>();

            weapons.Add(new Weapon("dagger", "stabs", 1f, 10));
            weapons.Add(new Weapon("sword", "slashes", 3f, 30));
            weapons.Add(new Weapon("axe", "hacks", 2f, 20));
            weapons.Add(new Weapon("spear", "pokes", 1.5f, 15));
            weapons.Add(new Weapon("flail", "mauls", 2.5f, 25));
            weapons.Add(new Weapon("club", "bludgeons", 0.5f, 5));
            weapons.Add(new Weapon("war hammer", "slams", 4f, 40));

            return weapons;
        }

        public static List<Character> Characters(List<Weapon> weapons)
        {
            Random r = new Random();
            List<Character> characters = new List<Character>();

            characters.Add(new Character("Lancelot", 100, weapons[r.Next(weapons.Count)]));
            characters.Add(new Character("Arthur", 100, weapons[r.Next(weapons.Count)]));
            characters.Add(new Character("Richard", 100, weapons[r.Next(weapons.Count)]));
            characters.Add(new Character("Galahad", 100, weapons[r.Next(weapons.Count)]));

            return characters;
        }
    }
}