using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    Menu,
    InGame,
    
    // Define SceneType
}

/// <summary>
/// Unity의 SceneManager를 확장하여 씬 관리를 향상시키는 MonoSingleton입니다.
/// SceneType 열거형을 사용하여 씬을 정의하며, 현재 씬 타입을 가져오거나 씬을 로드하는 기능을 제공합니다.
/// 이 클래스를 사용하여 게임 프로젝트 내의 씬 전환을 쉽게 관리할 수 있습니다.
/// </summary>
public class SceneManagerEx : MonoSingleton<SceneManagerEx>
{
    public SceneType CurrentSceneType
        => (SceneType)SceneManager.GetActiveScene().buildIndex;

    public void LoadScene(SceneType type)
    {
        SceneManager.LoadScene((int)type);
    }

    // Extend SceneManager
}