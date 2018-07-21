using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class ShroomNade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ShroomNade");
        }

        public override void SetDefaults()
        {
            projectile.timeLeft = 300;
            projectile.width = 14;
            projectile.height = 20;
            projectile.penetrate = 1;
            aiType = ProjectileID.Grenade;
            projectile.friendly = true;
            projectile.thrown = true;
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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.timeLeft >= 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Kill(int timeLeft)
        {
            //Search through array
            for (int i = 0; i < Main.npc.Length - 1; i++)
            {
                NPC N = Main.npc[i];
                float dX = N.Center.X - projectile.Center.X;
                float dY = N.Center.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(dX * dX + dY * dY));

                //So if the distance between the killed projectile and the npc is less than 80 pixels...
                if (distance < 120f && !N.friendly && N.active && (N.type != NPCID.DD2LanePortal))
                {
                    N.StrikeNPC(projectile.damage, 0f, N.direction, false, false, false); //Damages and shows damage on the NPC, this accounts for the defense of the NPC as well.
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            int num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 63), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore85 = Main.gore[num373];
            gore85.velocity.X = gore85.velocity.X + 1f;
            Gore gore86 = Main.gore[num373];
            gore86.velocity.Y = gore86.velocity.Y + 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 63), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore87 = Main.gore[num373];
            gore87.velocity.X = gore87.velocity.X - 1f;
            Gore gore88 = Main.gore[num373];
            gore88.velocity.Y = gore88.velocity.Y + 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 63), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore89 = Main.gore[num373];
            gore89.velocity.X = gore89.velocity.X + 1f;
            Gore gore90 = Main.gore[num373];
            gore90.velocity.Y = gore90.velocity.Y - 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 63), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore gore91 = Main.gore[num373];
            gore91.velocity.X = gore91.velocity.X - 1f;
            Gore gore92 = Main.gore[num373];
            gore92.velocity.Y = gore92.velocity.Y - 1f;
            for (int spore = 0; spore < Main.rand.Next(3, 8); spore++)
            {
                float chance = Main.rand.NextFloat();
                if (chance < .15f)
                {
                    Projectile.NewProjectile(projectile.position.X + 6, projectile.position.Y, Main.rand.Next(-10, 10), Main.rand.Next(-12, -6), mod.ProjectileType("GlowingSpore"), (int)(projectile.damage * 0.75f), 0f, Main.myPlayer);
                }
                else if (chance < .5f)
                {
                    Projectile.NewProjectile(projectile.position.X + 6, projectile.position.Y, Main.rand.Next(-10, 10), Main.rand.Next(-12, -6), mod.ProjectileType("ViciousSpore"), (int)(projectile.damage * 0.5f), 0f, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(projectile.position.X + 6, projectile.position.Y, Main.rand.Next(-10, 10), Main.rand.Next(-12, -6), mod.ProjectileType("MushroomSpore"), (int)(projectile.damage * 0.25f), 0f, Main.myPlayer);
                }
            }
        }

        public override void AI()
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 120;
                projectile.height = 120;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.damage = mod.GetItem("ShroomNade").item.damage;
                projectile.knockBack = mod.GetItem("ShroomNade").item.knockBack;
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 5f)
            {
                projectile.ai[0] = 10f;
                // Roll speed dampening.
                if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.97f;
                    //if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.99f;
                    }
                    if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
                    {
                        projectile.velocity.X = 0f;
                        projectile.netUpdate = true;
                    }
                }
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            // Rotation increased by velocity.X 
            projectile.rotation += projectile.velocity.X * 0.1f;
            return;
        }

    }
}