using UniRx;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Player Player { get; private set; }
    public Monster Monster { get; private set; }

    private void Awake()
    {
        Player.Hp.Subscribe(value => { if (value < Entity.MinHp) Player.Die(); });
        Player.CanPlay.Subscribe(value => {if (!value) InGame.Instance.GameEnd(false); });
        Monster.Hp.Subscribe(value => { if (value < Entity.MinHp) Monster.Die(); });
        Monster.CanPlay.Subscribe(value => { if (!value) InGame.Instance.GameEnd(true); });
    }

    public void SetBattle()
    {
        Player = new Player(100, 10);
        Monster = new Monster(100, 10);
    }
    
    public void StartBattle()
    {
        
    }
    
    public void EndBattle()
    {
        Player = null;
        Monster = null;
    }
}