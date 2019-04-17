using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class JesterJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Jester Javelin");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 14f;
            item.damage = 20;
            item.knockBack = 2f;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.rare = 2;
            item.ammo = ItemID.Javelin;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("JesterJavelin");
            item.value = Item.sellPrice(0, 0, 12, 0);
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
                recipe.AddIngredient(mod.GetItem("JesterJavelinWeapon"), 999);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}