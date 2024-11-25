using UnityEngine;

public class PlayerAndShadow : MonoBehaviour
{
    public GameObject player;
    public GameObject shadow;
    public float delay = 2f;

    private Vector3[] positionBuffer;
    private Quaternion[] rotationBuffer;
    private int bufferSize;
    private int writeIndex = 0;
    private int readIndex = 0;
    private float timePerStep;
    private float timer;

    void Start()
    {
        timePerStep = Time.fixedDeltaTime;
        bufferSize = Mathf.CeilToInt(delay / timePerStep);

        positionBuffer = new Vector3[bufferSize];
        rotationBuffer = new Quaternion[bufferSize];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timePerStep)
        {
            positionBuffer[writeIndex] = player.transform.position;
            rotationBuffer[writeIndex] = player.transform.rotation;

            writeIndex = (writeIndex + 1) % bufferSize;
            timer = 0f;

            if ((writeIndex + 1) % bufferSize == readIndex)
            {
                readIndex = (readIndex + 1) % bufferSize;
            }
        }

        shadow.transform.position = positionBuffer[readIndex];
        shadow.transform.rotation = rotationBuffer[readIndex];
    }
}
