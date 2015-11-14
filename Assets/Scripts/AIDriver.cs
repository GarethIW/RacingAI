using UnityEngine;
using System.Collections;

public class AIDriver : MonoBehaviour
{
    public Transform Track;
    public float NodeRadius;

    SimpleCarController controller;
    Vector3[] trackNodes;

    int nextNode;

	// Use this for initialization
	void Start ()
	{
	    controller = GetComponent<SimpleCarController>();
	    ProcessTrack();
	}
	
	// Update is called once per frame
	void Update () {
	    // Dot product gives us the angle towards the next node

	}

    void ProcessTrack()
    {
        trackNodes = new Vector3[Track.childCount];

        for (int i = 0; i < Track.childCount; i++)
        {
            trackNodes[i] = Track.GetChild(i).position;
        }

        nextNode = 0;
    }
}
