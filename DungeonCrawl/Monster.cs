using System.Drawing;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;

namespace DungeonCrawl
{
    internal class Monster
    {
        public string name;
        public Vector2 position;
        public int hitpoints;
        public char symbol;
        public ConsoleColor color;


        public Monster(string name, int hitpoints, char symbol, ConsoleColor color, Vector2 position)
        {
            this.name = name;
            this.hitpoints = hitpoints;
            this.symbol = symbol;
            this.color = color;
            this.position = position;
        }
    }
}
