using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Placeable
{
    public class MunitionsPack : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 3;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.createTile = mod.TileType("MunitionsPack");
            item.placeStyle = 0;
        }
    }
}