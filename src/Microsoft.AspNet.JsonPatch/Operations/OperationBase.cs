// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Framework.Internal;
using Newtonsoft.Json;

namespace Microsoft.AspNet.JsonPatch.Operations
{
    public class OperationBase
    {
        [JsonIgnore]
        public OperationType OperationType
        {
            get
            {
                return (OperationType)Enum.Parse(typeof(OperationType), op, true);
            }
        }

        [JsonProperty("path")]
        public string path { get; set; }

        [JsonProperty("op")]
        public string op { get; set; }

        [JsonProperty("from")]
        public string from { get; set; }

        public OperationBase()
        {

        }

        public OperationBase([NotNull] string op, [NotNull] string path, string from)
        {
            this.op = op;
            this.path = path;
            this.from = from;
        }

        public bool ShouldSerializefrom()
        {
            return (OperationType == OperationType.Move
                || OperationType == OperationType.Copy);
        }
    }
}