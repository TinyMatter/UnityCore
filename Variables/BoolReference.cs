
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace TinyMatter.Core {

    [Serializable]
    public class BoolReference : BaseReference<BoolVariable, bool> {
        public BoolReference(bool value) : base(value) { }
    }
}