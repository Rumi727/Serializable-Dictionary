#nullable enable
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rumi.Editor.Serializables
{
    public static class SerializableUtility
    {
        public static void BeginLabelWidth(string label) => BeginLabelWidth(new GUIContent(label));
        public static void BeginLabelWidth(GUIContent label) => BeginLabelWidth(label, EditorStyles.label);
        public static void BeginLabelWidth(GUIContent label, GUIStyle style) => BeginLabelWidth(GetXSize(label, style) + 2);



        static readonly Stack<float> labelWidthQueue = new Stack<float>();
        public static void BeginLabelWidth(float width)
        {
            labelWidthQueue.Push(EditorGUIUtility.labelWidth);
            EditorGUIUtility.labelWidth = width;
        }

        public static void EndLabelWidth()
        {
            if (labelWidthQueue.TryPop(out float result) && labelWidthQueue.Count > 0)
                EditorGUIUtility.labelWidth = result;
            else
                EditorGUIUtility.labelWidth = 0;
        }

        public static float GetXSize(string label, GUIStyle style) => GetXSize(new GUIContent(label), style);
        public static float GetYSize(string label, GUIStyle style) => GetYSize(new GUIContent(label), style);

        public static float GetXSize(GUIContent content, GUIStyle style) => style.CalcSize(content).x;
        public static float GetYSize(GUIContent content, GUIStyle style) => style.CalcSize(content).y;

        public static bool IsChildrenIncluded(this SerializedProperty prop) => prop.propertyType == SerializedPropertyType.Generic || prop.propertyType == SerializedPropertyType.Vector4;

        public static void SetDefaultValue(this SerializedProperty serializedProperty)
        {
            if (serializedProperty.isArray)
            {
                serializedProperty.ClearArray();
                return;
            }

            if (serializedProperty.propertyType == SerializedPropertyType.String)
            {
                serializedProperty.stringValue = string.Empty;
                return;
            }

            if (serializedProperty.boxedValue != null)
            {
                serializedProperty.boxedValue = serializedProperty.boxedValue.GetType().GetDefaultValue();
                return;
            }
        }

        public static bool IsNullable(this SerializedProperty serializedProperty) => serializedProperty.propertyType == SerializedPropertyType.ManagedReference || serializedProperty.propertyType == SerializedPropertyType.ObjectReference || serializedProperty.propertyType == SerializedPropertyType.ExposedReference || serializedProperty.propertyType == SerializedPropertyType.String;

        public static SerializedProperty? GetParent(this SerializedProperty serializedProperty)
        {
            string path = serializedProperty.propertyPath;
            if (path.Contains('.'))
            {
                int index = path.LastIndexOf('.');
                path = path.Substring(0, index);

                return serializedProperty.serializedObject.FindProperty(path);
            }

            return null;
        }

        public static bool IsInArray(this SerializedProperty? serializedProperty)
        {
            while ((serializedProperty = serializedProperty?.GetParent()) != null)
            {
                if (serializedProperty.isArray)
                    return true;
            }

            return false;
        }

        public static object? GetDefaultValue(this Type type)
        {
            if (!type.IsValueType)
                return null;

            return Activator.CreateInstance(type);
        }
    }
}
