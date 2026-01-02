using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MarksVanilla.Content.Items.Consumables
{
    public class ViewerHotline : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;

        }


        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useTurn = true;
            Item.UseSound = SoundID.Coins;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 0, 0, 0);
            Item.makeNPC = NPCID.TravellingMerchant; // this spawns the travelling merchant when used
        }


        public override bool CanUseItem(Player player) {

            return !NPC.AnyNPCs(NPCID.TravellingMerchant) && Main.dayTime; // if no other travelling merchant is there and it is between 4:30am - 7:30pm
            // important to not use IsItDay() because that breaks in remix/gfb worlds

        }



        public override void AddRecipes() { //use chaining method to add the recipe for this item
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 5)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.CopperBar, 5) 
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.TungstenBar, 5)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.CopperBar, 5)
                .AddTile(TileID.HeavyWorkBench)
                .Register();
                
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 5)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.TinBar, 5) 
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.TungstenBar, 5)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.TinBar, 5)
                .AddTile(TileID.HeavyWorkBench)
                .Register();
            
            // made 4 recipes to support copper/tin and silver/tungsten
            // in hindsight maybe easier to make groups for all the bars but oh well.
            
		}
        


    }
}