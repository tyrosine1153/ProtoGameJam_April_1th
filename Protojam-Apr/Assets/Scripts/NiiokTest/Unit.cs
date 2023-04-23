using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    protected Rigidbody2D rigid;
    
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;


    public void Move(Vector2 inVector)
    {
        //rigid.MovePosition(speed * inVector + new Vector2(transform.position.x, transform.position.y));
        transform.Translate(speed * inVector);
        animator.SetInteger(StringRef.Instance.ID_X, Mathf.CeilToInt(Mathf.Abs(inVector.x)) * (int)Mathf.Sign(inVector.x));
        animator.SetInteger(StringRef.Instance.ID_Y, Mathf.CeilToInt(Mathf.Abs(inVector.y)) * (int)Mathf.Sign(inVector.y));
        if (inVector.x != 0)
        {
            // sprites are left oriented
            spriteRenderer.flipX = inVector.x > 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }
}
