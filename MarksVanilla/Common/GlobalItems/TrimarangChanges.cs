using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarksVanilla.Common.GlobalItems
{

	// Declare the TrimarangChanges class and inherit from Moditem
	public class TrimarangChanges : GlobalItem
	{
		// Only instancing this for Trimarang item
		public override bool AppliesToEntity(Item item, bool lateInstantiation) {
			return item.type == ItemID.Trimarang; // grab the int id for Trimarang item
		}

		public override void SetDefaults(Item item) {
            item.damage = 24;
			
		}
		
	}
}