using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarksVanilla.Content.Projectiles
{
	public class DiamondBullet : ModProjectile
	{

		// most of this item's code was taken from the 1.4 ExampleMod

		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Type] = 5; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Type] = 0; // The recording mode
		}

		public override void SetDefaults() {
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.aiStyle = ProjAIStyleID.Arrow; // The ai style of the projectile, please reference the source code of Terraria
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
			Projectile.penetrate = 2; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.timeLeft = 300; 
			Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			Projectile.light = 0.75f; // How much light emit around the projectile
			Projectile.ignoreWater = false; 
			Projectile.tileCollide = true;
            Projectile.extraUpdates = 0; 
            


			AIType = ProjectileID.Bullet; // Act exactly like default Bullet
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {

			Dust dust = Dust.NewDustDirect(Projectile.position + Projectile.velocity * Main.rand.Next(6, 10) * 0.15f, Projectile.width, Projectile.height, DustID.GemDiamond, 0f, 0f, 80, Color.White, 1f);
			dust.position.X -= 4f;
			dust.noGravity = false;
			dust.velocity.X *= 0.5f;
			dust.velocity.Y = -Main.rand.Next(3, 8) * 0.1f;

			Projectile.Kill();

			return false;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			// Draws an afterimage trail. See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#afterimage-trail for more information.

			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = Projectile.oldPos.Length - 1; k > 0; k--)
			{
				Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}

			return true;
		}


		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{

			Dust dust = Dust.NewDustDirect(Projectile.position + Projectile.velocity * Main.rand.Next(6, 10) * 0.15f, Projectile.width, Projectile.height, DustID.GemDiamond, 0f, 0f, 80, Color.White, 1f);
			dust.position.X -= 4f;
			dust.noGravity = false;
			dust.velocity.X *= 0.5f;
			dust.velocity.Y = -Main.rand.Next(3, 8) * 0.1f;

		}
		

		public override void OnKill(int timeLeft) {
			
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}