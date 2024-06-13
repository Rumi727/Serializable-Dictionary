# Serializable Dictionary

Language available: \[[**한국어 (대한민국)**](README.md)\] \[[English (US)](README-EN.md)\]  

유니티에서 바로 사용 가능한 직렬화 딕셔너리 입니다

## 설치 방법

유니티 버전 2022.3.0f1 이상으로 테스트했습니다\
만약 특정 버전에서 오류가 발생한다면 얘기해주세요

1. 패키지 관리자에서 git URL로 설치합니다
    - \* Rumi's Serializable Dictionary : `https://github.com/Rumi727/Serializable-Dictionary.git?path=Packages/com.rumi727.serializable.dictionary`
2. 끝!

## 사용 방법

[Dictionary]: https://learn.microsoft.com/ko-kr/dotnet/api/system.collections.generic.dictionary-2?view=netstandard-2.0
[SerializableDictionary]: Packages/com.rumi727.serializable.dictionary/Runtime/Serializables/SerializableDictionary.cs

```csharp
public class Test : MonoBehaviour
{
  public SerializableDictionary<string, Color> colorDatas;
}
```

네. 이게 끝입니다!\
평소 딕셔너리 선언하듯이 해주면 알아서 모든걸 다 해줍니다

또한, [SerializableDictionary]는 Dictionary를 상속하기 때문에 평소 딕셔너리 쓰듯이 쓰기만 하면 됩니다\
즉, 기존에 쓰던 [Dictionary]를 [SerializableDictionary]로 교채만 해도 완벽히 호환된다는거죠!\
그렇기에 당연히 [Json.NET](https://www.newtonsoft.com/json) 같은 패키지에서도 딕셔너리로 감지할 것입니다 ~~(아마도요?)~~

추가로, 유니티 내부 직렬화 시스템을 사용한 것이기 때문에 스크립트 뿐만 아니라 [ScriptableObject](https://docs.unity3d.com/kr/2022.3/Manual/class-ScriptableObject.html), [JsonUtility](https://docs.unity3d.com/ScriptReference/JsonUtility.html) 등 여러곳에서도 사용할 수 있습니다\
또한 당연히 되돌리기, 다시실행 같은것도 지원합니다\
프리팹 오버라이딩 또한 지원은 하나, 리스트를 2개로 키와 값을 분류하는 그 특성상 조오금 이상하긴 합니다 (리스트 하나로 합치고 싶었는데 그러면 너무 복잡해지더라구요)

### 인스펙터에서는 어떻게 보이나요?

![image](https://github.com/Rumi727/Serializable-Dictionary/assets/65212622/39ec5f6e-02c6-4b32-8e65-84eade7917ec)
