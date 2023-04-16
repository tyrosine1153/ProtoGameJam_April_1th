using System.Collections;
using UnityEngine;

public class InGame : MonoSingleton<InGame>
{
    [SerializeField] private Battle battle;
    [SerializeField] private Map map;
    [SerializeField] private InputHandler inputHandler;

    public Battle Battle => battle;
    public Map Map => map;

    private bool isGamePlaying;

    public void GameStart()
    {
        if (isGamePlaying) return;
        isGamePlaying = true;

        // Todo : 연출

        StartCoroutine(CoStart());
    }

    private IEnumerator CoStart()
    {
        Battle.SetBattle();
        Map.SetCave();
        inputHandler.Init();

        yield return new WaitForSeconds(0);

        battle.StartBattle();
    }

    public void GameEnd(bool isWin)
    {
        if (!isGamePlaying) return;
        isGamePlaying = false;
        
        StartCoroutine(CoGameEnd(isWin));
    }
    
    private IEnumerator CoGameEnd(bool isWin)
    {
        battle.EndBattle();
        map.DestroyMap();
        inputHandler.Dispose();
        
        yield return new WaitForSeconds(0);        
    }
}