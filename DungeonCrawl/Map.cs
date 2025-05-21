namespace DungeonCrawl
{
    internal class Map
	{
		public enum Tile : sbyte
		{
			Floor,
			Wall,
			Door,
			Monster,
			Item,
			Player,
			Stairs
		}
		public int width;
		public int height;
		public Tile[] Tiles;

        internal static Map CreateMap(Random random)
        {
            Map level = new Map();

            level.width = Console.WindowWidth - Program.COMMANDS_WIDTH;
            level.height = Console.WindowHeight - Program.INFO_HEIGHT;
            level.Tiles = new Map.Tile[level.width * level.height];

            // Create perimeter wall
            for (int y = 0; y < level.height; y++)
            {
                for (int x = 0; x < level.width; x++)
                {
                    int ti = y * level.width + x;
                    if (y == 0 || x == 0 || y == level.height - 1 || x == level.width - 1)
                    {
                        level.Tiles[ti] = Map.Tile.Wall;
                    }
                    else
                    {
                        level.Tiles[ti] = Map.Tile.Floor;
                    }
                }
            }

            int roomRows = 3;
            int roomsPerRow = 6;
            int boxWidth = (Console.WindowWidth - Program.COMMANDS_WIDTH - 2) / roomsPerRow;
            int boxHeight = (Console.WindowHeight - Program.INFO_HEIGHT - 2) / roomRows;
            for (int roomRow = 0; roomRow < roomRows; roomRow++)
            {
                for (int roomColumn = 0; roomColumn < roomsPerRow; roomColumn++)
                {
                    Program.AddRoom(level, roomColumn * boxWidth + 1, roomRow * boxHeight + 1, boxWidth, boxHeight, random);
                }
            }

            // Add enemies and items
            for (int y = 0; y < level.height; y++)
            {
                for (int x = 0; x < level.width; x++)
                {
                    int ti = y * level.width + x;
                    if (level.Tiles[ti] == Map.Tile.Floor)
                    {
                        int chance = random.Next(100);
                        if (chance < Program.ENEMY_CHANCE)
                        {
                            level.Tiles[ti] = Map.Tile.Monster;
                            continue;
                        }

                        chance = random.Next(100);
                        if (chance < Program.ITEM_CHANCE)
                        {
                            level.Tiles[ti] = Map.Tile.Item;
                        }
                    }
                }
            }

            // Find starting place for player
            for (int i = 0; i < level.Tiles.Length; i++)
            {
                if (level.Tiles[i] == Map.Tile.Floor)
                {
                    level.Tiles[i] = Map.Tile.Player;
                    break;
                }
            }

            return level;
        }
    }
}
