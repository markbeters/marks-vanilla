using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarksVanilla.Content.Items.Consumables
{
	public class WormBGone : ModItem
	{
		public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            
			ItemID.Sets.DrinkParticleColors[Type] = [
				new Color(59, 92, 13),
				new Color(59, 92, 13),
				new Color(59, 92, 13)
			]; 
		}

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.SplashWeak;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.buffType = ModContent.BuffType<Buffs.WormBGone>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 36000; // This will last 10 minutes, 36000 ticks / 60 tps = 600 seconds = 10 minutes
        }
        
         public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.BottledWater).
                AddIngredient(ItemID.Worm, 1).
                AddIngredient(ItemID.Daybloom, 1).
                AddIngredient(ItemID.MudBlock, 20).
                AddTile(TileID.AlchemyTable).
                AddTile(TileID.Bottles).
                Register().
                DisableDecraft();
        }
	}
}