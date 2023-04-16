using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerProto playerController;
    
    [SerializeField] private InputAction moveAction;
    private readonly Subject<Vector2> _moveSubject = new Subject<Vector2>();
    public IObservable<Vector2> Move => _moveSubject;

    [SerializeField] private InputAction pickAction;
    private readonly Subject<Unit> _pickSubject = new Subject<Unit>();
    public IObservable<Unit> Pick => _pickSubject;

    [SerializeField] private InputAction restoreAction;
    private readonly Subject<Unit> _restoreSubject = new Subject<Unit>();
    public IObservable<Unit> Restore => _restoreSubject;  // Todo : 1.근처 돌맹이 체크 2.장전 바 맞추기(UI)

    [SerializeField] private InputAction shootAction;
    private readonly Subject<Vector2> _shootSubject = new Subject<Vector2>();
    public IObservable<Vector2> Shoot => _shootSubject;

    [SerializeField] private InputAction rollAction;
    private readonly Subject<Vector2> _rollSubject = new Subject<Vector2>();
    public IObservable<Vector2> Roll => _rollSubject;

    private IDisposable _playerCanPlaySubscription;
    
    private void Awake()
    {
        moveAction.performed += OnMove;
        pickAction.performed += OnPick;
        restoreAction.performed += OnRestore;
        shootAction.performed += OnShoot;
        rollAction.performed += OnRoll;
    }

    public void Init()
    {
        _playerCanPlaySubscription = InGame.Instance.Battle.Player.CanPlay.Subscribe(canPlay =>
        {
            if (canPlay)
            {
                moveAction.Enable();
                pickAction.Enable();
                restoreAction.Enable();
                shootAction.Enable();
                rollAction.Enable();
            }
            else
            {
                moveAction.Disable();
                pickAction.Disable();
                restoreAction.Disable();
                shootAction.Disable();
                rollAction.Disable();
            }
        });
    }

    public void Dispose()
    {
        _playerCanPlaySubscription?.Dispose();
    }
    
    public void OnMove(InputAction.CallbackContext context) 
    {
        _moveSubject.OnNext(context.ReadValue<Vector2>());
    }

    public void OnPick(InputAction.CallbackContext context)
    {
        _pickSubject.OnNext(Unit.Default);
    }

    public void OnRestore(InputAction.CallbackContext context)
    {
        _restoreSubject.OnNext(Unit.Default);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        _shootSubject.OnNext(GetMouseDirection(playerController.transform.position));
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        _rollSubject.OnNext(GetMouseDirection(playerController.transform.position));
    }

    private static Vector2 GetMouseDirection(Vector3 targetPosition)
    {
        var mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mousePositionInWorld - targetPosition).normalized;
    }
}