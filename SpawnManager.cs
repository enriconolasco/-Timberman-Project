using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject trunkN;
    public GameObject trunkL;
    public GameObject trunkR;
    public GameObject spawnPosition;

    int randomNumber;
    bool canSpawn = false;

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("trunk"))
        {
            canSpawn = true;
            randomNumber = Random.Range(0, 3);
            if (canSpawn)
            {
                switch (randomNumber)
                {
                    case 0:
                        Instantiate(trunkN, spawnPosition.transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                    case 1:
                        Instantiate(trunkL, spawnPosition.transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                    case 2:
                        Instantiate(trunkR, spawnPosition.transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                }
            }
        }
    }
}
