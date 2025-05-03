using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarksVanilla.Common.GlobalItems
{

	// Declare the FlamarangChanges class and inherit from ModProjectile
	public class FlamarangChanges : GlobalProjectile
	{
		// Only instancing this for Flamarang projectile
		public override bool AppliesToEntity(Projectile projectile, bool lateInstantiation) {
			return projectile.type == ProjectileID.Flamarang; // grab the int id for flamarang projectile
		}

		public override void SetDefaults(Projectile projectile) {
			//projectile.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
			//projectile.aiStyle = ProjAIStyleID.Beam; // Change id to beam so it moves exactly where aimed
			projectile.penetrate = 2; // increase pierce to 2
			//projectile.timeLeft = 120; //2 seconds of travel 
		}


		public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) {
			
			
			if (projectile.penetrate == 2){ //use 2 penetration to know if it's first hit from this throw
				projectile.velocity = projectile.oldVelocity * 9 / 5; //if it hits the first target, continue in same direction with 1.8x speed
				//projectile.idStaticNPCHitCooldown = 30;
				projectile.penetrate = -1; //set to infinite pierce after we hit something
			}

		}
		
	}
}
