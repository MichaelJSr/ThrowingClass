using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Launchers
{
    public class KnifeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knife Launcher");
            Tooltip.SetDefault("Uses mechanization to fire knives at a much stronger velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.crit = 6;
            item.noMelee = true;
            item.ranged = true;
            item.width = 54;
            item.height = 22;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.knockBack = 0.01f;
            item.value = Item.sellPrice(0, 4, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.ThrowingKnife;
            item.shoot = 10;
            item.shootSpeed = 4f; //How fast the projectile fires
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
            bool ShadowFlame = false;
            bool FrostDagger = false;
            bool BoneDagger = false;
            bool Else = false;
            if (type == ProjectileID.ShadowFlameKnife)
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 3;
                    item.useAnimation -= 3;
                    item.knockBack = 0.05f;
                }
                if (item.knockBack == 0.05f)
                {
                    ShadowFlame = true;
                }
            }

            else if (type == ProjectileID.FrostDaggerfish)
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 2;
                    item.useAnimation -= 2;
                    item.knockBack = 0.25f;
                }
                if (item.knockBack == 0.25f)
                {
                    FrostDagger = true;
                }
            }

            else if (type == ProjectileID.BoneDagger)
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.knockBack = 0.5f;
                }
                if (item.knockBack == 0.5f)
                {
                    BoneDagger = true;
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

            if (item.knockBack == 0.05f && ShadowFlame == false)
            {
                item.useTime += 3;
                item.useAnimation += 3;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.25f && FrostDagger == false)
            {
                item.useTime += 2;
                item.useAnimation += 2;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.5f && BoneDagger == false)
            {
                item.useTime += 1;
                item.useAnimation += 1;
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