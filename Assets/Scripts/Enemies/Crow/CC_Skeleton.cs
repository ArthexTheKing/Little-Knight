using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Skeleton : MonoBehaviour
{

    private Skeleton_Behaviour enemyParent;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        enemyParent = GetComponentInParent<Skeleton_Behaviour>();
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Weapon")){
            Debug.Log("qui ci arrivi?");
            if(enemyParent.isTakingDamage == false && enemyParent.invulnerable == false){
                Debug.Log("qui ci arrivi?");
                TakeDamage();
            }
        }
    }

    private void TakeDamage(){
        anim.SetTrigger("Damage");
        enemyParent.isTakingDamage = true;
    }
}
