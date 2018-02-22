using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class CryoKnifeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Knife Launcher");
            Tooltip.SetDefault("Uses mechanization to fire knives at a much stronger and faster velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.crit = 0;
            item.noMelee = true;
            item.ranged = true;
            item.width = 54;
            item.height = 22;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.knockBack = 0.5f;
            item.value = Item.sellPrice(0, 10, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.ThrowingKnife;
            item.shoot = 10;
            item.shootSpeed = 10f; //How fast the projectile fires
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = 0;
            int k = 0;
            int c = 0;
            if (item.crit == 2)
            {
                k = 1;
                i = 0;
                c = 0;
            }
            else if (item.crit == 4)
            {
                k = 0;
                i = 1;
                c = 0;
            }
            else if (item.crit == 6)
            {
                k = 0;
                i = 0;
                c = 1;
            }

            if (type == ProjectileID.BoneDagger) //Bone Throwing Knives
            {
                if (i == 1)
                {
                    item.useTime += 1;
                    item.useAnimation += 1;
                    item.crit = 2;
                }
                else if (c == 1)
                {
                    item.useTime += 2;
                    item.useAnimation += 2;
                    item.crit = 2;
                }
                else if (k == 0)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 2;
                }
            }
            else if (type == ProjectileID.FrostDaggerfish) //Frost Daggerfish
            {
                if (k == 1)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 4;
                }
                else if (c == 1)
                {
                    item.useTime += 1;
                    item.useAnimation += 1;
                    item.crit = 4;
                }
                else if (i == 0)
                {
                    item.useTime -= 2;
                    item.useAnimation -= 2;
                    item.crit = 4;
                }
            }
            else if (type == ProjectileID.ShadowFlameKnife) //Shadowflame Knives
            {
                if (k == 1)
                {
                    item.useTime -= 2;
                    item.useAnimation -= 2;
                    item.crit = 6;
                }
                else if (i == 1)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 6;
                }
                else if (c == 0)
                {
                    item.useTime -= 3;
                    item.useAnimation -= 3;
                    item.crit = 6;
                }
            }
            else //None of the above
            {
                if (k == 1)
                {
                    item.useTime += 1;
                    item.useAnimation += 1;
                    item.crit = 0;
                }
                else if (i == 1)
                {
                    item.useTime += 2;
                    item.useAnimation += 2;
                    item.crit = 0;
                }
                else if (c == 1)
                {
                    item.useTime += 3;
                    item.useAnimation += 3;
                    item.crit = 0;
                }
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
            recipe.AddIngredient(mod.GetItem("KnifeLauncher"), 1);
            recipe.AddIngredient(mod.GetItem("CryoIngot"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}