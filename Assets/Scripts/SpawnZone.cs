using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private GameObject Cible1;
    [SerializeField] private GameObject Cible2;
    [SerializeField] private GameObject Cible3;
    [SerializeField] private GameObject CibleInno;
    [SerializeField] private Vector2 zoneSize;
    [SerializeField] public int EnnemyNb = 0;
    [SerializeField] public int InnoNb = 0;

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(Respawn());
        StartCoroutine(RespawnInno());
        ;
    }
    void Update()
    {
      

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }

    IEnumerator Respawn()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        if (EnnemyNb <= 2)
        {
            float randomNumber = Random.Range(0, 9);
            if (randomNumber < 5)
            {
                GameObject instantiated = Instantiate(Cible1);

                instantiated.transform.position = new Vector2(
                    Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                    Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
                    );
                EnnemyNb++;
            }
            else if (randomNumber < 8)
            {
                GameObject instantiated = Instantiate(Cible2);

                instantiated.transform.position = new Vector2(
                    Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                    Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
                    );
                EnnemyNb++;
            }
            else
            {
                GameObject instantiated = Instantiate(Cible3);

                instantiated.transform.position = new Vector2(
                    Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                    Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
                    );
                EnnemyNb++;
            }
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(Respawn());
    }

    void EnnemyLess()
    {
        EnnemyNb--;
    }

    IEnumerator RespawnInno() // a mettre 
    {

        // if a mettre 
        if(InnoNb <= 2)
        {
            
            GameObject instantiated = Instantiate(CibleInno);

            instantiated.transform.position = new Vector2(
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                Random.Range(transform.position.y - zoneSize.y / 2 + 1500, transform.position.y + zoneSize.y / 2 + 1500)
                );
            InnoNb++; 
            
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(RespawnInno()); // a mettre 
        //}
    }
   
}
