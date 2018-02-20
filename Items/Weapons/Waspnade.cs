using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class Waspnade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Waspnade");
            Tooltip.SetDefault("Explodes upon contact");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 8;
            item.damage = 26;
            item.knockBack = 1f;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 14;
            item.height = 22;
            item.maxStack = 999;
            item.rare = 7;
            item.ammo = ItemID.Grenade;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("Waspnade");
            item.value = Item.sellPrice(0, 0, 1, 0);
        }
    }
}