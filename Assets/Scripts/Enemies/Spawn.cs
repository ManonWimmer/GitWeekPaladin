using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    int i = 1;
    [SerializeField] GameObject Zone1;
    [SerializeField] GameObject Zone2;
    [SerializeField] GameObject Zone3;
    [SerializeField] GameObject Zone4;
    [SerializeField] GameObject PrefabEnemy1;
    [SerializeField] GameObject PrefabEnemy2;

    IEnumerator CouroutineEnemy1()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(PrefabEnemy1, Zone1.transform.position, Quaternion.identity);
    }
    IEnumerator CouroutineEnemy2()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(PrefabEnemy2, Zone2.transform.position, Quaternion.identity);
    }
    IEnumerator CouroutineEnemy3()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(PrefabEnemy1, Zone3.transform.position, Quaternion.identity);
    }
    IEnumerator CouroutineEnemy4()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(PrefabEnemy2, Zone4.transform.position, Quaternion.identity);
    }
    private void FixedUpdate()
    {
        i++;
        if (i == 200)
        {
            StartCoroutine(CouroutineEnemy1());
            StartCoroutine(CouroutineEnemy2());
            StartCoroutine(CouroutineEnemy3());
            StartCoroutine(CouroutineEnemy4());
            i = 0;
        }
    }
}
