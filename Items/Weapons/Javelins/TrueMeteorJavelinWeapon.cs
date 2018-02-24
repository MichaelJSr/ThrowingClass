using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class TrueMeteorJavelinWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Meteor Javelin");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 20f;
            item.damage = 48;
            item.knockBack = 4f;
            item.useStyle = 1;
            item.useAnimation = 14;
            item.useTime = 14;
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.rare = 5;
            item.ammo = ItemID.Javelin;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("TrueMeteorJavelin");
            item.value = Item.sellPrice(0, 0, 16, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("MeteorJavelinWeapon"), 40);
            recipe.AddIngredient(ItemID.SoulofFright, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 40);
            recipe.AddRecipe();
        }
    }
}