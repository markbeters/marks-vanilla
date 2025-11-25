using MarksVanilla.Content.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace MarksVanilla.Common.GlobalNPCs
{
    // Showcases how to work with all NPCs
    public class GlobalSpawns : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary< int, float > pool, NPCSpawnInfo spawnInfo)
        {
            
            if (spawnInfo.Player == null) return;

            int wormBGoneType = ModContent.BuffType<WormBGone>();
            bool has = spawnInfo.Player.HasBuff(wormBGoneType);

            Main.NewText($"[GlobalSpawns] Player.HasBuff(WormBGone) = {has}"); // visible in-game

            if (has)
            {
                spawnInfo.Lihzahrd = true;
                spawnInfo.PlayerSafe = true;
            }

            /*
            if (spawnInfo.Player != null && spawnInfo.Player.HasBuff(ModContent.BuffType<WormBGone>()))
            {
                spawnInfo.Lihzahrd = true; // test    
                spawnInfo.PlayerSafe = true; // PlayerSafe is the boolean used for spawning enemies that move through blocks, like worms and wraith
            } */
        }	
        		
    }
}