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

namespace ThrowingClass
{
    public class ThrowingClass : Mod
    {
        public static ThrowingClass Instance;

        public override void Load()
        {
            Instance = this;
            ThrowingTweaksLang.AddText();
            ThrowingConfig.Load();
        }
    }
}

