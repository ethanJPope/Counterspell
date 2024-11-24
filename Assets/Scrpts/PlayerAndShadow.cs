using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAndShadow : MonoBehaviour
{
    public GameObject player; // The player object
    public GameObject shadow; // The shadow object
    public float delay = 2f;  // Delay in seconds

    private Queue<Vector3> positionQueue = new Queue<Vector3>();
    private Queue<Quaternion> rotationQueue = new Queue<Quaternion>();
    private float timer;
    private float startTime;
    float start = 1;

    void Update()
    {

        // Record player's position and rotation over time
        timer += Time.deltaTime;
        if (timer >= Time.fixedDeltaTime)
        {
            positionQueue.Enqueue(player.transform.position);
            rotationQueue.Enqueue(player.transform.rotation);
            timer = 0f;
        }

        // Remove positions/rotations older than the delay
        if (positionQueue.Count > delay / Time.fixedDeltaTime)
        {
            shadow.transform.position = positionQueue.Dequeue();
            shadow.transform.rotation = rotationQueue.Dequeue();
        }
    }
}
