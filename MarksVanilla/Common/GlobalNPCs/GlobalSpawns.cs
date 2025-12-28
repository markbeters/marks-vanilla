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
    public class GlobalSpawns : GlobalNPC
    {

        // here we are defining everything that counts as a ghost or worm that shouldn't be spawned in
        // careful deliberation to not remove difficulty from events (crawltipede, blood eel) or intended challenges like cursed skulls in dungeon
        public static readonly int[] worms = [
            NPCID.DevourerHead,
            NPCID.GiantWormHead,
            NPCID.Wraith,
            NPCID.CursedHammer,
            NPCID.EnchantedSword,
            NPCID.WyvernHead,
            NPCID.SeekerHead,
            NPCID.DiggerHead,
            NPCID.PigronCorruption,
            NPCID.PigronHallow,
            NPCID.PigronCrimson,
            NPCID.CrimsonAxe,
            NPCID.FloatyGross,
            NPCID.DuneSplicerHead,
            NPCID.TombCrawlerHead
        ];



        //Mostly Copilot generated, could not figure out best way to determine if player had WormBGone buff and handle singleplayer vs multiplayer spawning
        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            // Only do server-side spawn cancellation (spawn decisions are authoritative on server)
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            int wormBGoneType = ModContent.BuffType<WormBGone>();

            // Try to get the player from the spawn source if possible (optional)
            Player playerFromSource = null;
            if (source is EntitySource_Parent parent && parent.Entity is Player p)
                playerFromSource = p;

            // Fallback: find the closest player to the NPC spawn position
            Player player = playerFromSource ?? Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];

            if (player == null || !player.active)
            {
                base.OnSpawn(npc, source);
                return;
            }

            // Check the buff on the resolved player
            if (!player.HasBuff(wormBGoneType))
            {
                base.OnSpawn(npc, source);
                return;
            }

            // If player has the WormBGone buff, cancel worm/ghost spawns
            for (int i = 0; i < worms.Length; i++)
            {
                if (npc.type == worms[i])
                {
                    npc.active = false;
                    return; // cancelled, no need to call base
                }
            }

            base.OnSpawn(npc, source);
        }		
    }
}