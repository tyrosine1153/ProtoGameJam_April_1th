using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Vector2 mapSize;

    public Vector2 RandomPosition => new Vector2(Random.Range(-mapSize.x, mapSize.x), Random.Range(-mapSize.y, mapSize.y));
    
    public void SpawnPebble()
    {
        var pebble = PoolManager.Instance.CreateGameObject(PrefabType.Pebble);
        pebble.transform.position = RandomPosition;
    }
    
    // Map Setting
    public void SetCave()
    {
        
    }

    public void DestroyMap()
    {
        
    }
}