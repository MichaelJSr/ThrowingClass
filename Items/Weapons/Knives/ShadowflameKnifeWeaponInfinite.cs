using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Knives
{
    public class ShadowflameKnifeWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Shadowflame Throwing Knife");
            Tooltip.SetDefault("Inflicts Shadowflame on hit.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 13f;
            item.damage = 38;
            item.knockBack = 5.75f;
            item.useStyle = 1;
            item.useAnimation = 11;
            item.useTime = 11;
            item.width = 8;
            item.height = 8;
            item.maxStack = 1;
            item.rare = 5;
            item.ammo = ItemID.ThrowingKnife;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = 497;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public int numberShots = 0;
        public float chanceShots = 0f;
        public bool munition1 = false;

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

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteKnives)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("ShadowflameKnifeWeapon"), 999);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}