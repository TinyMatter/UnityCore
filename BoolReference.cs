
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace TinyMatter.CardClash.Core {

    [Serializable]
    public class BoolReference : BaseReference<BoolVariable, bool> {
        public BoolReference(bool value) : base(value) { }
    }
}