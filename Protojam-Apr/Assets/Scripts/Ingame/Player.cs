using UniRx;
using UnityEngine;

public class Player : Entity
{
    private const int MinDifficultLevel = 1;
    private const int MaxDifficultLevel = 5;
    private readonly IntReactiveProperty chargeDifficultLevel;
    private readonly BoolReactiveProperty havePebble;

    public IReadOnlyReactiveProperty<int> ChargeDifficultLevel => chargeDifficultLevel;
    public IReadOnlyReactiveProperty<bool> HavePebble => havePebble;

    public Player(int maxHp, int attack) : base(maxHp, attack)
    {
        chargeDifficultLevel = new IntReactiveProperty(MaxDifficultLevel);
        havePebble = new BoolReactiveProperty(true);  // 시작할 때 돌맹이를 가지고 있나?
    }

    public void Pick()
    {
        havePebble.Value = true;
    }

    public void Restore()
    {
        chargeDifficultLevel.Value = Mathf.Clamp(chargeDifficultLevel.Value - 1, MinDifficultLevel, MaxDifficultLevel);
    }

    public void Shoot()
    {
        if (!havePebble.Value)
        {
            Debug.Log($"돌맹이가 없어서 공격할 수 없습니다.");
            return;
        }
        havePebble.Value = false;
        chargeDifficultLevel.Value = Mathf.Clamp(chargeDifficultLevel.Value + 1, MinDifficultLevel, MaxDifficultLevel);
    }
}