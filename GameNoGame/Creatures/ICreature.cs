using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public interface ICreature 
    {
        Vector LeftTopLocation { get; set; }
        Size Size { get; }
        int Health { get; }

        //void Move(Vector movement);

        //bool CanMove(Vector location);

        bool IsAlive();
    }
}
