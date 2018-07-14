using System;
using System.Linq;
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
            Tooltip.SetDefault("Uses mechanization to fire javelins at a much stronger and faster velocity");
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
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 12, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.Javelin;
            item.shoot = 10;
            item.shootSpeed = 10f; //How fast the projectile fires
        }

        /*public override bool AltFunctionUse(Player player)
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
        }*/

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