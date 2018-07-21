using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Grenades
{
    public class IchorGrenadeInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Ichor Grenade");
            Tooltip.SetDefault("Explodes upon contact");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 8f;
            item.damage = 75;
            item.knockBack = 6f;
            item.useStyle = 1;
            item.useAnimation = 32;
            item.useTime = 32;
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
            item.shoot = mod.ProjectileType("IchorGrenade");
            item.value = Item.sellPrice(0, 8, 0, 0);
        }

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteElse)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("IchorGrenade"), 999);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}