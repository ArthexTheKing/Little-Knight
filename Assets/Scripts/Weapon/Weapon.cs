using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= Data.NumberOfAttack ? 0 : value;
    }

    public event Action OnEnter; 
    public event Action OnExit;

    [SerializeField] private float attackCounterResetCooldown;
    
    private Animator animator;
    private Utils.Timer attackCounterResetTimer;

    private int currentAttackCounter;
    
    [field: SerializeField] public WeaponDataSO Data { get; private set; }
    
    public Core Core { get; private set; }
    public GameObject BaseGameObject { get; private set; }
    public GameObject WeaponSpriteGameObject { get; private set; }
    public AnimationEventHandler EventHandler { get; private set; }

    public void Enter()
    {
        print($"{transform.name} enter");

        attackCounterResetTimer.StopTimer();

        animator.SetBool("active", true);
        animator.SetInteger("counter", CurrentAttackCounter);

        OnEnter?.Invoke();
    }

    private void Exit()
    {
        animator.SetBool("active", false);

        CurrentAttackCounter++;
        attackCounterResetTimer.StartTimer();

        OnExit?.Invoke();
    }

    public void SetCore(Core core)
    {
        Core = core;
    }

    private void Awake()
    {
        BaseGameObject = transform.Find("Base").gameObject;
        WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;

        animator = BaseGameObject.GetComponent<Animator>();
        EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

        attackCounterResetTimer = new Utils.Timer(attackCounterResetCooldown);
    }

    private void Update()
    {
        attackCounterResetTimer.Tick();
    }

    private void ResetAttackCounter() => CurrentAttackCounter = 0;

    private void OnEnable()
    {
        EventHandler.OnFinish += Exit;
        attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
    }

    private void OnDisable()
    {
        EventHandler.OnFinish -= Exit;
        attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
    }
}
