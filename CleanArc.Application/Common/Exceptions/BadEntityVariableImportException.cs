using System;
using System.Runtime.Serialization;

namespace CleanArc.Application.Common.Exceptions
{
    [Serializable]
    public sealed class BadEntityVariableImportException : Exception
    {
        public BadEntityVariableImportException() : base()
        {

        }

        public BadEntityVariableImportException(string message) : base(message)
        {
            this.FriendlyMessage = message;
        }

        public BadEntityVariableImportException(string message, string friendlyMessage) : base(message)
        {
            this.FriendlyMessage = friendlyMessage;
        }

        public BadEntityVariableImportException(string message, Exception innerException) : base(message, innerException)
        {
            this.FriendlyMessage = message;
        }

        public BadEntityVariableImportException(string message, string friendlyMessage, Exception innerException) : base(message, innerException)
        {
            this.FriendlyMessage = friendlyMessage;
        }

        private BadEntityVariableImportException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        public string FriendlyMessage { get; private set; } = "Alcune sezioni sono vuote!";

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
