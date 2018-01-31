using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyDetectPlayer : MonoBehaviour {

    public GameObject enemyController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Detecta el Player!" );
            enemyController.GetComponent<EnemyStickyBehaviour>().target = collision.transform;
            enemyController.GetComponent<EnemyStickyBehaviour>().targetOnSight = true;
        }
    }

    void OnDestroy()
    {
        Debug.Log("Se destruye");    
    }
}
