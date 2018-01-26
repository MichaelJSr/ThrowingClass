using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.NPCs
{
    public class VanillaShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Clothier:  //change NPC with whatg you want
                    shop.item[nextSlot].SetDefaults(ItemID.Javelin);  //this is an example of how to add your item
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(mod.ItemType("JavelinBallista"));  //this is an example of how to add your item
                    nextSlot++;
                    break;
            }
        }
    }
}