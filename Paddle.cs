using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minimum = 1f;
    [SerializeField] float maximum = 15f;
    [SerializeField] GameStatus gameSession;
    [SerializeField] BallMover gameBall;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameStatus>();
        gameBall = FindObjectOfType<BallMover>();
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(Mathf.Clamp(GetXPos(), minimum, maximum), transform.position.y);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return gameBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
