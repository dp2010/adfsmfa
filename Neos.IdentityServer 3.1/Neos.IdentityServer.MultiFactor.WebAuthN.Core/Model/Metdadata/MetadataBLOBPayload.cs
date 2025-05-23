﻿//******************************************************************************************************************************************************************************************//
// Copyright (c) 2021 abergs (https://github.com/abergs/fido2-net-lib)                                                                                                                      //                        
//                                                                                                                                                                                          //
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),                                       //
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,   //
// and to permit persons to whom the Software is furnished to do so, subject to the following conditions:                                                                                   //
//                                                                                                                                                                                          //
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.                                                           //
//                                                                                                                                                                                          //
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,                                      //
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,                            //
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                               //
//                                                                                                                                                                                          //
//******************************************************************************************************************************************************************************************//
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Neos.IdentityServer.MultiFactor.WebAuthN
{
    /// <summary>
    /// Represents the MetadataBLOBPayload
    /// </summary>
    /// <remarks>
    /// <see xref="https://fidoalliance.org/specs/mds/fido-metadata-service-v3.0-ps-20210518.html#metadata-blob-payload-dictionary"/>
    /// </remarks>
    [JsonSerializable(typeof(MetadataBLOBPayload))]
    public class MetadataBLOBPayload
    {
        /// <summary>
        /// Gets or sets the legalHeader, if present, contains a legal guide for accessing and using metadata.
        /// </summary>
        /// <remarks>
        /// This value MAY contain URL(s) pointing to further information, such as a full Terms and Conditions statement. 
        /// </remarks>
        [JsonProperty("legalHeader")]
        public string LegalHeader { get; set; }
        /// <summary>   
        /// Gets or sets the serial number of this UAF Metadata BLOB Payload. 
        /// </summary>
        /// <remarks>
        /// Serial numbers MUST be consecutive and strictly monotonic, i.e. the successor BLOB will have a no value exactly incremented by one.
        /// </remarks>
        [JsonProperty("no", Required = Required.Always)]
        public int Number { get; set; }
        /// <summary>
        /// Gets or sets a formatted date (ISO-8601) when the next update will be provided at latest.
        /// </summary>
        [JsonProperty("nextUpdate", Required = Required.Always)]
        public string NextUpdate { get; set; }
        /// <summary>
        /// Gets or sets a list of zero or more entries of <see cref="MetadataBLOBPayloadEntry"/>.
        /// </summary>
        [JsonProperty("entries", Required = Required.Always)]
        public MetadataBLOBPayloadEntry[] Entries { get; set; }

        /// <summary>
        /// The "alg" property from the original JWT header. Used to validate MetadataStatements.
        /// </summary>
        [JsonProperty("jwtAlg", Required = Required.Default)]
        public string JwtAlg { get; set; }
    }
}
