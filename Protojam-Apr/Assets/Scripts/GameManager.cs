using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerProto Player;
    public DragonProto Dragon;

    // hp
    // boss hp
    // 드간다
    // 공격, 공격, 공격
    // 시간 제간, 뭐시기 뭐시기 없음, hp만 둘 중 하나 0이 될 때까지

    // 동굴 밖 - 안의 반복
    // 아 귀찮다

    public Vector2 GetMousePosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        return pos;
    }
}