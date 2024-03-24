using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Script_RayViewer : MonoBehaviour
{

    public float weaponRange = 50f;

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        var target = GameObject.Find("Revolver2");


        Vector3 lineOrigin = target.transform.position = new Vector3(pos.x, pos.y - 100, -9);
        Debug.DrawRay (lineOrigin, target.transform.forward * weaponRange, Color.green);
    }
}
