using System.Numerics;

namespace DungeonCrawl
{
    internal class Item
	{
		public string name;
		public int quality; // means different things depending on the type
		public Vector2 position;
		public ItemType type;

		public Item(string name, ItemType type, int quality, Vector2 position)
		{
            this.name = name;
            this.type = type;
            this.quality = quality;
            this.position = position;
        }
        
	}
}
