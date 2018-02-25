using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Accessories
{
    public class SpartanAnkhShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spartan Ankh Shield");
            Tooltip.SetDefault("15% increased throwing damage and velocity\nGrants the ability to dash\nGrants immunity to knockback and fire blocks\nGrants immunity to most debuffs");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 40, 0);
            item.rare = 4;
            item.accessory = true;
            item.defense = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;
            player.thrownVelocity += 0.15f;
            player.dash = 2;
            player.noKnockback = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.Chilled] = true;
            /*if (Main.rand.Next(250) == 0) //On a 1/250 chance every tick, it'll spawn a projectile (to prevent lag)
            {
                float vel = 12f;
                if (player.direction == -1)
                {
                    vel = -12f;
                }
                Projectile.NewProjectile(player.position.X, player.position.Y+12, vel, 0f, mod.ProjectileType("HellfireJavelin"), 40, 5f, Main.myPlayer);
            }*/
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(mod.ItemType("SpartanRelicShield"));
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}