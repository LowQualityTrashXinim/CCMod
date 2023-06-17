﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CCMod.Utils;
using CCMod.Common;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using CCMod.Common.Attributes;

namespace CCMod.Content.Items.Weapons.Magic

{
	[CodedBy("Pexiltd")]
	[SpritedBy("Pexiltd")]
	[ConceptBy("Pexiltd")]
	public class Gattlinator : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gatlitnaor");
			// Tooltip.SetDefault("[c/6dc7d1:A mash of broken parts]");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 6; i++)
			{
				Vector2 vec = velocity.NextVector2RotatedByRandom(17f, 20, i);
				Projectile.NewProjectile(source, position, vec, type, damage, knockback, player.whoAmI);
			}
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ZapinatorOrange, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 3);
			recipe.AddIngredient(ItemID.Shotgun, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		public override void SetDefaults()
		{
			Terraria.Audio.SoundStyle item36 = SoundID.Item36;
			Item.UseSound = item36;
			Item.SetDefaultMagic(9, 9, 40, 6, 60, 60, ItemUseStyleID.Shoot, ProjectileID.ZapinatorLaser, 10, 6, true);
		}
	}
}