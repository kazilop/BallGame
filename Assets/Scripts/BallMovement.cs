using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 _direction;
    private float _speed = 500f;
    private Vector3 position;

    public bool isGame = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _direction = Vector3.zero;
        position = transform.position;

        isGame = true;
    }

    
    void Update()
    {
        if (isGame)
        {
            BallMove();
        }
        else
        {
            transform.position = position;
            transform.rotation = Quaternion.identity;
        }
    }

    private void BallMove()
    {
        if (rb != null)
        {
            if(Input.GetKey(KeyCode.W))
            {
                _direction = new Vector3(1,0,0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _direction = new Vector3(-1, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _direction = new Vector3(0, 0, 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _direction = new Vector3(0, 0, -1);
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                isGame = false;
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                _direction = Vector3.zero;
            }

            rb.AddForce(_direction * _speed * Time.deltaTime, ForceMode.Acceleration);
        }
              
    }
}
