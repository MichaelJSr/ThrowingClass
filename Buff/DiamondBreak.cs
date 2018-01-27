using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Buff
{
    public class DiamondBreak : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("DiamondBreak");
            Main.debuff[Type] = true;   //Tells the game if this is a buff or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not.
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 16);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff  
            Main.dust[num1].scale = 2f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 1f; //the dust velocity
            Main.dust[num1].noGravity = true;
            npc.defense -= 5;
        }
    }
}