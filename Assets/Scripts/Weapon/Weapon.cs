using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int numberOfAttack;
    [SerializeField] private float attackCounterResetCooldown;

    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= numberOfAttack ? 0 : value;
    }

    public event Action OnExit;

    private Animator animator;
    private GameObject baseGameObject;
    private AnimationEventHandler eventHandler;
    private Utils.Timer attackCounterResetTimer;

    private int currentAttackCounter;

    public void Enter()
    {
        print($"{transform.name} enter");

        attackCounterResetTimer.StopTimer();

        animator.SetBool("active", true);
        animator.SetInteger("counter", CurrentAttackCounter);
    }

    private void Exit()
    {
        animator.SetBool("active", false);

        CurrentAttackCounter++;
        attackCounterResetTimer.StartTimer();

        OnExit?.Invoke();
    }

    private void Awake()
    {
        baseGameObject = transform.Find("Base").gameObject;
        animator = baseGameObject.GetComponent<Animator>();
        eventHandler = baseGameObject.GetComponent<AnimationEventHandler>();

        attackCounterResetTimer = new Utils.Timer(attackCounterResetCooldown);
    }

    private void Update()
    {
        attackCounterResetTimer.Tick();
    }

    private void ResetAttackCounter() => CurrentAttackCounter = 0;

    private void OnEnable()
    {
        eventHandler.OnFinish += Exit;
        attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
    }

    private void OnDisable()
    {
        eventHandler.OnFinish -= Exit;
        attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
    }
}
