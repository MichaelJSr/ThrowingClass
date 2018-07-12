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
            //Cryo Shards
            if (npc.type == NPCID.ArmoredViking)
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("CryoShard"), 1);
            }
            if (npc.type == NPCID.IceTortoise)
            {
                if (Main.rand.NextFloat() < .03f)
                    Item.NewItem(npc.getRect(), mod.ItemType("CryoShard"), 1);
            }
            if (npc.type == NPCID.IceElemental)
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("CryoShard"), 1);
            }
            if (npc.type == NPCID.IcyMerman)
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("CryoShard"), 1);
            }
            if (npc.type == NPCID.IceGolem)
            {
                if (Main.rand.NextFloat() < 1f)
                    Item.NewItem(npc.getRect(), mod.ItemType("CryoShard"), 1);
            }
            if (npc.type == NPCID.Wolf)
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("CryoShard"), 1);
            }

            //Frozen Leaf
            if (npc.type == NPCID.Plantera)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("FrozenLeaf"), 1);
            }

            //Wicked Tooth
            if ((npc.type == NPCID.Piranha) || (npc.type == NPCID.Shark))
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("WickedTooth"), 1);
            }
            if ((npc.type == NPCID.GiantTortoise) || (npc.type == NPCID.IceTortoise))
            {
                if (Main.rand.NextFloat() < .04f)
                    Item.NewItem(npc.getRect(), mod.ItemType("WickedTooth"), 1);
            }
            if ((npc.type == NPCID.Derpling) || (npc.type == NPCID.Herpling))
            {
                if (Main.rand.NextFloat() < .02f)
                    Item.NewItem(npc.getRect(), mod.ItemType("WickedTooth"), 1);
            }
            if ((npc.type == NPCID.GiantFlyingFox) || (npc.type == NPCID.Wolf))
            {
                if (Main.rand.NextFloat() < .02f)
                    Item.NewItem(npc.getRect(), mod.ItemType("WickedTooth"), 1);
            }
            if ((npc.type == NPCID.AnglerFish) || (npc.type == NPCID.Arapaima))
            {
                if (Main.rand.NextFloat() < .02f)
                    Item.NewItem(npc.getRect(), mod.ItemType("WickedTooth"), 1);
            }
            if (npc.type == NPCID.DuneSplicerHead)
            {
                if (Main.rand.NextFloat() < .08f)
                    Item.NewItem(npc.getRect(), mod.ItemType("WickedTooth"), Main.rand.Next(1, 3));
            }
        }
    }
}