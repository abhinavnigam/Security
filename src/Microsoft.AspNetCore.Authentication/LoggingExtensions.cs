// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.Logging
{
    internal static class LoggingExtensions
    {
        private static Action<ILogger, string, Exception> _authSchemeAuthenticated;
        private static Action<ILogger, string, Exception> _authSchemeNotAuthenticated;
        private static Action<ILogger, string, Exception> _authSchemeSignedIn;
        private static Action<ILogger, string, Exception> _authSchemeSignedOut;
        private static Action<ILogger, string, Exception> _authSchemeChallenged;
        private static Action<ILogger, string, Exception> _authSchemeForbidden;
        private static Action<ILogger, string, Exception> _userAuthorizationFailed;
        private static Action<ILogger, string, Exception> _userAuthorizationSucceeded;

        static LoggingExtensions()
        {
            _authSchemeAuthenticated = LoggerMessage.Define<string>(
                eventId: 1,
                logLevel: LogLevel.Warning,
                formatString: "AuthenticationScheme: {AuthenticationScheme} was successfully authenticated.");
            _authSchemeNotAuthenticated = LoggerMessage.Define<string>(
                eventId: 2,
                logLevel: LogLevel.Debug,
                formatString: "AuthenticationScheme: {AuthenticationScheme} was not authenticated.");
            _authSchemeSignedIn = LoggerMessage.Define<string>(
                eventId: 3,
                logLevel: LogLevel.Information,
                formatString: "AuthenticationScheme: {AuthenticationScheme} signed in.");
            _authSchemeSignedOut = LoggerMessage.Define<string>(
                eventId: 4,
                logLevel: LogLevel.Information,
                formatString: "AuthenticationScheme: {AuthenticationScheme} signed out.");
            _authSchemeChallenged = LoggerMessage.Define<string>(
                eventId: 5,
                logLevel: LogLevel.Information,
                formatString: "AuthenticationScheme: {AuthenticationScheme} was challenged.");
            _authSchemeForbidden = LoggerMessage.Define<string>(
                eventId: 6,
                logLevel: LogLevel.Information,
                formatString: "AuthenticationScheme: {AuthenticationScheme} was forbidden.");
            _userAuthorizationSucceeded = LoggerMessage.Define<string>(
                eventId: 0,
                logLevel: LogLevel.Information,
                formatString: "Authorization was successful for user: {UserName}.");
            _userAuthorizationFailed = LoggerMessage.Define<string>(
                eventId: 0,
                logLevel: LogLevel.Information,
                formatString: "Authorization failed for user: {UserName}.");
        }

        public static void AuthenticationSchemeAuthenticated(this ILogger logger, string authenticationScheme)
        {
            _authSchemeAuthenticated(logger, authenticationScheme, null);
        }

        public static void AuthenticationSchemeNotAuthenticated(this ILogger logger, string authenticationScheme)
        {
            _authSchemeNotAuthenticated(logger, authenticationScheme, null);
        }

        public static void AuthenticationSchemeSignedIn(this ILogger logger, string authenticationScheme)
        {
            _authSchemeSignedIn(logger, authenticationScheme, null);
        }

        public static void AuthenticationSchemeSignedOut(this ILogger logger, string authenticationScheme)
        {
            _authSchemeSignedOut(logger, authenticationScheme, null);
        }

        public static void AuthenticationSchemeChallenged(this ILogger logger, string authenticationScheme)
        {
            _authSchemeChallenged(logger, authenticationScheme, null);
        }

        public static void AuthenticationSchemeForbidden(this ILogger logger, string authenticationScheme)
        {
            _authSchemeForbidden(logger, authenticationScheme, null);
        }

        public static void UserAuthorizationSucceeded(this ILogger logger, string userName)
        {
            _userAuthorizationSucceeded(logger, userName, null);
        }

        public static void UserAuthorizationFailed(this ILogger logger, string userName)
        {
            _userAuthorizationFailed(logger, userName, null);
        }
    }
}
