using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Placeable
{
    public class JavelinBallista : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 10;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.createTile = mod.TileType("JavelinBallista");
        }
    }
}