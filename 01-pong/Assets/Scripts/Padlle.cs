using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlle : MonoBehaviour
{
    //комопненты
    private Rigidbody2D rb;

    //другие настройки
    public int id;
    public float moveSpeed = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(ProccesInput());
    }

    private float ProccesInput()
    {
        float movement = 0f;
        switch(id)
        {
            case 1:
                movement = Input.GetAxis("LeftControl");
                break;
            case 2:
                movement = Input.GetAxis("RightControl");
                break;
        }

        return movement;
    }

    private void Move(float movement)
    {
        Vector2 velo = rb.velocity;// получаем текущую скорость
        velo.y = moveSpeed * movement;// меняем только Y (вертикаль)
        rb.velocity = velo;// применяем новую скорость

    }
}
