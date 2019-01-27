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
        foregroundElement.transform.position = new Vector3(foregroundElement.transform.position.x, foregroundElement.transform.position.y, foregroundElement.transform.position.z -1);
    }

    public void SetBackground(Sprite background)
    {
        backgroundElement.GetComponent<SpriteRenderer>().sprite = background;
    }

    public void SetIcon(Sprite icon)
    {
        foregroundElement.GetComponent<SpriteRenderer>().sprite = icon;
    }
}
