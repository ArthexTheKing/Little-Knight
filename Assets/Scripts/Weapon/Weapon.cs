using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float attackCounterResetCooldown;

    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= Data.NumberOfAttack ? 0 : value;
    }

    public event Action OnEnter; 
    public event Action OnExit;
    
    private Animator animator;
    private Utils.Timer attackCounterResetTimer;

    private int currentAttackCounter;
    
    public Core Core { get; private set; }
    public WeaponDataSO Data { get; private set; }
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

    public void SetData(WeaponDataSO data)
    {
        Data = data;
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
