using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class SapphireJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Sapphire Javelin");
            Tooltip.SetDefault("Has a high fire-rate.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 12f;
            item.damage = 10;
            item.knockBack = 0.5f;
            item.useStyle = 1;
            item.useAnimation = 8;
            item.useTime = 8;
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.rare = 1;
            item.ammo = ItemID.Javelin;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SapphireJavelin");
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteJavelins)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("SapphireJavelinWeapon"), 999);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}