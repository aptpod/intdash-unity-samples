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
    /// EdgeConnectionItem
    /// </summary>
    [DataContract(Name = "EdgeConnectionItem")]
    public partial class EdgeConnectionItem : IEquatable<EdgeConnectionItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeConnectionItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EdgeConnectionItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeConnectionItem" /> class.
        /// </summary>
        /// <param name="uuid">エッジ接続のUUID (required).</param>
        /// <param name="lastLivedAt">サーバーがこのエッジ接続を確認できた最後の日時。 エッジとサーバーがWebSocketで接続されている間、この値は数秒おきに最新の日時に更新されます。 WebSocketが切断されると、それ以上更新されなくなります。 更新は数秒おきであるため、WebSocketが切断された場合に その切断の時刻が正確に記録されるわけではありません。 (required).</param>
        /// <param name="edge">edge (required).</param>
        /// <param name="createdAt">エッジ接続が作成された日時 (required).</param>
        /// <param name="updatedAt">エッジ接続の最終更新日時 (required).</param>
        public EdgeConnectionItem(string uuid = default(string), string lastLivedAt = default(string), EdgeConnectionEdge edge = default(EdgeConnectionEdge), string createdAt = default(string), string updatedAt = default(string))
        {
            // to ensure "uuid" is required (not null)
            if (uuid == null)
            {
                throw new ArgumentNullException("uuid is a required property for EdgeConnectionItem and cannot be null");
            }
            this.Uuid = uuid;
            // to ensure "lastLivedAt" is required (not null)
            if (lastLivedAt == null)
            {
                throw new ArgumentNullException("lastLivedAt is a required property for EdgeConnectionItem and cannot be null");
            }
            this.LastLivedAt = lastLivedAt;
            // to ensure "edge" is required (not null)
            if (edge == null)
            {
                throw new ArgumentNullException("edge is a required property for EdgeConnectionItem and cannot be null");
            }
            this.Edge = edge;
            // to ensure "createdAt" is required (not null)
            if (createdAt == null)
            {
                throw new ArgumentNullException("createdAt is a required property for EdgeConnectionItem and cannot be null");
            }
            this.CreatedAt = createdAt;
            // to ensure "updatedAt" is required (not null)
            if (updatedAt == null)
            {
                throw new ArgumentNullException("updatedAt is a required property for EdgeConnectionItem and cannot be null");
            }
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// エッジ接続のUUID
        /// </summary>
        /// <value>エッジ接続のUUID</value>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public string Uuid { get; set; }

        /// <summary>
        /// サーバーがこのエッジ接続を確認できた最後の日時。 エッジとサーバーがWebSocketで接続されている間、この値は数秒おきに最新の日時に更新されます。 WebSocketが切断されると、それ以上更新されなくなります。 更新は数秒おきであるため、WebSocketが切断された場合に その切断の時刻が正確に記録されるわけではありません。
        /// </summary>
        /// <value>サーバーがこのエッジ接続を確認できた最後の日時。 エッジとサーバーがWebSocketで接続されている間、この値は数秒おきに最新の日時に更新されます。 WebSocketが切断されると、それ以上更新されなくなります。 更新は数秒おきであるため、WebSocketが切断された場合に その切断の時刻が正確に記録されるわけではありません。</value>
        [DataMember(Name = "last_lived_at", IsRequired = true, EmitDefaultValue = true)]
        public string LastLivedAt { get; set; }

        /// <summary>
        /// Gets or Sets Edge
        /// </summary>
        [DataMember(Name = "edge", IsRequired = true, EmitDefaultValue = true)]
        public EdgeConnectionEdge Edge { get; set; }

        /// <summary>
        /// エッジ接続が作成された日時
        /// </summary>
        /// <value>エッジ接続が作成された日時</value>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// エッジ接続の最終更新日時
        /// </summary>
        /// <value>エッジ接続の最終更新日時</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EdgeConnectionItem {\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  LastLivedAt: ").Append(LastLivedAt).Append("\n");
            sb.Append("  Edge: ").Append(Edge).Append("\n");
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
            return this.Equals(input as EdgeConnectionItem);
        }

        /// <summary>
        /// Returns true if EdgeConnectionItem instances are equal
        /// </summary>
        /// <param name="input">Instance of EdgeConnectionItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EdgeConnectionItem input)
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
                    this.LastLivedAt == input.LastLivedAt ||
                    (this.LastLivedAt != null &&
                    this.LastLivedAt.Equals(input.LastLivedAt))
                ) && 
                (
                    this.Edge == input.Edge ||
                    (this.Edge != null &&
                    this.Edge.Equals(input.Edge))
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
                if (this.LastLivedAt != null)
                {
                    hashCode = (hashCode * 59) + this.LastLivedAt.GetHashCode();
                }
                if (this.Edge != null)
                {
                    hashCode = (hashCode * 59) + this.Edge.GetHashCode();
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