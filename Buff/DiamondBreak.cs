using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

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
            npc.GetGlobalNPC<ThrowingGlobalNPC>().DiamondBreak = true;
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 16);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff  
            Main.dust[num1].scale = npc.GetGlobalNPC<ThrowingGlobalNPC>().maxScaleDB; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 1f; //the dust velocity
            Main.dust[num1].noGravity = true;
            npc.defense -= npc.GetGlobalNPC<ThrowingGlobalNPC>().maxDefDB;
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            if (npc.GetGlobalNPC<ThrowingGlobalNPC>().maxDefDB < 30)
            {
                npc.GetGlobalNPC<ThrowingGlobalNPC>().maxDefDB = (int)(npc.GetGlobalNPC<ThrowingGlobalNPC>().maxDefDB * 1.25f);
                npc.GetGlobalNPC<ThrowingGlobalNPC>().maxScaleDB *= 1.25f;
            }
            else
            {
                npc.GetGlobalNPC<ThrowingGlobalNPC>().maxDefDB = 30;
            }
            return false;
        }
    }
}