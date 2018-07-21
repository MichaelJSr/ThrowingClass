using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Grenades
{
    public class ShroomNade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Grenade");
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
            item.maxStack = 999;
            item.rare = 3;
            item.ammo = ItemID.Grenade;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ShroomNade");
            item.value = Item.sellPrice(0, 0, 12, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 40);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddIngredient(ItemID.Mushroom, 1);
            recipe.AddIngredient(ItemID.VileMushroom, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 40);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddIngredient(ItemID.Mushroom, 1);
            recipe.AddIngredient(ItemID.ViciousMushroom, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}