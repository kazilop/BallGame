using UnityEngine;

public class BallCollider : MonoBehaviour
{

    private BallMovement _ballMovement;
    private GameManager _gmanager;

    private void Start()
    {
        _ballMovement = GetComponent<BallMovement>();
        _gmanager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(transform.position.y < -1)
        {
            YouLose();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                FinishGame();
                break;
            case "Enemy":
                YouLose();
                break;
        }
    }

    private void FinishGame()
    {
        _ballMovement.isGame = false;
        _gmanager.LoadWinPanel();
       
    }

    private void YouLose()
    {
        _ballMovement.isGame = false;
        _gmanager.LoadLosePanel();
        
    }

}
