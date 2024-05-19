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
    [SerializeField] private GameObject _column;
    [SerializeField] private float _columnCooldown = 15f;
    private bool _columnCanSpawn = true;
    private Rigidbody2D _rigidbody;

    [SerializeField] private int _curentHealth = 1000;
    [SerializeField] private int _maxHealth = 1000;
    [SerializeField] private int _speed = 0;

    private float _chainikCooldown = 10f;
    private bool _canSpawn = true;

    //костыли
    private Vector2 offset = Vector2.up * 2.1f;

    //

    public bool canSpawn
    {
        get => _canSpawn;
    }
    public bool columnCanSpawn
    {
        get => _columnCanSpawn && (_columnCount == 0);
        set => _columnCanSpawn = value;
    }

    public int CurrentHealth
    {
        get => _curentHealth;
    }
    public int MaxHealth
    { get => _maxHealth; }
    private int _chainicsCount = 0;

    private int _columnCount = 0;

    [SerializeField]private List<GameObject> _points = new List<GameObject>();

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
    public int columnCount
    {
        get => _columnCount;
        set => _columnCount = value;
    }
        
        
    public void takeDamage(int dmgValue)
    {
        if (_columnCount != 0) return;
        
        _curentHealth -= dmgValue;
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
    public void SpawnColumns()
    {
        if (columnCanSpawn == false) return;
        _columnCount = 0;

        foreach(var i  in _points)
        {
            var col = Instantiate(_column, i.transform.position, _column.transform.rotation);
            if(col != null)
            {
                _columnCount += 1;
                col.GetComponent<Column>().patroler = this;
            }
        }
        _columnCanSpawn = false;
        StartCoroutine(ColumnSpawnReset());
    }

    IEnumerator ColumnSpawnReset()
    {
        yield return new WaitForSeconds(_columnCooldown);
        _columnCanSpawn = true;
    }


    public void setPlayerPoint()
    {
        _target = _player;
        _chainicsCount = 0;
        _canSpawn = false;
        StartCoroutine(spawnReset());
    }

    IEnumerator spawnReset()
    {
        yield return new WaitForSeconds(_chainikCooldown);
        _canSpawn = true;
    }

    public void SPAWNCHAINIC()
    {
        _chainicsCount++;
        int chX = Random.Range(25, 39);
        int chY = Random.Range(7, 19);
        Instantiate(_chainik, new Vector3(chX, chY), _chainik.transform.rotation);

    }

    public float targetDistance() {
        Vector2 to = _target.position;
        if (_target == _player) to -= offset;

        return Vector2.Distance(gameObject.transform.position, to); 
    }
    // Start is called before the first frame update

    void Start()
    {
        _animator = GetComponent<Animator>();
        _chainik.SetActive(true);

        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (_curentHealth<=0)
        {
            _animator.SetTrigger("Death");
        }
    }

    public void walkToTarget()
    {
        Vector2 to = _target.position;
        if (_target == _player) to -= offset;

        transform.position = Vector2.MoveTowards(gameObject.transform.position, to, _speed * Time.deltaTime);
        Vector3 dir = Vector3.Normalize(_target.position - transform.position);
        _animator.SetFloat("X", dir.x);
        _animator.SetFloat("Y", dir.y);
    }
}
