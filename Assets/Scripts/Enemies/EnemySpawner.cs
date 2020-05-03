using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    Vector3 location;

    // List<GameObject> enemiesSpawned;

    private void Awake() {

        //initialize enemies list
        // enemiesSpawned = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    void spawn(){

    location = new Vector3(Random.Range(-9,9), 1, Random.Range(-14,14));

    //TODO: don't instantiate where there is a object

    
    //Key: 3
    spawnByClick();
    }

    void spawnByClick(){
        if(Input.GetKeyDown("3")){
            Instantiate(enemy, location, transform.rotation);
        }
    }

    
}
