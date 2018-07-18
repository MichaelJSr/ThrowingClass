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
using ThrowingClass.Items.Weapons.Launchers;

namespace ThrowingClass
{
    public class ThrowingPlayer : ModPlayer
    {
        public float thrownSpeed = 1f;
        public int numberShots = 0;
        public float chanceShots = 0.05f;
        public int penetration = 0;
        public bool TruePoison = false;
        public bool DiamondBreak = false;
        public bool TrueDiamondBreak = false;
        //20% Chance for 2 shots
        public bool Munition1 = false;
        //20% Chance not to consume ammo
        public bool Munition2 = false;
        //+1 Penetration
        public bool Sharp1 = false;
        //Heals for 3 seconds if you hit an enemy
        public bool PalladiumGalea = false;

        public override void ResetEffects()
        {
            thrownSpeed = 1f;
            TruePoison = false;
            DiamondBreak = false;
            TrueDiamondBreak = false;
            Munition1 = false;
            Munition2 = false;
            Sharp1 = false;
            PalladiumGalea = false;
        }

        int tempType = 0;
        bool tempTypeTrue = false;
        int tempDmg = 0;
        int tempUseTime = 0;
        int tempUseAnimation = 0;
        int tempDmg2 = 0;
        int tempUseTime2 = 0;
        int tempUseAnimation2 = 0;

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            penCount = 0;
            if (item.thrown)
            {
                if (item.shoot == 10)
                {
                    //Javelins
                    if (type == mod.ProjectileType("TrueSapphireJavelin"))
                    {
                        tempDmg = 10;
                        tempUseTime = 14;
                        tempUseAnimation = 12;
                    }

                    else if (type == mod.ProjectileType("SapphireJavelin"))
                    {
                        tempDmg = 5;
                        tempUseTime = 10;
                        tempUseAnimation = 10;
                    }

                    else if (type == mod.ProjectileType("TrueDiamondJavelin") || type == mod.ProjectileType("TrueAmberJavelin") || type == mod.ProjectileType("TrueHellfireJavelin") || type == mod.ProjectileType("TrueJesterJavelin") || type == mod.ProjectileType("TrueMeteorJavelin"))
                    {
                        tempUseTime = 8;
                        tempUseAnimation = 8;
                    }

                    else if (type == mod.ProjectileType("DiamondJavelin") || type == mod.ProjectileType("AmberJavelin") || type == mod.ProjectileType("MeteorJavelin") || type == mod.ProjectileType("JesterJavelin") || type == mod.ProjectileType("HellfireJavelin") || type == mod.ProjectileType("TrueAmethystJavelin") || type == mod.ProjectileType("TrueTopazJavelin") || type == mod.ProjectileType("TrueEmeraldJavelin") || type == mod.ProjectileType("TrueRubyJavelin") || type == mod.ProjectileType("SplinterJavelin"))
                    {
                        tempUseTime = 4;
                        tempUseAnimation = 4;
                    }
                    //Grenades
                    if (type == ProjectileID.HappyBomb)
                    {
                        tempUseTime = 20;
                        tempUseAnimation = 20;
                    }

                    else if (type == ProjectileID.Beenade || type == mod.ProjectileType("Waspnade"))
                    {
                        tempDmg = 30;
                        tempUseTime = 12;
                        tempUseAnimation = 12;
                    }

                    else if (type == ProjectileID.BouncyGrenade || type == ProjectileID.MolotovCocktail)
                    {
                        tempUseTime = 5;
                        tempUseAnimation = 5;
                    }
                    //Knives
                    if (type == ProjectileID.ShadowFlameKnife)
                    {
                        tempUseTime = 3;
                        tempUseAnimation = 3;
                    }

                    else if (type == ProjectileID.FrostDaggerfish)
                    {
                        tempUseTime = 2;
                        tempUseAnimation = 2;
                    }

                    else if (type == ProjectileID.BoneDagger)
                    {
                        tempUseTime = 1;
                        tempUseAnimation = 1;
                    }

                    if ((tempType != type) && tempTypeTrue == false)
                    {
                        tempDmg2 = tempDmg;
                        tempUseTime2 = tempUseTime;
                        tempUseAnimation2 = tempUseAnimation;
                        item.damage -= tempDmg;
                        item.useTime -= tempUseTime;
                        item.useAnimation -= tempUseAnimation;
                        tempTypeTrue = true;
                        tempType = type;
                    }
                    else if ((tempType != type) && tempTypeTrue == true)
                    {
                        item.damage += tempDmg2;
                        item.useTime += tempUseTime2;
                        item.useAnimation += tempUseAnimation2;
                        tempTypeTrue = false;
                    }

                    if (item.useTime < 2 || item.useAnimation < 2)
                    {
                        item.useTime = 2;
                        item.useAnimation = 2;
                    }
                }
                int actualShots = 1;
                int chance = 0;
                int fired = 0;
                int odd = 0;
                int checkOdd = 0;
                int even = 0;
                int checkEven = -1;
                float rotation = MathHelper.ToRadians(6f);
                position += Vector2.Normalize(new Vector2(speedX, speedY)) * 6f;
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
                    if (fired % 2 != 1 && actualShots % 2 != 1)
                    {
                        even = 1;
                    }
                    if (fired == 0)
                    {
                        checkEven -= 1;
                    }
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(rotation / (1 - checkOdd - checkEven) * (fired - odd % 2 + even)); // Watch out for dividing by 0 if there is only 1 projectile.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    rotation = -rotation;
                    if (fired % 2 != 1)
                    {
                        even = 0;
                    }
                    fired += 1;
                    if (fired != 1 && actualShots % 2 != 0)
                    {
                        odd += 1;
                    }
                    if (fired == 1)
                    {
                        checkOdd -= 1;
                    }
                    penCount += 1;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        int penCount = 0;

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if ((proj.thrown) && (proj.penetrate != -1) && !proj.noEnchantments && penCount > 0)
            {
                proj.penetrate += penetration;
                penCount -= 1;
            }
            if ((proj.type == mod.ProjectileType("SplinterJavelin")) || (proj.type == mod.ProjectileType("MakeshiftJavelin")))
            {
                int actualShots = 1;
                int chance = 4;
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
                    //Check which splitting javelin is being used
                    if (proj.type == mod.ProjectileType("MakeshiftJavelin"))
                    {
                        Projectile.NewProjectile(proj.position.X, proj.position.Y, perturbedSpeedX * 3f, perturbedSpeedY * 3f, mod.ProjectileType("Splinter"), proj.damage - 10, 0.2f, Main.myPlayer);
                    }
                    else if (proj.type == mod.ProjectileType("SplinterJavelin"))
                    {

                        Projectile.NewProjectile(proj.position.X, proj.position.Y, perturbedSpeedX * 3f, perturbedSpeedY * 3f, mod.ProjectileType("MakeshiftJavelin"), proj.damage - 20, 0.2f, Main.myPlayer);
                    }
                }
            }

