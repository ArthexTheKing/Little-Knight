using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Object thisObject;
    public int coinFactor;
    void Start()
    {
        thisObject = GetComponent<Object>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            Destroy(gameObject);
            Global.countScore = Global.countScore + coinFactor;
        }
    }
}
