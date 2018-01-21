using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThunderfuryBlessedBladeOfTheWindseeker.Items.Weapons
{
        public class ThunderfuryBlessedBladeOfTheWindseeker : ModItem
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Thunderfury, Blessed Blade Of The Windseeker");
                Tooltip.SetDefault("Did somebody say...");
            }
            public override void SetDefaults()
            {
                item.damage = 80;
                item.melee = true;
                item.width = 25;
                item.height = 25;
                item.useTime = 20;
                item.useAnimation = 20;
                item.useStyle = 1;
                item.knockBack = 7;
                item.value = Item.buyPrice(1, 0, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
                item.rare = 9;
                item.UseSound = SoundID.Item45;
                item.autoReuse = true;
                item.useTurn = true;
                item.shoot = mod.ProjectileType("Thunder"); //What the item shoots, retains an int value
                item.shootSpeed = 40f; //How fast the projectile fires
        }

            public override void AddRecipes()
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Arkhalis, 1);
                recipe.AddIngredient(ItemID.EnchantedSword, 1);
                recipe.AddTile(TileID.DemonAltar);
                recipe.SetResult(this);
                recipe.AddRecipe();
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TerraBlade, 1);
                recipe.AddIngredient(ItemID.DD2SquireDemonSword, 1);
                recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
                recipe.AddTile(TileID.DemonAltar);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
        }
    }
}