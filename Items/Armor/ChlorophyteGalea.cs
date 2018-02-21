using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Chlorophyte Galea");
            Tooltip.SetDefault("20% increased throwing damage\n10% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 7;
            item.defense = 20;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.2f;
            player.thrownVelocity += 0.1f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "10% increased throwing velocity\nSummons a powerful leaf crystal to shoot at nearby enemies";
            player.thrownVelocity += 0.1f;
            player.AddBuff(BuffID.LeafCrystal, 1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}