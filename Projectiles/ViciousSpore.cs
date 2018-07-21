using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class ViciousSpore : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vicious Spore");
        }
        public override void SetDefaults()
        {
            projectile.width = 12; //Set the hitbox width
            projectile.height = 18; //Set the hitbox height
            projectile.timeLeft = 240; //The amount of time the projectile is alive for
            projectile.penetrate = 2; //Tells the game how many enemies it can hit before being destroyed
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.thrown = true; //Tells the game whether it is a throwing projectile or not
            projectile.aiStyle = -1; //How the projectile works, this is no AI, it just goes a straight path
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            // For going through platforms and such, javelins use a tad smaller size
            width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
            return true;
        }

        public float targetWhoAmI
        {
            get { return projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }

        private const int alphaReduction = 25;
        private const int maxTicks = 50;
        public int timer = 0;

        public override void AI()
        {
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
            timer += 1;
            // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
            if (timer <= maxTicks)
            {
                // Change these multiplication factors to alter the javelin's movement change after reaching maxTicks
                float velXmult = 0.98f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
                float velYmult = 0.2f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
                targetWhoAmI = maxTicks; // set ai1 to maxTicks continuously
                projectile.velocity.X = projectile.velocity.X * velXmult;
                projectile.velocity.Y = projectile.velocity.Y + velYmult;
            }
            else
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    //If the npc is hostile
                    if (!target.friendly && target.type != NPCID.TargetDummy)
                    {
                        //Get the shoot trajectory from the projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                        float shootToY = target.position.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the distance between the live targeted npc and the projectile is less than 480 pixels
                        if (distance < 600f && !target.friendly && target.active)
                        {
                            //Divide the factor, 3f, which is the desired velocity
                            distance = 2.5f / distance;

                            //Multiply the distance by a multiplier if you wish the projectile to have go faster
                            shootToX *= distance * 1;
                            shootToY *= distance * 1;

                            //Set the velocities to the shoot values
                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                        }
                    }
                }
            }
        }
    }
}