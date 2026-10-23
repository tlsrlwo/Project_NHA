namespace ShadowGame
{
    public abstract class PlayerStateBase
    {
        public abstract void EnterState(NormalModeStateMachine stateMachine);

        public abstract void UpdateState(NormalModeStateMachine stateMachine);

        public abstract void ExitState(NormalModeStateMachine stateMachine);
        
    }
}
