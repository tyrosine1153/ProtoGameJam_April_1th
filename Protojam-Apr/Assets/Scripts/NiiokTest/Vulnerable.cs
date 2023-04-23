using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vulnerable : MonoBehaviour
{
    [SerializeField]
    float maxHp = 100;

    float currentHp;
    public float CurrentHp
    {
        protected set
        {
            currentHp = Mathf.Max(value, 0);
            if(currentHp <= 0)
            {
                Die();
            }
        }
        get => currentHp;
    }

    virtual public void TakeDamage(float InDamage)
    {
        CurrentHp -= InDamage;
        // on hurt
    }

    public UnityEvent OnDead;

    virtual protected void Die() 
    {
        OnDead.Invoke();

        Debug.Log($"{gameObject.name} has died!");
    }

    virtual protected void Awake()
    {
        currentHp = maxHp;
    }
}
