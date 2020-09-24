
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class EnumUtil
{
    /// <summary>
    /// Returns a loopable IEnumerable from an Enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetLoopableValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    /// <summary>
    /// Gets the string name of the enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetName<T>(T value) where T : Enum
    {
        return Enum.GetName(typeof(T), value);
    }
}