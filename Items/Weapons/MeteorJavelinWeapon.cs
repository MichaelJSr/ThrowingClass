using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class MeteorJavelinWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Javelin");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 14f;
            item.damage = 24;
            item.knockBack = 4f;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 2;
            item.ammo = AmmoID.Stake;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("MeteorJavelin");
            item.value = Item.sellPrice(0, 0, 8, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}