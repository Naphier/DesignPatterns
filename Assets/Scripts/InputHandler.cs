using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Command currentCommand;

    private Command MOUSE_BUTTON0;

    public GameObject player;
    private Command SPACE_BAR;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        MOUSE_BUTTON0 = new FireCommand();
        SPACE_BAR = new JumpCommand();
    }

    // Update is called once per frame
    private void Update()
    {
        currentCommand = HandleInput();
        if (currentCommand != null)
        {
            currentCommand.Execute(player);
        }
    }

    private Command HandleInput()
    {
        if (Input.GetMouseButton(0))
        {
            return MOUSE_BUTTON0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return SPACE_BAR;
        }

        return null;
    }
}