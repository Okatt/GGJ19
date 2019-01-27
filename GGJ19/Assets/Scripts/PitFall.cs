using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{
    private Vector3 mainPosition;
    public GameObject particleDestroyPrefab;

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject particleDestroy = Instantiate(particleDestroyPrefab);
        particleDestroy.transform.position = collision.transform.position;
        Destroy(collision.gameObject);
        StartCoroutine(DestroyParticle(particleDestroy, 2.0f));
    }

    private IEnumerator DestroyParticle(GameObject particle, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(particle);
    }
}
