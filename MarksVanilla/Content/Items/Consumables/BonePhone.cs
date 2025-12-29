using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MarksVanilla.Content.Items.Consumables
{
    public class BonePhone : ModItem
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
            Item.UseSound = SoundID.Dig;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 0, 0, 0);
            Item.makeNPC = NPCID.SkeletonMerchant; // this spawns the skeleton merchant when used
        }


        public override bool CanUseItem(Player player) {

            return !NPC.AnyNPCs(NPCID.SkeletonMerchant) && Main.LocalPlayer.ZoneRockLayerHeight;

        }



        public override void AddRecipes() { //use chaining method to add the recipe for this item
            CreateRecipe()
                .AddIngredient(ItemID.Bone, 25)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.CopperBar, 5) //one recipe for copper
                .AddTile(TileID.HeavyWorkBench)
                .AddCondition(Condition.InGraveyard)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Bone, 25)
                .AddIngredient(ItemID.Wire, 10)
                .AddIngredient(ItemID.TinBar, 5) //one for tin
                .AddTile(TileID.HeavyWorkBench)
                .AddCondition(Condition.InGraveyard)
                .Register();
                
            
		}
        


    }
}