using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveBullet : MonoBehaviour
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

    private void Awake()
    {
        transform.Rotate(180, 0, 0);
    }
    void Update()
    {        
        ExampleCoroutine();
    }



    IEnumerator ExampleCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {

            Debug.Log("Move forward for 5 seconds");

            // Move the object forward (in the object's local forward direction) 
            float timer = 0f;
            float moveduration = 5f;

            while (timer < moveduration)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }


            Debug.Log("Wait for  1 seconds");
            yield return new WaitForSeconds(1f);




            // end of coroutine
        }

    }

}
