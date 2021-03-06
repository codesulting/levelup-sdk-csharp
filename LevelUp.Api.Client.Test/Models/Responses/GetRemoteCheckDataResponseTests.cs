#region Copyright (Apache 2.0)
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// <copyright file="GetRemoteCheckDataResponseTests.cs" company="SCVNGR, Inc. d/b/a LevelUp">
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
using FluentAssertions;
using LevelUp.Api.Client.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LevelUp.Api.Client.Test.Models.Responses
{
    [TestClass]
    public class GetRemoteCheckDataResponseTests : ModelTestsBase
    {
        [TestMethod]
        [TestCategory(LevelUp.Api.Http.Test.TestCategory.FunctionalTests)]
        public void Deserialize()
        {
            string identifier = Guid.NewGuid().ToString("N");
            const int discount = 324;

            string json = CreateSerializedObjectJsonString(identifier, discount);
            GetRemoteCheckDataResponse response = JsonConvert.DeserializeObject<GetRemoteCheckDataResponse>(json);

            response.Should().NotBeNull();
            response.OrderIdentifier.ShouldBeEquivalentTo(identifier);
            response.DiscountToApply.ShouldBeEquivalentTo(discount);

        }

        [TestMethod]
        [TestCategory(LevelUp.Api.Http.Test.TestCategory.FunctionalTests)]
        public void Deserialize_NullDiscount()
        {
            string identifier = Guid.NewGuid().ToString("N"); 
            int? discount = null;

            string json = CreateSerializedObjectJsonString(identifier, discount);
            GetRemoteCheckDataResponse response = JsonConvert.DeserializeObject<GetRemoteCheckDataResponse>(json);

            response.Should().NotBeNull();
            response.OrderIdentifier.ShouldBeEquivalentTo(identifier);
            response.DiscountToApply.ShouldBeEquivalentTo(discount);
        }

        private string CreateSerializedObjectJsonString(string id, int? availableDiscount)
        {
            return "{\"check\":{ \"pending_order\": { " +
                   "\"uuid\":" + FormatJsonString(id) +
                   ",\"discount_amount\":" + FormatJsonNullableType(availableDiscount) + 
                   "}}}";
        }
    }
}
