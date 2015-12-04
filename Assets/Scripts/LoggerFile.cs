using System;
using System.Diagnostics;
using System.IO;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

public class LoggerFile : MonoBehaviour, ILogger
{
    public static string FilePath = @"C:\UnityLogExample.txt";
    public string ChosenFileName = @"LogExample.txt";
    void Awake()
    {
        FilePath = Path.Combine(Application.dataPath,ChosenFileName);
        Services.Logger = this;
    }

    public void Info(object sender, object o)
    {
        if(o != null) L("I: "+o);
    }

    public void Warn(object sender, object o)
    {
        if (o != null) L("W: "+o);
    }

    public void Error(object sender, object o)
    {
        if (o != null) L("E: "+o);
    }

    public void Exception(object sender, Exception ex)
    {
        if (ex != null) L("X: "+ex.Message);
    }

    public void Fatal(object sender, object o)
    {
        if (o != null) L("F: "+o);
    }

    public void Variable(object sender, string name, object value)
    {
        if (value != null) L(String.Format("V: {0} - {1}",name,value));
    }


    void L(string m)
    {
        try
        {
            TextWriter tt = new StreamWriter(FilePath, true);
            tt.WriteLine(m);
            tt.Close();
        }
        catch (Exception e)
        {
            Services.Logger = new LoggerConsole();
            Services.Logger.Error(this, "File Logger Failed, Reverting to Console Logging");
            Services.Logger.Exception(this,e);
        }
    }

    [MenuItem("Logging/Open Log File")]
    public static void OpenLogFile()
    {
        Process.Start(FilePath);
    }

}