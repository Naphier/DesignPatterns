using System.Collections;
using Assets.Scripts;
using UnityEngine;

public class LoggingExample : MonoBehaviour
{
    ILogger Logger;
    int myVariable = 55;

    public bool ColorMessages = false;

    void Start ()
    {

        if (ColorMessages)
            Services.Logger = new LoggerConsole {ColorMessages = ColorMessages};


	    Logger = Services.Logger;


        Logger.Info(this,"Starting Example");
        Logger.Warn(this, "Things are about to get interesting!");
        Logger.Error(this, "Things got too interesting.....");


        StartCoroutine(TestVariableLogging());

	}


    IEnumerator TestVariableLogging()
    {
        Logger.Variable(this, "Awesomeness", myVariable);

        for (int i = 0; i < 100; i++)
            Logger.Variable(this, "Awesomeness", myVariable);

        myVariable = 1000;

        for (int i = 0; i < 100; i++)
            Logger.Variable(this, "Awesomeness", myVariable);


        yield return null;
    }

}
