using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class CryoChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryo Chest");
            Tooltip.SetDefault("15% increased throwing damage\n10% increased throwing critical strike chance\n5% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 8;
            item.defense = 24;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
            player.thrownCrit += 10;
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CryoIngot"), 12);
            recipe.AddIngredient(mod.ItemType("FrozenLeaf"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}