/*
 * intdash API specification
 *
 * ## ベースURL  ベースURLは以下のとおりです。APIエンドポイントはこのベースURLから始まります。  ``` https://<host>/api ``` エンドポイント例: ``` https://example.intdash.jp/api/v1/measurements https://example.intdash.jp/api/media/videos ```  ## レスポンスのステータスコード  サーバーからクライアントに返却されるHTTPレスポンスのステータスコードは以下のとおりです。   | コード                    | 説明                                                                  | |:- -- -- -- -- -- -- -- -- -- -- -- -- -|:- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | 101 Switching Protocols   | サーバーはプロトコルを切り替えます。                                  | | 200 OK                    | リクエストは成功しました。                                            | | 201 Created               | 新しいリソースが作成されました。                                      | | 204 No Content            | リクエストは成功しました。返却するコンテンツはありません。            | | 400 Bad Request           | 構文が正しくないなどの理由により、リクエストは処理できませんでした。  | | 401 Unauthorized          | リクエストには認証が必要です。                                        | | 403 Forbidden             | アクセス権がないなどの理由により、リクエストは拒否されました。        | | 404 Not Found             | APIまたはリソースが見つかりません。                                   | | 405 Method Not Allowed    | 指定されたメソッドは許可されていません。                              | | 409 Conflict              | 既存のリソースとのコンフリクトのため、リクエストは失敗しました。      | | 500 Internal Server Error | サーバーで予期しないエラーが発生したため、リクエストは失敗しました。  |   ## 注意 リクエストボディのJSONでは、キーの大文字と小文字は区別されません。 従って、以下の2つのリクエストは同じものと見なされます。  ```  {   \"username\" : \"username\",   \"password\" : \"password\" }  ```   ```  {   \"Username\" : \"username\",   \"Password\" : \"password\" }  ```
 *
 * The version of the OpenAPI document: v2.4.0-next-4a4316946
 * Contact: VM2M-support@aptpod.co.jp
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using FileParameter = intdash.Client.FileParameter;
using OpenAPIDateConverter = intdash.Client.OpenAPIDateConverter;
using System.Reflection;

namespace intdash.Model
{
    /// <summary>
    /// MeasurementMarkerPostRequest
    /// </summary>
    [JsonConverter(typeof(MeasurementMarkerPostRequestJsonConverter))]
    [DataContract(Name = "MeasurementMarkerPostRequest")]
    public partial class MeasurementMarkerPostRequest : AbstractOpenAPISchema, IEquatable<MeasurementMarkerPostRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementMarkerPostRequest" /> class
        /// with the <see cref="MeasurementMarkerPostRequestPoint" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of MeasurementMarkerPostRequestPoint.</param>
        public MeasurementMarkerPostRequest(MeasurementMarkerPostRequestPoint actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementMarkerPostRequest" /> class
        /// with the <see cref="MeasurementMarkerPostRequestRange" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of MeasurementMarkerPostRequestRange.</param>
        public MeasurementMarkerPostRequest(MeasurementMarkerPostRequestRange actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(MeasurementMarkerPostRequestPoint))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(MeasurementMarkerPostRequestRange))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: MeasurementMarkerPostRequestPoint, MeasurementMarkerPostRequestRange");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `MeasurementMarkerPostRequestPoint`. If the actual instance is not `MeasurementMarkerPostRequestPoint`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of MeasurementMarkerPostRequestPoint</returns>
        public MeasurementMarkerPostRequestPoint GetMeasurementMarkerPostRequestPoint()
        {
            return (MeasurementMarkerPostRequestPoint)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `MeasurementMarkerPostRequestRange`. If the actual instance is not `MeasurementMarkerPostRequestRange`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of MeasurementMarkerPostRequestRange</returns>
        public MeasurementMarkerPostRequestRange GetMeasurementMarkerPostRequestRange()
        {
            return (MeasurementMarkerPostRequestRange)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MeasurementMarkerPostRequest {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, MeasurementMarkerPostRequest.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of MeasurementMarkerPostRequest
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of MeasurementMarkerPostRequest</returns>
        public static MeasurementMarkerPostRequest FromJson(string jsonString)
        {
            MeasurementMarkerPostRequest newMeasurementMarkerPostRequest = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newMeasurementMarkerPostRequest;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(MeasurementMarkerPostRequestPoint).GetProperty("AdditionalProperties") == null)
                {
                    newMeasurementMarkerPostRequest = new MeasurementMarkerPostRequest(JsonConvert.DeserializeObject<MeasurementMarkerPostRequestPoint>(jsonString, MeasurementMarkerPostRequest.SerializerSettings));
                }
                else
                {
                    newMeasurementMarkerPostRequest = new MeasurementMarkerPostRequest(JsonConvert.DeserializeObject<MeasurementMarkerPostRequestPoint>(jsonString, MeasurementMarkerPostRequest.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("MeasurementMarkerPostRequestPoint");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into MeasurementMarkerPostRequestPoint: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(MeasurementMarkerPostRequestRange).GetProperty("AdditionalProperties") == null)
                {
                    newMeasurementMarkerPostRequest = new MeasurementMarkerPostRequest(JsonConvert.DeserializeObject<MeasurementMarkerPostRequestRange>(jsonString, MeasurementMarkerPostRequest.SerializerSettings));
                }
                else
                {
                    newMeasurementMarkerPostRequest = new MeasurementMarkerPostRequest(JsonConvert.DeserializeObject<MeasurementMarkerPostRequestRange>(jsonString, MeasurementMarkerPostRequest.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("MeasurementMarkerPostRequestRange");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into MeasurementMarkerPostRequestRange: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + matchedTypes);
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newMeasurementMarkerPostRequest;
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MeasurementMarkerPostRequest);
        }

        /// <summary>
        /// Returns true if MeasurementMarkerPostRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of MeasurementMarkerPostRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MeasurementMarkerPostRequest input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
                return hashCode;
            }
        }

    }

    /// <summary>
    /// Custom JSON converter for MeasurementMarkerPostRequest
    /// </summary>
    public class MeasurementMarkerPostRequestJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(MeasurementMarkerPostRequest).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return MeasurementMarkerPostRequest.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}