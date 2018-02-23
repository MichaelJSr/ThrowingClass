using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CryoAdminHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryo Admin Hat");
            Tooltip.SetDefault("50% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 11;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.5f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("CryoAdminHat");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "50% increased movement speed\nYour mobility is greatly increased\nWarning, does not protect against death";
            player.wingTimeMax += 1200;
            player.moveSpeed += 0.5f;
            player.runAcceleration += 0.5f;
            player.runSlowdown += 2f;
            player.maxRunSpeed += 20f;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
    }
}