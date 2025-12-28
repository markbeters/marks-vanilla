using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MarksVanilla.Content.Items.Ammo
{
	public class EmeraldBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults() {
			Item.damage = 1; // The damage for projectiles isn't actually 0, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1f;
			Item.value = 10;
			Item.rare = ItemRarityID.White;
			Item.shoot = ModContent.ProjectileType<Projectiles.EmeraldBullet>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 12f; // The speed of the projectile. 
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
		}

		public override void AddRecipes() {
            CreateRecipe(50)
				.AddIngredient(ItemID.Emerald)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}