using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.UI;

namespace ThrowingClass
{
	public class ThrowingTweaks : GlobalItem
	{
		const string GladiatorSet = "throwing gladiator";
		const string ObsidianSet = "throwing obsidian";
		
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.GladiatorHelmet:
					item.rare = 1;
					item.defense = 4;
					return;

				case ItemID.GladiatorBreastplate:
					item.rare = 1;
					item.defense = 5;
					return;

                case ItemID.GladiatorLeggings:
                    item.rare = 1;
                    item.defense = 4;
                    return;

                case ItemID.FossilHelm:
                    item.defense = 5;
                    return;

                case ItemID.FossilPants:
                    item.defense = 5;
                    return;

                case ItemID.ObsidianHelm:
                    item.defense = 4;
                    item.rare = 1;
                    return;

				case ItemID.ObsidianShirt:
                    item.defense = 4;
                    item.rare = 1;
                    return;

				case ItemID.ObsidianPants:
                    item.defense = 3;
				    item.rare = 1;
					return;

                case ItemID.StakeLauncher:
                    item.ranged = false;
                    item.thrown = true;
                    return;

                case ItemID.Javelin:
                case ItemID.BoneJavelin:
                    item.ammo = AmmoID.Stake;
                    item.autoReuse = true;
                    item.value = Item.buyPrice(0, 0, 2, 0);
                    return;

                case ItemID.Shuriken:
                case ItemID.StarAnise:
                    item.autoReuse = true;
                    item.ammo = ItemID.Shuriken;
                    return;

                case ItemID.ThrowingKnife:
                case ItemID.PoisonedKnife:
                case ItemID.BoneDagger:
                case ItemID.FrostDaggerfish:
                    item.autoReuse = true;
                    item.ammo = ItemID.ThrowingKnife;
                    return;

                case ItemID.Grenade:
                case ItemID.StickyGrenade:
                case ItemID.BouncyGrenade:
                case ItemID.PartyGirlGrenade:
                case ItemID.Beenade:
                case ItemID.MolotovCocktail:
                    item.autoReuse = true;
                    item.ammo = ItemID.Grenade;
                    return;

                case ItemID.Beenade:
                    item.damage = 10;
                    return;

                case ItemID.SpikyBall:
                        item.autoReuse = true;
                        item.ammo = ItemID.SpikyBall;
                    return;

                case ItemID.Snowball:
                        item.autoReuse = true;
                    return;

                case ItemID.Bone:
                    item.autoReuse = true;
                    item.ammo = ItemID.Bone;
                    return;

                case ItemID.RottenEgg:
                    item.autoReuse = true;
                    item.ammo = ItemID.RottenEgg;
                    return;
            }

            if (ModLoader.GetLoadedMods().Contains("Infinity"))
                if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessJavelin"))
                {
                    item.ammo = AmmoID.Stake;
                    item.autoReuse = true;
                }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessBoneJavelin"))
            {
                item.ammo = AmmoID.Stake;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessShuriken"))
            {
                item.ammo = ItemID.Shuriken;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessStarAnise"))
            {
                item.ammo = ItemID.Shuriken;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessKnife"))
            {
                item.ammo = ItemID.ThrowingKnife;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessKnifePoisoned"))
            {
                item.ammo = ItemID.ThrowingKnife;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessBoneKnife"))
            {
                item.ammo = ItemID.ThrowingKnife;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessFrostDaggerfish"))
            {
                item.ammo = ItemID.ThrowingKnife;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessGrenade"))
            {
                item.ammo = ItemID.Grenade;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessGrenadeSticky"))
            {
                item.ammo = ItemID.Grenade;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessGrenadeBouncy"))
            {
                item.ammo = ItemID.Grenade;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessPartyGirlGrenade"))
            {
                item.ammo = ItemID.Grenade;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessBeenade"))
            {
                item.ammo = ItemID.Grenade;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessMolotovCocktail"))
            {
                item.ammo = ItemID.Grenade;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessSpikyBall"))
            {
                item.ammo = ItemID.SpikyBall;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessBone"))
            {
                item.ammo = ItemID.Bone;
                item.autoReuse = true;
            }
            if (item.type == ModLoader.GetMod("Infinity").ItemType("EndlessRottenEgg"))
            {
                item.ammo = ItemID.RottenEgg;
                item.autoReuse = true;
            }
        }
		
		public override void UpdateEquip(Item item, Player player)
		{
			switch(item.type)
			{
				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
						player.thrownCrit += 3;
					return;

                case ItemID.GladiatorHelmet:
                case ItemID.GladiatorBreastplate:
                case ItemID.GladiatorLeggings:
                        player.meleeCrit += 2;
                        player.thrownCrit += 2;
                        player.meleeDamage += 0.02f;
                        player.thrownDamage += 0.02f;
                    return;

                case ItemID.VikingHelmet:
                        player.thrownDamage += 0.02f;
                        player.meleeDamage += 0.02f;
                    return;
			}
		}

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.GladiatorHelmet && body.type == ItemID.GladiatorBreastplate && legs.type == ItemID.GladiatorLeggings)
                return GladiatorSet;

            if (head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants)
                return ObsidianSet;
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateArmorSet(Player player, string armorSet)
		{
			if (armorSet == GladiatorSet)
			{
				player.setBonus = Language.GetTextValue("Mods.ThrowingClass.ArmorSet.Gladiator");
				player.meleeCrit += 10;
				player.thrownCrit += 10;
                player.meleeDamage += 0.1f;
                player.thrownDamage += 0.1f;
            }
            else if (armorSet == ObsidianSet)
			{
				player.setBonus = Language.GetTextValue("Mods.ThrowingClass.ArmorSet.Obsidian");
				player.moveSpeed += 0.1f;
                player.thrownDamage += 0.1f;
            }
		}
    }
}