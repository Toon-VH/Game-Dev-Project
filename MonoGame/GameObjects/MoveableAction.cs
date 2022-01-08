namespace MonoTest.GameObjects
{
    public class MoveableAction
    {
        public MoveableActionType Action { get; set; }
        public MoveableActionDirection Direction { get; set; }

        public MoveableAction(MoveableActionType action, MoveableActionDirection direction)
        {
            Action = action;
            Direction = direction;
        }
    }

    public enum MoveableActionType
    {
        Running, Idle, Attacking, AttackingLow, Rolling,Dying
    }

    public enum MoveableActionDirection
    {
        Left,Right,Static
    }
}