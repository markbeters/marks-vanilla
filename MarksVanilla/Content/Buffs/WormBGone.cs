using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MarksVanilla.Content.Buffs
{
	public class WormBGone : ModBuff
    {
        
        public override void SetStaticDefaults() //these variables are set for most buffs set by potions
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
        }

		public override void Update(Player player, ref int buffIndex) {
            // No specific effect needed here since the spawn logic is handled in GlobalNPCs/GlobalSpawns.cs
		}
	}
}