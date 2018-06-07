using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class Splinter : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splinter");
        }
        public override void SetDefaults()
        {
            projectile.width = 16; //Set the hitbox width
            projectile.height = 18; //Set the hitbox height
            projectile.timeLeft = 15; //The amount of time the projectile is alive for
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.thrown = true; //Tells the game whether it is a throwing projectile or not
            projectile.aiStyle = 0; //How the projectile works, this is no AI, it just goes a straight path
        }
        public override void AI()
        {
            // Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
            projectile.rotation =
                projectile.velocity.ToRotation() +
                MathHelper.ToRadians(0f); // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!
        }
    }
}