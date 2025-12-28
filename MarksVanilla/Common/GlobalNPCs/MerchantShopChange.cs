using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using MarksVanilla.Content.Items.Consumables;

namespace MarksVanilla.Common.GlobalNPCs
{
    public class MerchantShopChanges : GlobalNPC
    {

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type == NPCID.Merchant)
            {
                if (Main.anglerQuestFinished)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i] is null)
                        {
                            items[i] = new Item(ModContent.ItemType<AnglerReset>()); //only add this item to the shop when angler quest is done
                            break;
                        }
                    }
                }
            }
        }
        /*
        public override void ModifyShop(NPCShop shop)
        {
            // Check the NPC Type on the shop, then add the item.
            if (shop.NpcType == NPCID.Merchant)
            {
                shop.Add(ModContent.ItemType<AnglerReset>());
            }
        }*/

    }
}