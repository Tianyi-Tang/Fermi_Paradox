using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对dictionary的扩展
/// </summary>
public static class DictionaryExtension
{
    /// <summary>
    /// 尝试根据 key 得到 value，如果得到返回 value，如果没有得到返回 null
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="Tvalue"></typeparam>
    /// <param name="dict"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static Tvalue TryGet<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
    {
        Tvalue value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
