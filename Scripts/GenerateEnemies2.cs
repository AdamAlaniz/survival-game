using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies2 : MonoBehaviour
{
    public GameObject Zombie1;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombieSpawn());
    }

    IEnumerator ZombieSpawn(){
        while (enemyCount < 3){
            xPos = Random.Range(-15, 15);
            zPos = Random.Range(-14, -8);
            Instantiate(Zombie1, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            enemyCount += 1;
        }
    }
}
