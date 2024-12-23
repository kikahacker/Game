using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    public class Warrior : Character
{
    public Warrior(string name) : base(name, 150, 15,1) {}

    public override void SpecialAttack(Character target)
    {
        int specialDamage = Damage + 10; // Special attack adds bonus damage
        target.TakeDamage(specialDamage);
        Console.WriteLine($"{Name} uses special attack on {target.Name} for {specialDamage} damage.");
    }
}
}
 