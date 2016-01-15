using System;

namespace InSimSniffer {
    [Serializable]
    public class FishDanceException : Exception {
        public FishDanceException() { }
        public FishDanceException(string message) : base(message) { }
        public FishDanceException(string message, Exception inner) : base(message, inner) { }
        protected FishDanceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
