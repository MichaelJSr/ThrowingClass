using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ThrowingClass.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Libra : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Libra");
            Tooltip.SetDefault("20% increased throwing damage\n+50 max health\n20% decreased throwing speed\n15% decreased movement and throwing velocity");
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
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed -= 0.2f;
            player.thrownVelocity -= 0.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("LibraBreastplate") && legs.type == mod.ItemType("LibraLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% increased throwing damage and critical strike chance\n20% increased throwing speed\n15% increased movement and throwing velocity\n10% increased damage reduction\n+50 max health\nYou emanate divine light";
            player.thrownDamage += 0.2f;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.2f;
            player.thrownCrit += 20;
            player.moveSpeed += 0.15f;
            player.thrownVelocity += 0.15f;
            player.endurance += 0.1f;
            player.statLifeMax2 += 50;
            Lighting.AddLight(player.position, 1.25f, 1.25f, 1.25f);
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            Lighting.AddLight(item.position, 0.5f, 0.5f, 0.5f);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
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