using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class SplinterJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Splinter Javelin");
            Tooltip.SetDefault("How does this even work?...");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 12f;
            item.damage = 34;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 38;
            item.height = 36;
            item.maxStack = 1;
            item.rare = 5;
            item.ammo = ItemID.Javelin;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SplinterJavelin");
            item.value = Item.sellPrice(0, 0, 8, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return false;
        }

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteJavelins)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("SplinterJavelinWeapon"), 999);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}