using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Grenades
{
    public class ShroomNadeInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Shroom Grenade");
            Tooltip.SetDefault("Releases mushrooms upon explosion");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 9f;
            item.damage = 64;
            item.knockBack = 7f;
            item.useStyle = 1;
            item.useAnimation = 34;
            item.useTime = 34;
            item.width = 14;
            item.height = 20;
            item.maxStack = 1;
            item.rare = 3;
            item.ammo = ItemID.Grenade;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ShroomNade");
            item.value = Item.sellPrice(0, 9, 0, 0);
        }

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteElse)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("ShroomNade"), 999);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}