using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class AIDriver : MonoBehaviour
{
    public Transform Track;
    public float NodeRadius;
    public float Accuracy;

    SimpleCarController controller;
    Rigidbody rigidbody;
    Vector3[] trackNodes;

    Vector3 target;
    
    public int nextNode;
    float reverseTime;

	// Use this for initialization
	void Start ()
	{
	    controller = GetComponent<SimpleCarController>();
	    rigidbody = GetComponent<Rigidbody>();
	    ProcessTrack();

	    target = GetTarget();
	}
	
	// Update is called once per frame
	void Update () {
        // Cross product gives us the angle towards the next node
        Vector3 forward = transform.forward;
        Vector3 toOther = target - transform.position;
        float cross = Vector3.Cross(forward, toOther).y;

        // This stops the overcompensation
	    if (Mathf.Abs(cross) <0.5f) cross = 0f;

        // Send the cross product as our x input axis
        controller.AIXAxis = Mathf.Clamp(cross, -1f, 1f);

        // drive forward (or reverse if we're reversing)
	    controller.AIYAxis = (reverseTime>0f)?-1f:1f;

        // If we're not moving at all, wait 3 seconds and then reverse for 3 seconds
	    if (reverseTime > 0f) reverseTime -= Time.deltaTime;
        else if(rigidbody.velocity.magnitude<0.1f) reverseTime -= Time.deltaTime;
	    if (reverseTime < -3f)
	        reverseTime = 3f;

        // If we're in range of the current target node, move to the next node
	    if (Vector3.Distance(transform.position, target) < NodeRadius)
	    {
	        nextNode++;
            if (nextNode == trackNodes.Length) nextNode = 0;

	        target = GetTarget();
	    }

        Debug.DrawLine(transform.position, target, Color.magenta);
    }

    Vector3 GetTarget()
    {
        Vector3 skew = Random.insideUnitSphere*Accuracy;
        skew.y = 0;
        return trackNodes[nextNode] + skew;
    }

    void ProcessTrack()
    {
        trackNodes = new Vector3[Track.childCount];

        for (int i = 0; i < Track.childCount; i++)
        {
            trackNodes[i] = Track.GetChild(i).position;
        }
    }
}
