using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ThunderfuryBlessedBladeOfTheWindseeker.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class Thunder : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thunderfury, Blessed Blade Of The Windseeker");
        }
        public override void SetDefaults()
        {
            projectile.width = 16; //Set the hitbox width
            projectile.height = 16; //Set the hitbox height
            projectile.timeLeft = 60; //The amount of time the projectile is alive for
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
            projectile.melee = true; //Tells the game whether it is a meelee projectile or not
            projectile.aiStyle = 0; //How the projectile works, this is no AI, it just goes a straight path
        }
        public override void AI() //The projectile's AI/ what the projectile does
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.light = 0.9f; //Lights up the whole room
            projectile.alpha = 128; //Semi Transparent
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Spawns dust
            Main.dust[DustID].noGravity = true; //Makes dust not fall
            projectile.ai[0] += 1f;
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 10;
                        shootToY *= distance * 10;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }
    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //Calls when you hit an enemy
        {
            target.AddBuff(mod.BuffType("ThundersWrath"), 600);    //this adds the buff to the npc that got hit by this projectile , 600 is the time the buff lasts
        }
    }
}