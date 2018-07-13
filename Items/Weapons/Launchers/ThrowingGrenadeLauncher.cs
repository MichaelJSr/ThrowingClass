using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Launchers
{
    public class ThrowingGrenadeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Throwing Grenade Launcher");
            Tooltip.SetDefault("Uses mechanization to fire grenades at a much stronger velocity\n(With Calamity) Right click to change to ranged damage (reforge)");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.crit = 15;
            item.noMelee = true;
            item.thrown = true;
            item.width = 56;
            item.height = 22;
            item.useTime = 44;
            item.useAnimation = 44;
            item.useStyle = 5;
            item.knockBack = 0.01f;
            item.value = Item.sellPrice(0, 8, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.Grenade;
            item.shoot = 10;
            item.shootSpeed = 10f; //How fast the projectile fires
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
                    item.useTime -= 25;
                    item.useAnimation -= 25;
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
                    item.damage -= 20;
                    item.useTime -= 20;
                    item.useAnimation -= 20;
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

                item.useTime += 25;
                item.useAnimation += 25;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.25f && Beenade == false)
            {
                item.damage += 20;
                item.useTime += 20;
                item.useAnimation += 20;
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
            return false;
        }

        /*public override bool AltFunctionUse(Player player)
        {
            if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        }*/
    }
}