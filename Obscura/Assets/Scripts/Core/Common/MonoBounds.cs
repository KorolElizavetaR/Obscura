using UnityEngine;

public class MonoBounds : MonoBehaviour
{
    public float width = 10f;
    public float height = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0f));
    }
}