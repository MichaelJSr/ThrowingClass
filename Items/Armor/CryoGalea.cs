using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CryoGalea : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryo Galea");
            Tooltip.SetDefault("15% increased throwing damage\n10% increased throwing critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = 8;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
            player.thrownCrit += 10;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CryoChest") && legs.type == mod.ItemType("CryoLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% increased throwing damage\n15% increased throwing critical strike chance";
            player.thrownDamage += 0.2f;
            player.thrownCrit += 15;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
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