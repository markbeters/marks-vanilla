using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MarksVanilla.Content.NPCs;

namespace MarksVanilla.Content.Items.Consumables


/*
 THIS IS NOT A PERMANENT ITEM. SHOULD DELETE WHEN DONE

*/


{
	public class AnglerReset : ModItem
	{
		public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 20;

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
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                

                AnglerQuestReroll.reroll(); // Call the reroll method to reset the Angler quest
            }

            return true;
        }
        

	}
}