using System;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;

[Serializable]
public class JsonParser
{
    public string FilePath = "server.json";
    public string Key = "";

    public JsonParser() { }

    public JsonParser(string key)
    {
        Key = key;
    }

    public JsonParser(string filePath, string key)
    {
        FilePath = filePath;
        Key = key;
    }

    public bool IsEnabled
    {
        get
        {
            var filePath = FilePath;
#if UNITY_IOS && !UNITY_EDITOR
            filePath = Path.Combine(Application.persistentDataPath, filePath);
#endif
            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(Key))
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var json = JObject.Parse(reader.ReadToEnd());
                                if (json.SelectToken(Key) != null)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return false;
        }
    }

    public T GetValue<T>(bool outputError = true, JsonSerializerSettings settings = null)
    {
        var filePath = FilePath;
#if UNITY_IOS && !UNITY_EDITOR
        filePath = Path.Combine(Application.persistentDataPath, filePath);
#endif
        if (string.IsNullOrEmpty(filePath))
        {
            if (outputError)
                Debug.LogError("Not found file path. - JsonParser");
            return default;
        }
        if (string.IsNullOrEmpty(Key))
        {
            if (outputError)
                Debug.LogError("Not found key. - JsonParser");
            return default;
        }
        if (!File.Exists(filePath))
        {
            if (outputError)
                Debug.LogError($"Not found json file. path: {filePath} - JsonParser");
            return default;
        }
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd(), settings);
                    var token = json.SelectToken(Key);
                    return token.Value<T>();
                }
            }
        }
        catch (Exception e)
        {
            if (outputError)
                Debug.LogError("Failed to deserialize json. " + e.Message);
            return default;
        }
    }

    public int GetItemLength(bool outputError = true, JsonSerializerSettings settings = null)
    {
        var filePath = FilePath;
#if UNITY_IOS && !UNITY_EDITOR
        filePath = Path.Combine(Application.persistentDataPath, filePath);
#endif
        if (string.IsNullOrEmpty(filePath))
        {
            if (outputError)
                Debug.LogError("Not found file path. - JsonParser");
            return default;
        }
        if (string.IsNullOrEmpty(Key))
        {
            if (outputError)
                Debug.LogError("Not found key. - JsonParser");
            return default;
        }
        if (!File.Exists(filePath))
        {
            if (outputError)
                Debug.LogError($"Not found json file. path: {filePath} - JsonParser");
            return default;
        }
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd(), settings);
                    var token = json.SelectToken(Key);
                    return token.ToArray().Length;
                }
            }
        }
        catch (Exception e)
        {
            if (outputError)
                Debug.LogError("Failed to deserialize json. " + e.Message);
            return default;
        }
    }


    public static bool Contains(string filePath, string key)
    {
        if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(key))
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var json = JObject.Parse(reader.ReadToEnd());
                            if (json.SelectToken(key) != null)
                            {
                                return true;
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        return false;
    }

    public static T GetValue<T>(string filePath, string key, bool outputError = true)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            if (outputError)
                Debug.LogError("Not found file path. - JsonParser");
            return default;
        }
        if (string.IsNullOrEmpty(key))
        {
            if (outputError)
                Debug.LogError("Not found key. - JsonParser");
            return default;
        }
        if (!File.Exists(filePath))
        {
            if (outputError)
                Debug.LogError($"Not found json file. path: {filePath} - JsonParser");
            return default;
        }
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = JObject.Parse(reader.ReadToEnd());
                    var token = json.SelectToken(key);
                    return token.Value<T>();
                }
            }
        }
        catch (Exception e)
        {
            if (outputError)
                Debug.LogError("Failed to deserialize json. " + e.Message);
            return default;
        }
    }
}
