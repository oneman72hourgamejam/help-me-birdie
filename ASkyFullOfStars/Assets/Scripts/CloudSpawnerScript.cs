using UnityEngine;
using System.Collections;

public class CloudSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;    // our clouds

    public float distanceBetweenClouds1 = 1.0f; // distancate between y position of the cluds
	public float distanceBetweenClouds2 = 3.0f;
    public float minX, maxX; // min and max x for clouds

    private Player playerScript;  // player script

    public GameObject[] cloudsInGame;

    public float lastCloudPositionY; // the y position of the last cloud

    [SerializeField]
    private GameObject[] collectables;

    void Awake () {
        Vector3 t = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));

        maxX = t.x - 0.5f;
        minX = -t.x + 0.5f;

        float center = Screen.width / Screen.height;

        CreateClouds (center);

        for(int i = 0; i < collectables.Length; i++) {
            collectables[i] = Instantiate(collectables[i]) as GameObject;
            collectables[i].SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {

        playerScript = GameObject.Find ("Player").GetComponent<Player> ();

        cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

        Vector3 temp = new Vector3 (cloudsInGame [0].transform.position.x, cloudsInGame [0].transform.position.y + 0.6f, playerScript.transform.position.z);

        playerScript.transform.position = temp;


    }

    void OnTriggerEnter2D(Collider2D target) {

        if (target.tag == "Deadly" || target.tag == "Cloud") {

            if(target.transform.position.y == lastCloudPositionY) {

                Vector3 temp = target.transform.position;
                Shuffle(clouds);

                for(int i = 0; i < clouds.Length; i++) {

                    if(!clouds[i].activeInHierarchy) {
                        temp.x = Random.Range(minX, maxX);
                        temp.y -= Random.Range(distanceBetweenClouds1, distanceBetweenClouds2);

                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);

                        if(clouds[i].tag != "Deadly") {

                            if(!collectables[random].activeInHierarchy) {
                                collectables[random].SetActive(true);
                                collectables[random].transform.position = new Vector3(clouds[i].transform.position.x - 0.2f,
                                                                                      clouds[i].transform.position.y + 0.7f,
                                                                                      clouds[i].transform.position.z);
                            }
                        }
                    }
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {

	}

    void CreateClouds(float positionY) {

        // first shuffle clouds
        Shuffle (clouds);

        // loop through the array and initialize the clouds
        for(int i = 0; i < clouds.Length; i++) {

            clouds[i] = Instantiate(clouds[i], Vector3.zero, Quaternion.identity) as GameObject;

            Vector3 temp = clouds[i].transform.position;

            float randomX = Random.Range(minX, maxX);

            temp.x = randomX;
            temp.y = positionY;

            lastCloudPositionY = temp.y;

            clouds[i].transform.position = temp;

			positionY -= Random.Range(distanceBetweenClouds1, distanceBetweenClouds2);
        }
    }

    void Shuffle(GameObject[] array) {

        // loop through the array and shuffle it
        for(int i = 0; i < array.Length; i++) {

            GameObject temp = array[i];
            int random = Random.Range(i, array.Length);
            array[i] = array[random];
            array[random] = temp;

        }

    }
}
