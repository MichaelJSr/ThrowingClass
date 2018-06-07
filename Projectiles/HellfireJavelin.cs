using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class HellfireJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellfireJavelin");
        }

        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 15;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.knockBack = 6f;
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

        public override void Kill(int timeLeft)
        {
            projectile.width = 120;
            projectile.height = 120;
            for (int i = 0; i < Main.npc.Length - 1; i++)
            {
                NPC N = Main.npc[i];
                float dX = N.Center.X - projectile.Center.X;
                float dY = N.Center.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(dX * dX + dY * dY));

                //So if the distance between the killed projectile and the npc is less than 120 pixels...
                if (distance < 120f && !N.friendly && N.active && (N.type != NPCID.DD2LanePortal))
                {
                    N.StrikeNPC(projectile.damage, 0f, N.direction, false, false, false); //Damages and shows damage on the NPC, projectile accounts for the defense of the NPC as well.
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num369 = 0; num369 < 20; num369++)
            {
                int num370 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num370].velocity *= 1.4f;
            }
            for (int num371 = 0; num371 < 10; num371++)
            {
                int num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num372].noGravity = true;
                Main.dust[num372].velocity *= 5f;
                num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num372].velocity *= 3f;
            }
            int num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore85 = Main.gore[num373];
            gore85.velocity.X = gore85.velocity.X + 1f;
            Gore gore86 = Main.gore[num373];
            gore86.velocity.Y = gore86.velocity.Y + 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore87 = Main.gore[num373];
            gore87.velocity.X = gore87.velocity.X - 1f;
            Gore gore88 = Main.gore[num373];
            gore88.velocity.Y = gore88.velocity.Y + 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore89 = Main.gore[num373];
            gore89.velocity.X = gore89.velocity.X + 1f;
            Gore gore90 = Main.gore[num373];
            gore90.velocity.Y = gore90.velocity.Y - 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore91 = Main.gore[num373];
            gore91.velocity.X = gore91.velocity.X - 1f;
            Gore gore92 = Main.gore[num373];
            gore92.velocity.Y = gore92.velocity.Y - 1f;
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
            projectile.light = 0.1f;
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

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.penetrate > 1)
            {
                projectile.width = 120;
                projectile.height = 120;
                for (int i = 0; i < Main.npc.Length - 1; i++)
                {
                    NPC N = Main.npc[i];
                    float dX = N.Center.X - projectile.Center.X;
                    float dY = N.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(dX * dX + dY * dY));

                    //So if the distance between the killed projectile and the npc is less than 120 pixels...
                    if (distance < 120f && !N.friendly && N.active && (N.type != NPCID.DD2LanePortal))
                    {
                        N.StrikeNPC(projectile.damage, 0f, N.direction, false, false, false); //Damages and shows damage on the NPC, projectile accounts for the defense of the NPC as well.
                    }
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
                for (int num369 = 0; num369 < 20; num369++)
                {
                    int num370 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num370].velocity *= 1.4f;
                }
                for (int num371 = 0; num371 < 10; num371++)
                {
                    int num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[num372].noGravity = true;
                    Main.dust[num372].velocity *= 5f;
                    num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num372].velocity *= 3f;
                }
                int num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore85 = Main.gore[num373];
                gore85.velocity.X = gore85.velocity.X + 1f;
                Gore gore86 = Main.gore[num373];
                gore86.velocity.Y = gore86.velocity.Y + 1f;
                num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore87 = Main.gore[num373];
                gore87.velocity.X = gore87.velocity.X - 1f;
                Gore gore88 = Main.gore[num373];
                gore88.velocity.Y = gore88.velocity.Y + 1f;
                num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore89 = Main.gore[num373];
                gore89.velocity.X = gore89.velocity.X + 1f;
                Gore gore90 = Main.gore[num373];
                gore90.velocity.Y = gore90.velocity.Y - 1f;
                num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore91 = Main.gore[num373];
                gore91.velocity.X = gore91.velocity.X - 1f;
                Gore gore92 = Main.gore[num373];
                gore92.velocity.Y = gore92.velocity.Y - 1f;
            }
            projectile.width = 56;
            projectile.height = 15;
        }

    }
}