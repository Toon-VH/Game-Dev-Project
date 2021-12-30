using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    internal static class BlockFactory
    {
        private const int TileSetWidth = 27;
        private const int TileSetHeight = 31;
        private const int TileSetOffset = -1;
        private const int BlockSize = 16;
        private const int Margin = 2;

        public static Tile CreateBlock(int blockId, int x, int y, Texture2D texture, int size)
        {
            blockId += TileSetOffset;
            if (blockId == -1) return null;
            if (blockId is < TileSetOffset or > TileSetWidth * TileSetHeight + TileSetOffset) throw new Exception("BlockId is out of range");

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
            { 0, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 1, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 2, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 3, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 4, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 5, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 6, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 7, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 11, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 12, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 27, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 28, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 35, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 36, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 38, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 39, new TileConfig { Type = TileType.Default, IsPassable = false } },

            { 53, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 54, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 55, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 56, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 68, new TileConfig { Type = TileType.Default, IsPassable = false } },

            { 70, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 73, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 83, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 84, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 85, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 86, new TileConfig { Type = TileType.Default, IsPassable = false } },

            { 87, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 90, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 107, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 110, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 136, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 137, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 138, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 139, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 153, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 154, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 155, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 156, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 164, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 192, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 207, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 208, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 209, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 210, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 211, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 216, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 217, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 218, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 219, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 243, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 244, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 245, new TileConfig { Type = TileType.Default, IsPassable = false } },
            { 246, new TileConfig { Type = TileType.Default, IsPassable = false } },
        };
    }
}