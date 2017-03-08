using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class GameState
    {
        public static States.State State { get; set; }
    }

    public class States
    {
        public enum State
        {
            Playing,
            Paused,
            GameOver
        }
    }
}
