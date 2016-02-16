﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.Logging
{
    internal static class LoggingExtensions
    {
        private static Action<ILogger, string, Exception> _tokenValidationFailed;
        private static Action<ILogger, string, Exception> _tokenValidationSucceeded;
        private static Action<ILogger, string, Exception> _errorProcessingMessage;


        static LoggingExtensions()
        {
            _tokenValidationFailed = LoggerMessage.Define<string>(
                eventId: 0,
                logLevel: LogLevel.Information,
                formatString: "Failed to validate the token {Token}.");
            _tokenValidationSucceeded = LoggerMessage.Define<string>(
                eventId: 0,
                logLevel: LogLevel.Information,
                formatString: "Successfully validated the token.");
            _errorProcessingMessage = LoggerMessage.Define<string>(
                eventId: 0,
                logLevel: LogLevel.Error,
                formatString: "Exception occurred while processing message.");

        }

        public static void TokenValidationFailed(this ILogger logger, string token, Exception ex)
        {
            _tokenValidationFailed(logger, token, ex);
        }

        public static void TokenValidationSucceeded(this ILogger logger)
        {
            _tokenValidationSucceeded(logger, null, null);
        }

        public static void ErrorProcessingMessage(this ILogger logger)
        {
            _errorProcessingMessage(logger, null, null);
        }
    }
}
