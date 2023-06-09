using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Unit : Vulnerable
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
        bool bSideMoving = Mathf.Abs(inVector.x) > Mathf.Abs(inVector.y);
        animator.SetBool(StringRef.Instance.ID_SideMoving, bSideMoving);
        if (inVector.x != 0 && bSideMoving)
            spriteRenderer.flipX = inVector.x > 0;
    }

    public override void TakeDamage(float InDamage)
    {
        base.TakeDamage(InDamage);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    override protected void Awake()
    {
        base.Awake();

        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        OnDead.AddListener(() => { animator.SetBool(StringRef.Instance.ID_Die, true); });
        OnHurt.AddListener(() => { animator.SetBool(StringRef.Instance.ID_Hurt, true); });
    }
}
