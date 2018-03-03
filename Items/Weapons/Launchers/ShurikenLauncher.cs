using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Launchers
{
    public class ShurikenLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shuriken Launcher");
            Tooltip.SetDefault("Uses mechanization to fire shurikens at a much stronger velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 5;
            item.crit = 6;
            item.noMelee = true;
            item.ranged = true;
            item.width = 52;
            item.height = 26;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.knockBack = 0.01f;
            item.value = Item.sellPrice(0, 4, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.Shuriken;
            item.shoot = 10;
            item.shootSpeed = 8f; //How fast the projectile fires
        }

        public int numberShots = 0;
        public float chanceShots = 0f;
        public bool munition1 = false;

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            if (!(item.knockBack == 0.01f || item.knockBack == 0.05f || item.knockBack == 0.1f || item.knockBack == 0.2f || item.knockBack == 0.25f || item.knockBack == 0.5f || item.knockBack == 0.75f || item.knockBack == 1f))
            {
                item.knockBack = 0.01f;
            }
        }

        public override void HoldItem(Player player)
        {
            if (player.GetModPlayer<ThrowingPlayer>(mod).Munition1 == true && munition1 == false)
            {
                numberShots += 2;
                chanceShots += 0.2f;
                munition1 = true;
            }

            if (player.GetModPlayer<ThrowingPlayer>(mod).Munition1 == false && munition1 == true)
            {
                numberShots -= 2;
                chanceShots -= 0.2f;
                munition1 = false;
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int actualShots = 1;
            int chance = 0;
            int fired = 0;
            int odd = 0;
            int checkOdd = 0;
            int even = 0;
            int checkEven = -1;
            float rotation = MathHelper.ToRadians(15f);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            for (int shots = 0; shots < numberShots; shots++)
            {
                if (Main.rand.NextFloat() < chanceShots)
                {
                    chance += 1;
                }
            }
            actualShots = chance + 1;
            for (int shots = 0; shots < actualShots; shots++)
            {
                if (fired % 2 != 1 && actualShots % 2 != 1)
                {
                    even = 1;
                }
                if (fired == 0)
                {
                    checkEven -= 1;
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(rotation / (1 - checkOdd - checkEven) * (fired - odd % 2 + even)); // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                rotation = -rotation;
                if (fired % 2 != 1)
                {
                    even = 0;
                }
                fired += 1;
                if (fired != 1 && actualShots % 2 != 0)
                {
                    odd += 1;
                }
                if (fired == 1)
                {
                    checkOdd -= 1;
                }
            }
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