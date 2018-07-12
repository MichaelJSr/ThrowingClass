using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class MakeshiftJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Makeshift Javelin");
        }

        public override void SetDefaults()
        {
            projectile.width = 39;
            projectile.height = 7;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.thrown = true;
        }

        public bool penetration1 = false;

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

        public int numberShots = 12;
        public float chanceShots = 0.25f;
        public bool munition1 = false;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Main.player[projectile.owner].GetModPlayer<ThrowingPlayer>(mod).Munition1 == true && munition1 == false)
            {
                numberShots += 2;
                chanceShots += 0.2f;
                munition1 = true;
            }

            if (Main.player[projectile.owner].GetModPlayer<ThrowingPlayer>(mod).Munition1 == false && munition1 == true)
            {
                numberShots -= 2;
                chanceShots -= 0.2f;
                munition1 = false;
            }
            int actualShots = 1;
            int chance = 0;
            float perturbedSpeedX = 0f;
            float perturbedSpeedY = 0f;
            int counter = 0;
            int sectorOne = 0;
            for (int shots = 0; shots < numberShots; shots++)
            {
                if (Main.rand.NextFloat() < chanceShots)
                {
                    chance += 1;
                }
            }
            actualShots = chance + 1;
            for (int shots = 0; shots < actualShots; shots++)
            {
                counter++;
                //Sector 1
                if (shots == 0)
                {
                    perturbedSpeedX = MathHelper.ToRadians(90);
                    perturbedSpeedY = -MathHelper.ToRadians(0);
                    sectorOne++;
                }
                else if ((360 / actualShots) * (counter - 1) < 90)
                {
                    perturbedSpeedX = MathHelper.ToRadians(90 - ((360 / actualShots) * sectorOne));
                    perturbedSpeedY = -MathHelper.ToRadians((360 / actualShots) * sectorOne);
                    sectorOne++;
                }
                //Sector 2
                else if (((counter - 1) * (360 / actualShots)) == 180)
                {
                    perturbedSpeedX = -MathHelper.ToRadians(90);
                    perturbedSpeedY = -MathHelper.ToRadians(0);
                }
                else if ((360 / actualShots) * (counter - 1) < 180)
                {
                    if ((90 - ((360 / actualShots) * (counter - sectorOne))) < 0)
                    {
                        perturbedSpeedX = -MathHelper.ToRadians(180 - Math.Abs((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = -MathHelper.ToRadians(Math.Abs(((360 / actualShots) * (counter - sectorOne)) - 90));
                    }
                    else
                    {
                        perturbedSpeedX = -MathHelper.ToRadians(90 - ((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = -MathHelper.ToRadians((360 / actualShots) * (counter - sectorOne));
                    }
                }
                //Sector 3
                else if (((counter - 1) * (360 / actualShots)) == 270)
                {
                    perturbedSpeedX = -MathHelper.ToRadians(0);
                    perturbedSpeedY = MathHelper.ToRadians(90);
                }
                else if ((360 / actualShots) * (counter - 1) < 270)
                {
                    if ((180 - ((360 / actualShots) * (counter - sectorOne))) < 0)
                    {
                        perturbedSpeedX = -MathHelper.ToRadians(270 - Math.Abs((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = MathHelper.ToRadians(Math.Abs(((360 / actualShots) * (counter - sectorOne)) - 180));
                    }
                    else
                    {
                        if (actualShots == 8)
                        {
                            perturbedSpeedX = -MathHelper.ToRadians(45);
                            perturbedSpeedY = MathHelper.ToRadians(45);
                        }
                        else
                        {
                            perturbedSpeedX = -MathHelper.ToRadians(90 - ((360 / actualShots) * (counter - sectorOne * 2)));
                            perturbedSpeedY = MathHelper.ToRadians((360 / actualShots) * (counter - sectorOne * 2));
                        }
                    }
                }
                //Sector 4
                else if (((counter - 1) * (360 / actualShots)) == 360)
                {
                    perturbedSpeedX = MathHelper.ToRadians(90);
                    perturbedSpeedY = MathHelper.ToRadians(0);
                }
                else if ((360 / actualShots) * (counter - 1) <= 360)
                {
                    if ((270 - ((360 / actualShots) * (counter - sectorOne))) < 0)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(360 - Math.Abs((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = MathHelper.ToRadians(Math.Abs(((360 / actualShots) * (counter - sectorOne)) - 270));
                    }
                    else if (actualShots == 6)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(30);
                        perturbedSpeedY = MathHelper.ToRadians(60);
                    }
                    else if (actualShots == 8)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(30);
                        perturbedSpeedY = MathHelper.ToRadians(60);
                    }
                    else if (actualShots == 16)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(90 - ((360 / actualShots) * (counter - sectorOne * 2.5f)));
                        perturbedSpeedY = MathHelper.ToRadians((360 / actualShots) * (counter - sectorOne * 2.5f));
                    }
                    else
                    {
                        perturbedSpeedX = MathHelper.ToRadians(90 - ((360 / actualShots) * (counter % sectorOne)));
                        perturbedSpeedY = MathHelper.ToRadians((360 / actualShots) * (counter % sectorOne));
                    }
                }
                //Failsafe
                else
                {
                    perturbedSpeedX = Main.rand.Next(-6, 6);
                    perturbedSpeedY = Main.rand.Next(-6, 6);
                }
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeedX*3f, perturbedSpeedY*3f, mod.ProjectileType("Splinter"), projectile.damage - 10, 0.2f, Main.myPlayer);
            }
            {
                projectile.Kill();
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
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
            if (Main.player[projectile.owner].GetModPlayer<ThrowingPlayer>(mod).Penetration1 == true && penetration1 == false)
            {
                projectile.penetrate += 1;
                penetration1 = true;
            }

            if (Main.player[projectile.owner].GetModPlayer<ThrowingPlayer>(mod).Penetration1 == false && penetration1 == true)
            {
                projectile.penetrate -= 1;
                penetration1 = false;
            }
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
    }
}