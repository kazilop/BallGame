using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;

    private Vector3 _camPos;

    void Start()
    {
        _camPos = ball.transform.position - this.transform.position;
    }

    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, ball.transform.position - _camPos, 1f);
    }
}
