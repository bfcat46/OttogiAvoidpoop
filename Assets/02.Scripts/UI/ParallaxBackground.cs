using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField][Range(-1.0f, 1.0f)]
    private float MoveSpeed = 0.1f;
    private Material _material;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _material.SetTextureOffset(MainTex, Vector2.right * (MoveSpeed * Time.time));
    }
}
