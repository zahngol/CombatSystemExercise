namespace CombatSystemExample
{
    class Weapon
    {
        public string Name { get; private set; }
        public string Verb { get; private set; }
        public float AttackSpeed { get; private set; }
        public int Damage { get; private set; }

        public Weapon(string name, string verb, float attackSpeed, int damage)
        {
            Name = name;
            Verb = verb;
            AttackSpeed = attackSpeed;
            Damage = damage;
        }
    }
}