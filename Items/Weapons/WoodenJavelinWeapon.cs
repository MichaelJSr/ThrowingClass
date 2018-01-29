using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class WoodenJavelinWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Javelin");
            Tooltip.SetDefault("Pointy.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 10f;
            item.damage = 14;
            item.knockBack = 4f;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 0;
            item.ammo = AmmoID.Stake;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("WoodenJavelin");
            item.value = Item.sellPrice(0, 0, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
}