using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public interface ILogger
{
    void Info(object sender, object o);
    void Warn(object sender, object o);
    void Error(object sender, object o);
    void Exception(object sender, Exception ex);
    void Fatal(object sender, object o);

    void Variable(object sender, string name, object value);
}


/// <summary>
///     Basic logging implementation.
///     Just wraps the default console logging solution
///     and adds support for variable logging
/// </summary>
public class LoggerConsole : ILogger
{
    public bool ColorMessages = false;

    public string InfoColor = "#000000ff";
    public string WarnColor = "#808000ff";
    public string ErrorColor = "#ff0000ff";
    public string VariableColor = "#008080ff";

    private readonly Dictionary<string, object> _variables = new Dictionary<string, object>();

    public void Info(object sender, object o)
    {
        var obj = sender as Object;

        if (obj != null) Debug.Log(GetMessageColored(o,InfoColor), obj);
        else Debug.Log(GetMessageColored(o, InfoColor));
    }

    public void Warn(object sender, object o)
    {
        var obj = sender as Object;

        if (obj != null) Debug.LogWarning(GetMessageColored(o, WarnColor), obj);
        else Debug.LogWarning(GetMessageColored(o, WarnColor));
    }

    public void Error(object sender, object o)
    {
        var obj = sender as Object;

        if (obj != null) Debug.LogError(GetMessageColored(o, ErrorColor), obj);
        else Debug.LogError(GetMessageColored(o, ErrorColor));
    }

    public void Exception(object sender, Exception ex)
    {
        var obj = sender as Object;

        if (obj != null) Debug.LogException(ex, obj);
        else Debug.LogException(ex);
    }

    public void Fatal(object sender, object o)
    {
        Error(sender, o);
        Debug.Break();
    }

    /// <summary>
    ///     Variable logging is a bit more complex,
    ///     It basically checks to see if the object who is logging
    ///     it has logged it before, then keeps track of it.
    ///     If you log the same value over and over it will only log a new message when
    ///     the value actually changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Variable(object sender, string name, object value)
    {
        var obj = sender as Object;
        var keyName = obj != null ? obj.name : sender.GetType().Name;
        var actualKey = keyName + ":" + name;

        if (_variables.ContainsKey(actualKey))
        {
            if (!_variables[actualKey].Equals(value))
                Info(sender,
                    string.Format(GetMessageColored(actualKey,VariableColor) + " - " + value));
            _variables[actualKey] = value;
        }
        else
        {
            _variables.Add(actualKey, value);
            Info(sender, string.Format(GetMessageColored(actualKey, VariableColor) + " - " + value));
        }

    }

    object GetMessageColored(object o, string color)
    {
        return ColorMessages ? String.Format("<color={0}>", color) + o + "</color>" : o;
    }

}