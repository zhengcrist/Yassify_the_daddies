using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);


            var target = GameObject.Find("Revolver2");
        target.transform.position = new Vector3(pos.x, pos.y -100, -9);
    }
}
