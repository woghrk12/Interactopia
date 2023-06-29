using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ArrayHelper
{
    public static T[] Add<T>(T value, T[] array)
    {
        ArrayList tempList = new ArrayList();

        foreach (T item in array) { tempList.Add(item); }
        tempList.Add(value);

        return tempList.ToArray(typeof(T)) as T[];
    }

    public static T[] Remove<T>(int idx, T[] array)
    {
        ArrayList tempList = new ArrayList();

        foreach (T item in array) { tempList.Add(item); }
        tempList.RemoveAt(idx);

        return tempList.ToArray(typeof(T)) as T[];
    }

    public static T[] Remove<T>(T value, T[] array)
    {
        ArrayList tempList = new ArrayList();

        foreach (T item in array)
        {
            if (item.Equals(value)) { continue; }

            tempList.Add(item);
        }

        return tempList.ToArray(typeof(T)) as T[];
    }
}
