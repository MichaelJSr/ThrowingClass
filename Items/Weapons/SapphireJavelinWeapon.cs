using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class SapphireJavelinWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphire Javelin");
            Tooltip.SetDefault("Has a high fire-rate.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 12f;
            item.damage = 10;
            item.knockBack = 0.5f;
            item.useStyle = 1;
            item.useAnimation = 5;
            item.useTime = 8;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 1;
            item.ammo = ItemID.Javelin;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SapphireJavelin");
            item.value = Item.sellPrice(0, 0, 10, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(ItemID.Javelin, 40);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}