using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Adamantite Galea");
            Tooltip.SetDefault("14% increased throwing damage\n8% increased throwing speed\n8% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 4;
            item.defense = 13;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.14f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.08f;
            player.thrownVelocity += 0.08f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "25% chance not to consume ammo\n8% increased throwing speed";
            player.GetModPlayer<ThrowingPlayer>(mod).thrownAmmoChance += 0.25f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.08f;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}