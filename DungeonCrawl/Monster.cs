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

        static Monster CreateMonster(string name, int hitpoints, char symbol, ConsoleColor color, Vector2 position)
        {

            return new Monster(name, hitpoints, symbol, color, position);
        }

        internal static Monster CreateRandomMonster(Random random, Vector2 position)
        {
            int type = random.Next(4);
            return type switch
            {
                0 => CreateMonster("Goblin", 5, 'g', ConsoleColor.Green, position),
                1 => CreateMonster("Bat Man", 2, 'M', ConsoleColor.Magenta, position),
                2 => CreateMonster("Orc", 15, 'o', ConsoleColor.Red, position),
                3 => CreateMonster("Bunny", 1, 'B', ConsoleColor.Yellow, position)
            };
        }
    }
}
