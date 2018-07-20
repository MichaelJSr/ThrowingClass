using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class CryoLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryo Legs");
            Tooltip.SetDefault("10% increased throwing speed\n15% increased throwing critical strike chance\n10% increased throwing velocity\n5% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(0, 4, 50, 0);
            item.rare = 8;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.1f;
            player.thrownCrit += 15;
            player.thrownVelocity += 0.1f;
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