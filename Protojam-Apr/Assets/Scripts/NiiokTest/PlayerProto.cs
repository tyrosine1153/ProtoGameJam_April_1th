using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerProto : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float rollScale;

    Rigidbody2D rigid;

    SpriteRenderer spriteRenderer;
    Animator animator;
    PlayerBehaviour behaviour;

    Vector2 inputVector;


    public void Move(Vector2 inVector)
    {
        //rigid.MovePosition(speed * inVector + new Vector2(transform.position.x, transform.position.y));
        transform.Translate(speed * inVector);
        animator.SetInteger(behaviour.ID_X, Mathf.CeilToInt(Mathf.Abs(inVector.x)) * (int)Mathf.Sign(inVector.x));
        animator.SetInteger(behaviour.ID_Y, Mathf.CeilToInt(Mathf.Abs(inVector.y)) * (int)Mathf.Sign(inVector.y));
        if(inVector.x != 0)
        {
            spriteRenderer.flipX = inVector.x < 0;
        }
    }

    public void Shoot(Vector2 inVector)
    {
        // generate projectile
        animator.SetTrigger(behaviour.ID_Shoot);
    }

    public void Roll(Vector2 inVector)
    {
        rigid.AddForce(rollScale * inVector);
        animator.SetTrigger(behaviour.ID_Roll);
    }

    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        behaviour = animator.GetBehaviour<PlayerBehaviour>();
        behaviour.Init();
    }

    // Update is called once per frame
    void Update()
    {
        // input test
        const string Horizontal = "Horizontal";
        const string Vectical = "Vertical";

        inputVector = new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vectical));
        
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
