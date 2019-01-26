using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ToFollow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ToFollow == null)
        {
            return;
        }

        Vector2 old = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 newPos = Vector2.Lerp(old, ToFollow.transform.position, Time.fixedDeltaTime * 5);
        this.transform.position = new Vector3(newPos.x, newPos.y, this.transform.position.z);

    }
}
