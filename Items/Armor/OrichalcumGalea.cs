using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Orichalcum Galea");
            Tooltip.SetDefault("15% increased throwing damage\n7% increased throwing speed\n8% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 2, 25, 0);
            item.rare = 4;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.07f;
            player.moveSpeed += 0.08f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "10% increased throwing damage\n7% increased throwing speed\n10% increased throwing velocity";
            player.thrownDamage += 0.1f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.07f;
            player.thrownVelocity += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}