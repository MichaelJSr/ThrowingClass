using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ThrowingClass
{
    public class ThrowingClass : Mod
    {
        public static ThrowingClass Instance;

        public override void Load()
        {
            Instance = this;
            LanguageManager.Instance.OnLanguageChanged += ThrowingTweaksLang.EditTooltips;
            ThrowingTweaksLang.AddText();
        }
    }
}

