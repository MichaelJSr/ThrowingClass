using Terraria;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

namespace ThrowingClass.Buff
{
    public class Munition2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Munition 2");
            Description.SetDefault("+20% Chance to not consume ammo");
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).Munition2 = true;
        }
    }
}