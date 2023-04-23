using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class DragonProto : Unit
{
    PlayerProto player;
    Vector2 inputVector;





    [Task]
    public void SetMoving(bool bEnable)
    {
        inputVector = bEnable ? (player.transform.position - transform.position).normalized : Vector2.zero;
    }

    [Task]
    public bool IsPlayerNear(float InDistance)
    {
        return (Vector2.Distance(gameObject.transform.position, player.transform.position) < InDistance);
    }

    [Task]
    public void Grab(Vector2 InVector)
    {

    }



    private void Start()
    {
        player = GameManager.Instance.Player;

        if (player == null) Debug.LogError("there's no player!");
    }

    private void FixedUpdate()
    {
        Move(inputVector * Time.fixedDeltaTime * speed);
    }
}
