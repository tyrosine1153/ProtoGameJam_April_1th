using System.Text;
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

    [SerializeField]
    string sceneToLoad;
    [SerializeField]
    float secondTillTitle = 5.0f;

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
        int loopTime = 1;
        if(PlayerPrefs.HasKey(StringRef.Loop))
        {
            //byte[] ba = Encoding.ASCII.GetBytes(PlayerPrefs.GetString(StringRef.Loop));
            //loopTime = AesExample.DecryptStringFromBytes_Aes(ba, StringRef.Instance.AesKey, StringRef.Instance.AesIV);
            loopTime = PlayerPrefs.GetInt(StringRef.Loop);
        }

        winText.gameObject.SetActive(true);
        winText.text = $"Succeed\nin the {AddOrdinal(loopTime)} life";

        PlayerPrefs.DeleteKey(StringRef.Loop);

        Invoke("GoToTitle", secondTillTitle);
    }
    void ShowLose()
    {
        int loopTime = 1;
        if (PlayerPrefs.HasKey(StringRef.Loop))
        {
            //byte[] ba = Encoding.ASCII.GetBytes(PlayerPrefs.GetString(StringRef.Loop));
            //loopTime = int.Parse(AesExample.DecryptStringFromBytes_Aes(ba, StringRef.Instance.AesKey, StringRef.Instance.AesIV));
            loopTime = PlayerPrefs.GetInt(StringRef.Loop);
        }
        
        loseText.gameObject.SetActive(true);
        loseText.text = $"Failed\nin the {AddOrdinal(loopTime)} life";

        //byte[] next_ba = AesExample.EncryptStringToBytes_Aes((loopTime + 1).ToString(), StringRef.Instance.AesKey, StringRef.Instance.AesIV);
        //PlayerPrefs.SetString(StringRef.Loop, Encoding.ASCII.GetString(next_ba));
        PlayerPrefs.SetInt(StringRef.Loop, loopTime + 1);

        Invoke("GoToTitle", secondTillTitle);
    }


    void GoToTitle()
    {
        Fader.Instance.LoadScene(sceneToLoad);
    }

    public static string AddOrdinal(int num)
    {
        if (num <= 0) return num.ToString();

        switch (num % 100)
        {
            case 11:
            case 12:
            case 13:
                return num + "th";
        }

        switch (num % 10)
        {
            case 1:
                return num + "st";
            case 2:
                return num + "nd";
            case 3:
                return num + "rd";
            default:
                return num + "th";
        }
    }
}
