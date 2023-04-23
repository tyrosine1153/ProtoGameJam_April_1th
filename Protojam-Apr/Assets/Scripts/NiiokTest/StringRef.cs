using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRef : MonoSingleton<StringRef>
{
    [SerializeField]
    private string ParameterX = "X";
    public int ID_X { get; private set; }
    [SerializeField]
    private string ParameterY = "Y";
    public int ID_Y { get; private set; }

    [SerializeField]
    private string ParameterShoot = "Shoot";
    public int ID_Shoot { get; private set; }

    [SerializeField]
    private string ParameterRoll = "Roll" ;
    public int ID_Roll { get; private set; 
    
    }[SerializeField]
    private string ParameterGrab = "Grab" ;
    public int ID_Grab { get; private set; }

    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";


    override protected void Awake()
    {
        base.Awake();

        ID_X = Animator.StringToHash(ParameterX);
        ID_Y = Animator.StringToHash(ParameterY);
        ID_Shoot = Animator.StringToHash(ParameterShoot);
        ID_Roll = Animator.StringToHash(ParameterRoll);
    }
}
