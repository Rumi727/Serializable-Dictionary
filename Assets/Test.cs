#nullable enable
using Rumi.Serializables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Test : MonoBehaviour
{
    public Color backgroundColor = new Color(0.1921568627f, 0.3019607843f, 0.4745098039f);

    public SerializableDictionary<string, string> stringData = new();
    public SerializableDictionary<string, int> intData = new();
    public SerializableDictionary<string, SerializableDictionary<string, int>> dictionaryIntData = new();
    public SerializableDictionary<string, Test2> customData = new();
    public SerializableDictionary<string, SerializableDictionary<string, Test2>> dictionaryCustomData = new();
    public SerializableDictionary<string, List<float>> listData = new();
    public Test2 test2 = new();
    [SerializeReference] public Test2? test3 = new();

    [Serializable]
    public class Test2
    {
        public SerializableDictionary<string, float> floatData = new();
        public string helloWorld = "hello world";

        public override string ToString()
        {
            string result = "";
            result += $@"
{{
  ""{nameof(floatData)}"": {Test.ToString(floatData).Replace("\n", "\n  ")},
  ""{nameof(helloWorld)}"": ""{helloWorld}""
}}";

            return result;
        }
    }

    [NonSerialized] GUIStyle? labelStyle;
    void OnGUI()
    {
        labelStyle ??= new GUIStyle(GUI.skin.label) { fontSize = 16 };

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture, ScaleMode.StretchToFill, false, 0, backgroundColor, 0, 0);

        GUI.BeginGroup(new Rect(4, 0, Screen.width - 4, Screen.height - 4));

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label($@"""{nameof(stringData)}"": {ToString(stringData)}", labelStyle);
        GUILayout.Label($@"""{nameof(test2)}"": {test2}", labelStyle);
        GUILayout.EndVertical();
        GUILayout.Space(10);
        GUILayout.Label($@"""{nameof(intData)}"": {ToString(intData)}", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label($@"""{nameof(dictionaryIntData)}"": {ToString(dictionaryIntData)}", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label($@"""{nameof(customData)}"": {ToString(customData)}", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label($@"""{nameof(dictionaryCustomData)}"": {ToString(dictionaryCustomData)}", labelStyle);
        GUILayout.EndHorizontal();

        GUI.EndGroup();
    }

    public static object?[] ToArray(ICollection collection)
    {
        object?[] result = new object[collection.Count];
        IEnumerator enumerator = collection.GetEnumerator();

        int index = 0;
        while (enumerator.MoveNext())
        {
            result[index] = enumerator.Current;
            index++;
        }

        return result;
    }

    public static string ToString(IDictionary dictionarys)
    {
        string result = $"[\n";
        var keys = ToArray(dictionarys.Keys);
        var values = ToArray(dictionarys.Values);
        for (int i = 0; i < keys.Length; i++)
        {
            var key = keys[i];
            var value = values[i];

            string valueText;
            if (value != null)
            {
                if (typeof(IDictionary).IsAssignableFrom(value.GetType()))
                    valueText = ToString((IDictionary)value);
                else
                    valueText = value.GetType() == typeof(string) ? $@"""{value}""" : value.ToString();

                valueText = valueText.Replace("\n", "\n    ");
            }
            else
                valueText = "null";

            if (key != null)
                result += $@"  {{
    ""{nameof(key)}"": {(key.GetType() == typeof(string) ? $@"""{key}""" : key)},
    ""{nameof(value)}"": {valueText}
  }}";
            else
                result += $@"  {{
    ""{nameof(key)}"": null}},
    ""{nameof(value)}"": {valueText}
  }}";

            if (i < keys.Length - 1)
                result += ",\n";
        }

        return result += $"\n]";
    }
}
