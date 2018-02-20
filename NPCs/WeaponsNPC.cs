using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace WeaponsNPC.NPCs
{
    class WeaponsNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
                //Throwing Grenade Launcher
                if (npc.type == NPCID.WallofFlesh)
                {
                    if (Main.rand.NextFloat() < .25f)
                        Item.NewItem(npc.getRect(), mod.ItemType("ThrowingGrenadeLauncher"), 1);
                }
                //Waspnades
                if (npc.type == NPCID.Plantera)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Waspnade"), Main.rand.Next(80, 100));
                }
        }
    }
}