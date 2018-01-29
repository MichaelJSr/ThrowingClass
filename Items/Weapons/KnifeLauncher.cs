using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class KnifeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knife Launcher");
            Tooltip.SetDefault("Uses mechanization to fire knives at a much stronger velocity.");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 4;
            item.noMelee = true;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.knockBack = 0.5f;
            item.value = Item.buyPrice(0, 20, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.ThrowingKnife;
            item.shoot = 10;
            item.shootSpeed = 4f; //How fast the projectile fires
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == 599)
            {
                item.damage = 20;
                item.useTime = 13;
                item.useAnimation = 13;
            }
            if (type == 520)
            {
                item.damage = 20;
                item.useTime = 12;
                item.useAnimation = 12;
            }
            if (type == 497)
            {
                item.damage = 20;
                item.useTime = 11;
                item.useAnimation = 11;
            }
            else
            {
                item.damage = 20;
                item.useTime = 14;
                item.useAnimation = 14;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.LeadBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}