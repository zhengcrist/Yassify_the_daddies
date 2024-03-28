using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Script_CibleInno : MonoBehaviour
{
    public SpawnZone spawnZone;
    public Script_New_Ray newRay;

    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    [SerializeField] private float[] _speed; // speeds of the target to go to the next waypoint[same index]

    private float _checkDistance = 0.1f; // current distance waypoint-cible
    Vector3 startPosition = Vector3.zero;

    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array

    //
    public int Score;
    [SerializeField] TextMeshProUGUI textScore;


    //Sprites
    [SerializeField] public Sprite daddy_western;
    [SerializeField] public Sprite daddy_yassified;

    // Audio
    Script_Audio_Manager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Script_Audio_Manager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = daddy_western;
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

    private void HitByRay()
    {
        GetComponent<SpriteRenderer>().sprite = daddy_yassified;
        audioManager.PlaySFX(audioManager.SFX_non);
        newRay.Score -= 250;
        Debug.Log("Score : " + newRay.Score);
        textScore.text = newRay.Score.ToString();
        SendMessage("Reload");
        StartCoroutine(DaddyPleaseKissMe());
    }

    private IEnumerator DaddyPleaseKissMe()
    {
        yield return new WaitForSeconds(2f);
        spawnZone.EnnemyNb--;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}