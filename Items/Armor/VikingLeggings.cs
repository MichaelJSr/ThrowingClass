using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class VikingLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Viking Leggings");
            Tooltip.SetDefault("2% increased throwing and melee damage");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = 1;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.02f;
            player.meleeDamage += 0.02f;
        }
    }
}