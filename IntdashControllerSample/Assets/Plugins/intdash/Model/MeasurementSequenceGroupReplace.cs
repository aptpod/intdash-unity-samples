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
    /// MeasurementSequenceGroupReplace
    /// </summary>
    [DataContract(Name = "MeasurementSequenceGroupReplace")]
    public partial class MeasurementSequenceGroupReplace : IEquatable<MeasurementSequenceGroupReplace>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementSequenceGroupReplace" /> class.
        /// </summary>
        /// <param name="expectedDataPoints">この計測シーケンスでサーバーが受信することが想定されるデータポイントの総数 （既に受信済みのデータポイントを含む） 符号なし64bit整数。.</param>
        /// <param name="finalSequenceNumber">最後の計測シーケンスの番号.</param>
        public MeasurementSequenceGroupReplace(long expectedDataPoints = default(long), long finalSequenceNumber = default(long))
        {
            this.ExpectedDataPoints = expectedDataPoints;
            this.FinalSequenceNumber = finalSequenceNumber;
        }

        /// <summary>
        /// この計測シーケンスでサーバーが受信することが想定されるデータポイントの総数 （既に受信済みのデータポイントを含む） 符号なし64bit整数。
        /// </summary>
        /// <value>この計測シーケンスでサーバーが受信することが想定されるデータポイントの総数 （既に受信済みのデータポイントを含む） 符号なし64bit整数。</value>
        [DataMember(Name = "expected_data_points", EmitDefaultValue = false)]
        public long ExpectedDataPoints { get; set; }

        /// <summary>
        /// 最後の計測シーケンスの番号
        /// </summary>
        /// <value>最後の計測シーケンスの番号</value>
        [DataMember(Name = "final_sequence_number", EmitDefaultValue = false)]
        public long FinalSequenceNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MeasurementSequenceGroupReplace {\n");
            sb.Append("  ExpectedDataPoints: ").Append(ExpectedDataPoints).Append("\n");
            sb.Append("  FinalSequenceNumber: ").Append(FinalSequenceNumber).Append("\n");
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
            return this.Equals(input as MeasurementSequenceGroupReplace);
        }

        /// <summary>
        /// Returns true if MeasurementSequenceGroupReplace instances are equal
        /// </summary>
        /// <param name="input">Instance of MeasurementSequenceGroupReplace to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MeasurementSequenceGroupReplace input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ExpectedDataPoints == input.ExpectedDataPoints ||
                    this.ExpectedDataPoints.Equals(input.ExpectedDataPoints)
                ) && 
                (
                    this.FinalSequenceNumber == input.FinalSequenceNumber ||
                    this.FinalSequenceNumber.Equals(input.FinalSequenceNumber)
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
                hashCode = (hashCode * 59) + this.ExpectedDataPoints.GetHashCode();
                hashCode = (hashCode * 59) + this.FinalSequenceNumber.GetHashCode();
                return hashCode;
            }
        }

    }

}
