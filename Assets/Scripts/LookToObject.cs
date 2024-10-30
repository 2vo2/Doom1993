using UnityEngine;

public class LookToObject : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Player.Instance.transform);
    }
}
