using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMoveScript : MonoBehaviour
{
    public float moveSpeed = 7.5F;
    public float deletePosition = -45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;   

        if(transform.position.x < deletePosition )
        {
            Debug.Log("key deleted");
            Destroy(gameObject);
        }
    }
}
