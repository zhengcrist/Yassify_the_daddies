using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] int TempEnVie = 5;
    [SerializeField] private GameObject Cible;
    [SerializeField] private GameObject CibleInno;
    [SerializeField] private Vector2 zoneSize;

    // Update is called once per frame
    void Update()
    {
        
            StartCoroutine(SpawnAfterTime());

            IEnumerator SpawnAfterTime()
            {
                yield return new WaitForSeconds(2);
                ApparitionCible();
            }
            StartCoroutine(SpawnAfterTime2());

            IEnumerator SpawnAfterTime2()
            {
                yield return new WaitForSeconds(5);
                ApparitionCibleInno();
            }
        

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }

    void ApparitionCible()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            StartCoroutine(Restant1());


            GameObject instantiated = Instantiate(Cible);

            instantiated.transform.position = new Vector2(
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
                );
            IEnumerator Restant1()
            {
                yield return new WaitForSeconds(TempEnVie);
                Destroy(Cible);
            }
        
    }
    void ApparitionCibleInno()
    {
        //}
        //else if (Input.GetKeyDown(KeyCode.G))
        //{
        StartCoroutine(Restant2());
        GameObject instantiated = Instantiate(CibleInno);

        instantiated.transform.position = new Vector2(
            Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2 + 200),
            Random.Range(transform.position.y - zoneSize.y / 2 + 1500, transform.position.y + zoneSize.y / 2 + 1500)
            );
        IEnumerator Restant2()
        {
            yield return new WaitForSeconds(TempEnVie);
            Destroy(CibleInno);
        }
        //}
    }
}
