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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using intdash.Client;
using intdash.Model;

namespace intdash.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthRolesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get Role
        /// </summary>
        /// <remarks>
        /// ロールを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <returns>Role</returns>
        Role GetRole(string roleUuid);

        /// <summary>
        /// Get Role
        /// </summary>
        /// <remarks>
        /// ロールを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <returns>ApiResponse of Role</returns>
        ApiResponse<Role> GetRoleWithHttpInfo(string roleUuid);
        /// <summary>
        /// List Roles
        /// </summary>
        /// <remarks>
        /// ロールのリストを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <returns>Roles</returns>
        Roles ListRoles(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?));

        /// <summary>
        /// List Roles
        /// </summary>
        /// <remarks>
        /// ロールのリストを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <returns>ApiResponse of Roles</returns>
        ApiResponse<Roles> ListRolesWithHttpInfo(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthRolesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get Role
        /// </summary>
        /// <remarks>
        /// ロールを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Role</returns>
        System.Threading.Tasks.Task<Role> GetRoleAsync(string roleUuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Role
        /// </summary>
        /// <remarks>
        /// ロールを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Role)</returns>
        System.Threading.Tasks.Task<ApiResponse<Role>> GetRoleWithHttpInfoAsync(string roleUuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Roles
        /// </summary>
        /// <remarks>
        /// ロールのリストを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Roles</returns>
        System.Threading.Tasks.Task<Roles> ListRolesAsync(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Roles
        /// </summary>
        /// <remarks>
        /// ロールのリストを取得します。
        /// </remarks>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Roles)</returns>
        System.Threading.Tasks.Task<ApiResponse<Roles>> ListRolesWithHttpInfoAsync(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthRolesApi : IAuthRolesApiSync, IAuthRolesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AuthRolesApi : IDisposable, IAuthRolesApi
    {
        private intdash.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public AuthRolesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public AuthRolesApi(string basePath)
        {
            this.Configuration = intdash.Client.Configuration.MergeConfigurations(
                intdash.Client.GlobalConfiguration.Instance,
                new intdash.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new intdash.Client.ApiClient(this.Configuration.BasePath);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = intdash.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public AuthRolesApi(intdash.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = intdash.Client.Configuration.MergeConfigurations(
                intdash.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new intdash.Client.ApiClient(this.Configuration.BasePath);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = intdash.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public AuthRolesApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public AuthRolesApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = intdash.Client.Configuration.MergeConfigurations(
                intdash.Client.GlobalConfiguration.Instance,
                new intdash.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new intdash.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = intdash.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public AuthRolesApi(HttpClient client, intdash.Client.Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = intdash.Client.Configuration.MergeConfigurations(
                intdash.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new intdash.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = intdash.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthRolesApi(intdash.Client.ISynchronousClient client, intdash.Client.IAsynchronousClient asyncClient, intdash.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = intdash.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            this.ApiClient?.Dispose();
        }

        /// <summary>
        /// Holds the ApiClient if created
        /// </summary>
        public intdash.Client.ApiClient ApiClient { get; set; } = null;

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public intdash.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public intdash.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public intdash.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public intdash.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get Role ロールを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <returns>Role</returns>
        public Role GetRole(string roleUuid)
        {
            intdash.Client.ApiResponse<Role> localVarResponse = GetRoleWithHttpInfo(roleUuid);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Role ロールを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <returns>ApiResponse of Role</returns>
        public intdash.Client.ApiResponse<Role> GetRoleWithHttpInfo(string roleUuid)
        {
            // verify the required parameter 'roleUuid' is set
            if (roleUuid == null)
                throw new intdash.Client.ApiException(400, "Missing required parameter 'roleUuid' when calling AuthRolesApi->GetRole");

            intdash.Client.RequestOptions localVarRequestOptions = new intdash.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };

            var localVarContentType = intdash.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = intdash.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("role_uuid", intdash.Client.ClientUtils.ParameterToString(roleUuid)); // path parameter

            // authentication (IntdashToken) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Intdash-Token", this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token"));
            }
            // authentication (OAuth2TokenInCookie) required
            // cookie parameter support
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("_bearer_token")))
            {
                localVarRequestOptions.Cookies.Add(new Cookie("_bearer_token", this.Configuration.GetApiKeyWithPrefix("_bearer_token")));
            }
            // authentication (OAuth2TokenInHeader) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Role>("/auth/roles/{role_uuid}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRole", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Role ロールを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Role</returns>
        public async System.Threading.Tasks.Task<Role> GetRoleAsync(string roleUuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            intdash.Client.ApiResponse<Role> localVarResponse = await GetRoleWithHttpInfoAsync(roleUuid, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Role ロールを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="roleUuid">ロールのUUID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Role)</returns>
        public async System.Threading.Tasks.Task<intdash.Client.ApiResponse<Role>> GetRoleWithHttpInfoAsync(string roleUuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'roleUuid' is set
            if (roleUuid == null)
                throw new intdash.Client.ApiException(400, "Missing required parameter 'roleUuid' when calling AuthRolesApi->GetRole");


            intdash.Client.RequestOptions localVarRequestOptions = new intdash.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };


            var localVarContentType = intdash.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = intdash.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("role_uuid", intdash.Client.ClientUtils.ParameterToString(roleUuid)); // path parameter

            // authentication (IntdashToken) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Intdash-Token", this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token"));
            }
            // authentication (OAuth2TokenInCookie) required
            // cookie parameter support
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("_bearer_token")))
            {
                localVarRequestOptions.Cookies.Add(new Cookie("_bearer_token", this.Configuration.GetApiKeyWithPrefix("_bearer_token")));
            }
            // authentication (OAuth2TokenInHeader) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Role>("/auth/roles/{role_uuid}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRole", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Roles ロールのリストを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <returns>Roles</returns>
        public Roles ListRoles(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?))
        {
            intdash.Client.ApiResponse<Roles> localVarResponse = ListRolesWithHttpInfo(uuid, name, page, perPage);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Roles ロールのリストを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <returns>ApiResponse of Roles</returns>
        public intdash.Client.ApiResponse<Roles> ListRolesWithHttpInfo(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?))
        {
            intdash.Client.RequestOptions localVarRequestOptions = new intdash.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };

            var localVarContentType = intdash.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = intdash.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (uuid != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("multi", "uuid", uuid));
            }
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("multi", "name", name));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (perPage != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("", "per_page", perPage));
            }

            // authentication (IntdashToken) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Intdash-Token", this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token"));
            }
            // authentication (OAuth2TokenInCookie) required
            // cookie parameter support
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("_bearer_token")))
            {
                localVarRequestOptions.Cookies.Add(new Cookie("_bearer_token", this.Configuration.GetApiKeyWithPrefix("_bearer_token")));
            }
            // authentication (OAuth2TokenInHeader) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Roles>("/auth/roles", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListRoles", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Roles ロールのリストを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Roles</returns>
        public async System.Threading.Tasks.Task<Roles> ListRolesAsync(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            intdash.Client.ApiResponse<Roles> localVarResponse = await ListRolesWithHttpInfoAsync(uuid, name, page, perPage, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Roles ロールのリストを取得します。
        /// </summary>
        /// <exception cref="intdash.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uuid">ロールのUUID (optional)</param>
        /// <param name="name">ロールの名前による部分一致検索。文字列をダブルクォーテーションで囲むと、完全一致のものだけを取得します。 (optional)</param>
        /// <param name="page">取得するページの番号 (optional, default to 1)</param>
        /// <param name="perPage">1回のリクエストで取得する件数 (optional, default to 30)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Roles)</returns>
        public async System.Threading.Tasks.Task<intdash.Client.ApiResponse<Roles>> ListRolesWithHttpInfoAsync(List<string> uuid = default(List<string>), List<string> name = default(List<string>), int? page = default(int?), int? perPage = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            intdash.Client.RequestOptions localVarRequestOptions = new intdash.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };


            var localVarContentType = intdash.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = intdash.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (uuid != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("multi", "uuid", uuid));
            }
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("multi", "name", name));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (perPage != null)
            {
                localVarRequestOptions.QueryParameters.Add(intdash.Client.ClientUtils.ParameterToMultiMap("", "per_page", perPage));
            }

            // authentication (IntdashToken) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Intdash-Token", this.Configuration.GetApiKeyWithPrefix("X-Intdash-Token"));
            }
            // authentication (OAuth2TokenInCookie) required
            // cookie parameter support
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("_bearer_token")))
            {
                localVarRequestOptions.Cookies.Add(new Cookie("_bearer_token", this.Configuration.GetApiKeyWithPrefix("_bearer_token")));
            }
            // authentication (OAuth2TokenInHeader) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Roles>("/auth/roles", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListRoles", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
