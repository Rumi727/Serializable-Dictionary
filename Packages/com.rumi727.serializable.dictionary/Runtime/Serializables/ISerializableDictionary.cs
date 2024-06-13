#nullable enable
using System;
using System.Collections;
using UnityEngine;

namespace Rumi.Serializables
{
    public interface ISerializableDictionary : IDictionary, ISerializationCallbackReceiver
    {
        Type keyType { get; }
        Type valueType { get; }

        IList serializableKeys { get; }
        IList serializableValues { get; }
    }
}
