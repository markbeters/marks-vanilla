using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace MarksVanilla.Content.Items.BossSummons
{
    public class MLinfinite : ModItem
    {

        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 1; // only 1 needed to research in journey mode
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

        }


        public override void SetDefaults() { //set stats of item when used
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 1; // only 1 held at a time
			Item.value = 0; // no value when sold
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 60;
			Item.useTime = 60;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false; // should not consume, this is infinite summons
		}

        // more journey mode sorting
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) {
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossSpawners;
		}


        public override bool CanUseItem(Player player) {
			// this is also the check the server does when receiving MessageID.SpawnBoss.
			// Plantera only summonable in jungle biome and if one does not already exist
			return !NPC.AnyNPCs(NPCID.MoonLordHead) && !NPC.AnyNPCs(NPCID.MoonLordCore) && NPC.downedAncientCultist && Main.hardMode;
		}



        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				// If the player using the item is the client
				// (explicitly excluded serverside here)
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = NPCID.MoonLordCore;

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					// If the player is not in multiplayer, spawn directly
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else {
					// If the player is in multiplayer, request a spawn
					// This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
					NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
				}
			}

			return true;
		}


        public override void AddRecipes() { //use chaining method to add the recipe for this item
			CreateRecipe()
				.AddIngredient(ItemID.CelestialSigil, 10) //this should be replaced with a custom item that drops upon breaking bulbs
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
				.AddIngredient(ItemID.SoulofMight, 10)
                .AddIngredient(ItemID.SoulofFright, 10)
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddIngredient(ItemID.Ectoplasm, 10)
				.AddTile(TileID.DemonAltar)
                .AddCondition(Condition.InGraveyard)
				.Register();
		}

    }

}