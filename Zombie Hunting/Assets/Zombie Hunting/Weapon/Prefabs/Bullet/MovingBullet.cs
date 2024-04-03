using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBullet : MonoCache
{
    [SerializeField] private float speed = 10f;

    public Vector3 directionMoving { get; set; }
    
    public override void OnTick()
    {
        if(directionMoving != null)
        {
            transform.position += directionMoving * speed * Time.deltaTime;
        }
    }
}
