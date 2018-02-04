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
            var text = mod.CreateTranslation("ArmorSet.Obsidian");
			text.SetDefault("10% increased movement speed\n10% increased throwing damage");
            text = mod.CreateTranslation("ArmorSet.Gladiator");
			text.SetDefault("10% increased meelee and throwing critical strike chance\n10% increased meelee and throwing damage");
        }
	}
}
