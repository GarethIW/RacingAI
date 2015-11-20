using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public Vector3 Offset;
    public Transform Target;
    public float Speed;

    Vector3 target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Target = new Vector3(Kaiju.transform.position.x, Kaiju.transform.position.y, Kaiju.Depth*2f) + Offset;
        target = Target.transform.position + Offset;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * Speed);
    }


}