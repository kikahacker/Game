using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Archer : Character
    {
        public Archer(string name) : base(name, 100, 10) { }

        public override void Attack(Character target)
        {
            // Buff: If the archer is on an even index (for example), increase damage
            if (Array.IndexOf(Game.CurrentField.Characters.ToArray(), this) % 2 == 0)
            {
                Damage += 5; // Buff damage
                Console.WriteLine($"{Name} is buffed! Damage increased to {Damage}.");
            }
            base.Attack(target);
        }

        public override void SpecialAttack(Character target)
        {
            int specialDamage = Damage * 2; // Special attack deals double damage
            target.TakeDamage(specialDamage);
            Console.WriteLine($"{Name} uses special attack on {target.Name} for {specialDamage} damage.");
        }
    }
}
