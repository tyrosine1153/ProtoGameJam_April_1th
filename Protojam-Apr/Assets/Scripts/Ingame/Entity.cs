using UniRx;

public abstract class Entity
{
    private const int MinHp = 0;
    private readonly int maxHp;

    protected readonly BoolReactiveProperty canPlay;
    protected readonly IntReactiveProperty hp;
    protected readonly int attack;
    public IReadOnlyReactiveProperty<bool> CanPlay => canPlay;
    public IReadOnlyReactiveProperty<int> Hp => hp;

    protected Entity(int maxHp, int attack)
    {
        canPlay = new BoolReactiveProperty(true);
        this.maxHp = maxHp;
        hp = new IntReactiveProperty(maxHp);
        this.attack = attack;
    }

    public virtual void Attack(Entity target)
    {
        target.Damage(attack);
    }

    private void Damage(int damage)
    {
        hp.Value -= damage;

        if (hp.Value <= MinHp)
        {
            hp.Value = MinHp;
            Die();
        }
    }

    private void Die()
    {
        canPlay.Value = false;
    }
}