using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ArmorsNPC.NPCs
{
    class ArmorsNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            //Viking Breastplate
            if (npc.type == NPCID.UndeadViking)
            {
                if (Main.rand.NextFloat() < .02f)
                    Item.NewItem(npc.getRect(), mod.ItemType("VikingBreastplate"), 1);
            }
            //Viking Leggings
            if (npc.type == NPCID.UndeadViking)
            {
                if (Main.rand.NextFloat() < .02f)
                    Item.NewItem(npc.getRect(), mod.ItemType("VikingLeggings"), 1);
            }
        }
    }
}