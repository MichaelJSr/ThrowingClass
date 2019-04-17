using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class SplinterJavelinWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splinter Javelin");
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
            item.maxStack = 999;
            item.rare = 5;
            item.ammo = ItemID.Javelin;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SplinterJavelin");
            item.value = Item.sellPrice(0, 0, 0, 8);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("MakeshiftJavelinWeapon"), 120);
            recipe.AddIngredient(mod.GetItem("WickedTooth"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
    }
}