using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public Vector3 inGamePosition = Vector3.forward;
    public bool resetToInitialPosition = true;

    public Color cubeColor = Color.skyBlue;

    public float cubeRotationSpeed = 2f;

    private Vector3 initialPosition = Vector3.zero;
    private Material cubeMaterial;
    
    void Start()
    {
        transform.localScale = Vector3.one * 1.3f;
        
        cubeMaterial = Renderer.material;
    }
    
    void Update()
    {
        ResetCubePosition(resetToInitialPosition);

        cubeMaterial.color = cubeColor;

        transform.Rotate(cubeRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void ResetCubePosition(bool reset)
    {
        if(reset)
        {
            transform.position = initialPosition;
        }
        else
        {
            transform.position = inGamePosition;
        }
    }
}
