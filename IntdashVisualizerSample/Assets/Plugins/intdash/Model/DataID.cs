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
    /// データID
    /// </summary>
    [DataContract(Name = "DataID")]
    public partial class DataID : IEquatable<DataID>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataID" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DataID() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataID" /> class.
        /// </summary>
        /// <param name="dataType">データタイプ (required).</param>
        /// <param name="channel">チャンネル (required).</param>
        /// <param name="dataId">データID (required).</param>
        public DataID(int dataType = default(int), long channel = default(long), string dataId = default(string))
        {
            this.DataType = dataType;
            this.Channel = channel;
            // to ensure "dataId" is required (not null)
            if (dataId == null)
            {
                throw new ArgumentNullException("dataId is a required property for DataID and cannot be null");
            }
            this._DataId = dataId;
        }

        /// <summary>
        /// データタイプ
        /// </summary>
        /// <value>データタイプ</value>
        [DataMember(Name = "data_type", IsRequired = true, EmitDefaultValue = true)]
        public int DataType { get; set; }

        /// <summary>
        /// チャンネル
        /// </summary>
        /// <value>チャンネル</value>
        [DataMember(Name = "channel", IsRequired = true, EmitDefaultValue = true)]
        public long Channel { get; set; }

        /// <summary>
        /// データID
        /// </summary>
        /// <value>データID</value>
        [DataMember(Name = "data_id", IsRequired = true, EmitDefaultValue = true)]
        public string _DataId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DataID {\n");
            sb.Append("  DataType: ").Append(DataType).Append("\n");
            sb.Append("  Channel: ").Append(Channel).Append("\n");
            sb.Append("  _DataId: ").Append(_DataId).Append("\n");
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
            return this.Equals(input as DataID);
        }

        /// <summary>
        /// Returns true if DataID instances are equal
        /// </summary>
        /// <param name="input">Instance of DataID to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DataID input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DataType == input.DataType ||
                    this.DataType.Equals(input.DataType)
                ) && 
                (
                    this.Channel == input.Channel ||
                    this.Channel.Equals(input.Channel)
                ) && 
                (
                    this._DataId == input._DataId ||
                    (this._DataId != null &&
                    this._DataId.Equals(input._DataId))
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
                hashCode = (hashCode * 59) + this.DataType.GetHashCode();
                hashCode = (hashCode * 59) + this.Channel.GetHashCode();
                if (this._DataId != null)
                {
                    hashCode = (hashCode * 59) + this._DataId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}