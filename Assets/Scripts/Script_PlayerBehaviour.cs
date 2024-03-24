using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;


public class Script_PlayerBehaviour : MonoBehaviour
{

    [SerializeField] public float movingRangeX, movingRangeY;
    private float PlayerX, PlayerY;

    [SerializeField] Animator Revolver_animator;

    // [SerializeField] private float moveSpeed;

    public Transform Fire_Position;
    [SerializeField] GameObject Prefab_Bullet;

    // Start is called before the first frame update
    void Start()
    {
        // Starting positions on x and y axes
        PlayerX = 0f;
        PlayerY = 0f;
        // moveSpeed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        Follow_Mouse1();
        Fire();
    }

    void Follow_Mouse1()
    {
        // Calculate the horizontal position of the screen and clamping the borders
        float horizontalPos = (Input.mousePosition.x / Screen.width) * 2f - 1f;
        horizontalPos = Mathf.Clamp(horizontalPos, -0.9f, 0.9f);

        // Calculate the vertical position of the screen and clamping the borders
        float verticalPos = (Input.mousePosition.y / Screen.height) * 2f - 1f;
        verticalPos = Mathf.Clamp(verticalPos, -0.9f, 0.9f);

        //sDebug.Log(horizontalPos);
        //sDebug.Log(verticalPos);

        // Final player movement
        PlayerX = horizontalPos * movingRangeX;
        PlayerY = verticalPos * movingRangeY;
        transform.position = new Vector3(PlayerX, PlayerY, transform.position.z);
    }

    /* void Follow_Mouse2()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }*/

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(Prefab_Bullet, Fire_Position.position, Fire_Position.rotation);
            Revolver_animator.SetTrigger("Shoot");
        }
    }
    
}
