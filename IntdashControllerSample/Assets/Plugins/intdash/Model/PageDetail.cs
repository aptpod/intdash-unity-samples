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
    /// PageDetail
    /// </summary>
    [DataContract(Name = "PageDetail")]
    public partial class PageDetail : IEquatable<PageDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageDetail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PageDetail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PageDetail" /> class.
        /// </summary>
        /// <param name="totalCount">取得対象の総件数 (required).</param>
        /// <param name="first">&#x60;true&#x60; の場合、現在のページが最初のページです。 (required).</param>
        /// <param name="last">&#x60;true&#x60; の場合、現在のページが最後のページです。 (required).</param>
        /// <param name="next">次のページのパス。現在のページが最後のページの場合は空文字列です。 (required).</param>
        /// <param name="previous">次のページのパス。現在のページが最後のページの場合は空文字列です。 (required).</param>
        public PageDetail(long totalCount = default(long), bool first = default(bool), bool last = default(bool), string next = default(string), string previous = default(string))
        {
            this.TotalCount = totalCount;
            this.First = first;
            this.Last = last;
            // to ensure "next" is required (not null)
            if (next == null)
            {
                throw new ArgumentNullException("next is a required property for PageDetail and cannot be null");
            }
            this.Next = next;
            // to ensure "previous" is required (not null)
            if (previous == null)
            {
                throw new ArgumentNullException("previous is a required property for PageDetail and cannot be null");
            }
            this.Previous = previous;
        }

        /// <summary>
        /// 取得対象の総件数
        /// </summary>
        /// <value>取得対象の総件数</value>
        [DataMember(Name = "total_count", IsRequired = true, EmitDefaultValue = true)]
        public long TotalCount { get; set; }

        /// <summary>
        /// &#x60;true&#x60; の場合、現在のページが最初のページです。
        /// </summary>
        /// <value>&#x60;true&#x60; の場合、現在のページが最初のページです。</value>
        [DataMember(Name = "first", IsRequired = true, EmitDefaultValue = true)]
        public bool First { get; set; }

        /// <summary>
        /// &#x60;true&#x60; の場合、現在のページが最後のページです。
        /// </summary>
        /// <value>&#x60;true&#x60; の場合、現在のページが最後のページです。</value>
        [DataMember(Name = "last", IsRequired = true, EmitDefaultValue = true)]
        public bool Last { get; set; }

        /// <summary>
        /// 次のページのパス。現在のページが最後のページの場合は空文字列です。
        /// </summary>
        /// <value>次のページのパス。現在のページが最後のページの場合は空文字列です。</value>
        [DataMember(Name = "next", IsRequired = true, EmitDefaultValue = true)]
        public string Next { get; set; }

        /// <summary>
        /// 次のページのパス。現在のページが最後のページの場合は空文字列です。
        /// </summary>
        /// <value>次のページのパス。現在のページが最後のページの場合は空文字列です。</value>
        [DataMember(Name = "previous", IsRequired = true, EmitDefaultValue = true)]
        public string Previous { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PageDetail {\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
            sb.Append("  First: ").Append(First).Append("\n");
            sb.Append("  Last: ").Append(Last).Append("\n");
            sb.Append("  Next: ").Append(Next).Append("\n");
            sb.Append("  Previous: ").Append(Previous).Append("\n");
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
            return this.Equals(input as PageDetail);
        }

        /// <summary>
        /// Returns true if PageDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of PageDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PageDetail input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TotalCount == input.TotalCount ||
                    this.TotalCount.Equals(input.TotalCount)
                ) && 
                (
                    this.First == input.First ||
                    this.First.Equals(input.First)
                ) && 
                (
                    this.Last == input.Last ||
                    this.Last.Equals(input.Last)
                ) && 
                (
                    this.Next == input.Next ||
                    (this.Next != null &&
                    this.Next.Equals(input.Next))
                ) && 
                (
                    this.Previous == input.Previous ||
                    (this.Previous != null &&
                    this.Previous.Equals(input.Previous))
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
                hashCode = (hashCode * 59) + this.TotalCount.GetHashCode();
                hashCode = (hashCode * 59) + this.First.GetHashCode();
                hashCode = (hashCode * 59) + this.Last.GetHashCode();
                if (this.Next != null)
                {
                    hashCode = (hashCode * 59) + this.Next.GetHashCode();
                }
                if (this.Previous != null)
                {
                    hashCode = (hashCode * 59) + this.Previous.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
