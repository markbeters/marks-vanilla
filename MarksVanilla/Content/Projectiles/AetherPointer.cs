using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using MarksVanilla.Content.Items.Misc;
using MarksVanilla.Content.Items.BossSummons;

namespace MarksVanilla.Content.Projectiles
{
    public class AetherPointer : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            ProjectileID.Sets.DontAttachHideToAlpha[Type] = true; // Necessary for non-held projectiles using Projectile.hide
        }

        public override void SetDefaults()
        {
            Projectile.width = 27;
            Projectile.height = 37;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ownerHitCheck = false;
            Projectile.hide = true;
            Projectile.timeLeft = 180; // projectile should last 3 seconds (180 ticks)

            // Draw the projectile higher and centered, then scale it because it is usually tiny
            DrawOriginOffsetY = -30;
            DrawOriginOffsetX = 10;
            Projectile.scale = 2f;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindProjectiles.Add(index); // This projectile draws behind other projectiles to not be in the way.
        }


        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Animation code could go here if the projectile was animated. 

            // Plays a sound every 88 ticks
            if (Projectile.soundDelay <= 0)
            {
                SoundEngine.PlaySound(SoundID.ShimmerWeak1, Projectile.Center);
                Projectile.soundDelay = 88;
            }


            // Replace older projectiles when a new one is spawned.
            if (Projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Projectile otherProjectile = Main.projectile[i];
                    if (i != Projectile.whoAmI && otherProjectile.active && otherProjectile.owner == Projectile.owner && otherProjectile.type == Projectile.type)
                    {
                        if (Projectile.timeLeft >= otherProjectile.timeLeft)
                        {
                            otherProjectile.Kill();
                        }
                        else
                        {
                            Projectile.Kill();
                        }
                    }
                }
            }


            //player.heldProj = Projectile.whoAmI; // We tell the player that the drill is the held projectile, so it will draw in their hand
            //player.SetDummyItemTime(2); // Make sure the player's item time does not change while the projectile is out
            Projectile.Center = Main.player[Projectile.owner].Center; // Centers the projectile on the player. Projectile.velocity will be added to this in later Terraria code causing the projectile to be held away from the player at a set distance.
            
            //Main.NewText(ShimmerLocation.GetLocation());
            //Main.NewText(player.position);
            Vector2 aetherPos = ShimmerLocation.GetLocation();

            float dX = aetherPos.X - player.position.X;
            float dY = aetherPos.Y - player.position.Y;
            double ResultRadians = Math.Atan2(dY, dX) + Math.PI/2;
            //double ResultDegrees = ResultRadians * (180 / Math.PI);


            //Main.NewText(ResultDegrees);
            Projectile.rotation = (float)ResultRadians;
            
            if (Main.rand.NextBool(player.itemAnimation > 0 ? 7 : 30)) {
				Dust dust = Dust.NewDustDirect(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), 4, 4, 309, 0f, 0f, 100); //309 for shimmer spark
				if (!Main.rand.NextBool(3)) {
					dust.noGravity = true;
				}

				dust.velocity *= 0.3f;
				dust.velocity.Y -= 1.5f;
				dust.position = player.RotatedRelativePoint(dust.position);
			}


            // Create a white (1.0, 1.0, 1.0) light at the torch's approximate position, when the item is held.
			Vector2 roughPos = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);

			Lighting.AddLight(roughPos, 1f, 1f, 1f);

        }
    }
}