using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetectPlayer : MonoBehaviour {

    public GameObject enemyController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Detecta el Player!");
            enemyController.GetComponent<EnemyTurretBehaviour>().target = collision.transform;
            enemyController.GetComponent<EnemyTurretBehaviour>().targetOnSight = true;
        }
    }

    void OnDestroy()
    {
        Debug.Log("Se destruye");    
    }
}
