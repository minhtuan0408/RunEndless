public class StateMachine<T> where T : BaseEnemy
{
    public EnemyState<T> currentEnemyState { get; private set; }

    public void Initialize(EnemyState<T> newEnemyState)
    {
        this.currentEnemyState = newEnemyState;
        newEnemyState.Enter();
    }

    public void ChangeState(EnemyState<T> State)
    {
        currentEnemyState.Exit();
        currentEnemyState = State;
        State.Enter();
    }
}
