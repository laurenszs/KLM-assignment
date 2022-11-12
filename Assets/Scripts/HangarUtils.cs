using UnityEngine;

public class HangarUtils : MonoBehaviour
{
    public Light point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            point.color = Color.red;

            GameManager.Instance.hangarReadiness += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            point.color = Color.green;
            GameManager.Instance.hangarReadiness -= 1;
        }
    }
}