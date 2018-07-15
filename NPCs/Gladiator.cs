using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Gladiator.NPCs
{
    [AutoloadHead]
    public class Gladiator : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "ThrowingClass/NPCs/Gladiator";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "Gladiator";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gladiator");
            Main.npcFrameCount[npc.type] = 26;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 350;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 0;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 176);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    for (int j = 0; j < player.inventory.Length; j++)
                    {
                        if (player.inventory[j].type == ItemID.Javelin || player.inventory[j].type == ItemID.Bone)
                        {
                            return true;
                        }
                    }
                }
            }

            if (NPC.downedBoss2)
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(9))
            {
                case 0:
                    return "Lacedaemon";
                case 1:
                    return "Amyklas";
                case 2:
                    return "Argalus";
                case 3:
                    return "Kynorta";
                case 4:
                    return "Perieres";
                case 5:
                    return "Oibalos";
                case 6:
                    return "Tyndareos";
                case 7:
                    return "Hippocoon";
                default:
                    return "Spartacus";
            }
        }

        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        // Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
        // The WeightedRandom class needs "using Terraria.Utilities;" to use
        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int armsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (partyGirl >= 0 && Main.rand.Next(4) == 0)
            {
                chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
            }
            if (armsDealer > 0 && Main.rand.Next(4) == 0)
            {
                chat.Add(Main.npc[armsDealer].GivenName + " thinks he's so great with his guns? Let's see him shoot after getting stabbed in the eye with a javelin.");
            }
            chat.Add("I will never lay down my weapon.");
            chat.Add("This. Is. Sparta!!!");
            chat.Add("I need to find the way to Uganda in order to claim my prize.", 0.1);
            return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Javelin);  //this is an example of how to add your item
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("JavelinQuiver"));  //this is an example of how to add your item
            nextSlot++;

            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    for (int j = 0; j < player.inventory.Length; j++)
                    {
                        if (player.inventory[j].type == ItemID.ShadowFlameKnife)
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowflameKnifeWeapon"));
                            nextSlot++;
                        }
                    }
                }
            }
            /*if (Main.LocalPlayer.GetModPlayer<Gladiator>(mod).Desert)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("BoneJavelin"));
                nextSlot++;
            }
            if (Main.moonPhase < 2)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleSword"));
                nextSlot++;
            }
            else if (Main.moonPhase < 4)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleGun"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleBullet"));
                nextSlot++;
            }
            else if (Main.moonPhase < 6)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleStaff"));
                nextSlot++;
            }
            else
            {
            }
            // Here is an example of how your npc can sell items from other mods.
            if (ModLoader.GetLoadedMods().Contains("Infinity"))
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Infinity").ItemType("EndlessJavelin"));
                nextSlot++;
            }*/
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("JavelinBallista"));
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 30;
            knockback = 5f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 25;
            randExtraCooldown = 25;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 507;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}