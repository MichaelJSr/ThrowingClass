using Terraria;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

namespace ThrowingClass.Buff
{
    public class Munition1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Not enough ammo 1");
            Description.SetDefault("+20% chance to shoot up to 2 more shots");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).Munition1 = true;
        }
    }
}