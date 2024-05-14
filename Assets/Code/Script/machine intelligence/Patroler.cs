using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEditor;

public class Patroler : MonoBehaviour
{
    public enum SpeedStates
    {
        Run, 
        Idle,
        Jump,
        Stay
    }

    private Transform _target;
    [SerializeField][FormerlySerializedAs("player")] private Transform _player;
    private float _speed;
    
    [SerializeField] private float _attackDistance = 2f;
    [SerializeField] private float _detectionDistance = 5f;
    [SerializeField] private float _outOfReachDistance = 8f;
    [SerializeField] private float runSpeed = 5;
    [SerializeField] private float idleSpeed = 3;
    [SerializeField] private float jumtSpeed = 10;


    public List<Transform> points = new List<Transform>();

    
    public float speed
    {
        get { return _speed; }
    }

    public float attackDistance { get => _attackDistance; }
    public float detectionDistance { get => _detectionDistance; }
    public float outOfReachDistance { get => _outOfReachDistance; }
    public float toTargetDistance { get => Vector2.Distance(gameObject.transform.position, _target.position); }
    public float toPlayerDistance { get => Vector2.Distance(gameObject.transform.position, _player.position); }

    public void setSpeed(SpeedStates speed)
    {
        switch (speed) {
        case SpeedStates.Idle:
            _speed = idleSpeed;
            break;
        case SpeedStates.Run:
            _speed = runSpeed;
            break;
        case SpeedStates.Jump:
            _speed = jumtSpeed;
            break;
        default:
            _speed = 0;
            break;
        }
    }

    public void setPlayerTarget()
    {
        _target = _player;
    }

    public void setRandPointTarget()
    {
        if (points.Count == 0) throw new System.Exception("There is no points in list");
        _target = points[Random.Range(0, points.Count - 1)];
    }

    void Start()
    {
        _target = gameObject.transform;
    }

    void Update()
    {
        if (_speed != 0)
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _target.position, _speed * Time.deltaTime);
    }
}
