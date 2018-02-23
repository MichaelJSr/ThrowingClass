using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class WaspnadeInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Waspnade");
            Tooltip.SetDefault("Explodes upon contact");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 8f;
            item.damage = 32;
            item.knockBack = 1f;
            item.useStyle = 1;
            item.useAnimation = 24;
            item.useTime = 24;
            item.width = 14;
            item.height = 22;
            item.maxStack = 1;
            item.rare = 7;
            item.ammo = ItemID.Grenade;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("Waspnade");
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteElse)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("Waspnade"), 999);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}