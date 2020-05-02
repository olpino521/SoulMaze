using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] private GameObject souls, box;
    Vector3 location;

    List<GameObject> objectsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        //initiliaze list
        objectsSpawned = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
        
    }

    void spawn(){

        location = new Vector3(Random.Range(-9,9), 1, Random.Range(-14,14));

        //TODO: don't instantiate where there is a object

      
        //Keys: 1 - souls & 2 - Box
        spawnByClick();
    }

    void spawnByClick(){

        if(Input.GetKeyDown("1")) {

          Instantiate(souls, location, transform.rotation);

        } else if(Input.GetKeyDown("2")){
      
            Instantiate(box, location, transform.rotation);
            
        }
    }
}
