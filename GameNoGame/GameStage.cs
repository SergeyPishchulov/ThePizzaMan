using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame
{
    public enum GameStage
    {
        NotStarted = 0,
        Setup = 1,
        MapChoosing = 2,
        LevelFirst = 3,
        LevelSecond = 4,
        LevelThird = 5,
        LevelFourth = 6,
        Finished = 7
    }
}
