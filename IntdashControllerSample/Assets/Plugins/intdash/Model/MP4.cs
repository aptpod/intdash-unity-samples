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
    /// MP4
    /// </summary>
    [DataContract(Name = "MP4")]
    public partial class MP4 : IEquatable<MP4>
    {

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public MP4Status Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MP4" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MP4() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MP4" /> class.
        /// </summary>
        /// <param name="uuid">MP4のUUID (required).</param>
        /// <param name="startOffset">動画の開始時刻からのオフセット（マイクロ秒） (required).</param>
        /// <param name="duration">長さ（マイクロ秒） (required).</param>
        /// <param name="trimmed">指定された時間範囲のみを抽出したものである場合は &#x60;true&#x60; 。 (required).</param>
        /// <param name="filePath">メディアファイルのパス.</param>
        /// <param name="status">status (required).</param>
        /// <param name="createdAt">作成された日時 (required).</param>
        /// <param name="updatedAt">最終更新日時 (required).</param>
        public MP4(Guid uuid = default(Guid), int startOffset = default(int), int duration = default(int), bool trimmed = default(bool), string filePath = default(string), MP4Status status = default(MP4Status), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime))
        {
            this.Uuid = uuid;
            this.StartOffset = startOffset;
            this.Duration = duration;
            this.Trimmed = trimmed;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.FilePath = filePath;
        }

        /// <summary>
        /// MP4のUUID
        /// </summary>
        /// <value>MP4のUUID</value>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// 動画の開始時刻からのオフセット（マイクロ秒）
        /// </summary>
        /// <value>動画の開始時刻からのオフセット（マイクロ秒）</value>
        [DataMember(Name = "start_offset", IsRequired = true, EmitDefaultValue = true)]
        public int StartOffset { get; set; }

        /// <summary>
        /// 長さ（マイクロ秒）
        /// </summary>
        /// <value>長さ（マイクロ秒）</value>
        [DataMember(Name = "duration", IsRequired = true, EmitDefaultValue = true)]
        public int Duration { get; set; }

        /// <summary>
        /// 指定された時間範囲のみを抽出したものである場合は &#x60;true&#x60; 。
        /// </summary>
        /// <value>指定された時間範囲のみを抽出したものである場合は &#x60;true&#x60; 。</value>
        [DataMember(Name = "trimmed", IsRequired = true, EmitDefaultValue = true)]
        public bool Trimmed { get; set; }

        /// <summary>
        /// メディアファイルのパス
        /// </summary>
        /// <value>メディアファイルのパス</value>
        [DataMember(Name = "file_path", EmitDefaultValue = false)]
        public string FilePath { get; set; }

        /// <summary>
        /// 作成された日時
        /// </summary>
        /// <value>作成された日時</value>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        /// <value>最終更新日時</value>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MP4 {\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  StartOffset: ").Append(StartOffset).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Trimmed: ").Append(Trimmed).Append("\n");
            sb.Append("  FilePath: ").Append(FilePath).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as MP4);
        }

        /// <summary>
        /// Returns true if MP4 instances are equal
        /// </summary>
        /// <param name="input">Instance of MP4 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MP4 input)
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
                    this.StartOffset == input.StartOffset ||
                    this.StartOffset.Equals(input.StartOffset)
                ) && 
                (
                    this.Duration == input.Duration ||
                    this.Duration.Equals(input.Duration)
                ) && 
                (
                    this.Trimmed == input.Trimmed ||
                    this.Trimmed.Equals(input.Trimmed)
                ) && 
                (
                    this.FilePath == input.FilePath ||
                    (this.FilePath != null &&
                    this.FilePath.Equals(input.FilePath))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                hashCode = (hashCode * 59) + this.StartOffset.GetHashCode();
                hashCode = (hashCode * 59) + this.Duration.GetHashCode();
                hashCode = (hashCode * 59) + this.Trimmed.GetHashCode();
                if (this.FilePath != null)
                {
                    hashCode = (hashCode * 59) + this.FilePath.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
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
