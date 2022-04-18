using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _zpos;

    void Start()
    {
        _zpos = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _zpos = transform.position.z;
        
        if (_zpos < -1 || _zpos > 8)
        {
            _speed = - _speed;
        }

        transform.position = new Vector3(transform.position.x, 
            transform.position.y, transform.position.z + _speed * Time.deltaTime);

    }
}
