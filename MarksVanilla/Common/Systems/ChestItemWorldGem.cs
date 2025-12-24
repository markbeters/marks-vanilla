using ExampleMod.Content.Items.Mounts;
using ExampleMod.Content.Pets.ExampleLightPet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExampleMod.Common.Systems
{
	// This class showcases adding additional items to vanilla chests. Taken from Example Mod and modified for desert chests.
	
	public class ChestItemWorldGen : ModSystem
	{
		// We use PostWorldGen for this because we want to ensure that all chests have been placed before adding items.
		public override void PostWorldGen() {
            // we want oysters to generate in sandstone chests, and somewhat generously
            int[] itemsToPlaceInSandstoneChests = [ItemID.Oyster];
            int itemsToPlaceInSandstoneChestsChoice = 0; //leave as 0 since we're only adding oysters for now
			int itemsPlaced = 0;
			int maxItems = 50;
			// Loop over all the chests
			for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				if (chest == null) {
					continue;
				}
                Tile chestTile = Main.tile[chest.x, chest.y];
				// We need to check if the current chest is the Sandstone Chest. We need to check that it exists and has the TileType and TileFrameX values corresponding to the Sandstone Chest.
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Sandstone Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                // An alternate approach is to check the wiki and looking for the "Internal Tile ID" section in the infobox: https://terraria.wiki.gg/wiki/Sandstone_Chest
				if (chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 10 * 36) {
					// We have found a Sandstone Chest
					// If we don't want to add one of the items to every Sandstone Chest, we can randomly skip this chest with a 20% chance.
					if (WorldGen.genRand.NextBool(5))
						continue;
					// Next we need to find the first empty slot for our item
					for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							// Place the item
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInSandstoneChests[itemsToPlaceInSandstoneChestsChoice]);

							itemsPlaced++;
							break;
						}
					}
				}
				// Once we've placed as many items as we wanted, break out of the loop
				if (itemsPlaced >= maxItems) {
					break;
				}
			}
		}
	}
}
