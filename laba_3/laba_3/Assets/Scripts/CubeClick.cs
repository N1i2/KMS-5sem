using UnityEditor.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        float r = Random.Range(.0f, 1.0f); 
        float g = Random.Range(.0f, 1.0f); 
        float b = Random.Range(.0f, 1.0f); 
        Color col = new Color(r, g, b);

        GetComponent<Renderer>().material.color = col;
    }
}
