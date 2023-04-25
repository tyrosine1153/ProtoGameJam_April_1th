using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerProto : Unit
{
    [SerializeField]
    float rollScale;

    [SerializeField]
    GameObject bulletPrefab;

    Vector2 inputVector;
    Vector2 reservedShoot;

    Collider2D bodyCollider;

    public void Shoot(Vector2 inVector)
    {
        if (animator.GetBool(StringRef.Instance.ID_Shoot)) return;

        reservedShoot = inVector;
        animator.SetBool(StringRef.Instance.ID_Shoot, true);
    }

    public void Roll(Vector2 inVector)
    {
        if (animator.GetBool(StringRef.Instance.ID_Roll)) return;

        rigid.AddForce(rollScale * inVector);
        animator.SetBool(StringRef.Instance.ID_Roll, true);
    }



    override protected void Awake()
    {
        base.Awake();

        bodyCollider = GetComponent<Collider2D>();
        GameManager.Instance.Player = this;
        OnDead.AddListener(() => { inputVector = Vector2.zero; });
    }

    // Update is called once per frame
    void Update()
    {
        // input test
        if (IsAlive())
        {
            inputVector = new Vector2(Input.GetAxisRaw(StringRef.Horizontal), Input.GetAxisRaw(StringRef.Vertical));

            if (Input.GetMouseButtonDown(1))
            {
                Roll(inputVector);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Shoot(GameManager.Instance.GetMousePosition() - new Vector2(transform.position.x, transform.position.y));
            }
            //Debug.Log($"{inputVector}");
        }
    }

    void FixedUpdate()
    {
        Move(inputVector.normalized * Time.fixedDeltaTime);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance.Player == this)
        {
            GameManager.Instance.Player = null;
        }
    }


    // used by animation event
    void ShootReservedBullet()
    {
        Bullet bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        Physics2D.IgnoreCollision(bodyCollider, bullet.GetComponent<Collider2D>());

        bullet.Direction = reservedShoot;
    }


}
