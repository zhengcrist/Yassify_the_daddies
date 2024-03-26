using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Cible1 : MonoBehaviour
{
    public Script_Score scriptScore;
    public SpawnZone spawnZone;
    public Sprite Daddy_Arnoldy;

    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    [SerializeField] private float[] _speed; // speeds of the target to go to the next waypoint[same index]

    private float _checkDistance = 0.1f; // current distance waypoint-cible
    Vector3 startPosition = Vector3.zero;

    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array

    // Audio
    Script_Audio_Manager audioManager;

    private void Awake()
    {
     audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Script_Audio_Manager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _targetWaypoint = _waypoints[0];
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        transform.position = Vector2.MoveTowards(transform.position, _targetWaypoint.position, _speed[_currentWaypointIndex] * Time.deltaTime); // transform position to move to the target waypoint at _speed speed (mod deltaTime)
        if (Vector2.Distance(transform.position, _targetWaypoint.position) < _checkDistance)
        {
            // if the position hasn't reached the target waypoint yet
            _targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++; // inc the index
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            // if the index is larger than the last index in the waypoint array
            _currentWaypointIndex = 0;
        }
        return _waypoints[_currentWaypointIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // à debug lol
        Debug.Log("Destroy Collision");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Daddy_Arnoldy;
            spawnZone.EnnemyNb = spawnZone.EnnemyNb - 1;
            scriptScore.Score = scriptScore.Score + 1; // Rajoute 1 a la variable score ( dans le script score)
            audioManager.PlaySFX(audioManager.SFX_Meow);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
