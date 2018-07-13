using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class SplinterJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splinter Javelin");
        }

        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.thrown = true;
            projectile.aiStyle = 2;
        }
    }
}