# Serializable Dictionary

Language available: \[[한국어 (대한민국)](README.md)\] \[[**English (US)**](README-EN.md)\]  

This is a serializable dictionary that can be used directly in Unity.

## How to install

Tested with Unity version 2022.3.0f1 or higher\
If an error occurs in a specific version, please let me know.

1. Install with git URL from package manager
    - \* Rumi's Serializable Dictionary : `https://github.com/Rumi727/Serializable-Dictionary.git?path=Packages/com.rumi727.serializable.dictionary`
2. End!

## How to use

[Dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netstandard-2.0
[SerializableDictionary]: Packages/com.rumi727.serializable.dictionary/Runtime/Serializables/SerializableDictionary.cs
[Json.NET]: https://www.newtonsoft.com/json
[ScriptableObject]: https://docs.unity3d.com/kr/2022.3/Manual/class-ScriptableObject.html
[JsonUtility]: https://docs.unity3d.com/ScriptReference/JsonUtility.html

```csharp
public class Test : MonoBehaviour
{
  public SerializableDictionary<string, Color> colorDatas;
}
```

Yes. This is the end!\
If you do it like you normally declare a dictionary, it will do everything for you.

Additionally, [SerializableDictionary] inherits Dictionary, so you can just use it as you would normally use a dictionary\
In other words, you can just replace the previously used [Dictionary] with [SerializableDictionary] and it will be completely compatible!\
So, of course, packages such as [Json.NET] will also detect it as a dictionary ~~(maybe?)~~

Additionally, since it uses Unity's internal serialization system, it can be used not only in scripts but also in various places such as [ScriptableObject] and [JsonUtility]\
Of course, it also supports things like undo and redo\
Prefab overriding is also supported, but it is a bit strange due to the nature of classifying keys and values ​​into two lists (I wanted to combine them into one list, but that would make it too complicated).

### How does it look in the inspector?

![image](https://github.com/Rumi727/Serializable-Dictionary/assets/65212622/39ec5f6e-02c6-4b32-8e65-84eade7917ec)
