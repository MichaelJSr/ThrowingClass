using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Launchers
{
    public class CryoGrenadeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Grenade Launcher");
            Tooltip.SetDefault("Uses mechanization to fire grenades at a much stronger velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.crit = 25;
            item.noMelee = true;
            item.ranged = true;
            item.width = 56;
            item.height = 22;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = 5;
            item.knockBack = 0.01f;
            item.value = Item.sellPrice(0, 16, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.Grenade;
            item.shoot = 10;
            item.shootSpeed = 16f; //How fast the projectile fires
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            if (!(item.knockBack == 0.01f || item.knockBack == 0.05f || item.knockBack == 0.1f || item.knockBack == 0.2f || item.knockBack == 0.25f || item.knockBack == 0.5f || item.knockBack == 0.75f || item.knockBack == 1f))
            {
                item.knockBack = 0.01f;
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            bool Happy = false;
            bool Beenade = false;
            bool Molotov = false;
            bool Else = false;
            if (type == ProjectileID.HappyBomb)
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 20;
                    item.useAnimation -= 20;
                    item.knockBack = 0.1f;
                }
                if (item.knockBack == 0.1f)
                {
                    Happy = true;
                }
            }

            else if (type == ProjectileID.Beenade || type == mod.ProjectileType("Waspnade"))
            {
                if (item.knockBack == 0.01f)
                {
                    item.damage -= 30;
                    item.useTime -= 12;
                    item.useAnimation -= 12;
                    item.knockBack = 0.25f;
                }
                if (item.knockBack == 0.25f)
                {
                    Beenade = true;
                }
            }

            else if (type == ProjectileID.BouncyGrenade || type == ProjectileID.MolotovCocktail)
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 5;
                    item.useAnimation -= 5;
                    item.knockBack = 0.5f;
                }
                if (item.knockBack == 0.5f)
                {
                    Molotov = true;
                }
            }

            else
            {
                if (item.knockBack == 0.01f)
                {
                    item.knockBack = 1f;
                }
                if (item.knockBack == 1f)
                {
                    Else = true;
                }
            }

            if (item.knockBack == 0.1f && Happy == false)
            {

                item.useTime += 20;
                item.useAnimation += 20;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.25f && Beenade == false)
            {
                item.damage += 30;
                item.useTime += 12;
                item.useAnimation += 12;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.5f && Molotov == false)
            {
                item.useTime += 5;
                item.useAnimation += 5;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 1f && Else == false)
            {
                item.knockBack = 0.01f;
            }

            if (item.useTime < 2 || item.useAnimation < 2)
            {
                item.useTime = 2;
                item.useAnimation = 2;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (item.ranged == true)
                {
                    item.ranged = false;
                    item.thrown = true;
                }

                else
                {
                    item.ranged = true;
                    item.thrown = false;
                }
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("ThrowingGrenadeLauncher"), 1);
            recipe.AddIngredient(mod.GetItem("CryoIngot"), 15);
            recipe.AddIngredient(mod.ItemType("FrozenLeaf"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}