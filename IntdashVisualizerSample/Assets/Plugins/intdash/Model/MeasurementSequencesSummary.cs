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
    /// MeasurementSequencesSummary
    /// </summary>
    [DataContract(Name = "MeasurementSequencesSummary")]
    public partial class MeasurementSequencesSummary : IEquatable<MeasurementSequencesSummary>
    {
        /// <summary>
        /// 計測のステータス:   - ready     - 計測準備中   - measuring     - 計測中   - resending     - 再送中。計測（エッジにおけるデータの取得）は終了しましたが、エッジにデータが残っており、サーバーに再送中です。   - finished（非推奨。段階的にcompletedへ移行）     - 完了。サーバーへのデータの回収が完了しています。   - completed     - 完了。サーバーへのデータの回収が完了しています。
        /// </summary>
        /// <value>計測のステータス:   - ready     - 計測準備中   - measuring     - 計測中   - resending     - 再送中。計測（エッジにおけるデータの取得）は終了しましたが、エッジにデータが残っており、サーバーに再送中です。   - finished（非推奨。段階的にcompletedへ移行）     - 完了。サーバーへのデータの回収が完了しています。   - completed     - 完了。サーバーへのデータの回収が完了しています。</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Ready for value: ready
            /// </summary>
            [EnumMember(Value = "ready")]
            Ready = 1,

            /// <summary>
            /// Enum Measuring for value: measuring
            /// </summary>
            [EnumMember(Value = "measuring")]
            Measuring = 2,

            /// <summary>
            /// Enum Resending for value: resending
            /// </summary>
            [EnumMember(Value = "resending")]
            Resending = 3,

            /// <summary>
            /// Enum Finished for value: finished
            /// </summary>
            [EnumMember(Value = "finished")]
            Finished = 4,

            /// <summary>
            /// Enum Completed for value: completed
            /// </summary>
            [EnumMember(Value = "completed")]
            Completed = 5

        }


        /// <summary>
        /// 計測のステータス:   - ready     - 計測準備中   - measuring     - 計測中   - resending     - 再送中。計測（エッジにおけるデータの取得）は終了しましたが、エッジにデータが残っており、サーバーに再送中です。   - finished（非推奨。段階的にcompletedへ移行）     - 完了。サーバーへのデータの回収が完了しています。   - completed     - 完了。サーバーへのデータの回収が完了しています。
        /// </summary>
        /// <value>計測のステータス:   - ready     - 計測準備中   - measuring     - 計測中   - resending     - 再送中。計測（エッジにおけるデータの取得）は終了しましたが、エッジにデータが残っており、サーバーに再送中です。   - finished（非推奨。段階的にcompletedへ移行）     - 完了。サーバーへのデータの回収が完了しています。   - completed     - 完了。サーバーへのデータの回収が完了しています。</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementSequencesSummary" /> class.
        /// </summary>
        /// <param name="receivedChunksRatio">計測シーケンス回収率。計測内に含まれる計測シーケンスのうち、 サーバーへの保存が完了した計測シーケンスの割合です。.</param>
        /// <param name="receivedDataPoints">サーバーが受信したデータポイントの数。符号無し64bit整数。.</param>
        /// <param name="expectedDataPoints">サーバーが受信することが想定されるデータポイントの総数（既に受信済みのデータポイントを含む）。符号無し64bit整数。.</param>
        /// <param name="status">計測のステータス:   - ready     - 計測準備中   - measuring     - 計測中   - resending     - 再送中。計測（エッジにおけるデータの取得）は終了しましたが、エッジにデータが残っており、サーバーに再送中です。   - finished（非推奨。段階的にcompletedへ移行）     - 完了。サーバーへのデータの回収が完了しています。   - completed     - 完了。サーバーへのデータの回収が完了しています。.</param>
        public MeasurementSequencesSummary(decimal receivedChunksRatio = default(decimal), long receivedDataPoints = default(long), long expectedDataPoints = default(long), StatusEnum? status = default(StatusEnum?))
        {
            this.ReceivedChunksRatio = receivedChunksRatio;
            this.ReceivedDataPoints = receivedDataPoints;
            this.ExpectedDataPoints = expectedDataPoints;
            this.Status = status;
        }

        /// <summary>
        /// 計測シーケンス回収率。計測内に含まれる計測シーケンスのうち、 サーバーへの保存が完了した計測シーケンスの割合です。
        /// </summary>
        /// <value>計測シーケンス回収率。計測内に含まれる計測シーケンスのうち、 サーバーへの保存が完了した計測シーケンスの割合です。</value>
        [DataMember(Name = "received_chunks_ratio", EmitDefaultValue = false)]
        public decimal ReceivedChunksRatio { get; set; }

        /// <summary>
        /// サーバーが受信したデータポイントの数。符号無し64bit整数。
        /// </summary>
        /// <value>サーバーが受信したデータポイントの数。符号無し64bit整数。</value>
        [DataMember(Name = "received_data_points", EmitDefaultValue = false)]
        public long ReceivedDataPoints { get; set; }

        /// <summary>
        /// サーバーが受信することが想定されるデータポイントの総数（既に受信済みのデータポイントを含む）。符号無し64bit整数。
        /// </summary>
        /// <value>サーバーが受信することが想定されるデータポイントの総数（既に受信済みのデータポイントを含む）。符号無し64bit整数。</value>
        [DataMember(Name = "expected_data_points", EmitDefaultValue = false)]
        public long ExpectedDataPoints { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MeasurementSequencesSummary {\n");
            sb.Append("  ReceivedChunksRatio: ").Append(ReceivedChunksRatio).Append("\n");
            sb.Append("  ReceivedDataPoints: ").Append(ReceivedDataPoints).Append("\n");
            sb.Append("  ExpectedDataPoints: ").Append(ExpectedDataPoints).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as MeasurementSequencesSummary);
        }

        /// <summary>
        /// Returns true if MeasurementSequencesSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of MeasurementSequencesSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MeasurementSequencesSummary input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ReceivedChunksRatio == input.ReceivedChunksRatio ||
                    this.ReceivedChunksRatio.Equals(input.ReceivedChunksRatio)
                ) && 
                (
                    this.ReceivedDataPoints == input.ReceivedDataPoints ||
                    this.ReceivedDataPoints.Equals(input.ReceivedDataPoints)
                ) && 
                (
                    this.ExpectedDataPoints == input.ExpectedDataPoints ||
                    this.ExpectedDataPoints.Equals(input.ExpectedDataPoints)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                hashCode = (hashCode * 59) + this.ReceivedChunksRatio.GetHashCode();
                hashCode = (hashCode * 59) + this.ReceivedDataPoints.GetHashCode();
                hashCode = (hashCode * 59) + this.ExpectedDataPoints.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                return hashCode;
            }
        }

    }

}