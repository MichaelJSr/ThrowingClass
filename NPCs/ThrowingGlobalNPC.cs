using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThrowingClass.Buff;

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

        //Diamond Break reduces between 10 - 30 defense
        public bool DiamondBreak = false;
        public int maxDefDB = 10;
        public float maxScaleDB = 1.5f;
        //True Diamond Break reduces between 30 - 60 defense
        public bool TrueDiamondBreak = false;
        public int maxDefTDB = 30;
        public float maxScaleTDB = 1.75f;
        public bool TruePoison = false;
        public bool DoTJavelin = false;

        public override void ResetEffects(NPC npc)
        {
            DiamondBreak = false;
            TrueDiamondBreak = false;
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

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (DiamondBreak == false)
            {
                maxDefDB = 10;
                maxScaleDB = 1.5f;
            }
            if (TrueDiamondBreak == false)
            {
                maxDefTDB = 30;
                maxScaleTDB = 1.75f;
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