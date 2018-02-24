using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class TrueDiamondJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Infinite Diamond Javelin");
            Tooltip.SetDefault("Reduces enemies defense dramatically");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 24f;
            item.damage = 64;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 14;
            item.useTime = 14;
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
            item.shoot = mod.ProjectileType("TrueDiamondJavelin");
            item.value = Item.sellPrice(0, 2, 80, 0);
        }
        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteJavelins)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("TrueDiamondJavelinWeapon"), 999);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}