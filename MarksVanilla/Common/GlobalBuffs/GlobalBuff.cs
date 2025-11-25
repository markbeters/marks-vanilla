using MarksVanilla.Content.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MarksVanilla.Common.GlobalBuffs
{
	// Showcases how to work with all buffs
	public class GlobalBuffs : GlobalBuff
	{
		public static LocalizedText RemainingTimeText { get; private set; }
		public static LocalizedText CannotCancelText { get; private set; }

		public override void SetStaticDefaults() {
			RemainingTimeText = Mod.GetLocalization($"{nameof(GlobalBuffs)}.RemainingTime");
			CannotCancelText = Mod.GetLocalization($"{nameof(GlobalBuffs)}.CannotCancel");
		}

		public override void Update(int type, Player player, ref int buffIndex) {
			
		}		

	}
}