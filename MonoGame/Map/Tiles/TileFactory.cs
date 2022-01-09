using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    internal static class BlockFactory
    {
        private const int TileSetWidth = 17;
        private const int TileSetHeight = 100;
        private const int TileSetOffset = -1;
        private const int BlockSize = 16;
        private const int Margin = 2;

        public static Tile CreateBlock(int blockId, int x, int y, Texture2D texture, int size)
        {
            blockId += TileSetOffset;
            if (blockId == -1) return null;
            if (blockId is < TileSetOffset or > TileSetWidth * TileSetHeight + TileSetOffset)
                throw new Exception("BlockId is out of range");

            var virtualX = blockId % TileSetWidth;
            var virtualY = (blockId - virtualX) / TileSetWidth;

            var realX = virtualX * BlockSize + virtualX * Margin;
            var realY = virtualY * BlockSize + virtualY * Margin;
            var sourceRectangle = new Rectangle(realX, realY, BlockSize, BlockSize);

            var tile = new Tile(sourceRectangle, x, y, texture, size);
            if (TileConfigs.TryGetValue(blockId, out var config))
            {
                tile.IsPassable = config.IsPassable;
                tile.Type = config.Type;
            }

            return tile;
        }

        private static readonly Dictionary<int, TileConfig> TileConfigs = new()
        {
            { 0, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 14, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 15, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 16, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 17, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 19, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 20, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 21, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 22, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 23, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 24, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 37, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 38, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 39, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 40, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 41, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 42, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 43, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 44, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 45, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 46, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 47, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 51, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 58, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 59, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 61, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 62, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 63, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 64, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 65, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 69, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 72, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 74, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 75, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 76, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 78, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 79, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 80, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 81, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 82, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 86, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 91, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 92, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 93, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 95, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 96, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 98, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 99, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 106, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 109, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 110, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 111, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 112, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 113, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 114, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 115, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 116, new TileConfig() { Type = TileType.Default, IsPassable = true } },


            { 126, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 127, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 128, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 129, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 130, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 131, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 132, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 133, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 134, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 135, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 140, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 141, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 142, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 143, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 144, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 145, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 146, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 157, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 158, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 159, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 160, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 161, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 162, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 163, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 170, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 171, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 172, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 186, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 203, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 204, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 205, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 209, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 210, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 211, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 220, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 221, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 222, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 226, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 227, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 228, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 237, new TileConfig() { Type = TileType.Default, IsPassable = true } },

            { 238, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 239, new TileConfig() { Type = TileType.DamageBlock, IsPassable = true } },
            { 243, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 244, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 245, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 312, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 313, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 314, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 329, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 330, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 331, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 346, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 347, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 348, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 363, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 364, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 365, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 380, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 381, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 382, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 397, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 398, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 399, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            
            { 414, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 415, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 416, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            
            { 431, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 432, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 433, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            
            { 448, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 449, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            { 450, new TileConfig() { Type = TileType.FinishBlock, IsPassable = false } },
            
            { 493, new TileConfig() { Type = TileType.Default, IsPassable = true } },
            { 494, new TileConfig() { Type = TileType.Default, IsPassable = true } },
        };
    }
}