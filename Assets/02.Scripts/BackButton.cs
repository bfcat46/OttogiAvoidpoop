using UnityEngine;

public class BackButton : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        GameManager.Instance.OpenStartScene();
    }
}