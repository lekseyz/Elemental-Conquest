using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PatrolerKnight : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _chainik;

    [SerializeField] private int _curentHealth = 1000;
    [SerializeField] private int _maxHealth = 1000;
    [SerializeField] private int _speed = 0;

    private int _chainicsCount = 0;

    [SerializeField] private List<GameObject> _points = new List<GameObject>();

    private Animator _animator;
    public int speed
    {
        get 
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    public int chainicsCount
    {
        get => _chainicsCount;
    }

    public void setFarestPoint()
    {
        var orderedPoints = _points.OrderBy((p) => Vector2.Distance(p.transform.position, _player.position)).Reverse().ToList();
        foreach (var point in orderedPoints)
        {
            if (point.transform != _target)
            {
                _target = point.transform;
                break;
            }
        }
    }
    
    public void setPlayerPoint()
    {
        _target = _player;
    }

    public void SPAWNCHAINIC()
    {
        _chainicsCount++;
        int chX = Random.Range(25, 39);
        int chY = Random.Range(7, 19);
        Instantiate(_chainik, new Vector3(chX, chY), _chainik.transform.rotation);

    }

    public float targetDistance() { return Vector2.Distance(gameObject.transform.position, _target.position); }
    // Start is called before the first frame update

    void Start()
    {
        _animator = GetComponent<Animator>();
        _chainik.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, _target.position, _speed * Time.deltaTime);
        Vector3 dir = Vector3.Normalize(_target.position - transform.position);
        _animator.SetFloat("X", dir.x);
        _animator.SetFloat("Y", dir.y);
    }
}
