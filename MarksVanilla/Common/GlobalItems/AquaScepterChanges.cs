using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace MarksVanilla.Common.GlobalItems
{

	// 
	public class AquaScepterChanges : GlobalItem
	{
		// Only instancing this for AquaScepter item
		public override bool AppliesToEntity(Item item, bool lateInstantiation) {
			return item.type == ItemID.AquaScepter; // grab the int id for Aqua Scepter
		}

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.setBonus == "Refunds 4 mana per attack")
            {

                player.statMana -= (int)(7 * player.manaCost * 0.5); //this takes the base mana cost of 7 and applies proper mana reduction to it 
                // this weapon shoots twice per click and gets refunded 8 mana, this is too OP so we need to remove mana again (baseCost * reduction * (1/# of times weapon shoots each click))
                // Other weapons like golden shower, amber staff and blood thorn do it but I doubt it's a big deal for those, maybe look into mana refund cooldowns instead of editing every item if it is a problem?

                // TODO: change so that it grabs default value instead of magic number (both above and below)
                player.manaRegenDelay = 90;
            }
            return true; //make sure to return true, we only want to override Shoot when our set bonus is the meteor armour's

        }
		
	}
}