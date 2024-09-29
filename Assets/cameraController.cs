using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
    }
}
