using Terraria;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

namespace ThrowingClass.Buff
{
    public class ThrowingPotion1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Enhanced Throwing");
            Description.SetDefault("+10% Thrown damage, velocity, crit, and speed");
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.1f;
            player.thrownVelocity += 0.1f;
            player.thrownCrit += 10;
            player.GetModPlayer<ThrowingPlayer>(mod).thrownSpeed += 0.1f;
        }
    }
}