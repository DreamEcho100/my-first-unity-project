using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monstersRefrences;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject SpawnedMonster;

    private int randomMonsterIndex;
    private int randomSpawnSideIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomMonsterIndex = Random.Range(0, monstersRefrences.Length);
            randomSpawnSideIndex = Random.Range(0, 2);
            
            SpawnedMonster = Instantiate(monstersRefrences[randomMonsterIndex]);
            
            float monsterSpeed = Random.Range(4, 10);

            if (randomSpawnSideIndex == 0)
            {
                SpawnedMonster.transform.position = leftPos.position;
            } else
            {
                SpawnedMonster.transform.position = rightPos.position;
                SpawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                monsterSpeed *= -1;
            }

            SpawnedMonster.GetComponent<Monster>().speed = monsterSpeed;
        }
    }
}
