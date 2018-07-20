using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Titanium Galea");
            Tooltip.SetDefault("16% increased throwing damage\n9% increased throwing speed\n7% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 4;
            item.defense = 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.16f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.09f;
            player.thrownVelocity += 0.07f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "16% increased throwing damage\n9% increased throwing speed";
            player.thrownDamage += 0.16f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.09f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}