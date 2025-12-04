using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shootbullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ExampleCoroutine");
        // start the ExampleCoroutine()
    }

    // Speed at which the object will move 
    public float moveSpeed = 5f;
    public GameObject objectToSpawn;

    public Transform spawnPosition;


    void Update()
    {
        ExampleCoroutine();
    }

    IEnumerator ExampleCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {

            yield return new WaitForSeconds(1f);

            GameObject newObject = Instantiate(objectToSpawn, spawnPosition.transform.position, transform.rotation);
            //Debug.Log(newObject);
           // newObject.transform.SetParent(spawnPosition.transform);



            // end of coroutine
        }

    }

}



