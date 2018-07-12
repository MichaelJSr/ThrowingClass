using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Accessories
{
    public class ShinyRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shiny Rock");
            Tooltip.SetDefault("Adds +1 penetration to throwing weapons");
        }

        public override void SetDefaults()
        {
            item.width = 13;
            item.height = 12;
            item.value = Item.buyPrice(0, 4, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(mod.BuffType("Penetration1"), 60);
        }
    }
}