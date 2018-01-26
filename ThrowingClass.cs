using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Localization;
using ThrowingClass.Tiles;

namespace ThrowingClass
{
    public class ThrowingClass : Mod
    {
        public static ThrowingClass Instance;
        public enum ModMessageID { RotateTurret, ProjectileMakeHostile, KickFromChest }

        public override void Load()
        {
            Instance = this;
            LanguageManager.Instance.OnLanguageChanged += ThrowingTweaksLang.EditTooltips;
            ThrowingTweaksLang.AddText();
        }
    }
}

