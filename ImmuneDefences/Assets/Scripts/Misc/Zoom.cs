using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoomSpeed = 100;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 5.0f;
    [SerializeField] private float scroll;

    void Start() {
        targetOrtho = Camera.main.orthographicSize;
    }

    private void Update() {
        scroll = Input.GetAxis("Mouse ScrollWheel") * 10000000000000;
        if (scroll != 0.0f) {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        transform.position += new Vector3(0, Input.GetAxis("Vertical") / 100, 0);
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.4f + Camera.main.orthographicSize * Camera.main.aspect, 9.4f - Camera.main.orthographicSize * Camera.main.aspect), Mathf.Clamp(transform.position.y, -5 +  Camera.main.orthographicSize, 5 - Camera.main.orthographicSize), -10);
    
    }
}
