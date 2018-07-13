using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class TrueMeteorJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TrueMeteorJavelin");
        }

        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 9;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.penetrate = 10;
            projectile.thrown = true;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            // For going through platforms and such, javelins use a tad smaller size
            width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
            return true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // Inflate some target hitboxes if they are beyond 8,8 size
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            // Return if the hitboxes intersects, which means the javelin collides or not
            return projHitbox.Intersects(targetHitbox);
        }

        public float targetWhoAmI
        {
            get { return projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }

        private const int alphaReduction = 25;
        private const float maxTicks = 50f;

        public override void AI()
        {
            projectile.light = 0.25f;
            // Slowly remove alpha as it is present
            if (projectile.alpha > 0)
            {
                projectile.alpha -= alphaReduction;
            }
            // If alpha gets lower than 0, set it to 0
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
                targetWhoAmI += 1f;
                // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
                if (targetWhoAmI >= maxTicks)
                {
                    // Change these multiplication factors to alter the javelin's movement change after reaching maxTicks
                    float velXmult = 0.98f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
                    float
                        velYmult = 0.35f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
                    targetWhoAmI = maxTicks; // set ai1 to maxTicks continuously
                    projectile.velocity.X = projectile.velocity.X * velXmult;
                    projectile.velocity.Y = projectile.velocity.Y + velYmult;
                }
                // Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
                projectile.rotation =
                    projectile.velocity.ToRotation() +
                    MathHelper.ToRadians(0f); // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!
        }

        //When the projectile hits a tile
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -0.75f * oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -0.75f * oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }

    }
}