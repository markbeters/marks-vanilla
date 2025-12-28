using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarksVanilla.Common.GlobalItems
{

	// Declare the BlueMoonChanges class and inherit from ModProjectile
	public class BlueMoonChanges : GlobalItem
	{
		// Only instancing this for BlueMoon weapon
		public override bool AppliesToEntity(Item item, bool lateInstantiation) {
			return item.type == ItemID.BlueMoon; // grab the int id for BlueMoon weapon
		}

		public override void SetDefaults(Item item) {
            item.damage = 31;
            item.crit = 11;
            item.shootSpeed = 30f;
            item.knockBack = 4f;
            
		}

		
	}
}
