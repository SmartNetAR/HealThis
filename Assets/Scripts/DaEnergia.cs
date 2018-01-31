using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaEnergia : MonoBehaviour {

    //private void OnDestroy()
    //{
    //    Debug.Log("DA ENERGIA");
    //    GameController.instance.HaceDanio();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameController.instance.HaceDanio();
        }
    }
}
