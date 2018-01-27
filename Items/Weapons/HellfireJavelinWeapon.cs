using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class HellfireJavelinWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Javelin");
            Tooltip.SetDefault("Explodes upon contact.");
        }
        public override void SetDefaults()
        {
            // Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
            item.shootSpeed = 12f;
            item.damage = 50;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 5;
            item.ammo = AmmoID.Stake;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("HellfireJavelin");
            item.value = Item.sellPrice(0, 0, 20, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 1);
            recipe.AddIngredient(ItemID.Javelin, 70);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
}