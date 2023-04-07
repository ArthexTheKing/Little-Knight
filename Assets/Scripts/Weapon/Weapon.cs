using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action OnExit;

    private Animator animator;
    private GameObject baseGameObject;
    private AnimationEventHandler eventHandler;

    public void Enter()
    {
        print($"{transform.name} enter");

        animator.SetBool("active", true);
    }

    private void Exit()
    {
        animator.SetBool("active", false);

        OnExit?.Invoke();
    }

    private void Awake()
    {
        baseGameObject = transform.Find("Base").gameObject;
        animator = baseGameObject.GetComponent<Animator>();
        eventHandler = baseGameObject.GetComponent<AnimationEventHandler>();
    }

    private void OnEnable()
    {
        eventHandler.OnFinish += Exit;
    }

    private void OnDisable()
    {
        eventHandler.OnFinish -= Exit;
    }
}
