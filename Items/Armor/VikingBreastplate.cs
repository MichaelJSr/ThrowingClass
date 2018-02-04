using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class VikingBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Viking Breastplate");
            Tooltip.SetDefault("2% increased throwing and melee damage");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 1;
            item.defense = 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ItemID.VikingHelmet && legs.type == mod.ItemType("VikingLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "14% increased meelee and throwing damage";
            player.meleeDamage += 0.14f;
            player.thrownDamage += 0.14f;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.02f;
            player.meleeDamage += 0.02f;
        }
    }
}