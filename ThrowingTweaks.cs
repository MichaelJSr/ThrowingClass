using System;
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
		const string VikingSet = "throwing viking";
		
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.GladiatorHelmet:
						item.rare = 1;
						item.defense = 5;
					return;

				case ItemID.GladiatorBreastplate:
						item.rare = 1;
						item.defense = 6;
					return;

				case ItemID.GladiatorLeggings:
						item.rare = 1;
						item.defense = 5;
					return;

				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
						item.rare = 1;
					return;

                case ItemID.StakeLauncher:
                        item.ranged = false;
                        item.thrown = true;
                    return;

                case ItemID.Javelin:
                case ItemID.BoneJavelin:
                case ItemID.FrostDaggerfish:
                        item.ammo = AmmoID.Stake;
                        item.autoReuse = true;
                        item.value = Item.buyPrice(0, 0, 4, 0);
                    return;

                case ItemID.Shuriken:
                case ItemID.StarAnise:
                        item.autoReuse = true;
                        item.ammo = ItemID.Shuriken;
                    return;

                case ItemID.ThrowingKnife:
                case ItemID.PoisonedKnife:
                case ItemID.BoneDagger:
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
			if(armorSet == GladiatorSet)
			{
				player.setBonus = Language.GetTextValue("Mods.ThrowingClass.ArmorSet.Gladiator");
				player.meleeCrit += 10;
				player.thrownCrit += 10;
                player.meleeDamage += 0.1f;
                player.thrownDamage += 0.1f;
            }
            else if (armorSet == VikingSet)
            {
                player.setBonus = Language.GetTextValue("Mods.ThrowingClass.ArmorSet.Viking");
                player.meleeDamage += 0.15f;
                player.thrownDamage += 0.15f;
            }
            else if(armorSet == ObsidianSet)
			{
				player.setBonus = Language.GetTextValue("Mods.ThrowingClass.ArmorSet.Obsidian");
				player.moveSpeed += 0.1f;
                player.thrownDamage += 0.1f;
            }
		}
    }
}