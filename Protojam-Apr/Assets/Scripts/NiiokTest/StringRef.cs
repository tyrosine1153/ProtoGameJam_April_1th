using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRef : MonoSingleton<StringRef>
{
    // common
    [SerializeField]
    private string ParameterX = "X";
    public int ID_X { get; private set; }
    [SerializeField]
    private string ParameterY = "Y";
    public int ID_Y { get; private set; }
    [SerializeField]
    private string ParameterSidemoving = "SideMoving";
    public int ID_SideMoving { get; private set; }
    [SerializeField]
    private string ParameterDie = "Die";
    public int ID_Die { get; private set; }
    [SerializeField]
    private string ParameterHurt = "Hurt";
    public int ID_Hurt { get; private set; }

    // player
    [SerializeField]
    private string ParameterShoot = "Shoot";
    public int ID_Shoot { get; private set; }
    [SerializeField]
    private string ParameterRoll = "Roll";
    public int ID_Roll { get; private set; }

    // dragon
    [SerializeField]
    private string ParameterGrab = "Grab";
    public int ID_Grab { get; private set; }
    [SerializeField]
    private string ParameterRun = "Run";
    public int ID_Run { get; private set; }

    public const string Horizontal = "Horizontal";
    public const string Vertical = "Vertical";
    public const string Player = "Player";
    public const string Enemy = "Enemy";

    public const string Loop = "Loop";
    public const string Ascend = "Ascend";


    override protected void Awake()
    {
        base.Awake();

        ID_X = Animator.StringToHash(ParameterX);
        ID_Y = Animator.StringToHash(ParameterY);
        ID_SideMoving = Animator.StringToHash(ParameterSidemoving);
        ID_Die = Animator.StringToHash(ParameterDie);
        ID_Hurt = Animator.StringToHash(ParameterHurt);

        ID_Shoot = Animator.StringToHash(ParameterShoot);
        ID_Roll = Animator.StringToHash(ParameterRoll);

        ID_Grab = Animator.StringToHash(ParameterGrab);
        ID_Run = Animator.StringToHash(ParameterRun);

        //byte[] tempBytes;
        //tempBytes = Encoding.ASCII.GetBytes(AES_KEY);
        //Array.Resize(ref tempBytes, 256);
        //AesKey = tempBytes;
        
        //tempBytes = Encoding.ASCII.GetBytes(AES_IV);
        //Array.Resize(ref tempBytes, 256 / 8);
        //AesIV = tempBytes;
    }

    //public const string AES_KEY = "31jeLj2VO6GmwGoCCiCKMWBQ3phlwQ4XudomDHoi6tO4fSwjJueGPB6MoQf3Iui7nDuNnXhA22hbFr16AL7PgPPDfrWUsnT8ted3LmTPcuHx3qzQHFkw7k1QSu1avDbfgx1Epq1CAPnAQQ4WTEsolp7G5yIdc1oCa9zWY0HNfdJJstlaH9ALK9ovaOEdVvQCI7ae9UaUoCmI6nxNaxDCTKvMLSHptepqmU5vEv3VdPpjJeK9eQ4USRLvrQ4AYHQY";
    //public byte[] AesKey { get; private set; }
    //public const string AES_IV = "6iVZhQWekrq1lk2Gba0G74VMTTYq5XMW2I3GmJhAvK9WmwaAdY2tfV5aFP5Tex5NcZ12SZNYlEMiePjDRw8Qal4FMh42r7flgu7n1gr3KLA6DgIFwqDXtbtf5lQMG8aDdHQ9yjfTJEjFEVzTkeRKq18d8JR4PqBlCXgZM9bya7eP4yZkZDGY5LcKm7xzBjaFDUo6V3H1bJeVhKYakjdi8O4gVBhLLkl19tnCGpw2Ozs0GQzHI6pL0BufyfCoWhVt";
    //public byte[] AesIV { get; private set; }
}
