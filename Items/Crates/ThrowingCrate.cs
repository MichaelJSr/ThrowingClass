using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Crates
{
    public class ThrowingCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Throwing Crate");
            Tooltip.SetDefault("Right click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 34;
            item.height = 34;
            item.rare = 2;
            item.createTile = mod.TileType("ThrowingCrate");
            item.placeStyle = 0;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = 1;
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.hardMode)
            {
                //Gauranteed javelins
                int Choose = Main.rand.Next(11);
                if (Choose == 0)
                {
                    player.QuickSpawnItem(ItemID.Javelin, Main.rand.Next(40, 120));
                }
                else if (Choose == 1)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueAmethystJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 2)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueDiamondJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 3)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueEmeraldJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 4)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueHellfireJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 5)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueJesterJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 6)
                {
                    player.QuickSpawnItem(mod.ItemType("SplinterJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 7)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueMeteorJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 8)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueRubyJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 9)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueSapphireJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 10)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueTopazJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 11)
                {
                    player.QuickSpawnItem(mod.ItemType("TrueAmberJavelinWeapon"), Main.rand.Next(20, 80));
                }
                //Not gauranteed
                if (Main.rand.NextFloat() < .2f)
                    player.QuickSpawnItem(mod.ItemType("ThrowingPotion"), Main.rand.Next(1, 4));
                if (Main.rand.NextFloat() < .02f)
                    player.QuickSpawnItem(mod.ItemType("MunitionsPack"), 1);
                //Drops gauranteed money
                Choose = Main.rand.Next(100);
                if (Choose > 90)
                {
                    player.QuickSpawnItem(ItemID.PlatinumCoin, 1);
                }
                else if (Choose > 65)
                {
                    player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 8));
                }
                else if (Choose > 30)
                {
                    player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(1, 50));
                }
                else if (Choose > 0)
                {
                    player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(1, 99));
                }

            }
            else
            {
                //Gauranteed javelins
                int Choose = Main.rand.Next(11);
                if (Choose == 0)
                {
                    player.QuickSpawnItem(ItemID.Javelin, Main.rand.Next(40, 120));
                }
                else if (Choose == 1)
                {
                    player.QuickSpawnItem(mod.ItemType("AmethystJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 2)
                {
                    player.QuickSpawnItem(mod.ItemType("DiamondJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 3)
                {
                    player.QuickSpawnItem(mod.ItemType("EmeraldJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 4)
                {
                    player.QuickSpawnItem(mod.ItemType("HellfireJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 5)
                {
                    player.QuickSpawnItem(mod.ItemType("JesterJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 6)
                {
                    player.QuickSpawnItem(mod.ItemType("MakeshiftJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 7)
                {
                    player.QuickSpawnItem(mod.ItemType("MeteorJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 8)
                {
                    player.QuickSpawnItem(mod.ItemType("RubyJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 9)
                {
                    player.QuickSpawnItem(mod.ItemType("SapphireJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 10)
                {
                    player.QuickSpawnItem(mod.ItemType("TopazJavelinWeapon"), Main.rand.Next(20, 80));
                }
                else if (Choose == 11)
                {
                    player.QuickSpawnItem(mod.ItemType("AmberJavelinWeapon"), Main.rand.Next(20, 80));
                }
                //Not gauranteed
                if (Main.rand.NextFloat() < .02f)
                    player.QuickSpawnItem(mod.ItemType("SplinterJavelinWeapon"), Main.rand.Next(1, 10));
                if (Main.rand.NextFloat() < .2f)
                    player.QuickSpawnItem(mod.ItemType("ThrowingPotion"), Main.rand.Next(1, 4));
                if (Main.rand.NextFloat() < .02f)
                    player.QuickSpawnItem(mod.ItemType("MunitionsPack"), 1);
                //Drops gauranteed money
                Choose = Main.rand.Next(100);
                if (Choose > 95)
                {
                    player.QuickSpawnItem(ItemID.PlatinumCoin, 1);
                }
                else if (Choose > 75)
                {
                    player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 4));
                }
                else if (Choose > 50)
                {
                    player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(1, 50));
                }
                else if (Choose > 0)
                {
                    player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(1, 99));
                }
            }
        }
    }
}