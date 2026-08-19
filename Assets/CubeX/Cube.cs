using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    //Mesh renderer for cube used to fetch components like material,etc. from the game object
    public MeshRenderer Renderer;

    //Position of cube when the game plays
    public Vector3 inGamePosition = Vector3.forward;
    //Boolean to reset the position of the cube
    public bool resetToInitialPosition = true;

    //Array of colors which player can change colors when key pressed 
    public Color[] cubeColor = { Color.blue, Color.skyBlue, Color.lightPink, Color.purple};

    //Input Action to reset the position of the cube
    public InputAction resetPositionAction;
    //Input Action to change the color of the cube
    public InputAction changeColorAction;

    //Rotation speed of the cube 
    private float cubeRotationSpeed = 10f;
    //Initial position of the cube (0,0,0)
    private Vector3 initialPosition = Vector3.zero;
    //Material of the cube to change the cube properties
    private Material cubeMaterial;
    
    void Start()
    {
        //Enables InputAcion for "ResetPosition" & "ColorChange" to take inputs from user
        resetPositionAction.Enable();
        changeColorAction.Enable();

        //Increases the size of the cube 
        transform.localScale = Vector3.one * 1.3f;
        
        //Fetch material from renderer
        cubeMaterial = Renderer.material;

        //Sets the cube position for game 
        transform.position = inGamePosition;
    }
    
    void Update()
    {
        //Checks if the button is pressed to reset position
        if (resetPositionAction.triggered)
        {
            //Calls ResetCubePosition method to reset the position of cube
            ResetCubePosition(resetToInitialPosition);
            //resets the boolean state
            resetToInitialPosition = !resetToInitialPosition;
        }

        //Checks if the button is pressed to change color
        if (changeColorAction.triggered)
        {
            //Randomly change cube color from the array
            cubeMaterial.color = cubeColor[Random.Range(0, cubeColor.Length)];
        }
        
        //Roatate cube over time
        transform.Rotate(cubeRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }


    //Method to reset the position of cube
    void ResetCubePosition(bool reset)
    {
        //If condition  is true perform action
        if(reset)
        {
            //reset the cube position to its initial position which is (0,0,0) 
            transform.position = initialPosition;
        }
        else
        {
            //Change the cube position to in game position
            transform.position = inGamePosition;
        }
    }
}
