using UnityEngine;

/// <summary>
/// Unity에서 싱글톤 패턴을 구현하는 기본 클래스입니다. 이 클래스는 MonoBehaviour를 상속받으며, 제네릭 타입 T를 사용하여 서브 클래스를 생성합니다.
/// </summary>
/// <typeparam name="T">싱글톤으로 구현할 MonoBehaviour를 상속받은 클래스 타입입니다.</typeparam>
[DisallowMultipleComponent]
public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    [SerializeField]
    bool dontDestroyOnLoad;

    private static T _instance;
    private static object _syncRoot = new object();

    public static T Instance
    {
        get
        {
            Initialize();
            return _instance;
        }
    }

    public static bool IsInitialized => _instance != null;

    public static void Initialize()
    {
        if (IsInitialized)
        {
            return;
        }

        lock (_syncRoot)
        {
            _instance = FindObjectOfType<T>();

            if (!IsInitialized)
            {
                Debug.LogWarning($"couldn't find mono singleton : {typeof(T).Name}");

                var go = new GameObject(typeof(T).FullName);
                _instance = go.AddComponent<T>();
            }
        }
    }

    protected virtual void Awake()
    {
        if (IsInitialized)
        {
            Debug.LogWarning(GetType().Name + " Singleton class is already created.");
            Destroy(gameObject);
            return;
        }

        Initialize();

        if (dontDestroyOnLoad)
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}