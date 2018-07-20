using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cobalt Galea");
            Tooltip.SetDefault("10% increased throwing damage\n4% increased throwing speed\n6% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = 4;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.1f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.04f;
            player.thrownVelocity += 0.06f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% chance not to consume ammo\n4% increased throwing speed";
            player.GetModPlayer<ThrowingPlayer>(mod).thrownAmmoChance += 0.2f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.04f;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawShadowSubtle = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}