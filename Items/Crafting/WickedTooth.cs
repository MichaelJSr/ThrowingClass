using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Crafting
{
    public class WickedTooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wicked Tooth");
            Tooltip.SetDefault("A sharp and durable monster tooth");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 16;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
        }
    }
}