using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //компоненты
    private Rigidbody2D rb;
    
    //настройка движения 
    public float maxInitialAngle = 0.67f; //38 примерно
    public float moveSpeed = 5f;
    private float speedMultiplier = 1.1f;

    //настройка респавна
    private float spawnX = 0;
    private float maxSpawnY = 4.20f;

    void Awake()
    {
        //выдача компонента
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //первый импульс мяча
        InitialPush();
        GameManager.Instance.onReset += ResetBall;
    }

    private void InitialPush()
    {
        //1 способ движения, простой
        //Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        //dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);

        //2 способ, с точным отклонением (длина всегда = 1)
        bool goLeft = Random.value < 0.5f;// генерация случайного направления
        Vector2 dir;

        float angleRad = Random.Range(-maxInitialAngle, maxInitialAngle);
        if(goLeft)
            dir = new Vector2(-Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        else
            dir = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        //если рб не равно null, задаем скорость
        //защита от NullReferenceException
        if (rb)
            rb.velocity = dir * moveSpeed;

    }

    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }
    private void ResetBallPosition()
    {
        //генерация позиции по y
        float posY = Random.Range(-maxSpawnY, maxSpawnY);
        Vector2 position = new Vector2(spawnX, posY);
        //телепорт назад
        transform.position = position;

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ищем компонент ScoreZone на объекте столкновения
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();

        if (scoreZone)
        {
            //гол забит
            GameManager.Instance.OnScoreZoneReached(scoreZone.id);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Padlle padlle = collision.collider.GetComponent<Padlle>();

        if(padlle)
        {
            rb.velocity *= speedMultiplier;
        }
    }

}
