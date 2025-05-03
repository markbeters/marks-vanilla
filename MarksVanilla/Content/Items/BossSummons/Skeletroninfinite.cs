using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace MarksVanilla.Content.Items.BossSummons
{
    public class Skeletroninfinite : ModItem
    {

        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 1; // only 1 needed to research in journey mode
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

			// This is set to true for all NPCs that can be summoned via an Item (calling NPC.SpawnOnPlayer). If this is for a modded boss,
			// write this in the bosses file instead
			NPCID.Sets.MPAllowedEnemies[NPCID.SkeletronHead] = true;
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
			// Deerclops only summonable in snow biome and if one does not already exist
			return !NPC.AnyNPCs(NPCID.SkeletronHead) && !Main.IsItDay();
		}



        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				// If the player using the item is the client
				// (explicitly excluded serverside here)
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = NPCID.SkeletronHead;

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
				.AddIngredient(ItemID.ClothierVoodooDoll, 1)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
				.AddTile(TileID.DemonAltar)
                .AddCondition(Condition.InGraveyard)
				.Register();
		}

    }

}