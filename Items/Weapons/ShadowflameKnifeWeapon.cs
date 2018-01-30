using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class ShadowflameKnifeWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Knife");
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
            item.maxStack = 999;
            item.rare = 5;
            item.ammo = ItemID.ThrowingKnife;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = 497;
            item.value = Item.buyPrice(0, 0, 7, 50);
        }
    }
}