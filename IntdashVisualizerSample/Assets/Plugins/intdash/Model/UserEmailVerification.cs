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
    /// UserEmailVerification
    /// </summary>
    [DataContract(Name = "UserEmailVerification")]
    public partial class UserEmailVerification : IEquatable<UserEmailVerification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEmailVerification" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UserEmailVerification() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEmailVerification" /> class.
        /// </summary>
        /// <param name="emailId">メールアドレスのID (required).</param>
        /// <param name="expiredAt">有効期限 (required).</param>
        /// <param name="createdAt">作成日時 (required).</param>
        /// <param name="updatedAt">最終更新日時 (required).</param>
        public UserEmailVerification(long emailId = default(long), DateTime expiredAt = default(DateTime), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime))
        {
            this.EmailId = emailId;
            this.ExpiredAt = expiredAt;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// メールアドレスのID
        /// </summary>
        /// <value>メールアドレスのID</value>
        [DataMember(Name = "email_id", IsRequired = true, EmitDefaultValue = true)]
        public long EmailId { get; set; }

        /// <summary>
        /// 有効期限
        /// </summary>
        /// <value>有効期限</value>
        [DataMember(Name = "expired_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime ExpiredAt { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        /// <value>作成日時</value>
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
            sb.Append("class UserEmailVerification {\n");
            sb.Append("  EmailId: ").Append(EmailId).Append("\n");
            sb.Append("  ExpiredAt: ").Append(ExpiredAt).Append("\n");
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
            return this.Equals(input as UserEmailVerification);
        }

        /// <summary>
        /// Returns true if UserEmailVerification instances are equal
        /// </summary>
        /// <param name="input">Instance of UserEmailVerification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserEmailVerification input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.EmailId == input.EmailId ||
                    this.EmailId.Equals(input.EmailId)
                ) && 
                (
                    this.ExpiredAt == input.ExpiredAt ||
                    (this.ExpiredAt != null &&
                    this.ExpiredAt.Equals(input.ExpiredAt))
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
                hashCode = (hashCode * 59) + this.EmailId.GetHashCode();
                if (this.ExpiredAt != null)
                {
                    hashCode = (hashCode * 59) + this.ExpiredAt.GetHashCode();
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