using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace Marksvanilla.Common.ArmourChanges
{
    public class JungleHat : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.JungleHat; // grab the int id for Jungle Hat
        } 

        public override void SetDefaults(Item item)
        {
            item.defense = 4; //nerf by 1 defense
        }

    }
}


