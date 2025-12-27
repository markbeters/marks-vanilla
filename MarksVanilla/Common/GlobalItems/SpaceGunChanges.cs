using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace MarksVanilla.Common.GlobalItems
{

	// 
	public class SpaceGunChanges : GlobalItem
	{
		// Only instancing this for Space Gun item
		public override bool AppliesToEntity(Item item, bool lateInstantiation) {
			return item.type == ItemID.SpaceGun; // grab the int id for Space Gun
		}

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.setBonus == "Refunds 4 mana per attack")
            {
                

                player.statMana -= (int)(6 * player.manaCost); //this takes the base mana cost of 6 and applies proper mana reduction to it 
                // TODO: change so that it grabs default value instead of magic number (both above and below)
                player.manaRegenDelay = 90;

            }
            return true; //make sure to return true, we only want to override Shoot when our set bonus is the meteor armour's

        }
		
	}
}