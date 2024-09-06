using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Vector3 offset;
    private Transform playTransfrom;
    // Start is called before the first frame update
    void Start()
    {
        playTransfrom = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        offset = transform.position - playTransfrom.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playTransfrom.position + offset;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll*5;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);
    }
}
