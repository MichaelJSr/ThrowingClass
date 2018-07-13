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
    public class ThrowingCrate : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;     //this make so the tile is solid on top like a table
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;   //this make so you can place another tile on the top      
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Throwing Crate");
            AddMapEntry(new Color(20, 120, 200), name);  //this defines the color and the name when you see this tile on the map
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("ThrowingCrate"));
        }
    }
}