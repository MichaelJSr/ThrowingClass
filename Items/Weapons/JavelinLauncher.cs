using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class JavelinLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Javelin Launcher");
            Tooltip.SetDefault("Uses mechanization to fire javelins at a much stronger velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.crit = 0;
            item.noMelee = true;
            item.ranged = true;
            item.width = 40;
            item.height = 22;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 4, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Stake;
            item.shoot = 10;
            item.shootSpeed = 4f; //How fast the projectile fires
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = 0;
            int k = 0;
            if (item.crit == 1) //If useTime 8 javelins were last shot
            {
                k = 1;
                i = 0;
            }
            else if (item.crit == 2) //If useTime 20 javelins were last shot
            {
                k = 0;
                i = 1;
            }

            if (type == mod.ProjectileType("SapphireJavelin"))
            {
                if (i == 1)
                {
                    item.damage -= 5;
                    item.knockBack -= 0.5f;
                    item.useTime -= 12;
                    item.useAnimation -= 12;
                    item.crit = 1;
                }
                else if (k == 0)
                {
                    item.damage -= 5;
                    item.knockBack -= 0.5f;
                    item.useTime -= 17;
                    item.useAnimation -= 17;
                    item.crit = 1;
                }
            }

            else if (type == mod.ProjectileType("DiamondJavelin") || type == mod.ProjectileType("AmberJavelin") || type == mod.ProjectileType("MeteorJavelin") || type == mod.ProjectileType("JesterJavelin") || type == mod.ProjectileType("HellfireJavelin"))
            {
                if (k == 1)
                {
                    item.damage += 5;
                    item.knockBack += 0.5f;
                    item.useTime += 12;
                    item.useAnimation += 12;
                    item.crit = 2;
                }
                else if (i == 0)
                {
                    item.useTime -= 5;
                    item.useAnimation -= 5;
                    item.crit = 2;
                }
            }

            else //Neither useTime 5 or 20 javelins are shot
            {
                if (k == 1)
                {
                    item.damage += 5;
                    item.knockBack += 0.5f;
                    item.useTime += 17;
                    item.useAnimation += 17;
                    item.crit = 0;
                }
                else if (i == 1)
                {
                    item.useTime += 5;
                    item.useAnimation += 5;
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
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.Harpoon, 1);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.Harpoon, 1);
            recipe.AddIngredient(ItemID.LeadBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}