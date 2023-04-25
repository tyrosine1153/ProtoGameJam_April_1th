using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Image bossHpBar;
    [SerializeField]
    Image playerHpBar;
    [SerializeField]
    TextMeshProUGUI winText;
    [SerializeField]
    TextMeshProUGUI loseText;

    void Awake()
    {
        bossHpBar.fillAmount = 1;
        playerHpBar.fillAmount = 1;
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Dragon?.OnHurt.AddListener(OnDragonHpChange);
        GameManager.Instance.Dragon?.OnDead.AddListener(ShowWin);
        GameManager.Instance.Player?.OnHurt.AddListener(OnPlayerHpChange);
        GameManager.Instance.Player?.OnDead.AddListener(ShowLose);
    }


    void OnDragonHpChange()
    {
        DragonProto dragon = GameManager.Instance.Dragon;
        bossHpBar.fillAmount = dragon.CurrentHp / dragon.MaxHP;
    }
    
    void OnPlayerHpChange()
    {
        PlayerProto player = GameManager.Instance.Player;
        playerHpBar.fillAmount = player.CurrentHp / player.MaxHP;
    }

    void ShowWin()
    {
        winText.gameObject.SetActive(true);
    }
    void ShowLose()
    {
        loseText.gameObject.SetActive(true);
    }
}
