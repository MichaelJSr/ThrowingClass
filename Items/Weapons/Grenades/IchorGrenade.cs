using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Grenades
{
    public class IchorGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Grenade");
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
            item.maxStack = 999;
            item.rare = 3;
            item.ammo = ItemID.Grenade;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("IchorGrenade");
            item.value = Item.sellPrice(0, 0, 9, 15);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 40);
            recipe.AddIngredient(ItemID.Ichor, 1);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}