using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnScript : MonoBehaviour
{
    public GameObject keys;
    public float spawnRate = 3;
    private float timer;
    public float spawnOffset = 15F;
    public NoteScript note;
    // Start is called before the first frame update
    void Start()
    {
        note = GameObject.FindGameObjectWithTag("Note").GetComponent<NoteScript>();
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (note.started)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnKey();
                timer = 0;
            }
        }
    }

    void spawnKey()
    {
        float lowestSpawn = transform.position.y - spawnOffset;
        float highestSpawn = transform.position.y + spawnOffset;
        Instantiate(keys, new Vector3(transform.position.x, Random.Range(lowestSpawn, highestSpawn), 0), transform.rotation);
    }
}
