using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ThrowingClass.Tiles
{
    public class MunitionsPack : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoFail[Type] = true;

            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Munitions Pack");
            AddMapEntry(new Color(200, 200, 200), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("MunitionsPack"));
        }

        public override void MouseOver(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            if (tile == null || !tile.active())
                return;

            Main.LocalPlayer.showItemIcon2 = mod.ItemType("MunitionsPack");
            Main.LocalPlayer.showItemIcon = true;
        }

        public override void RightClick(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            if (tile == null || !tile.active())
                return;
            int myPlayer = Main.myPlayer;
            Main.player[myPlayer].AddBuff(mod.BuffType("Munition2"), 36000);
            Main.PlaySound(SoundID.Item37);
        }
    }
}