using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items
{
    public class FrozenLeaf : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Leaf");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 30;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 6;
        }
    }
}