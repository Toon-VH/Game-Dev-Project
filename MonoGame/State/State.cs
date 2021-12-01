namespace MonoTest.State
{
     abstract class State
    {
        void Update(){}
        void Draw(){}
    }

    class IdleState : State
    {
        void Update()
        {
            
        }

        void Draw()
        {
            
        }
    }
    
    class RunningState : State
    {
        void Update()
        {
            
        }

        void Draw()
        {
            
        }
    }
    
    class JumpingState : State
    {
        void Update()
        {
            
        }

        void Draw()
        {
            
        }
    }
}