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
    /// CreateOAuth2ClientAuthorizationCodeRequestAllOf
    /// </summary>
    [DataContract(Name = "CreateOAuth2ClientAuthorizationCodeRequest_allOf")]
    public partial class CreateOAuth2ClientAuthorizationCodeRequestAllOf : IEquatable<CreateOAuth2ClientAuthorizationCodeRequestAllOf>
    {
        /// <summary>
        /// トークンエンドポイントの認証方式
        /// </summary>
        /// <value>トークンエンドポイントの認証方式</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TokenEndpointAuthMethodEnum
        {
            /// <summary>
            /// Enum ClientSecretBasic for value: client_secret_basic
            /// </summary>
            [EnumMember(Value = "client_secret_basic")]
            ClientSecretBasic = 1,

            /// <summary>
            /// Enum None for value: none
            /// </summary>
            [EnumMember(Value = "none")]
            None = 2

        }


        /// <summary>
        /// トークンエンドポイントの認証方式
        /// </summary>
        /// <value>トークンエンドポイントの認証方式</value>
        [DataMember(Name = "token_endpoint_auth_method", EmitDefaultValue = false)]
        public TokenEndpointAuthMethodEnum? TokenEndpointAuthMethod { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOAuth2ClientAuthorizationCodeRequestAllOf" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateOAuth2ClientAuthorizationCodeRequestAllOf() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOAuth2ClientAuthorizationCodeRequestAllOf" /> class.
        /// </summary>
        /// <param name="name">名前.</param>
        /// <param name="grantType">グラントタイプ.</param>
        /// <param name="redirectUris">redirectUris (required).</param>
        /// <param name="tokenEndpointAuthMethod">トークンエンドポイントの認証方式 (default to TokenEndpointAuthMethodEnum.ClientSecretBasic).</param>
        /// <param name="tlsClientAuthSubjectDn">TLSクライアント認証のサブジェクトDN.</param>
        public CreateOAuth2ClientAuthorizationCodeRequestAllOf(string name = default(string), string grantType = default(string), List<string> redirectUris = default(List<string>), TokenEndpointAuthMethodEnum? tokenEndpointAuthMethod = TokenEndpointAuthMethodEnum.ClientSecretBasic, string tlsClientAuthSubjectDn = default(string))
        {
            // to ensure "redirectUris" is required (not null)
            if (redirectUris == null)
            {
                throw new ArgumentNullException("redirectUris is a required property for CreateOAuth2ClientAuthorizationCodeRequestAllOf and cannot be null");
            }
            this.RedirectUris = redirectUris;
            this.Name = name;
            this.GrantType = grantType;
            this.TokenEndpointAuthMethod = tokenEndpointAuthMethod;
            this.TlsClientAuthSubjectDn = tlsClientAuthSubjectDn;
        }

        /// <summary>
        /// 名前
        /// </summary>
        /// <value>名前</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// グラントタイプ
        /// </summary>
        /// <value>グラントタイプ</value>
        [DataMember(Name = "grant_type", EmitDefaultValue = false)]
        public string GrantType { get; set; }

        /// <summary>
        /// Gets or Sets RedirectUris
        /// </summary>
        [DataMember(Name = "redirect_uris", IsRequired = true, EmitDefaultValue = true)]
        public List<string> RedirectUris { get; set; }

        /// <summary>
        /// TLSクライアント認証のサブジェクトDN
        /// </summary>
        /// <value>TLSクライアント認証のサブジェクトDN</value>
        [DataMember(Name = "tls_client_auth_subject_dn", EmitDefaultValue = false)]
        public string TlsClientAuthSubjectDn { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateOAuth2ClientAuthorizationCodeRequestAllOf {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  GrantType: ").Append(GrantType).Append("\n");
            sb.Append("  RedirectUris: ").Append(RedirectUris).Append("\n");
            sb.Append("  TokenEndpointAuthMethod: ").Append(TokenEndpointAuthMethod).Append("\n");
            sb.Append("  TlsClientAuthSubjectDn: ").Append(TlsClientAuthSubjectDn).Append("\n");
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
            return this.Equals(input as CreateOAuth2ClientAuthorizationCodeRequestAllOf);
        }

        /// <summary>
        /// Returns true if CreateOAuth2ClientAuthorizationCodeRequestAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateOAuth2ClientAuthorizationCodeRequestAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateOAuth2ClientAuthorizationCodeRequestAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.GrantType == input.GrantType ||
                    (this.GrantType != null &&
                    this.GrantType.Equals(input.GrantType))
                ) && 
                (
                    this.RedirectUris == input.RedirectUris ||
                    this.RedirectUris != null &&
                    input.RedirectUris != null &&
                    this.RedirectUris.SequenceEqual(input.RedirectUris)
                ) && 
                (
                    this.TokenEndpointAuthMethod == input.TokenEndpointAuthMethod ||
                    this.TokenEndpointAuthMethod.Equals(input.TokenEndpointAuthMethod)
                ) && 
                (
                    this.TlsClientAuthSubjectDn == input.TlsClientAuthSubjectDn ||
                    (this.TlsClientAuthSubjectDn != null &&
                    this.TlsClientAuthSubjectDn.Equals(input.TlsClientAuthSubjectDn))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.GrantType != null)
                {
                    hashCode = (hashCode * 59) + this.GrantType.GetHashCode();
                }
                if (this.RedirectUris != null)
                {
                    hashCode = (hashCode * 59) + this.RedirectUris.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenEndpointAuthMethod.GetHashCode();
                if (this.TlsClientAuthSubjectDn != null)
                {
                    hashCode = (hashCode * 59) + this.TlsClientAuthSubjectDn.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
