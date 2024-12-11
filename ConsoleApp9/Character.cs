using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public virtual void Attack(Character target)
        {
            target.TakeDamage(Damage);
            Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage.");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
            if (Health <= 0)
                Console.WriteLine($"{Name} has been defeated!");
        }
        public abstract void SpecialAttack(Character target);
    }
}
