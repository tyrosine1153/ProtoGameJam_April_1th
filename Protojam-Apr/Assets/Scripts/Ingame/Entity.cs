using UniRx;

public abstract class Entity
{
    protected readonly BoolReactiveProperty canPlay;
    protected readonly IntReactiveProperty hp;
    protected readonly int attack;
    public IReadOnlyReactiveProperty<bool> CanPlay => canPlay;
    public IReadOnlyReactiveProperty<int> Hp => hp;
    public const int MinHp = 0;
    public int maxHp { get; }

    protected Entity(int maxHp, int attack)
    {
        canPlay = new BoolReactiveProperty(true);
        this.maxHp = maxHp;
        hp = new IntReactiveProperty(maxHp);
        this.attack = attack;
    }

    public void Attack(Entity target)
    {
        target.hp.Value -= attack;
    }
    
    public void Die()
    {
        canPlay.Value = false;
    }
}