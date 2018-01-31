using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] enemys;
	public int enemyCount ;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject background;
	public float speedBackground;
	public GameObject holdFire;
	public GameObject[] spawnHolds;
    public GameObject player;
    public GameObject playerSpawnPoint;

    public static GameController instance;

    public Slider timeBar;
    public float maxTime;
    public float remainingTime;



    private bool gameOver;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        // INICIALIZAMOS EL PLAYER
        player = GameObject.Find("PlayerSelector").GetComponent<PlayerSelector>().selectedPlayer;
        Instantiate(player, playerSpawnPoint.transform.position, Quaternion.identity);
        //player.transform.parent = playerSpawnPoint.transform;


        StartCoroutine( SpawnWaves());

		for (int i = 0; i < spawnHolds.Length; i++) {
			StartCoroutine (SpawnHolds (spawnHolds[i]));
		}

		Rigidbody2D rbBackground = background.GetComponent<Rigidbody2D>();

		rbBackground.velocity = transform.right * - speedBackground;
		for (int i = 0; i < spawnHolds.Length; i++) 
		{
			Rigidbody2D rbSpawnHold = spawnHolds[i].GetComponent<Rigidbody2D> ();
			rbSpawnHold.velocity = transform.right * - speedBackground;
		}


	}
	
	// Update is called once per frame
	void Update () {
        RecibeDanio();
        StartCoroutine(ActualizaBarra());
	}

    public void RecibeDanio()
    {
        remainingTime -= 5 * Time.deltaTime;
    }

    public void HaceDanio()
    {
        remainingTime += 10 * Time.deltaTime;
    }

    public IEnumerator ActualizaBarra()
    {
        timeBar.value = remainingTime / 100;
        yield return null;
    }


    IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while (!gameOver) {
			for (int i = 0; i <= Random.Range (0, enemyCount); i++) {
				GameObject enemy = enemys [Random.Range (0, enemys.Length)];
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}
	}

	IEnumerator SpawnHolds(GameObject spawnHold)
	{
			yield return new WaitForSeconds (startWait);
			while (!gameOver) { 
							
				//GameObject spawnHold = spawnHolds [i];
				for (int j = 0; j <= Random.Range (0, 5); j++) {
					
					Vector3 spawnPosition = new Vector3 (spawnHold.transform.position.x, spawnHold.transform.position.y);
					//Quaternion spawnRotation = Quaternion.identity;
					Quaternion spawnRotation = spawnHold.transform.rotation;
					Instantiate (holdFire, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				yield return new WaitForSeconds (waveWait);


				/* if (gameOver)
			{
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}*/
			}
	}

	public void EndGame()
	{
		gameOver = true;
		Debug.Log ("Game Over");
		//Time.timeScale = 0f;
        Fade.instance.FadeIn();
        StartCoroutine(Delay(1));
        SceneManager.LoadScene("end");
	}

    IEnumerator Delay(int seg)
    {
        yield return new WaitForSeconds(seg);
    }

	void UpdateFixed()
	{
		
	}
}
