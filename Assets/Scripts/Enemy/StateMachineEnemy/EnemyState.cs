public abstract class EnemyState<T> where T : BaseEnemy 
{
    protected T enemy;
    public StateMachine<T> stateMachine;
    public EnemyDATA enemyDATA;
    public string name;
    public EnemyState(T enemy, StateMachine<T> stateMachine, EnemyDATA enemyDATA,string name )
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.enemyDATA = enemyDATA;
        this.name = name;
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit() 
    {

    }

    public virtual void Update()
    {

    }
}
