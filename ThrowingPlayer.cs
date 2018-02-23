using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace ThrowingClass
{
    public class ThrowingPlayer : ModPlayer
    {
        public bool TruePoison = false;
        public bool DiamondBreak = false;
        public bool TrueDiamondBreak = false;

        public override void ResetEffects()
        {
            TruePoison = false;
            DiamondBreak = false;
            TrueDiamondBreak = false;
        }

        /*public override void clientClone(ModPlayer clientClone)
        {
            ThrowingPlayer clone = clientClone as ThrowingPlayer;
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
            // clone.someLocalVariable = someLocalVariable;
        }*/

        public override void UpdateDead()
        {
            TruePoison = false;
            DiamondBreak = false;
            TrueDiamondBreak = false;
        }

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("WoodenJavelin"));
            item.stack = 40;
            items.Add(item);
        }

        public override void UpdateBadLifeRegen()
        {
            if (TruePoison)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= (int)Math.Pow((player.statLifeMax / 70), (0.4 + 0.3 * 1000 / (player.statLifeMax + 1000))) * 10 * (int)Math.Log(12, (6 + 1));
            }
            /*if (healHurt > 0)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 120 * healHurt;
            }*/
        }

        /*public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (healHurt > 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason("Was dissolved by holy powers");
            }
            return true;
        }*/

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (TruePoison)
            {
                int dust = Dust.NewDust(player.position, player.width, player.height, 18);
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].scale *= 1f;
                Main.dust[dust].noGravity = true;
                Lighting.AddLight(player.position, 0.1f, 0.2f, 0.7f);
            }
        }
    }
}