            if (PalladiumGalea == true)
            {
                player.AddBuff(BuffID.RapidHealing, 180);
            }
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
            thrownSpeed = 1f;
            TruePoison = false;
            DiamondBreak = false;
            TrueDiamondBreak = false;
            Munition1 = false;
            Munition2 = false;
            Sharp1 = false;
            PalladiumGalea = false;
        }

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("WoodenJavelinWeapon"));
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

        public bool Munition1Equip = false;
        public bool Sharp1Equip = false;

        public override void PostUpdateBuffs()
        {
            if ((Munition1 == true) && (Munition1Equip == false))
            {
                numberShots += 2;
                chanceShots += 0.2f;
                Munition1Equip = true;
            }
            else if ((Munition1 == false) && (Munition1Equip == true))
            {
                numberShots -= 2;
                chanceShots -= 0.2f;
                Munition1Equip = false;
            }
            if ((Sharp1 == true) && (Sharp1Equip == false))
            {
                penetration += 1;
                Sharp1Equip = true;
            }
            else if ((Sharp1 == false) && (Sharp1Equip == true))
            {
                penetration -= 1;
                Sharp1Equip = false;
            }
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            if (Munition2 == true && weapon.thrown == true)
            {
                return Main.rand.NextFloat() >= .2f;
            }
            return true;
        }

        public override float UseTimeMultiplier(Item item)
        {
            if (item.thrown && item.useAnimation > 2)
            {
                return thrownSpeed;
            }
            else
            {
                return 1f;
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk) return; // Don't do stuff if the catch is a junk catch

            bool common, uncommon, rare, veryrare, superrare, isCrate;
            calculateCatchRates(power, out common, out uncommon, out rare, out veryrare, out superrare, out isCrate);

            if (liquidType != 0) return; // Uness it's special, all fish are caught in water only

            // Do catch stuff here
            if (isCrate)
            {
                if (uncommon)
                {
                    caughtType = mod.ItemType("ThrowingCrate");
                }
            }
        }


        /// <summary>
        /// Calculate the base catch rates for different tiers of fish. Parameter chances are shown at 50% fishing power. Examples of fish at each tier, plus individual catch rates:
        /// <para> Common: Neon Tetra, Crimson Tigerfish, Atlantic Cod, Red Snapper (1/2)</para>
        /// <para> Uncommon: Damselfish, Frost Minnow, Ebonkoi</para>
        /// <para> Rare: Honeyfin, Prismite, Purple Clubberfish</para>
        /// <para> Very Rare: Sawtooth Shark, Flarefin Koi, Golden Crate</para>
        /// <para> Extremely Rare: Obsidian Swordfish, Toxikarp (1/2),  Bladetongue (1/2), Balloon Pufferfish (1/5), Zephyr Fish (1/10)</para>
        /// If all else fails, Terraria rewards the player with a Bass (or Trout in the ocean).
        /// </summary>/
        /// <param name="power">The fishing skill. </param>
        /// <param name="common">33.3% = power:150 (capped 1:2). /</param>
        /// <param name="uncommon">16.7% = power:300 (capped 1:3). </param>
        /// <param name="rare">4.8% = power:1050 (capped 1:4). </param>
        /// <param name="veryrare">2.2% = power:2250 (capped 1:5). </param>
        /// <param name="superrare">1.1% = power:4500 (capped 1:6). </param>
        /// <param name="isCrate">1:10, 1:5 with crate potion. </param>
        public void calculateCatchRates(int power, out bool common, out bool uncommon, out bool rare, out bool veryrare, out bool superrare, out bool isCrate)
        {
            common = false;
            uncommon = false;
            rare = false;
            veryrare = false;
            superrare = false;
            isCrate = false;

            if (power <= 0) return;

            if (Main.rand.Next(Math.Max(2, 150 * 1 / power)) == 0)
            { common = true; }
            if (Main.rand.Next(Math.Max(3, 150 * 2 / power)) == 0)
            { uncommon = true; }
            if (Main.rand.Next(Math.Max(4, 150 * 7 / power)) == 0)
            { rare = true; }
            if (Main.rand.Next(Math.Max(5, 150 * 15 / power)) == 0)
            { veryrare = true; }
            if (Main.rand.Next(Math.Max(6, 150 * 30 / power)) == 0)
            { superrare = true; }
            if (Main.rand.Next(100) < (10 + (player.cratePotion ? 10 : 0)))
            { isCrate = true; }
        }
    }
}