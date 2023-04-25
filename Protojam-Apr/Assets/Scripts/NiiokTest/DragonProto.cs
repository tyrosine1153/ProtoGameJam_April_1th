using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class DragonProto : Unit
{
    [SerializeField]
    float runScale = 20;
    [SerializeField]
    float bodyDamage;
    [SerializeField]
    Collider2D skillTrigger;
    [SerializeField]
    float skillDamage;


    PlayerProto player;
    Vector2 inputVector;





    [Task]
    public void SetMoving(bool bEnable)
    {
        inputVector = bEnable ? (player.transform.position - transform.position).normalized : Vector2.zero;

        ThisTask.Succeed();
    }

    [Task]
    public bool IsPlayerNear(float InDistance)
    {
        return (Vector2.Distance(gameObject.transform.position, player.transform.position) < InDistance);
    }

    [Task]
    public bool IsDead()
    {
        return !IsAlive();
    }

    [Task]
    public void Grab()
    {
        animator.SetBool(StringRef.Instance.ID_Grab, true);

        ThisTask.Succeed();
    }
    
    [Task]
    public void Run()
    {
        animator.SetBool(StringRef.Instance.ID_Run, true);
        rigid.AddForce(inputVector * runScale);

        ThisTask.Succeed();
    }



    virtual protected void Start()
    {
        player = GameManager.Instance.Player;
        if (player == null) Debug.LogError("there's no player!");

        EnableSkillTrigger(0);
    }

    private void FixedUpdate()
    {
        Move(inputVector * Time.fixedDeltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(StringRef.Player))
        {
            collision.gameObject.GetComponent<Vulnerable>().TakeDamage(bodyDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(StringRef.Player))
        {
            collision.gameObject.GetComponent<Vulnerable>().TakeDamage(skillDamage);
        }
    }


    // used by animation event
    void EnableSkillTrigger(int bEnable)
    {
        skillTrigger.gameObject.SetActive(0 < bEnable);
    }
}
