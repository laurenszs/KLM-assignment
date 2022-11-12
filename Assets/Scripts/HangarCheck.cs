using UnityEngine;

public class HangarCheck : MonoBehaviour
{
    public Light point;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            point.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            point.color = Color.green;
        }
    }
}