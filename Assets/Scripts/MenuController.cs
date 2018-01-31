using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Vector2 hotSpot2 = Vector2.zero;



    //Animators
    public Animator Player1Animator;
    public Animator Player2Animator;
    public Animator Player3Animator;


    // Use this for initialization
    void Start () {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void onExit()
    {
        Cursor.SetCursor(null,hotSpot2, CursorMode.Auto);
    }

    public void offExit()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    


    public void changeScaleP1(string clip)
    {
        Player1Animator.Play(clip);
    }

    public void changeScaleP2(string clip)
    {
        Player2Animator.Play(clip);
    }

    public void changeScaleP3(string clip)
    {
        Player3Animator.Play(clip);
    }
    //public void startGame(int index)
    //{
    //    SceneManager.LoadScene("2");
    //}
}
