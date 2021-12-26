using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    class BlockFactory
    {
        public static Tile CreateBlock(BlockType type, int x, int y, Texture2D texture, int size)
        {

            Tile newTile = null;
            switch (type)
            {
                case BlockType.Dirt:
                    newTile = new DirtTile(x, y, texture, size);
                    break;
                case BlockType.GrassBlock:
                    newTile = new GrassTile(x, y, texture, size);
                    break;
                case BlockType.GrassBlock2:
                    newTile = new GrassBlock(x, y, texture, size);
                    break;
                case BlockType.GrassLeftCorner:
                    newTile = new GrassLeftCorner(x, y, texture, size);
                    break;
                case BlockType.GrassRightCorner:
                    newTile = new GrassRightCorner(x, y, texture, size);
                    break;
                case BlockType.Dirt2:
                    newTile = new DirtTile2(x, y, texture, size);
                    break;
                case BlockType.LeftRock:
                    newTile = new LeftRock(x, y, texture, size);
                    break;
                case BlockType.SideRightBlock:
                    newTile = new SideRightBlock(x, y, texture, size);
                    break;
                case BlockType.GrassToRockLeft:
                    newTile = new GrassToRockLeft(x, y, texture, size);
                    break;
                case BlockType.GrassToRockRight:
                    newTile = new GrassToRockRight(x, y, texture, size);
                    break;
                case BlockType.RockCornerLeft:
                    newTile = new RockCornerLeft(x, y, texture, size);
                    break;
                case BlockType.RockCornerRight:
                    newTile = new RockCornerRight(x, y, texture, size);
                    break;
                case BlockType.RockCornerLeft2:
                    newTile = new RockCornerLeft2(x, y, texture, size);
                    break;
                case BlockType.LeftBridgeCorner:
                    newTile = new LeftBridgeCorner(x, y, texture, size);
                    break;
                case BlockType.BridgeMiddle:
                    newTile = new BridgeMiddle(x, y, texture, size);
                    break;
                case BlockType.RightBridgeCorner:
                    newTile = new RightBridgeCorner(x, y, texture, size);
                    break;
                case BlockType.RightRock:
                    newTile = new RightRock(x, y, texture, size);
                    break;
                case BlockType.RightSide1:
                    newTile = new RightSideBlock1(x, y, texture, size);
                    break;
                case BlockType.RightSide2:
                    newTile = new RightSideBlock2(x, y, texture, size);
                    break;
                case BlockType.LeftSide1:
                    newTile = new LeftSideBlock1(x, y, texture, size);
                    break;
                case BlockType.LeftSide2:
                    newTile = new LeftSideBlock2(x, y, texture, size);
                    break;
                case BlockType.PlatformLadder1:
                    newTile = new PlatformLadder1(x, y, texture, size);
                    break;
                case BlockType.PlatformLadder2:
                    newTile = new PlatformLadder2(x, y, texture, size);
                    break;
                case BlockType.Platform2:
                    newTile = new Platform2(x, y, texture, size);
                    break;
                case BlockType.Platform1:
                    newTile = new Platform1(x, y, texture, size);
                    break;
                case BlockType.Platform3:
                    newTile = new Platform3(x, y, texture, size);
                    break;
                case BlockType.SupportBottemLeftCorner:
                    newTile = new SupportBottemLeftCorner(x, y, texture, size);
                    break;
                case BlockType.SupportBottemRightCorner:
                    newTile = new SupportBottemRightCorner(x, y, texture, size);
                    break;
                case BlockType.SupportDirt:
                    newTile = new SupportDirt(x, y, texture, size);
                    break;
                case BlockType.SupportLeft:
                    newTile = new SupportLeft(x, y, texture, size);
                    break;
                case BlockType.SupportRight:
                    newTile = new SupportRight(x, y, texture, size);
                    break;
                case BlockType.SupportMiddle:
                    newTile = new SupportMiddle(x, y, texture, size);
                    break;
                case BlockType.SupportTop1:
                    newTile = new SupportTop1(x, y, texture, size);
                    break;
                case BlockType.SupportTop2:
                    newTile = new SupportTop2(x, y, texture, size);
                    break;
                case BlockType.SupportTopLeftCorner:
                    newTile = new SupportTopLeftCorner(x, y, texture, size);
                    break;
                case BlockType.SupportTopRightCorner:
                    newTile = new SupportTopRightCorner(x, y, texture, size);
                    break;
                case BlockType.SidePlantLeft1:
                    newTile = new SidePlantLeft1(x, y, texture, size);
                    break;
                case BlockType.SidePlantLeft2:
                    newTile = new SidePlantLeft2(x, y, texture, size);
                    break;
                case BlockType.SidePlantRight1:
                    newTile = new SidePlantRight1(x, y, texture, size);
                    break;
                case BlockType.SidePlantRight2:
                    newTile = new SidePlantRight2(x, y, texture, size);
                    break;
                case BlockType.MineBack:
                    newTile = new MineBack(x, y, texture, size);
                    break;
                case BlockType.MineBack2:
                    newTile = new MineBack2(x, y, texture, size);
                    break;
                case BlockType.MineBack3:
                    newTile = new MineBack3(x, y, texture, size);
                    break;
                case BlockType.MineBack4:
                    newTile = new MineBack4(x, y, texture, size);
                    break;
                case BlockType.MineBack5:
                    newTile = new MineBack5(x, y, texture, size);
                    break;
                case BlockType.MineBack6:
                    newTile = new MineBack6(x, y, texture, size);
                    break;
                case BlockType.MineBack7:
                    newTile = new MineBack7(x, y, texture, size);
                    break;
                case BlockType.MineBack8:
                    newTile = new MineBack8(x, y, texture, size);
                    break;
                case BlockType.MineBack9:
                    newTile = new MineBack9(x, y, texture, size);
                    break;
                case BlockType.MineBack10:
                    newTile = new MineBack10(x, y, texture, size);
                    break;
                case BlockType.MineLadder1:
                    newTile = new MineLadder1(x, y, texture, size);
                    break;
                case BlockType.MineLadder2:
                    newTile = new MineLadder2(x, y, texture, size);
                    break;
                case BlockType.MineLadder3:
                    newTile = new MineLadder3(x, y, texture, size);
                    break;
                case BlockType.MineLadder4:
                    newTile = new MineLadder4(x, y, texture, size);
                    break;
                case BlockType.MineLadder5:
                    newTile = new MineLadder5(x, y, texture, size);
                    break;
                case BlockType.MineLadder6:
                    newTile = new MineLadder6(x, y, texture, size);
                    break;
                case BlockType.MineLadder7:
                    newTile = new MineLadder7(x, y, texture, size);
                    break;
                case BlockType.MineLadder8:
                    newTile = new MineLadder8(x, y, texture, size);
                    break;
                case BlockType.MineLadder9:
                    newTile = new MineLadder9(x, y, texture, size);
                    break;
                case BlockType.MineLadder10:
                    newTile = new MineLadder10(x, y, texture, size);
                    break;
                case BlockType.MineLadder11:
                    newTile = new MineLadder11(x, y, texture, size);
                    break;
                case BlockType.MineLadder12:
                    newTile = new MineLadder12(x, y, texture, size);
                    break;
                case BlockType.MineLadder13:
                    newTile = new MineLadder13(x, y, texture, size);
                    break;
                case BlockType.MineLadder14:
                    newTile = new MineLadder14(x, y, texture, size);
                    break;
                case BlockType.MineLadder15:
                    newTile = new MineLadder15(x, y, texture, size);
                    break;
                case BlockType.MineLadder16:
                    newTile = new MineLadder16(x, y, texture, size);
                    break;
                case BlockType.MineLadder17:
                    newTile = new MineLadder17(x, y, texture, size);
                    break;
                case BlockType.MineLadder18:
                    newTile = new MineLadder18(x, y, texture, size);
                    break;
                case BlockType.MineLight:
                    newTile = new MineLight(x, y, texture, size);
                    break;
                case BlockType.MinePillar1:
                    newTile = new MinePillar1(x, y, texture, size);
                    break;
                case BlockType.MinePillar2:
                    newTile = new MinePillar2(x, y, texture, size);
                    break;
                case BlockType.MinePillar3:
                    newTile = new MinePillar3(x, y, texture, size);
                    break;
                case BlockType.MinePillar4:
                    newTile = new MinePillar4(x, y, texture, size);
                    break;
                case BlockType.MinePillar5:
                    newTile = new MinePillar5(x, y, texture, size);
                    break;
                case BlockType.MinePillar6:
                    newTile = new MinePillar6(x, y, texture, size);
                    break;
                case BlockType.MinePillar7:
                    newTile = new MinePillar7(x, y, texture, size);
                    break;
                case BlockType.MinePillar8:
                    newTile = new MinePillar8(x, y, texture, size);
                    break;
                case BlockType.MinePillar9:
                    newTile = new MinePillar9(x, y, texture, size);
                    break;
                case BlockType.MinePillar10:
                    newTile = new MinePillar10(x, y, texture, size);
                    break;
                case BlockType.GrassPlant:
                    newTile = new GrassPlant(x, y, texture, size);
                    break;
                case BlockType.BigPlant:
                    newTile = new PlantTile(x, y, texture, size);
                    break;
                case BlockType.SmallStone:
                    newTile = new SmallStone(x, y, texture, size);
                        break;
                case BlockType.SquareStone1:
                    newTile = new SquareStone1(x, y, texture, size);
                    break;
                case BlockType.SquareStone2:
                    newTile = new SquareStone2(x, y, texture, size);
                    break;
                case BlockType.SquareStone3:
                    newTile = new SquareStone3(x, y, texture, size);
                    break;
                case BlockType.SquareStone4:
                    newTile = new SquareStone4(x, y, texture, size);
                    break;
                case BlockType.BullStone1:
                    newTile = new BullStone1(x, y, texture, size);
                    break;
                case BlockType.BullStone2:
                    newTile = new BullStone2(x, y, texture, size);
                    break;
                case BlockType.BullStone3:
                    newTile = new BullStone3(x, y, texture, size);
                    break;
                case BlockType.BullStone4:
                    newTile = new BullStone4(x, y, texture, size);
                    break;
                case BlockType.RockBottem:
                    newTile = new RockBottem(x, y, texture, size);
                    break;
                case BlockType.Empty:
                    break;
            }
            return newTile;
        }
    }
}
