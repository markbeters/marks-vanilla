using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;

namespace MarksVanilla.Content.NPCs
{
    public class AnglerQuestReroll
    {
        public static void reroll()
        {

            Main.anglerQuestFinished = false; // Reset the quest completion status
            Main.anglerWhoFinishedToday.Clear(); // remove all players from finished list
            Main.AnglerQuestSwap(); //swap quest
            
            
            //Random rnd = new Random(); //pick a new quest, this assumes the array isn't filled with unobtainable fish though
            // EDIT: THIS CONTAINS UNOBTAINABLE FISH. USE AnglerQuestSwap() INSTEAD.

            //Main.anglerQuest = rnd.Next(0, Main.anglerQuestItemNetIDs.Length - 1);

        }
    }
}