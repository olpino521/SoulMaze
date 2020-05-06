using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // print(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.transform.tag == "Bullet" || other.transform.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
