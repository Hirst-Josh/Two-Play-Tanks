using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turrent : MonoBehaviour
{

    public int rotate;
    private Camera camera;
    public Image target;
    public float speed = 1.0f;
    private Vector3 vector3;
    public float turrrentspeed = 1f;
    public Transform hull;
    private void Start()
    {
        camera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        Quaternion TargetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        float angle = Quaternion.Angle(TargetRotation, transform.rotation);

        if (Vector3.Dot(transform.TransformDirection(Vector3.right), (target.transform.position - transform.position)) < 0f)
        {
            transform.RotateAround(hull.position, hull.up, angle * (-1f) * Time.deltaTime * turrrentspeed);
        }
        else
        {
            transform.RotateAround(hull.position, hull.up, angle * Time.deltaTime * turrrentspeed);
        }
    }

    private void FixedUpdate()
    {
       
    }
}
