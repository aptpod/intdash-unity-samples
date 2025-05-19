using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntdashLoadSettingsSample : MonoBehaviour
{
    [Serializable]
    public class ApiManagerSettings
    {
        public IntdashApiManager ApiManager;
        [RenameInspectorName("Server URL")]
        public JsonParser ServerUrl;
        public JsonParser ServerPath;
        public JsonParser AuthorizationType;
        [RenameInspectorName("API Token")]
        public JsonParser ApiToken;
        [RenameInspectorName("Client ID [Edge UUID] ")]
        public JsonParser EdgeClientId;
        [RenameInspectorName("Client Secret For Edge UUID")]
        public JsonParser EdgeClientSecret;
        [RenameInspectorName("Client ID For OAuth2")]
        public JsonParser OAuth2ClientId;
        [RenameInspectorName("Client Secret For OAuth2")]
        public JsonParser OAuth2ClientSecret;
        [RenameInspectorName("Project UUID")]
        public JsonParser ProjectUuid;
    }
    public List<ApiManagerSettings> ApiManagers = new List<ApiManagerSettings>();

    [Serializable]
    public class ConnectionSettings
    {
        public IscpConnection Connection;

        [RenameInspectorName("Node ID [Edge UUID] ")]
        public JsonParser NodeId;

        [RenameInspectorName("Connection Timeout")]
        public JsonParser ConnectionTimeout;

        [RenameInspectorName("Send Message Response Timeout")]
        public JsonParser SendMessageResponseTimeout;
    }
    public List<ConnectionSettings> Connections = new List<ConnectionSettings>();

    //[Serializable]
    //public class PlaybackSettings
    //{
    //    public IntdashPlaybackManagerSample PlaybackManager;

    //    [RenameInspectorName("Request Bulk Data Duration")]
    //    public JsonParser RequestBulkDataDuration;

    //    [RenameInspectorName("Request Partial Data Duration")]
    //    public JsonParser RequestPartialDataDuration;

    //    [RenameInspectorName("Pre-Reading Time at Seek")]
    //    public JsonParser PreReadingTimeAtSeek;
    //}
    //public List<PlaybackSettings> Playbacks = new List<PlaybackSettings>();

    private void Awake()
    {
        // API Manager Settings
        foreach (var m in ApiManagers)
        {
            if (m.ApiManager == null) continue;
            if (m.ServerUrl.IsEnabled) m.ApiManager.ServerUrl = m.ServerUrl.GetValue<string>();
            if (m.ServerPath.IsEnabled) m.ApiManager.ServerPath = m.ServerPath.GetValue<string>();
            if (m.AuthorizationType.IsEnabled) m.ApiManager.Type = (IntdashApiManager.AuthorizationType)m.AuthorizationType.GetValue<int>();
            var apiTokenInfo = m.ApiManager.ApiTokenInfo;
            if (m.ApiToken.IsEnabled) apiTokenInfo.ApiToken = m.ApiToken.GetValue<string>();
            m.ApiManager.ApiTokenInfo = apiTokenInfo;
            var edgeClientSecretInfo = m.ApiManager.EdgeClientSecretInfo;
            if (m.EdgeClientId.IsEnabled) edgeClientSecretInfo.ClientId = m.EdgeClientId.GetValue<string>();
            if (m.EdgeClientSecret.IsEnabled) edgeClientSecretInfo.ClientSecret = m.EdgeClientSecret.GetValue<string>();
            m.ApiManager.EdgeClientSecretInfo = edgeClientSecretInfo;
            var oauth2ClientSecretInfo = m.ApiManager.OAuth2ClientSecretInfo;
            if (m.OAuth2ClientId.IsEnabled) oauth2ClientSecretInfo.ClientId = m.OAuth2ClientId.GetValue<string>();
            if (m.OAuth2ClientSecret.IsEnabled) oauth2ClientSecretInfo.ClientSecret = m.OAuth2ClientSecret.GetValue<string>();
            m.ApiManager.OAuth2ClientSecretInfo = oauth2ClientSecretInfo;
            if (m.ProjectUuid.IsEnabled) m.ApiManager.ProjectUuid = m.ProjectUuid.GetValue<string>();
        }
        // Connection Settings
        foreach (var c in Connections)
        {
            if (c.Connection == null) continue;
            if (c.NodeId.IsEnabled) c.Connection.NodeId = c.NodeId.GetValue<string>();
            if (c.ConnectionTimeout.IsEnabled)
            {
                var timeout = c.ConnectionTimeout.GetValue<int>();
                c.Connection.ConnectionTimeout = (uint)timeout;
            }
            if (c.SendMessageResponseTimeout.IsEnabled)
            {
                var timeout = c.SendMessageResponseTimeout.GetValue<int>();
                c.Connection.SendMessageResponseTimeout = timeout;
            }
        }
        //// Playback Setting
        //foreach (var p in Playbacks)
        //{
        //    if (p.PlaybackManager == null) continue;
        //    if (p.RequestBulkDataDuration.IsEnabled) p.PlaybackManager.RequestBulkDataDuration = p.RequestBulkDataDuration.GetValue<int>();
        //    if (p.RequestPartialDataDuration.IsEnabled) p.PlaybackManager.RequestPartialDataDuration = p.RequestPartialDataDuration.GetValue<int>();
        //    if (p.PreReadingTimeAtSeek.IsEnabled) p.PlaybackManager.PreReadingTimeAtSeek = p.PreReadingTimeAtSeek.GetValue<int>();
        //}
    }
}
