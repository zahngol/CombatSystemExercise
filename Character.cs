using System;
using System.Threading;
using System.Collections.Generic;

namespace CombatSystemExample
{
    class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public Weapon Weapon { get; private set; }

        // Is this character alive?
        public bool Alive { get; private set; }

        // The active target for this character
        public Character Target { get; private set; }
        
        // All remaining valid targets for this character
        private List<Character> availableTargets;

        // A thread to use for executing the attacks so that all characters may operate simultaneously
        private Thread attackThread;

        public Character(string name, int startingHealth, Weapon startingWeapon)
        {
            Name = name;
            Health = startingHealth;
            Weapon = startingWeapon;
            Alive = true;
        }

        public void BeginFight(List<Character> characters)
        {
            // Store all characters as available targets, but remove self from the list
            availableTargets = new List<Character>(characters);
            availableTargets.Remove(this);

            StartAttack();
        }

        // Recieve damage from an outside source
        public void TakeDamage(int amount)
        {
            Health -= amount;

            // Check to see if the attack has killed this character
            // and make sure it's the first time the character has been killed
            if (Health <= 0 && Alive)
            {
                Print.CharacterDied(this);
                Alive = false;
            }
        }

        private Character SelectTarget()
        {
            // If there are still more potential targets
            if (availableTargets.Count > 0)
            {
                // Get a new target
                Character target = availableTargets[new Random().Next(availableTargets.Count)];
                
                // Check to make sure someone else hasn't already killed that target in the meantime
                if (!target.Alive)
                {
                    // If the target has already been killed, remove it from the valid list and try again
                    availableTargets.Remove(target);
                    target = SelectTarget();
                }
                
                return target;
            }
            // If no valid targets remain, return null
            else 
            {
                return null;
            }    
            
        }

        // Select a target and, if a valid target is available, start the new attack thread
        private void StartAttack()
        {
            Target = SelectTarget();

            // If the target returns null, it means there are no more valid targets and this character has won
            if (Target == null)
            { 
                DeclareVictory();
            }
            else
            {
                attackThread = new Thread(()=>Attack());
                attackThread.Start();
            } 
        }

        private void Attack()
        {
            // Store the current time to compare and calculate elapsed time
            DateTime startTime = DateTime.Now;

            // Continue to fight until either this character or it's target are dead
            while (Alive && Target.Alive)
            {
                // Calculate the time since start/damage was last dealt
                double elapsedTime = DateTime.Now.Subtract(startTime).TotalSeconds;
                
                // If enough time has passed, deal damage
                if (elapsedTime >= Weapon.AttackSpeed)
                {
                    Print.CharacterDealsDamage(this);
                    Target.TakeDamage(Weapon.Damage);

                    // Reset the start time to create a new count-down for the next attack
                    startTime = DateTime.Now;
                }
            }

            // If the conflict ends, and this character is still alive, then his target must have died
            if (Alive)
            {
                TargetDied();
            }
        }

        private void TargetDied()
        {
            // Remove the current target from the valid list
            availableTargets.Remove(Target);

            StartAttack();
        }

        private void DeclareVictory()
        {
            Print.CharacterWins(this);

            // If this character was killed simultaneously in the final blow, mourn his passing
            if (!Alive)
                Print.CharacterDiedVictorious();

            // Wait for user input in the event that the application is being run from the executable instead of a console
            Print.AnyKeyToExit();
            Console.ReadKey();
        }
    }
}