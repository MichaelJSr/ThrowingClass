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
            Tooltip.SetDefault("Uses mechanization to fire knives at a much stronger velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.crit = 0;
            item.noMelee = true;
            item.ranged = true;
            item.width = 54;
            item.height = 32;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.knockBack = 0.5f;
            item.value = Item.sellPrice(0, 4, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.ThrowingKnife;
            item.shoot = 10;
            item.shootSpeed = 4f; //How fast the projectile fires
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = 0;
            int k = 0;
            int c = 0;
            if (item.crit == 1)
            {
                k = 1;
                i = 0;
                c = 0;
            }
            else if (item.crit == 2)
            {
                k = 0;
                i = 1;
                c = 0;
            }
            else if (item.crit == 3)
            {
                k = 0;
                i = 0;
                c = 1;
            }

            if (type == 599) //Bone Throwing Knives
            {
                if (i == 1)
                {
                    item.useTime += 1;
                    item.useAnimation += 1;
                    item.crit = 1;
                }
                else if (c == 1)
                {
                    item.useTime += 2;
                    item.useAnimation += 2;
                    item.crit = 1;
                }
                else if (k == 0)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 1;
                }
            }
            else if (type == 520) //Frost Daggerfish
            {
                if (k == 1)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 2;
                }
                else if (c == 1)
                {
                    item.useTime += 1;
                    item.useAnimation += 1;
                    item.crit = 2;
                }
                else if (i == 0)
                {
                    item.useTime -= 2;
                    item.useAnimation -= 2;
                    item.crit = 2;
                }
            }
            else if (type == 497) //Shadowflame Knives
            {
                if (k == 1)
                {
                    item.useTime -= 2;
                    item.useAnimation -= 2;
                    item.crit = 3;
                }
                else if (i == 1)
                {
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 3;
                }
                else if (c == 0)
                {
                    item.useTime -= 3;
                    item.useAnimation -= 3;
                    item.crit = 3;
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