using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace MarksVanilla.Content.NPCs
{

    /*
        genuinely don't know how to give existing angler a new button. Lets put re-roll on an item and see how it works out



    class AnglerBribe : ModNPC
    {
        

        
        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (npc.type == NPCID.Angler && !Main.hardMode)
            {
                button = "Quest";
                button2 = "Bribe (5 Gold)"; //need second button to give bribe option, 5 gold in pre-hardmode
            }
            else if (npc.type == NPCID.Angler && Main.hardMode)
            {
                button = "Quest";
                button2 = "Bribe (25 Gold)"; //need second button to give bribe option, 25 gold in hardmode
            }
            else
            {
                return;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (npc.type == NPCID.Angler && !Main.hardMode && !firstButton) //pre-hardmode bribe
            {
                Player player = Main.LocalPlayer;
                int bribeAmount = 50000; //5 gold in copper coins
                if (player.BuyItem(bribeAmount))
                {
                    Main.npcChatText = "Alright, only because you're paying...";
                    AnglerQuestReroll.reroll();
                }
                else
                {
                    Main.npcChatText = "You heard me, now scram!";
                }
            }
            else if (npc.type == NPCID.Angler && Main.hardMode && !firstButton) //hardmode bribe
            {
                Player player = Main.LocalPlayer;
                int bribeAmount = 250000; //25 gold in copper coins
                if (player.BuyItem(bribeAmount))
                {
                    Main.npcChatText = "Alright, only because you're paying...";
                    AnglerQuestReroll.reroll();
                }
                else
                {
                    Main.npcChatText = "You heard me, beat it!";
                }
            }
        }
        
    }*/

} 