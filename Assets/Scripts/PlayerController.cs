using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool start = false;
    private bool ballIsKick = false;

    // Save Point
    private Vector3 startSphere;
    private Vector3 startPlayer;

    private const float xMin = -3f, xMax = 3f;
    private const float zMin = -7f, zMax = -4f;
    private const float xMinMark = -4f, xMaxMark = 0f;

    public float distance;
    private int countTarget = 0;

    [SerializeField] private GameObject ball;
    private LevelControll levelControll;
    private LineRenderer lineRenderer;

    [SerializeField] private LineRenderer markRenderer;
    private SpriteRenderer spriteRendererMark;
    private Rigidbody ballRb;

    //Helpful Vector 
    private float angleMark;
    private float angleKickX;
    private float angleKickZ;

    void Start()
    {
        startPlayer = transform.position;
        startSphere = ball.transform.position;

        markRenderer.enabled = false;

        lineRenderer = GetComponent<LineRenderer>();
        ballRb = ball.GetComponent<Rigidbody>();
        levelControll = GetComponent<LevelControll>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1, ball.transform.position);

        markRenderer.SetPosition(0, transform.position);

        if (Input.GetMouseButton(0) && start && !ballIsKick)
        {
            distance = Vector3.Distance(ball.transform.position, transform.position);

            MarkDrawable();

            PlayerMove();
        }
        if (Input.GetMouseButtonUp(0) && start && !ballIsKick)
        {
            angleKickX = ball.transform.position.x - transform.position.x;
            angleKickZ = ball.transform.position.z - transform.position.z;

            if (angleKickX != 0 && angleKickZ != -2)
            {
                KickBall();
            }
        }
    }

    private void KickBall()
    {
        ballIsKick = true;

        Vector3 ballForce = new Vector3(-angleKickX, 0.5f, -angleKickZ);
        ball.GetComponent<Rigidbody>().AddForce(ballForce * distance, ForceMode.Impulse);

        lineRenderer.enabled = false;
        markRenderer.enabled = false;
    }

    private void MarkDrawable()
    {
        angleMark = ball.transform.position.x - transform.position.x;

        Vector3 ballForce = new Vector3(-angleMark * 2, 0.5f, (transform.position.z + distance));

        markRenderer.enabled = true;
        markRenderer.SetPosition(1, ballForce);
    }

    private void PlayerMove()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        transform.position = new Vector3(Mathf.Clamp(objPosition.x, xMin, xMax), 0.5f, Mathf.Clamp(objPosition.z, zMin, zMax)); // и собственно объекту записываються координаты
    }

    public void ResetPosition(bool isEnemy) // Reset position
    {
        ballIsKick = false;
        lineRenderer.enabled = true;
        ballRb.isKinematic = true;

        transform.position = startPlayer;
        ball.transform.position = startSphere;

        ballRb.isKinematic = false;

        if(!isEnemy)
            countTarget++;

        if (countTarget == 3)
        {
            levelControll.nextLevel();
            countTarget = 0;
        }  
    }
}
