using MarksVanilla.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.ModLoader;
using Terraria.ID;
using System;


namespace MarksVanilla.Common.Players
{
    public class MeteorArmourChanges : GlobalItem
    {

        public static readonly int ManaRefund = 4;
      

        public override string IsArmorSet(Item head, Item body, Item legs) {
            if (head.type == ItemID.MeteorHelmet && body.type == ItemID.MeteorSuit && legs.type == ItemID.MeteorLeggings)
            {
                return "meteor"; //this 
            }
            return "";
		}

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player, string set)
        {
            player.setBonus = "Refunds 4 mana per attack";
            // other functionalities that change the player's stats directly/passively should be added here.

        }


        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.setBonus == "Refunds 4 mana per attack")
            {
                player.statMana += ManaRefund; //give 4 mana for a shot
                if (player.statMana > player.statManaMax) //if we exceed max, cap it at the max
                {
                    player.statMana = player.statManaMax;
                }

            }
            return true; //make sure to return true, we only want to override Shoot when our set bonus is the meteor armour's

        }
    }
}