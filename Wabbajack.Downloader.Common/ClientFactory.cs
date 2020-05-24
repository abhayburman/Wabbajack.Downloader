﻿using System;
using System.Net;
using SysHttp = System.Net.Http;

namespace Wabbajack.Downloader.Common
{
    public static class ClientFactory
    {
        private static SysHttp.SocketsHttpHandler SocketsHandler { get; }
        public static SysHttp.HttpClient Client { get; }
        internal static CookieContainer Cookies { get; }

        static ClientFactory()
        {
            Cookies = new CookieContainer();
            SocketsHandler = new SysHttp.SocketsHttpHandler
            {
                CookieContainer = Cookies,
                MaxConnectionsPerServer = 20,
                PooledConnectionLifetime = TimeSpan.FromMilliseconds(100),
                PooledConnectionIdleTimeout = TimeSpan.FromMilliseconds(100)
            };
            Client = new SysHttp.HttpClient(SocketsHandler);
        }
    }
}
