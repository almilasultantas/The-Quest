using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace korkuoyunu
{
    class BluePotion:Weapon,IPotion
    {
        public BluePotion(Game game,Point location)
            : base(game, location) { }
        public override string Name { get { return "Blue Potion"; } }
        public bool Used { get; set; }
        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
            Used = true;
        }
    }
}
