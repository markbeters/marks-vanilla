using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;



namespace MarksVanilla.Content.Items.Misc
{
    public class ShimmerLocation : GlobalItem
    {

        public static Vector2 GetLocation()
        {
            Vector2 pos = new Vector2(0, 0);
            
            for (int x = Main.maxTilesX - 32; x > 17; x -= 32) //these are actual tile counts, we are searching downwards for a shimmer tile every 8 blocks and then across every 32 blocks if none have been found. Starts at top right of world
            {
                for (int y = 300; y < Main.maxTilesY; y += 8) // starting number can be higher, we know the shimmer is not in the sky or on surface
                {
                    if (Main.tile[x, y].LiquidAmount == 255 && Main.tile[x, y].LiquidType == 3) // looking for tile of shimmer that is full (each tile ranges from 0 to 255 for fullness)
                    {
                        pos = new Vector2((x) * 16, (y - 2) * 16); //this is the location (not tile # of where the shimmer is)
                        break;
                    }

                }

                if (pos != new Vector2(0,0)){ break; } //end searching early if it has been found
                
            }
            return pos;
        }
    }
}