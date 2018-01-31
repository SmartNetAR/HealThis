using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour {

    public List<GameObject> players;
    public GameObject selectedPlayer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SelectPlayer(int id)
    {
        selectedPlayer = players[id];
    }

}
