using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerProto : Unit
{
    [SerializeField]
    float rollScale;

    Vector2 inputVector;

    public void Shoot(Vector2 inVector)
    {
        // generate projectile
        animator.SetTrigger(StringRef.Instance.ID_Shoot);
    }

    public void Roll(Vector2 inVector)
    {
        rigid.AddForce(rollScale * inVector);
        animator.SetTrigger(StringRef.Instance.ID_Roll);
    }



    private void Awake()
    {
        GameManager.Instance.Player = this;
    }

    // Update is called once per frame
    void Update()
    {
        // input test

        inputVector = new Vector2(Input.GetAxisRaw(StringRef.Horizontal), Input.GetAxisRaw(StringRef.Vertical));
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Roll(inputVector);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot(Vector2.zero);
        }
        //Debug.Log($"{inputVector}");
    }

    void FixedUpdate()
    {
        Move(inputVector.normalized * Time.fixedDeltaTime);
    }
}
