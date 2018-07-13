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
    public class JavelinBallista : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoFail[Type] = true;

            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //allows me to place example chairs facing the same way as the player
            TileObjectData.addAlternate(1); //facing right will use the second texture style
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Javelin Ballista");
            AddMapEntry(new Color(200, 200, 200), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, DropType(frameX));
        }

        public int DropType(int frameX)
        {
            int style = frameX / 146;
            switch (style)
            {
                case 0: return mod.ItemType("JavelinBallista");
                default: return 0;
            }
        }

        public override void MouseOver(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            if (tile == null || !tile.active())
                return;

            Main.LocalPlayer.showItemIcon2 = ItemID.Javelin;
            Main.LocalPlayer.showItemIcon = true;
        }
    }
}