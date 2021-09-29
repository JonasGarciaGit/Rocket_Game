using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public GameObject starVfx;

    private void OnParticleCollision(GameObject other)
    {
        GameObject star =  Instantiate(starVfx, transform.position, Quaternion.identity);
        StartCoroutine("DestroyVfx", star);
    }

    IEnumerator DestroyVfx(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
    }


}
