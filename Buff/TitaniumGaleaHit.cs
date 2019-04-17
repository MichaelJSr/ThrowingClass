using Terraria;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

namespace ThrowingClass.Buff
{
    public class TitaniumGaleaHit : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shadow Dodge Cooldown");
            Description.SetDefault("3 Second Cooldown");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).TitaniumGaleaHit = true;
        }
    }
}