﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.Logging
{
    internal static class LoggingExtensions
    {
        private static Action<ILogger, Exception> _redirectToEndSessionEndpointHandledResponse;
        private static Action<ILogger, Exception> _redirectToEndSessionEndpointSkipped;
        private static Action<ILogger, Exception> _redirectToAuthenticationEndpointHandledResponse;
        private static Action<ILogger, Exception> _redirectToAuthenticationEndpointSkipped;
        private static Action<ILogger, Exception> _updatingConfiguration;
        private static Action<ILogger, Exception> _receivedIdToken;
        private static Action<ILogger, Exception> _redeemingCodeForTokens;
        private static Action<ILogger, string, Exception> _enteringOpenIdAuthenticationHandlerHandleRemoteAuthenticateAsync;
        private static Action<ILogger, string, Exception> _enteringOpenIdAuthenticationHandlerHandleUnauthorizedAsync;
        private static Action<ILogger, string, Exception> _messageReceived;
        private static Action<ILogger, Exception> _messageReceivedContextHandledResponse;
        private static Action<ILogger, Exception> _messageReceivedContextSkipped;
        private static Action<ILogger, Exception> _authorizationResponseReceived;
        private static Action<ILogger, Exception> _authorizationCodeReceived;
        private static Action<ILogger, Exception> _configurationManagerRequestRefreshCalled;
        private static Action<ILogger, Exception> _tokenResponseReceived;
        private static Action<ILogger, Exception> _authorizationResponseReceivedHandledResponse;
        private static Action<ILogger, Exception> _authorizationResponseReceivedSkipped;
        private static Action<ILogger, Exception> _authenticationFailedContextHandledResponse;
        private static Action<ILogger, Exception> _authenticationFailedContextSkipped;
        private static Action<ILogger, Exception> _authorizationCodeReceivedContextHandledResponse;
        private static Action<ILogger, Exception> _authorizationCodeReceivedContextSkipped;
        private static Action<ILogger, Exception> _authorizationCodeRedeemedContextHandledResponse;
        private static Action<ILogger, Exception> _authorizationCodeRedeemedContextSkipped;
        private static Action<ILogger, Exception> _authenticationValidatedHandledResponse;
        private static Action<ILogger, Exception> _authenticationValidatedtSkipped;
        private static Action<ILogger, string, Exception> _userInformationReceived;
        private static Action<ILogger, Exception> _userInformationReceivedHandledResponse;
        private static Action<ILogger, Exception> _userInformationReceivedSkipped;
        private static Action<ILogger, string, Exception> _invalidLogoutQueryStringRedirectUrl;
        private static Action<ILogger, Exception> _nullOrEmptyAuthorizationResponseState;
        private static Action<ILogger, Exception> _unableToReadAuthorizationResponseState;
        private static Action<ILogger, string, string, string, Exception> _authorizationResponseError;
        private static Action<ILogger, Exception> _exceptionProcessingMessage;
        private static Action<ILogger, Exception> _accessTokenNotAvailable;
        private static Action<ILogger, Exception> _retrievingClaims;
        private static Action<ILogger, Exception> _userInfoEndpointNotSet;
        private static Action<ILogger, Exception> _unableToProtectNonceCookie;
        private static Action<ILogger, string, Exception> _invalidAuthenticationRequestUrl;
        private static Action<ILogger, string, Exception> _unableToReadIdToken;
        private static Action<ILogger, string, Exception> _invalidSecurityTokenType;
        private static Action<ILogger, string, Exception> _unableToValidateIdToken;
        private static Action<ILogger, string, Exception> _postAuthenticationLocalRedirect;

        static LoggingExtensions()
        {
            // Final
            _redirectToEndSessionEndpointHandledResponse = LoggerMessage.Define(
                eventId: 1,
                logLevel: LogLevel.Debug,
                formatString: "RedirectToEndSessionEndpoint.HandledResponse");
            _redirectToEndSessionEndpointSkipped = LoggerMessage.Define(
                eventId: 2,
                logLevel: LogLevel.Debug,
                formatString: "RedirectToEndSessionEndpoint.Skipped");
            _invalidLogoutQueryStringRedirectUrl = LoggerMessage.Define<string>(
                eventId: 3,
                logLevel: LogLevel.Warning,
                formatString: "The query string for Logout is not a well-formed URI. Redirect URI: '{RedirectUrl}'.");
            _enteringOpenIdAuthenticationHandlerHandleUnauthorizedAsync = LoggerMessage.Define<string>(
                eventId: 4,
                logLevel: LogLevel.Trace,
                formatString: "Entering {OpenIdConnectHandlerType}'s HandleUnauthorizedAsync.");
            _postAuthenticationLocalRedirect = LoggerMessage.Define<string>(
                eventId: 5,
                logLevel: LogLevel.Trace,
                formatString: "Using properties.RedirectUri for 'local redirect' post authentication: '{RedirectUri}'.");
            _redirectToAuthenticationEndpointHandledResponse = LoggerMessage.Define(
                eventId: 6,
                logLevel: LogLevel.Debug,
                formatString: "RedirectToAuthenticationEndpoint.HandledResponse");
            _redirectToAuthenticationEndpointSkipped = LoggerMessage.Define(
                eventId: 7,
                logLevel: LogLevel.Debug,
                formatString: "RedirectToAuthenticationEndpoint.Skipped");
            _invalidAuthenticationRequestUrl = LoggerMessage.Define<string>(
                eventId: 8,
                logLevel: LogLevel.Warning,
                formatString: "The redirect URI is not well-formed. The URI is: '{AuthenticationRequestUrl}'.");
            _enteringOpenIdAuthenticationHandlerHandleRemoteAuthenticateAsync = LoggerMessage.Define<string>(
                eventId: 9,
                logLevel: LogLevel.Trace,
                formatString: "Entering {OpenIdConnectHandlerType}'s HandleRemoteAuthenticateAsync.");
            _nullOrEmptyAuthorizationResponseState = LoggerMessage.Define(
                eventId: 10,
                logLevel: LogLevel.Debug,
                formatString: "message.State is null or empty.");
            _unableToReadAuthorizationResponseState = LoggerMessage.Define(
                eventId: 11,
                logLevel: LogLevel.Debug,
                formatString: "Unable to read the message.State.");
            _authorizationResponseError = LoggerMessage.Define<string, string, string>(
                eventId: 12,
                logLevel: LogLevel.Error,
                formatString: "Message contains error: '{Error}', error_description: '{ErrorDescription}', error_uri: '{ErrorUri}'.");
            _updatingConfiguration = LoggerMessage.Define(
                eventId: 13,
                logLevel: LogLevel.Debug,
                formatString: "Updating configuration");
            _authorizationResponseReceived = LoggerMessage.Define(
                eventId: 14,
                logLevel: LogLevel.Trace,
                formatString: "Authorization response received.");
            _authorizationResponseReceivedHandledResponse = LoggerMessage.Define(
                eventId: 15,
                logLevel: LogLevel.Debug,
                formatString: "AuthorizationResponseReceived.HandledResponse");
            _authorizationResponseReceivedSkipped = LoggerMessage.Define(
                eventId: 16,
                logLevel: LogLevel.Debug,
                formatString: "AuthorizationResponseReceived.Skipped");
            _exceptionProcessingMessage = LoggerMessage.Define(
                eventId: 17,
                logLevel: LogLevel.Error,
                formatString: "Exception occurred while processing message.");
            _configurationManagerRequestRefreshCalled = LoggerMessage.Define(
                eventId: 18,
                logLevel: LogLevel.Debug,
                formatString: "Exception of type 'SecurityTokenSignatureKeyNotFoundException' thrown, Options.ConfigurationManager.RequestRefresh() called.");
            _redeemingCodeForTokens = LoggerMessage.Define(
                eventId: 19,
                logLevel: LogLevel.Debug,
                formatString: "Redeeming code for tokens.");
            _retrievingClaims = LoggerMessage.Define(
                eventId: 20,
                logLevel: LogLevel.Trace,
                formatString: "Retrieving claims from the user info endpoint.");
            _receivedIdToken = LoggerMessage.Define(
                eventId: 21,
                logLevel: LogLevel.Debug,
                formatString: "Received 'id_token'");
            _userInfoEndpointNotSet = LoggerMessage.Define(
                eventId: 22,
                logLevel: LogLevel.Debug,
                formatString: "UserInfoEndpoint is not set. Claims cannot be retrieved.");
            _unableToProtectNonceCookie = LoggerMessage.Define(
                eventId: 23,
                logLevel: LogLevel.Warning,
                formatString: "Failed to un-protect the nonce cookie.");
            _messageReceived = LoggerMessage.Define<string>(
                eventId: 24,
                logLevel: LogLevel.Trace,
                formatString: "MessageReceived: '{RedirectUrl}'.");
            _messageReceivedContextHandledResponse = LoggerMessage.Define(
                eventId: 25,
                logLevel: LogLevel.Debug,
                formatString: "MessageReceivedContext.HandledResponse");
            _messageReceivedContextSkipped = LoggerMessage.Define(
                eventId: 26,
                logLevel: LogLevel.Debug,
                formatString: "MessageReceivedContext.Skipped");
            _authorizationCodeReceived = LoggerMessage.Define(
                eventId: 27,
                logLevel: LogLevel.Trace,
                formatString: "Authorization code received.");
            _authorizationCodeReceivedContextHandledResponse = LoggerMessage.Define(
                eventId: 28,
                logLevel: LogLevel.Debug,
                formatString: "AuthorizationCodeReceivedContext.HandledResponse");
            _authorizationCodeReceivedContextSkipped = LoggerMessage.Define(
                eventId: 29,
                logLevel: LogLevel.Debug,
                formatString: "AuthorizationCodeReceivedContext.Skipped");
            _tokenResponseReceived = LoggerMessage.Define(
                eventId: 30,
                logLevel: LogLevel.Trace,
                formatString: "Token response received.");
            _authorizationCodeRedeemedContextHandledResponse = LoggerMessage.Define(
                eventId: 31,
                logLevel: LogLevel.Debug,
                formatString: "AuthorizationCodeRedeemedContext.HandledResponse");
            _authorizationCodeRedeemedContextSkipped = LoggerMessage.Define(
                eventId: 32,
                logLevel: LogLevel.Debug,
                formatString: "AuthorizationCodeRedeemedContext.Skipped");
            _authenticationValidatedHandledResponse = LoggerMessage.Define(
                eventId: 33,
                logLevel: LogLevel.Debug,
                formatString: "AuthenticationFailedContext.HandledResponse");
            _authenticationValidatedtSkipped = LoggerMessage.Define(
                eventId: 34,
                logLevel: LogLevel.Debug,
                formatString: "AuthenticationFailedContext.Skipped");
            _userInformationReceived = LoggerMessage.Define<string>(
               eventId: 35,
               logLevel: LogLevel.Trace,
               formatString: "User information received: {User}");
            _userInformationReceivedHandledResponse = LoggerMessage.Define(
                eventId: 36,
                logLevel: LogLevel.Debug,
                formatString: "The UserInformationReceived event returned Handled.");
            _userInformationReceivedSkipped = LoggerMessage.Define(
                eventId: 37,
                logLevel: LogLevel.Debug,
                formatString: "The UserInformationReceived event returned Skipped.");
            _authenticationFailedContextHandledResponse = LoggerMessage.Define(
                eventId: 38,
                logLevel: LogLevel.Debug,
                formatString: "AuthenticationFailedContext.HandledResponse");
            _authenticationFailedContextSkipped = LoggerMessage.Define(
                eventId: 39,
                logLevel: LogLevel.Debug,
                formatString: "AuthenticationFailedContext.Skipped");
            _invalidSecurityTokenType = LoggerMessage.Define<string>(
               eventId: 40,
               logLevel: LogLevel.Error,
               formatString: "The Validated Security Token must be of type JwtSecurityToken, but instead its type is: '{SecurityTokenType}'");
            _unableToValidateIdToken = LoggerMessage.Define<string>(
               eventId: 41,
               logLevel: LogLevel.Error,
               formatString: "Unable to validate the 'id_token', no suitable ISecurityTokenValidator was found for: '{IdToken}'.");
            _accessTokenNotAvailable = LoggerMessage.Define(
               eventId: 42,
               logLevel: LogLevel.Debug,
               formatString: "The access_token is not available. Claims cannot be retrieved.");
            _unableToReadIdToken = LoggerMessage.Define<string>(
               eventId: 43,
               logLevel: LogLevel.Error,
               formatString: "Unable to read the 'id_token', no suitable ISecurityTokenValidator was found for: '{IdToken}'.");
        }

        public static void UpdatingConfiguration(this ILogger logger)
        {
            _updatingConfiguration(logger, null);
        }

        public static void ConfigurationManagerRequestRefreshCalled(this ILogger logger)
        {
            _configurationManagerRequestRefreshCalled(logger, null);
        }

        public static void AuthorizationCodeReceived(this ILogger logger)
        {
            _authorizationCodeReceived(logger, null);
        }

        public static void TokenResponseReceived(this ILogger logger)
        {
            _tokenResponseReceived(logger, null);
        }

        public static void ReceivedIdToken(this ILogger logger)
        {
            _receivedIdToken(logger, null);
        }

        public static void RedeemingCodeForTokens(this ILogger logger)
        {
            _redeemingCodeForTokens(logger, null);
        }

        public static void AuthorizationResponseReceived(this ILogger logger)
        {
            _authorizationResponseReceived(logger, null);
        }

        public static void AuthorizationResponseReceivedHandledResponse(this ILogger logger)
        {
            _authorizationResponseReceivedHandledResponse(logger, null);
        }

        public static void AuthorizationResponseReceivedSkipped(this ILogger logger)
        {
            _authorizationResponseReceivedSkipped(logger, null);
        }

        public static void AuthorizationCodeReceivedContextHandledResponse(this ILogger logger)
        {
            _authorizationCodeReceivedContextHandledResponse(logger, null);
        }

        public static void AuthorizationCodeReceivedContextSkipped(this ILogger logger)
        {
            _authorizationCodeReceivedContextSkipped(logger, null);
        }

        public static void AuthorizationCodeRedeemedContextHandledResponse(this ILogger logger)
        {
            _authorizationCodeRedeemedContextHandledResponse(logger, null);
        }

        public static void AuthorizationCodeRedeemedContextSkipped(this ILogger logger)
        {
            _authorizationCodeRedeemedContextSkipped(logger, null);
        }

        public static void AuthenticationValidatedHandledResponse(this ILogger logger)
        {
            _authenticationValidatedHandledResponse(logger, null);
        }

        public static void AuthenticationValidatedSkipped(this ILogger logger)
        {
            _authenticationValidatedtSkipped(logger, null);
        }

        public static void AuthenticationFailedContextHandledResponse(this ILogger logger)
        {
            _authenticationFailedContextHandledResponse(logger, null);
        }

        public static void AuthenticationFailedContextSkipped(this ILogger logger)
        {
            _authenticationFailedContextSkipped(logger, null);
        }

        public static void MessageReceived(this ILogger logger, string redirectUrl)
        {
            _messageReceived(logger, redirectUrl, null);
        }

        public static void MessageReceivedContextHandledResponse(this ILogger logger)
        {
            _messageReceivedContextHandledResponse(logger, null);
        }

        public static void MessageReceivedContextSkipped(this ILogger logger)
        {
            _messageReceivedContextSkipped(logger, null);
        }

        public static void RedirectToEndSessionEndpointHandledResponse(this ILogger logger)
        {
            _redirectToEndSessionEndpointHandledResponse(logger, null);
        }

        public static void RedirectToEndSessionEndpointSkipped(this ILogger logger)
        {
            _redirectToEndSessionEndpointSkipped(logger, null);
        }

        public static void RedirectToAuthenticationEndpointHandledResponse(this ILogger logger)
        {
            _redirectToAuthenticationEndpointHandledResponse(logger, null);
        }

        public static void RedirectToAuthenticationEndpointSkipped(this ILogger logger)
        {
            _redirectToAuthenticationEndpointSkipped(logger, null);
        }

        public static void UserInformationReceivedHandledResponse(this ILogger logger)
        {
            _userInformationReceivedHandledResponse(logger, null);
        }

        public static void UserInformationReceivedSkipped(this ILogger logger)
        {
            _userInformationReceivedSkipped(logger, null);
        }

        public static void InvalidLogoutQueryStringRedirectUrl(this ILogger logger, string redirectUrl)
        {
            _invalidLogoutQueryStringRedirectUrl(logger, redirectUrl, null);
        }

        public static void NullOrEmptyAuthorizationResponseState(this ILogger logger)
        {
            _nullOrEmptyAuthorizationResponseState(logger, null);
        }

        public static void UnableToReadAuthorizationResponseState(this ILogger logger)
        {
            _unableToReadAuthorizationResponseState(logger, null);
        }

        public static void AuthorizationResponseError(this ILogger logger, string error, string errorDescription, string errorUri)
        {
            _authorizationResponseError(logger, error, errorDescription, errorUri, null);
        }

        public static void ExceptionProcessingMessage(this ILogger logger, Exception ex)
        {
            _exceptionProcessingMessage(logger, ex);
        }

        public static void AccessTokenNotAvailable(this ILogger logger)
        {
            _accessTokenNotAvailable(logger, null);
        }

        public static void RetrievingClaims(this ILogger logger)
        {
            _retrievingClaims(logger, null);
        }

        public static void UserInfoEndpointNotSet(this ILogger logger)
        {
            _userInfoEndpointNotSet(logger, null);
        }

        public static void UnableToProtectNonceCookie(this ILogger logger, Exception ex)
        {
            _unableToProtectNonceCookie(logger, ex);
        }

        public static void InvalidAuthenticationRequestUrl(this ILogger logger, string redirectUri)
        {
            _invalidAuthenticationRequestUrl(logger, redirectUri, null);
        }

        public static void UnableToReadIdToken(this ILogger logger, string idToken)
        {
            _unableToReadIdToken(logger, idToken, null);
        }

        public static void InvalidSecurityTokenType(this ILogger logger, string tokenType)
        {
            _invalidSecurityTokenType(logger, tokenType, null);
        }

        public static void UnableToValidateIdToken(this ILogger logger, string idToken)
        {
            _unableToValidateIdToken(logger, idToken, null);
        }

        public static void EnteringOpenIdAuthenticationHandlerHandleRemoteAuthenticateAsync(this ILogger logger, string openIdConnectHandlerTypeName)
        {
            _enteringOpenIdAuthenticationHandlerHandleRemoteAuthenticateAsync(logger, openIdConnectHandlerTypeName, null);
        }

        public static void EnteringOpenIdAuthenticationHandlerHandleUnauthorizedAsync(this ILogger logger, string openIdConnectHandlerTypeName)
        {
            _enteringOpenIdAuthenticationHandlerHandleUnauthorizedAsync(logger, openIdConnectHandlerTypeName, null);
        }

        public static void UserInformationReceived(this ILogger logger, string user)
        {
            _userInformationReceived(logger, user, null);
        }

        public static void PostAuthenticationLocalRedirect(this ILogger logger, string redirectUri)
        {
            _postAuthenticationLocalRedirect(logger, redirectUri, null);
        }
    }
}
