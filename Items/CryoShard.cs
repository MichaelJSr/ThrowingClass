using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items
{
    public class CryoShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Shard");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 30;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 4;
        }
    }
}