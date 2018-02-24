using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class TrueSapphireJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Infinite Sapphire Javelin");
            Tooltip.SetDefault("Has an insane high fire-rate");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 18f;
            item.damage = 20;
            item.knockBack = 0.5f;
            item.useStyle = 1;
            item.useAnimation = 4;
            item.useTime = 4;
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
            item.shoot = mod.ProjectileType("TrueSapphireJavelin");
            item.value = Item.sellPrice(0, 2, 0, 0);
        }
        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteJavelins)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("TrueSapphireJavelinWeapon"), 999);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}