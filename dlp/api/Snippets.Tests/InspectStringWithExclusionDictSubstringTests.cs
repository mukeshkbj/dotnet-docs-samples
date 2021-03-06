// Copyright 2020 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using Xunit;

namespace GoogleCloudSamples
{
    public class InspectStringWithExclusionDictSubstringTests : IClassFixture<DlpTestFixture>
    {
        private DlpTestFixture Fixture { get; }
        public InspectStringWithExclusionDictSubstringTests(DlpTestFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void TestInspectStringExclusionDictSubstring()
        {
            string testData = "Some email addresses: gary@example.com, TEST@example.com";
            var testList = new List<string> { "TEST" };
            var response = InspectStringWithExclusionDictSubstring.Inspect(Fixture.ProjectId, testData, testList);

            Assert.Contains(response.Result.Findings, f => f.Quote.Contains("gary@example.com"));
            Assert.DoesNotContain(response.Result.Findings, f => f.Quote.Contains("TEST@example.com"));
        }
    }
}
