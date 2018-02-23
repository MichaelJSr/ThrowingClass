using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.NPCs
{
    public class ThrowingGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool TruePoison = false;
        public bool DoTJavelin = false;

        public override void ResetEffects(NPC npc)
        {
            TruePoison = false;
            DoTJavelin = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (DoTJavelin)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int DoTJavelinCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active)
                    {
                        DoTJavelinCount++;
                    }
                }
                npc.lifeRegen -= DoTJavelinCount * 2 * 3;
                if (damage < DoTJavelinCount * 3)
                {
                    damage = DoTJavelinCount * 3;
                }
            }

            if (TruePoison)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= (int)Math.Pow((npc.lifeMax / 70), (0.4 + 0.3 * 1000 / (npc.lifeMax + 1000))) * 10 * (int)Math.Log(12, (6 + 1));
                if (damage < 4)
                {
                    damage = 4;
                }
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (TruePoison)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 18);
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].scale *= 1f;
                Main.dust[dust].noGravity = true;
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
        }
    }
}