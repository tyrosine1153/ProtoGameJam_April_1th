using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 _direction;
    public Vector2 Direction 
    {
        set => _direction = value.normalized;
        get => _direction;
    }
    [SerializeField]
    float speed = 5;
    [SerializeField]
    float damage = 10;

    void FixedUpdate()
    {
        transform.Translate(Direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(StringRef.Enemy))
        {
            collision.collider.GetComponent<Vulnerable>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
