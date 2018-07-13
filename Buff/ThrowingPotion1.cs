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
            Description.SetDefault("+20% Throwing damage and velocity");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.2f;
            player.thrownVelocity += 0.2f;
        }
    }
}