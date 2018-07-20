using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hallowed Galea");
            Tooltip.SetDefault("15% increased throwing damage\n10% increased throwing speed\nincreased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 5;
            item.defense = 16;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.1f;
            player.thrownVelocity += 0.08f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "25% chance not to consume ammo\n10% increased throwing speed\n6% increased throwing velocity";
            player.GetModPlayer<ThrowingPlayer>(mod).thrownAmmoChance += 0.25f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.1f;
            player.thrownVelocity += 0.06f;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawShadowSubtle = true;
            player.armorEffectDrawOutlines = true;
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}