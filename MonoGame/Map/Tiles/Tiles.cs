using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    #region solid
    
    #region bridge
    class LeftBridgeCorner : Tile
    {
        public LeftBridgeCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(128, 00, 16, 16);
        }
    }

    class BridgeMiddle : Tile
    {
        public BridgeMiddle(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(160, 00, 16, 16);
        }
    }

    class RightBridgeCorner : Tile
    {
        public RightBridgeCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(192, 00, 16, 16);
        }
    }
    #endregion
    #region platform
    class PlatformLadder1 : Tile
    {
        public PlatformLadder1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(46, 01, 16, 16);
        }
    }
    class PlatformLadder2 : Tile
    {
        public PlatformLadder2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(46, 18, 16, 16);
        }
    }

    class Platform1 : Tile
    {
        public Platform1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(63, 01, 16, 16);
        }
    }
    class Platform2 : Tile
    {
        public Platform2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(80, 01, 16, 16);
        }
    }
    class Platform3 : Tile
    {
        public Platform3(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(97, 01, 16, 16);
        }
    }
    #endregion    
    #region grassBlocks
    class GrassTile : Tile
    {
        public GrassTile(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 32, 16, 16);
        }
    }

    class GrassBlock : Tile
    {
        public GrassBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(90, 32, 16, 16);
        }
    }

    class GrassRightCorner : Tile
    {
        public GrassRightCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(124, 32, 16, 16);
        }
    }

    class GrassLeftCorner : Tile
    {
        public GrassLeftCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(073, 32, 16, 16);
        }
    }


    #endregion
    #region dirtBlocks
    class DirtTile : Tile
    {
        public DirtTile(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 49, 16, 16);
        }
    }

    class DirtTile2 : Tile
    {
        public DirtTile2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(90, 49, 16, 16);
        }
    }

    class DirtPlant1 : Tile
    {
        public DirtPlant1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 83, 16, 16);
        }
    }

    class DirtPlant2 : Tile
    {
        public DirtPlant2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(107, 100, 16, 16);
        }
    }

    #endregion
    #region transition
    class GrassToRockLeft : Tile
    {
        public GrassToRockLeft(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(1, 102, 16, 16);
        }
    }

    class GrassToRockRight : Tile
    {
        public GrassToRockRight(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(54, 101, 16, 16);
        }
    }
    class SideRightBlock : Tile
    {
        public SideRightBlock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(124, 117, 16, 16);
        }
    }
    #endregion
    #region sides
    class LeftRock : Tile
    {
        public LeftRock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(73, 83, 16, 16);
        }
    }

    class RightRock : Tile
    {
        public RightRock(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(124, 83, 16, 16);
        }
    }

    class RightSideBlock1 : Tile
    {
        public RightSideBlock1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(124, 49, 16, 16);
        }
    }

    class RightSideBlock2 : Tile
    {
        public RightSideBlock2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(124, 66, 16, 16);
        }
    }

    class LeftSideBlock2 : Tile
    {
        public LeftSideBlock2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(73, 49, 16, 16);
        }
    }
    class LeftSideBlock1 : Tile
    {
        public LeftSideBlock1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(73, 66, 16, 16);
        }
    }

    #endregion
    #region rock
    class RockCornerLeft : Tile
    {
        public RockCornerLeft(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(18, 102, 16, 16);
        }
    }
    class RockCornerLeft2 : Tile
    {
        public RockCornerLeft2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(18, 119, 16, 16);
        }
    }
    class RockCornerRight : Tile
    {
        public RockCornerRight(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(37, 101, 16, 16);
        }
    }

    class RockBottem : Tile
    {
        public RockBottem(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(124, 100, 16, 16);
        }
    }


    #endregion
    #region stones
    class SmallStone : Tile
    {
        public SmallStone(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(90, 100, 16, 16);
        }
    }

    class SquareStone1 : Tile
    {
        public SquareStone1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(47, 159, 16, 16);
        }
    }
    class SquareStone2 : Tile
    {
        public SquareStone2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(64, 159, 16, 16);
        }
    }
    class SquareStone3 : Tile
    {
        public SquareStone3(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(47, 176, 16, 16);
        }
    }
    class SquareStone4 : Tile
    {
        public SquareStone4(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(64, 176, 16, 16);
        }
    }
    class BullStone1 : Tile
    {
        public BullStone1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(0, 159, 16, 16);
        }
    }
    class BullStone2 : Tile
    {
        public BullStone2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(17, 159, 16, 16);
        }
    }
    class BullStone3 : Tile
    {
        public BullStone3(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(0, 176, 16, 16);
        }
    }
    class BullStone4 : Tile
    {
        public BullStone4(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(17, 176, 16, 16);
        }
    }
    #endregion
    
    #endregion

    #region passable
    
    #region plants
    class PlantTile : Tile
    {
        public PlantTile(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(107, 15, 16, 16);
        }
    }
  
    class GrassPlant : Tile
    {
        public GrassPlant(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(90, 15, 16, 16);
        }
    }

    class SidePlantRight1 : Tile
    {
        public SidePlantRight1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(141, 49, 16, 16);
        }
    }
    class SidePlantRight2 : Tile
    {
        public SidePlantRight2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(141, 66, 16, 16);
        }
    }

    class SidePlantLeft1 : Tile
    {
        public SidePlantLeft1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(56, 49, 16, 16);
        }
    }
    class SidePlantLeft2 : Tile
    {
        public SidePlantLeft2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(56, 66, 16, 16);
        }
    }
    #endregion
    #region supportBlocks
    class SupportDirt : Tile
    {
        public SupportDirt(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(131, 154, 16, 16);
        }
    }

    class SupportTop1 : Tile
    {
        public SupportTop1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(114, 137, 16, 16);
        }
    }


    class SupportTop2 : Tile
    {
        public SupportTop2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(131, 137, 16, 16);
        }
    }


    class SupportLeft : Tile
    {
        public SupportLeft(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(97, 154, 16, 16);
        }
    }
    class SupportRight : Tile
    {
        public SupportRight(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(148, 154, 16, 16);
        }
    }

    class SupportTopRightCorner : Tile
    {
        public SupportTopRightCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(148, 137, 16, 16);
        }
    }

    class SupportTopLeftCorner : Tile
    {
        public SupportTopLeftCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(97, 137, 16, 16);
        }
    }

    class SupportBottemLeftCorner : Tile
    {
        public SupportBottemLeftCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(97, 171, 16, 16);
        }
    }
    class SupportBottemRightCorner : Tile
    {
        public SupportBottemRightCorner(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(148, 172, 16, 16);
        }
    }
    class SupportMiddle : Tile
    {
        public SupportMiddle(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(114, 171, 16, 16);
        }
    }
    #endregion
    #region MineShaft
    class MineLadder1 : Tile
    {
        public MineLadder1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(199, 99, 16, 16);
        }
    }
    class MineLadder2 : Tile
    {
        public MineLadder2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(199, 116, 16, 16);
        }
    }
    class MineLadder3 : Tile
    {
        public MineLadder3(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(199, 133, 16, 16);
        }
    }
    class MineLadder4 : Tile
    {
        public MineLadder4(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(199, 150, 16, 16);
        }
    }
    class MineLadder5 : Tile
    {
        public MineLadder5(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(199, 167, 16, 16);
        }
    }
    class MineBack : Tile
    {
        public MineBack(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(216, 99, 16, 16);
        }
    }

    class MineLadder6 : Tile
    {
        public MineLadder6(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(216, 116, 16, 16);
        }
    }
    class MineLadder7 : Tile
    {
        public MineLadder7(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(216, 133, 16, 16);
        }
    }
    class MineLadder8 : Tile
    {
        public MineLadder8(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(216, 150, 16, 16);
        }
    }
    class MineLadder9 : Tile
    {
        public MineLadder9(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(216, 167, 16, 16);
        }
    }
    class MineLadder10 : Tile
    {
        public MineLadder10(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(233, 116, 16, 16);
        }
    }

    class MineLadder11 : Tile
    {
        public MineLadder11(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(233, 133, 16, 16);
        }
    }
    class MineLadder12 : Tile
    {
        public MineLadder12(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(233, 150, 16, 16);
        }
    }
    class MineLadder13 : Tile
    {
        public MineLadder13(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(233, 167, 16, 16);
        }
    }
    class MineLadder14 : Tile
    {
        public MineLadder14(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(250, 99, 16, 16);
        }
    }
    class MineLadder15 : Tile
    {
        public MineLadder15(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(250, 116, 16, 16);
        }
    }
    class MineLadder16 : Tile
    {
        public MineLadder16(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(250, 133, 16, 16);
        }
    }
    class MineLadder17 : Tile
    {
        public MineLadder17(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(250, 150, 16, 16);
        }
    }
    class MineLadder18 : Tile
    {
        public MineLadder18(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(250, 167, 16, 16);
        }
    }

    class MinePillar1 : Tile
    {
        public MinePillar1(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(159, 36, 16, 16);
        }
    }
    class MinePillar2 : Tile
    {
        public MinePillar2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(159, 53, 16, 16);
        }
    }
    class MinePillar3 : Tile
    {
        public MinePillar3(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(159, 70, 16, 16);
        }
    }
    class MinePillar4 : Tile
    {
        public MinePillar4(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(176, 53, 16, 16);
        }
    }
    class MinePillar5 : Tile
    {
        public MinePillar5(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(193, 53, 16, 16);
        }
    }
    class MinePillar6 : Tile
    {
        public MinePillar6(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(193, 36, 16, 16);
        }
    }
    class MinePillar7 : Tile
    {
        public MinePillar7(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(193, 70, 16, 16);
        }
    }
    class MinePillar8 : Tile
    {
        public MinePillar8(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(210, 36, 16, 16);
        }
    }
    class MinePillar9 : Tile
    {
        public MinePillar9(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(210, 53, 16, 16);
        }
    }
    class MinePillar10 : Tile
    {
        public MinePillar10(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(210, 70, 16, 16);
        }
    }
    class MineBack2 : Tile
    {
        public MineBack2(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(258, 15, 16, 16);
        }
    }
    class MineBack3 : Tile
    {
        public MineBack3(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(258, 33, 16, 16);
        }
    }
    class MineBack4 : Tile
    {
        public MineBack4(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(258, 50, 16, 16);
        }
    }
    class MineBack5 : Tile
    {
        public MineBack5(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(258, 67, 16, 16);
        }
    }
    class MineBack6 : Tile
    {
        public MineBack6(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(275, 15, 16, 16);
        }
    }
    class MineBack7 : Tile
    {
        public MineBack7(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(275, 33, 16, 16);
        }
    }
    class MineBack8 : Tile
    {
        public MineBack8(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(275, 50, 16, 16);
        }
    }
    class MineBack9 : Tile
    {
        public MineBack9(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = false;
            SourceRectangle = new Rectangle(275, 67, 16, 16);
        }
    }
    class MineBack10 : Tile
    {
        public MineBack10(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(292, 15, 16, 16);
        }
    }
    class MineLight : Tile
    {
        public MineLight(int x, int y, Texture2D texture, int size) : base(x, y, texture, size)
        {
            IsPassable = true;
            SourceRectangle = new Rectangle(292, 50, 16, 16);
        }
    }
    #endregion
    
    #endregion







}