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
using FileParameter = intdash.Client.FileParameter;
using OpenAPIDateConverter = intdash.Client.OpenAPIDateConverter;

namespace intdash.Model
{
    /// <summary>
    /// SignalConversionOptionJSON
    /// </summary>
    [DataContract(Name = "SignalConversionOptionJSON")]
    public partial class SignalConversionOptionJSON : IEquatable<SignalConversionOptionJSON>
    {
        /// <summary>
        /// 値のタイプ
        /// </summary>
        /// <value>値のタイプ</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ValueTypeEnum
        {
            /// <summary>
            /// Enum Str for value: str
            /// </summary>
            [EnumMember(Value = "str")]
            Str = 1,

            /// <summary>
            /// Enum Num for value: num
            /// </summary>
            [EnumMember(Value = "num")]
            Num = 2

        }


        /// <summary>
        /// 値のタイプ
        /// </summary>
        /// <value>値のタイプ</value>
        [DataMember(Name = "value_type", IsRequired = true, EmitDefaultValue = true)]
        public ValueTypeEnum ValueType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalConversionOptionJSON" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SignalConversionOptionJSON() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalConversionOptionJSON" /> class.
        /// </summary>
        /// <param name="fieldpath">抽出したいフィールドのパス (required).</param>
        /// <param name="valueType">値のタイプ (required).</param>
        public SignalConversionOptionJSON(string fieldpath = default(string), ValueTypeEnum valueType = default(ValueTypeEnum))
        {
            // to ensure "fieldpath" is required (not null)
            if (fieldpath == null)
            {
                throw new ArgumentNullException("fieldpath is a required property for SignalConversionOptionJSON and cannot be null");
            }
            this.Fieldpath = fieldpath;
            this.ValueType = valueType;
        }

        /// <summary>
        /// 抽出したいフィールドのパス
        /// </summary>
        /// <value>抽出したいフィールドのパス</value>
        [DataMember(Name = "fieldpath", IsRequired = true, EmitDefaultValue = true)]
        public string Fieldpath { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SignalConversionOptionJSON {\n");
            sb.Append("  Fieldpath: ").Append(Fieldpath).Append("\n");
            sb.Append("  ValueType: ").Append(ValueType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as SignalConversionOptionJSON);
        }

        /// <summary>
        /// Returns true if SignalConversionOptionJSON instances are equal
        /// </summary>
        /// <param name="input">Instance of SignalConversionOptionJSON to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignalConversionOptionJSON input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Fieldpath == input.Fieldpath ||
                    (this.Fieldpath != null &&
                    this.Fieldpath.Equals(input.Fieldpath))
                ) && 
                (
                    this.ValueType == input.ValueType ||
                    this.ValueType.Equals(input.ValueType)
                );
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
                if (this.Fieldpath != null)
                {
                    hashCode = (hashCode * 59) + this.Fieldpath.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ValueType.GetHashCode();
                return hashCode;
            }
        }

    }

}
