using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Movement Movement => movement != null ? movement : core.GetCoreComponent(ref movement);

    private Movement movement;

    [SerializeField] private SO_WeaponData weaponData;

    private Core core;
    private Animator weaponAnimator;
    private PlayerAttackState attackState;

    private readonly List<IDamageble> detectedDamagebes = new();
    private readonly List<IKnockbackable> detectedKnockbackables = new();

    private int attackCounter;

    #region Unity Callback Functions

    private void Start()
    {
        weaponAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageble damageble)) detectedDamagebes.Add(damageble);
        
        if (collision.TryGetComponent(out IKnockbackable knockbackable)) detectedKnockbackables.Add(knockbackable);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageble damageble)) detectedDamagebes.Remove(damageble);
        
        if (collision.TryGetComponent(out IKnockbackable knockbackable)) detectedKnockbackables.Remove(knockbackable);
    }

    #endregion

    #region Animation Trigger

    public void AnimationFinishTrigger() => attackState.AnimationFinishTrigger();

    public void AnimationStartMovementTrigger() => attackState.SetPlayerVelocity(weaponData.MovementSpeed[attackCounter]);

    public void AnimationStopMovementTrigger() => attackState.SetPlayerVelocity(0f);

    public void AnimationTurnOffFlipTrigger() => attackState.SetFlipCheck(false);

    public void AnimationTurnOnFlipTrigger() => attackState.SetFlipCheck(true);

    public void AnimationActionTrigger() => CheckMeleeAttack();

    #endregion

    public void InitializeWeapon(PlayerAttackState attackState, Core core)
    {
        this.attackState = attackState;
        this.core = core;
    }

    public void EnterWeapon()
    {
        gameObject.SetActive(true);

        if(attackCounter >= weaponData.AmountOfAttacks)
        {
            attackCounter = 0;
        }

        weaponAnimator.SetBool("attack", true);

        weaponAnimator.SetInteger("attackCounter", attackCounter);
    }

    public void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails attackDetails = weaponData.AttackDetails[attackCounter];

        foreach (IDamageble item in detectedDamagebes.ToList())
        {
            item.Damage(attackDetails.damageAmount);
        }

        foreach (IKnockbackable item in detectedKnockbackables.ToList())
        {
            item.Knockback(attackDetails.knockbackAngle, attackDetails.knockbackStrenght, Movement.FacingDirection);
        }
    }

}
