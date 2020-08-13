using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace korkuoyunu
{
    class Mace:Weapon
    {
        public Mace(Game game, Point location)
               : base(game, location) { }
        public override string Name { get { return "Mace"; } }
        public override void Attack(Direction direction, Random random)
        {
           if (direction == Direction.Up)
           {
                DamageEnemy(Direction.Up, 20, 6, random);
                DamageEnemy(Direction.Right, 20, 6, random);
                DamageEnemy(Direction.Down, 20, 6, random);
                DamageEnemy(Direction.Left, 20, 6, random);
           }
           if (direction == Direction.Down)
           {
                DamageEnemy(Direction.Down, 20, 6, random);
                DamageEnemy(Direction.Left, 20, 6, random);
                DamageEnemy(Direction.Up, 20, 6, random);
                DamageEnemy(Direction.Right, 20, 6, random);
           }
           if (direction == Direction.Left)
           {
                DamageEnemy(Direction.Left, 20, 6, random);
                DamageEnemy(Direction.Up, 20, 6, random);
                DamageEnemy(Direction.Right, 20, 6, random);
                DamageEnemy(Direction.Down, 20, 6, random);
           }
          
           if (direction == Direction.Right)
           {
                DamageEnemy(Direction.Right, 20, 6, random);
                DamageEnemy(Direction.Down, 20, 6, random);
                DamageEnemy(Direction.Left, 20, 6, random);
                DamageEnemy(Direction.Up, 20, 6, random);
           }

        }
    }
}
