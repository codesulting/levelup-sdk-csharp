#region Copyright (Apache 2.0)
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// <copyright file="AccessTokenRequestBody.cs" company="SCVNGR, Inc. d/b/a LevelUp">
//   Copyright(c) 2016 SCVNGR, Inc. d/b/a LevelUp. All rights reserved.
// </copyright>
// <license publisher="Apache Software Foundation" date="January 2004" version="2.0">
//   Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
//   in compliance with the License. You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software distributed under the License
//   is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
//   or implied. See the License for the specific language governing permissions and limitations under
//   the License.
// </license>
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
#endregion

using System;
using JsonEnvelopeSerializer;
using Newtonsoft.Json;

namespace LevelUp.Api.Client.Models.Requests
{
    /// <summary>
    /// Class representing a LevelUp access token request object
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [ObjectEnvelope("access_token")]
    [JsonConverter(typeof(EnvelopeSerializer))]
    public class AccessTokenRequestBody
    {
        private AccessTokenRequestBody()
        {
            // Private constructor for deserialization
        }

        /// <summary>
        /// Constructor for a LevelUp access token request
        /// </summary>
        /// <param name="apiKey">Your LevelUp API key</param>
        /// <param name="username">The merchant's LevelUp user name</param>
        /// <param name="password">The merchant's LevelUp password</param>
        public AccessTokenRequestBody(string apiKey, string username, string password)
        {
            ApiKey = apiKey;
            Username = username;
            Password = password;
        }

        /// <summary>
        /// A string identifier that uniquely identifies the source of the access token request
        /// i.e. identifies which integration the request originated from
        /// </summary>
        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; private set; }

        /// <summary>
        /// The LevelUp user name of the party on whose behalf the access token request is made
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; private set; }


        /// <summary>
        /// The LevelUp password of the party on whose behalf the access token request is made
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; private set; }

        #region Deprecated Properties

        [Obsolete("Use ApiKey property instead")]
        public string ClientId { get { return ApiKey; } }

        #endregion Deprecated Properties

    }
}
