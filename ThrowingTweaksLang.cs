using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ThrowingClass
{
	public static class ThrowingTweaksLang
	{
		public static void AddText()
		{
			var mod = ThrowingClass.Instance;
			var text = mod.CreateTranslation("ItemTooltip.ObsidianArmor");
			text.SetDefault("3% increased throwing critical strike chance");
            mod.AddTranslation(text);

            text = mod.CreateTranslation("ArmorSet.Obsidian");
			text.SetDefault("10% increased movement speed\n10% increased throwing damage\n9% increased throwing critical strike chance");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("ArmorSet.Gladiator");
			text.SetDefault("10% increased meelee and throwing critical strike chance\n10% increased meelee and throwing damage");
            mod.AddTranslation(text);
            text = mod.CreateTranslation("ArmorSet.Viking");
			text.SetDefault("15% increased meelee and throwing damage");
            mod.AddTranslation(text);
        }

		public static void EditTooltips(LanguageManager manager)
		{
			var bindFlags = BindingFlags.Static | BindingFlags.NonPublic;
			var tooltipsField = typeof(Lang).GetField("_itemTooltipCache", bindFlags);
			var tooltips = (ItemTooltip[])tooltipsField.GetValue(null);
				tooltips[ItemID.ObsidianHelm] = ItemTooltip.FromLanguageKey("Mods.ThrowingClass.ItemTooltip.ObsidianArmor");
				tooltips[ItemID.ObsidianShirt] = ItemTooltip.FromLanguageKey("Mods.ThrowingClass.ItemTooltip.ObsidianArmor");
				tooltips[ItemID.ObsidianPants] = ItemTooltip.FromLanguageKey("Mods.ThrowingClass.ItemTooltip.ObsidianArmor");
		}
	}
}
