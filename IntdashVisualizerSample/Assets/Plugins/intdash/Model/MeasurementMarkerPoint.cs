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
    /// MeasurementMarkerPoint
    /// </summary>
    [DataContract(Name = "MeasurementMarkerPoint")]
    public partial class MeasurementMarkerPoint : IEquatable<MeasurementMarkerPoint>
    {
        /// <summary>
        /// 計測マーカーのタイプ - &#x60;point&#x60; : ポイントマーカー - &#x60;range&#x60; : 範囲マーカー
        /// </summary>
        /// <value>計測マーカーのタイプ - &#x60;point&#x60; : ポイントマーカー - &#x60;range&#x60; : 範囲マーカー</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Point for value: point
            /// </summary>
            [EnumMember(Value = "point")]
            Point = 1,

            /// <summary>
            /// Enum Range for value: range
            /// </summary>
            [EnumMember(Value = "range")]
            Range = 2

        }


        /// <summary>
        /// 計測マーカーのタイプ - &#x60;point&#x60; : ポイントマーカー - &#x60;range&#x60; : 範囲マーカー
        /// </summary>
        /// <value>計測マーカーのタイプ - &#x60;point&#x60; : ポイントマーカー - &#x60;range&#x60; : 範囲マーカー</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementMarkerPoint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MeasurementMarkerPoint() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementMarkerPoint" /> class.
        /// </summary>
        /// <param name="uuid">計測マーカーのUUID (required).</param>
        /// <param name="name">計測マーカーの名前 (required).</param>
        /// <param name="description">計測マーカーの説明 (required).</param>
        /// <param name="type">計測マーカーのタイプ - &#x60;point&#x60; : ポイントマーカー - &#x60;range&#x60; : 範囲マーカー (required).</param>
        /// <param name="tag">計測マーカーに付与されたタグ (required).</param>
        /// <param name="createdAt">計測マーカーの作成日時 (required).</param>
        /// <param name="createdBy">計測マーカー作成者 (required).</param>
        /// <param name="updatedAt">計測マーカーの最終更新日時 (required).</param>
        /// <param name="updatedBy">計測マーカーの最終更新者 (required).</param>
        /// <param name="detail">detail (required).</param>
        public MeasurementMarkerPoint(string uuid = default(string), string name = default(string), string description = default(string), TypeEnum type = default(TypeEnum), Object tag = default(Object), string createdAt = default(string), string createdBy = default(string), string updatedAt = default(string), string updatedBy = default(string), MeasurementMarkerDetailPoint detail = default(MeasurementMarkerDetailPoint))
        {
            // to ensure "uuid" is required (not null)
            if (uuid == null)
            {
                throw new ArgumentNullException("uuid is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.Uuid = uuid;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.Name = name;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.Description = description;
            this.Type = type;
            // to ensure "tag" is required (not null)
            if (tag == null)
            {
                throw new ArgumentNullException("tag is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.Tag = tag;
            // to ensure "createdAt" is required (not null)
            if (createdAt == null)
            {
                throw new ArgumentNullException("createdAt is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.CreatedAt = createdAt;
            // to ensure "createdBy" is required (not null)
            if (createdBy == null)
            {
                throw new ArgumentNullException("createdBy is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.CreatedBy = createdBy;
            // to ensure "updatedAt" is required (not null)
            if (updatedAt == null)
            {
                throw new ArgumentNullException("updatedAt is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.UpdatedAt = updatedAt;
            // to ensure "updatedBy" is required (not null)
            if (updatedBy == null)
            {
                throw new ArgumentNullException("updatedBy is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.UpdatedBy = updatedBy;
            // to ensure "detail" is required (not null)
            if (detail == null)
            {
                throw new ArgumentNullException("detail is a required property for MeasurementMarkerPoint and cannot be null");
            }
            this.Detail = detail;
        }

        /// <summary>
        /// 計測マーカーのUUID
        /// </summary>
        /// <value>計測マーカーのUUID</value>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public string Uuid { get; set; }

        /// <summary>
        /// 計測マーカーの名前
        /// </summary>
        /// <value>計測マーカーの名前</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// 計測マーカーの説明
        /// </summary>
        /// <value>計測マーカーの説明</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// 計測マーカーに付与されたタグ
        /// </summary>
        /// <value>計測マーカーに付与されたタグ</value>
        [DataMember(Name = "tag", IsRequired = true, EmitDefaultValue = true)]
        public Object Tag { get; set; }

        /// <summary>
        /// 計測マーカーの作成日時
        /// </summary>
        /// <value>計測マーカーの作成日時</value>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 計測マーカー作成者
        /// </summary>
        /// <value>計測マーカー作成者</value>
        [DataMember(Name = "created_by", IsRequired = true, EmitDefaultValue = true)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 計測マーカーの最終更新日時
        /// </summary>
        /// <value>計測マーカーの最終更新日時</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// 計測マーカーの最終更新者
        /// </summary>
        /// <value>計測マーカーの最終更新者</value>
        [DataMember(Name = "updated_by", IsRequired = true, EmitDefaultValue = true)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Detail
        /// </summary>
        [DataMember(Name = "detail", IsRequired = true, EmitDefaultValue = true)]
        public MeasurementMarkerDetailPoint Detail { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MeasurementMarkerPoint {\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  Detail: ").Append(Detail).Append("\n");
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
            return this.Equals(input as MeasurementMarkerPoint);
        }

        /// <summary>
        /// Returns true if MeasurementMarkerPoint instances are equal
        /// </summary>
        /// <param name="input">Instance of MeasurementMarkerPoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MeasurementMarkerPoint input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Tag == input.Tag ||
                    (this.Tag != null &&
                    this.Tag.Equals(input.Tag))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
                ) && 
                (
                    this.Detail == input.Detail ||
                    (this.Detail != null &&
                    this.Detail.Equals(input.Detail))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Tag != null)
                {
                    hashCode = (hashCode * 59) + this.Tag.GetHashCode();
                }
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.CreatedBy != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedBy.GetHashCode();
                }
                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }
                if (this.UpdatedBy != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedBy.GetHashCode();
                }
                if (this.Detail != null)
                {
                    hashCode = (hashCode * 59) + this.Detail.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
