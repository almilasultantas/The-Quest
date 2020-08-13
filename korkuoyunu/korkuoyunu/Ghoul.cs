using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace korkuoyunu
{
    class Ghoul:Enemy
    {
        public Ghoul(Game game, Point location)
           : base(game, location, 10) { }
        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                int a = random.Next(0, 2);
                if (a == 0||a==1)
                    location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);

                if (NearPlayer())
                    game.HitPlayer(4, random);
            }
        }
    }
}
