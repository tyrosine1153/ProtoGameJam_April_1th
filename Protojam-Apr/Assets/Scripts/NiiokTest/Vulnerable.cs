using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vulnerable : MonoBehaviour
{
    [SerializeField]
    protected float maxHp = 100;

    public float MaxHP { get => maxHp; }

    float currentHp;
    public float CurrentHp
    {
        protected set
        {
            if (IsAlive())
            {
                currentHp = Mathf.Max(value, 0);
                OnHurt.Invoke();
                if (currentHp == 0)
                {
                    OnDead.Invoke();
                    Debug.Log($"{gameObject.name} has died!");
                }
            }
        }
        get => currentHp;
    }

    public bool IsAlive() { return CurrentHp > 0; }

    virtual public void TakeDamage(float InDamage)
    {
        CurrentHp -= InDamage;
        // on hurt
    }

    public UnityEvent OnDead;
    public UnityEvent OnHurt;


    virtual protected void Awake()
    {
        currentHp = maxHp;
    }
}
