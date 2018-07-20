using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CryoHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryo Hat");
            Tooltip.SetDefault("20% increased throwing speed\n15% increased movement speed\n15% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = 8;
            item.defense = 17;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.2f;
            player.moveSpeed += 0.15f;
            player.thrownVelocity += 0.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CryoChest") && legs.type == mod.ItemType("CryoLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "15% increased movement speed\n25% increased throwing velocity\n5% increased throwing speed\nYour mobility is greatly increased";
            player.wingTimeMax += 120;
            player.moveSpeed += 0.15f;
            player.runAcceleration += 0.5f;
            player.runSlowdown += 0.5f;
            player.maxRunSpeed += 3f;
            player.thrownVelocity += 0.25f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.05f;
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