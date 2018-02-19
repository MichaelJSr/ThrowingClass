using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class HellfireJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Hellfire Javelin");
            Tooltip.SetDefault("Explodes upon contact.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 12f;
            item.damage = 28;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.rare = 4;
            item.ammo = AmmoID.Stake;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("HellfireJavelin");
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteJavelins)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("HellfireJavelinWeapon"), 999);
                recipe.AddTile(TileID.Hellforge);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}