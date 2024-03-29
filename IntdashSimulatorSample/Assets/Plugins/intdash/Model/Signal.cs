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
    /// Signal
    /// </summary>
    [DataContract(Name = "Signal")]
    public partial class Signal : IEquatable<Signal>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Signal" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Signal() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Signal" /> class.
        /// </summary>
        /// <param name="uuid">信号定義のUUID (required).</param>
        /// <param name="label">信号定義のラベル (required).</param>
        /// <param name="description">信号定義の説明 (required).</param>
        /// <param name="dataType">データタイプ (required).</param>
        /// <param name="dataId">データID (required).</param>
        /// <param name="channel">チャンネル (required).</param>
        /// <param name="conversion">conversion (required).</param>
        /// <param name="display">display (required).</param>
        /// <param name="hash">信号定義のハッシュ値 (required).</param>
        /// <param name="createdAt">信号定義の作成日時 (required).</param>
        /// <param name="updatedAt">信号定義の最終更新日時 (required).</param>
        public Signal(string uuid = default(string), string label = default(string), string description = default(string), int dataType = default(int), string dataId = default(string), int channel = default(int), SignalConversion conversion = default(SignalConversion), SignalDisplay display = default(SignalDisplay), string hash = default(string), string createdAt = default(string), string updatedAt = default(string))
        {
            // to ensure "uuid" is required (not null)
            if (uuid == null)
            {
                throw new ArgumentNullException("uuid is a required property for Signal and cannot be null");
            }
            this.Uuid = uuid;
            // to ensure "label" is required (not null)
            if (label == null)
            {
                throw new ArgumentNullException("label is a required property for Signal and cannot be null");
            }
            this.Label = label;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for Signal and cannot be null");
            }
            this.Description = description;
            this.DataType = dataType;
            // to ensure "dataId" is required (not null)
            if (dataId == null)
            {
                throw new ArgumentNullException("dataId is a required property for Signal and cannot be null");
            }
            this.DataId = dataId;
            this.Channel = channel;
            // to ensure "conversion" is required (not null)
            if (conversion == null)
            {
                throw new ArgumentNullException("conversion is a required property for Signal and cannot be null");
            }
            this.Conversion = conversion;
            // to ensure "display" is required (not null)
            if (display == null)
            {
                throw new ArgumentNullException("display is a required property for Signal and cannot be null");
            }
            this.Display = display;
            // to ensure "hash" is required (not null)
            if (hash == null)
            {
                throw new ArgumentNullException("hash is a required property for Signal and cannot be null");
            }
            this.Hash = hash;
            // to ensure "createdAt" is required (not null)
            if (createdAt == null)
            {
                throw new ArgumentNullException("createdAt is a required property for Signal and cannot be null");
            }
            this.CreatedAt = createdAt;
            // to ensure "updatedAt" is required (not null)
            if (updatedAt == null)
            {
                throw new ArgumentNullException("updatedAt is a required property for Signal and cannot be null");
            }
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 信号定義のUUID
        /// </summary>
        /// <value>信号定義のUUID</value>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public string Uuid { get; set; }

        /// <summary>
        /// 信号定義のラベル
        /// </summary>
        /// <value>信号定義のラベル</value>
        [DataMember(Name = "label", IsRequired = true, EmitDefaultValue = true)]
        public string Label { get; set; }

        /// <summary>
        /// 信号定義の説明
        /// </summary>
        /// <value>信号定義の説明</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// データタイプ
        /// </summary>
        /// <value>データタイプ</value>
        [DataMember(Name = "data_type", IsRequired = true, EmitDefaultValue = true)]
        public int DataType { get; set; }

        /// <summary>
        /// データID
        /// </summary>
        /// <value>データID</value>
        [DataMember(Name = "data_id", IsRequired = true, EmitDefaultValue = true)]
        public string DataId { get; set; }

        /// <summary>
        /// チャンネル
        /// </summary>
        /// <value>チャンネル</value>
        [DataMember(Name = "channel", IsRequired = true, EmitDefaultValue = true)]
        public int Channel { get; set; }

        /// <summary>
        /// Gets or Sets Conversion
        /// </summary>
        [DataMember(Name = "conversion", IsRequired = true, EmitDefaultValue = true)]
        public SignalConversion Conversion { get; set; }

        /// <summary>
        /// Gets or Sets Display
        /// </summary>
        [DataMember(Name = "display", IsRequired = true, EmitDefaultValue = true)]
        public SignalDisplay Display { get; set; }

        /// <summary>
        /// 信号定義のハッシュ値
        /// </summary>
        /// <value>信号定義のハッシュ値</value>
        [DataMember(Name = "hash", IsRequired = true, EmitDefaultValue = true)]
        public string Hash { get; set; }

        /// <summary>
        /// 信号定義の作成日時
        /// </summary>
        /// <value>信号定義の作成日時</value>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 信号定義の最終更新日時
        /// </summary>
        /// <value>信号定義の最終更新日時</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Signal {\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DataType: ").Append(DataType).Append("\n");
            sb.Append("  DataId: ").Append(DataId).Append("\n");
            sb.Append("  Channel: ").Append(Channel).Append("\n");
            sb.Append("  Conversion: ").Append(Conversion).Append("\n");
            sb.Append("  Display: ").Append(Display).Append("\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
            return this.Equals(input as Signal);
        }

        /// <summary>
        /// Returns true if Signal instances are equal
        /// </summary>
        /// <param name="input">Instance of Signal to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Signal input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Uuid == input.Uuid ||
                    (this.Uuid != null &&
                    this.Uuid.Equals(input.Uuid))
                ) && 
                (
                    this.Label == input.Label ||
                    (this.Label != null &&
                    this.Label.Equals(input.Label))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DataType == input.DataType ||
                    this.DataType.Equals(input.DataType)
                ) && 
                (
                    this.DataId == input.DataId ||
                    (this.DataId != null &&
                    this.DataId.Equals(input.DataId))
                ) && 
                (
                    this.Channel == input.Channel ||
                    this.Channel.Equals(input.Channel)
                ) && 
                (
                    this.Conversion == input.Conversion ||
                    (this.Conversion != null &&
                    this.Conversion.Equals(input.Conversion))
                ) && 
                (
                    this.Display == input.Display ||
                    (this.Display != null &&
                    this.Display.Equals(input.Display))
                ) && 
                (
                    this.Hash == input.Hash ||
                    (this.Hash != null &&
                    this.Hash.Equals(input.Hash))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
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
                if (this.Uuid != null)
                {
                    hashCode = (hashCode * 59) + this.Uuid.GetHashCode();
                }
                if (this.Label != null)
                {
                    hashCode = (hashCode * 59) + this.Label.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DataType.GetHashCode();
                if (this.DataId != null)
                {
                    hashCode = (hashCode * 59) + this.DataId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Channel.GetHashCode();
                if (this.Conversion != null)
                {
                    hashCode = (hashCode * 59) + this.Conversion.GetHashCode();
                }
                if (this.Display != null)
                {
                    hashCode = (hashCode * 59) + this.Display.GetHashCode();
                }
                if (this.Hash != null)
                {
                    hashCode = (hashCode * 59) + this.Hash.GetHashCode();
                }
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
