using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class CryoJavelinLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Javelin Launcher");
            Tooltip.SetDefault("Uses mechanization to fire javelins at a much stronger and faster velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.crit = 12;
            item.noMelee = true;
            item.ranged = true;
            item.width = 40;
            item.height = 22;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.knockBack = 0.01f;
            item.value = Item.sellPrice(0, 12, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.Javelin;
            item.shoot = 10;
            item.shootSpeed = 10f; //How fast the projectile fires
        }

        public override void PostReforge()
        {
            item.knockBack = 0.01f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            bool TrueSapphire = false;
            bool Sapphire = false;
            bool TrueDiamond = false;
            bool Diamond = false;
            bool Else = false;
            if (type == mod.ProjectileType("TrueSapphireJavelin"))
            {
                if (item.knockBack == 0.01f)
                {
                    item.damage -= 10;
                    item.useTime -= 14;
                    item.useAnimation -= 14;
                    item.knockBack = 0.05f;
                }
                if (item.knockBack == 0.05f)
                {
                    TrueSapphire = true;
                }
            }

            else if (type == mod.ProjectileType("SapphireJavelin"))
            {
                if (item.knockBack == 0.01f)
                {
                    item.damage -= 5;
                    item.useTime -= 10;
                    item.useAnimation -= 10;
                    item.knockBack = 0.1f;
                }
                if (item.knockBack == 0.1f)
                {
                    Sapphire = true;
                }
            }

            else if (type == mod.ProjectileType("TrueDiamondJavelin") || type == mod.ProjectileType("TrueAmberJavelin"))
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 8;
                    item.useAnimation -= 8;
                    item.knockBack = 0.2f;
                }
                if (item.knockBack == 0.2f)
                {
                    TrueDiamond = true;
                }
            }

            else if (type == mod.ProjectileType("DiamondJavelin") || type == mod.ProjectileType("AmberJavelin") || type == mod.ProjectileType("MeteorJavelin") || type == mod.ProjectileType("JesterJavelin") || type == mod.ProjectileType("HellfireJavelin") || type == mod.ProjectileType("TrueAmethystJavelin") || type == mod.ProjectileType("TrueTopazJavelin") || type == mod.ProjectileType("TrueEmeraldJavelin") || type == mod.ProjectileType("TrueRubyJavelin"))
            {
                if (item.knockBack == 0.01f)
                {
                    item.useTime -= 4;
                    item.useAnimation -= 4;
                    item.knockBack = 0.5f;
                }
                if (item.knockBack == 0.5f)
                {
                    Diamond = true;
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

            if (item.knockBack == 0.05f && TrueSapphire == false)
            {
                item.damage += 10;
                item.useTime += 14;
                item.useAnimation += 14;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.1f && Sapphire == false)
            {
                item.damage += 5;
                item.useTime += 10;
                item.useAnimation += 10;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.2f && TrueDiamond == false)
            {
                item.useTime += 8;
                item.useAnimation += 8;
                item.knockBack = 0.01f;
            }
            else if (item.knockBack == 0.5f && Diamond == false)
            {
                item.useTime += 4;
                item.useAnimation += 4;
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
            recipe.AddIngredient(mod.GetItem("JavelinLauncher"), 1);
            recipe.AddIngredient(mod.GetItem("CryoIngot"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}