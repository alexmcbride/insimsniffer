using System;

namespace InSimSniffer {
    [Serializable]
    public class ExportException : Exception {
        public ExportException() { }
        public ExportException(string message) : base(message) { }
        public ExportException(string message, Exception inner) : base(message, inner) { }
        protected ExportException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
