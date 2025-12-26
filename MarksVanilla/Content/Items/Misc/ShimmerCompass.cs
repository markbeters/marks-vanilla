using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using MarksVanilla.Content.Projectiles;



namespace MarksVanilla.Content.Items.Misc
{
    public class ShimmerCompass : ModItem
    {

        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 1; // only 1 needed to research in journey mode
        }


        public override void SetDefaults() { //set stats of item when used
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 1; // only 1 held at a time
			Item.value = 10000; // 1 gold when sold
			Item.rare = ItemRarityID.Green;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false; 
            

            Item.shoot = ModContent.ProjectileType<AetherPointer>(); // spawn the crystal
			
			Item.noMelee = true; // Turns off damage from the item itself, as we have a projectile
			
			Item.channel = true; // Important as the projectile checks if the player channels


		}


        public override bool CanUseItem(Player player) {
            return true; //no conditions to use, make sure True is returned
		}



        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				// If the player using the item is the client
				// (explicitly excluded serverside here)
                // only need to play sound for client, this is the mana crystal sound
				SoundEngine.PlaySound(SoundID.Item29, player.position);
                
			}

			return true;
		}




        

        public override void AddRecipes()
        { //use chaining method to add the recipe for this item
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 5)
                .AddIngredient(ItemID.Topaz, 1)
                .AddIngredient(ItemID.Amethyst, 1)
                .AddIngredient(ItemID.Sapphire, 1)
                .AddIngredient(ItemID.Emerald, 1)
                .AddIngredient(ItemID.Ruby, 1)
                .AddIngredient(ItemID.Diamond, 1)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 5)
                .AddIngredient(ItemID.Topaz, 1)
                .AddIngredient(ItemID.Amethyst, 1)
                .AddIngredient(ItemID.Sapphire, 1)
                .AddIngredient(ItemID.Emerald, 1)
                .AddIngredient(ItemID.Ruby, 1)
                .AddIngredient(ItemID.Diamond, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }

}