using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace Marksvanilla.Common.ArmourChanges
{
    public class JungleChestplate : GlobalItem
    {
        public static readonly int critBonus = 3;

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.JungleShirt; // grab the int id for Jungle Chestplate
        } 

        public override void SetDefaults(Item item)
        {
            item.defense = 5; //nerf by 1 defense
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {

            if (tooltips[1].Text != "Equipped in social slot"){
                tooltips[4].Text = "3% increased magic critical strike chance";
            } //only try to change the tooltip if the armour is not in the vanity slot
        }
        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage<MagicDamageClass>() -= 0.06f; //remove the pre-existing +6% ,agic dmg boost
            player.GetCritChance<MagicDamageClass>() += critBonus; //add our 3% crit boost
        }
    }
}


