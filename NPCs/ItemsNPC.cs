using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ItemsNPC.NPCs
{
    class ItemsNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            //Icy Shards
            if (npc.type == NPCID.ArmoredViking)
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("IcyShard"), 1);
            }
            if (npc.type == NPCID.IceTortoise)
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("IcyShard"), 1);
            }
            if (npc.type == NPCID.IceElemental)
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("IcyShard"), 1);
            }
            if (npc.type == NPCID.IcyMerman)
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("IcyShard"), 1);
            }
            if (npc.type == NPCID.IceGolem)
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("IcyShard"), 1);
            }
            if (npc.type == NPCID.Wolf)
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("IcyShard"), 1);
            }
        }
    }
}