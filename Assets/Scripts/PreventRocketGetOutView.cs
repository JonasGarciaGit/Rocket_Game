using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventRocketGetOutView : MonoBehaviour
{

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.2f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
