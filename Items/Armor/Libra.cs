using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Libra : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Libra");
            Tooltip.SetDefault("20% increased throwing damage\n+50 max health\n15% decreased movement and throwing speed");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 20;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 5;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.2f;
            player.statLifeMax2 += 50;
            player.moveSpeed -= 0.15f;
            player.thrownVelocity -= 0.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("LibraBreastplate") && legs.type == mod.ItemType("LibraLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% increased throwing damage and critical strike chance\n15% increased movement and throwing speed\n8% increased damage reduction\n+50 max health\nYou emanate divine light";
            player.AddBuff(BuffID.Shine, 0);
            player.thrownDamage += 0.2f;
            player.thrownCrit += 20;
            player.moveSpeed += 0.15f;
            player.thrownVelocity += 0.15f;
            player.endurance += 0.08f;
            player.statLifeMax2 += 50;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.AdamantiteBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.TitaniumBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}