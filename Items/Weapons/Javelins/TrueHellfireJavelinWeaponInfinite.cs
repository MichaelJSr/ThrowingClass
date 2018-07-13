using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class TrueHellfireJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Infinite Hellfire Javelin");
            Tooltip.SetDefault("Explodes upon contact");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 18f;
            item.damage = 50;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 14;
            item.useTime = 14;
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.rare = 5;
            item.ammo = ItemID.Javelin;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("TrueHellfireJavelin");
            item.value = Item.sellPrice(0, 2, 0, 0);
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
                recipe.AddIngredient(mod.GetItem("TrueHellfireJavelinWeapon"), 999);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}