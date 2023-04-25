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
        if (player != null)
            inputVector = bEnable ? (player.transform.position - transform.position).normalized : Vector2.zero;
        else
            inputVector = Vector2.zero;

        ThisTask.Succeed();
    }

    [Task]
    public bool IsPlayerNear(float InDistance)
    {
        if(player != null)
            return (Vector2.Distance(gameObject.transform.position, player.transform.position) < InDistance);
        else
            return false;
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


    protected override void Awake()
    {
        base.Awake();

        GameManager.Instance.Dragon = this;
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

    private void OnDestroy()
    {
        if(GameManager.Instance.Dragon == this)
        {
            GameManager.Instance.Dragon = null;
        }
    }


    // used by animation event
    void EnableSkillTrigger(int bEnable)
    {
        skillTrigger.gameObject.SetActive(0 < bEnable);
    }
}
