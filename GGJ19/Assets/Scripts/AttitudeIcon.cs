using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttitudeIcon : MonoBehaviour
{
    public GameObject attitudeElementPrefab;

    public GameObject backgroundElement;
    public GameObject foregroundElement;

    void Awake()
    {
        backgroundElement = Instantiate(attitudeElementPrefab, transform);
        backgroundElement.transform.SetParent(transform);
        foregroundElement = Instantiate(attitudeElementPrefab, transform);
        foregroundElement.transform.SetParent(transform);

        // TODO: refactor in something less shit.
        backgroundElement.transform.position = new Vector3(foregroundElement.transform.position.x + 0.25f, foregroundElement.transform.position.y - 0.25f, foregroundElement.transform.position.z);
    }

    public void SetBackground(Sprite background)
    {
        backgroundElement.GetComponent<SpriteRenderer>().sprite = background;
        backgroundElement.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void SetIcon(Sprite icon)
    {
        foregroundElement.GetComponent<SpriteRenderer>().sprite = icon;
    }
}
