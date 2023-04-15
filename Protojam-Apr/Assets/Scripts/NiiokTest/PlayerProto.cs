using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProto : MonoBehaviour
{
    [SerializeField]
    float speed;

    SpriteRenderer spriteRenderer;
    Animator animator;
    PlayerBehaviour behaviour;

    Vector2 inputVector;


    public void Move(Vector2 inVector)
    {
        transform.Translate(speed * inVector);
        animator.SetFloat(behaviour.ID_Speed, inVector.magnitude * speed);
    }

    public void Shoot(Vector2 inVector)
    {
        // generate projectile
        animator.SetTrigger(behaviour.ID_Shoot);
    }

    // Start is called before the first frame update
    void Start()
    {
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
