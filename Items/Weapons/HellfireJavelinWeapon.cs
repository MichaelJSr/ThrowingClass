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
            item.shootSpeed = 12f;
            item.damage = 28;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 4;
            item.ammo = ItemID.Javelin;

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
            recipe.AddIngredient(ItemID.Javelin, 40);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}