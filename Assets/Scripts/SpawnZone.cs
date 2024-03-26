using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] int TempEnVie = 5;
    [SerializeField] private GameObject Cible;
    [SerializeField] private GameObject CibleInno;
    [SerializeField] private Vector2 zoneSize;
    [SerializeField] public int EnnemyNb = 0;
    [SerializeField] public int InnoNb = 0;

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(Respawn());
        StartCoroutine(RespawnInno());
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
                GameObject instantiated = Instantiate(Cible);

                instantiated.transform.position = new Vector2(
                    Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                    Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
                    );
                EnnemyNb++;
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(Respawn());
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
