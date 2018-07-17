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
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
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

        public bool shot = false;

        public override void RightClick(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            for (int k = 0; k < 58; k++)
            {
                var localItem = Main.player[Main.myPlayer].inventory[k];
                if (localItem.ammo == ItemID.Javelin && localItem.stack > 0 && shot == false)
                {
                    if (localItem.consumable)
                        localItem.stack--;
                    if (localItem.stack <= 0)
                    {
                        localItem.SetDefaults(0, false);
                    }

                    int ammo = localItem.shoot;
                    if (tile.frameX > 70)
                    {
                        Projectile.NewProjectile(i * 16, j * 16, localItem.shootSpeed * 1.5f, 0f, localItem.shoot, localItem.damage * 2, localItem.knockBack * 2, Main.myPlayer);
                    }
                    else
                    {
                        Projectile.NewProjectile(i * 16, j * 16, localItem.shootSpeed * -1.5f, 0f, localItem.shoot, localItem.damage * 2, localItem.knockBack * 2, Main.myPlayer);
                    }
                    Main.PlaySound(SoundID.Item56); // Boing
                    shot = true;
                }
            }
            shot = false;
        }
    }
}