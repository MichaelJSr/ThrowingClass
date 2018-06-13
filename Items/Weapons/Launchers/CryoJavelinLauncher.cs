using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Launchers
{
    public class CryoJavelinLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Javelin Launcher");
            Tooltip.SetDefault("Uses mechanization to fire javelins at a much stronger and faster velocity\n(With Calamity) Right click to change to ranged damage (reforge)");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.crit = 12;
            item.noMelee = true;
            item.thrown = true;
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

        public int numberShots = 0;
        public float chanceShots = 0.1f;
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

            else if (type == mod.ProjectileType("TrueDiamondJavelin") || type == mod.ProjectileType("TrueAmberJavelin") || type == mod.ProjectileType("TrueHellfireJavelin") || type == mod.ProjectileType("TrueJesterJavelin") || type == mod.ProjectileType("TrueMeteorJavelin"))
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

            else if (type == mod.ProjectileType("DiamondJavelin") || type == mod.ProjectileType("AmberJavelin") || type == mod.ProjectileType("MeteorJavelin") || type == mod.ProjectileType("JesterJavelin") || type == mod.ProjectileType("HellfireJavelin") || type == mod.ProjectileType("TrueAmethystJavelin") || type == mod.ProjectileType("TrueTopazJavelin") || type == mod.ProjectileType("TrueEmeraldJavelin") || type == mod.ProjectileType("TrueRubyJavelin") || type == mod.ProjectileType("SplinterJavelin"))
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
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("JavelinLauncher"), 1);
            recipe.AddIngredient(mod.GetItem("CryoIngot"), 15);
            recipe.AddIngredient(mod.ItemType("FrozenLeaf"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}