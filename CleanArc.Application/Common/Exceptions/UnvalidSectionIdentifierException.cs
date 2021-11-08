using System;
using System.Runtime.Serialization;

namespace CleanArc.Application.Common.Exceptions
{
    [Serializable]
    public sealed class UnvalidSectionIdentifierException : Exception
    {
        public UnvalidSectionIdentifierException() : base()
        {
        }

        public UnvalidSectionIdentifierException(string message) : base(message)
        {
            this.FriendlyMessage = message;
        }

        public UnvalidSectionIdentifierException(string message, string friendlyMessage) : base(message)
        {
            this.FriendlyMessage = friendlyMessage;
        }

        public UnvalidSectionIdentifierException(string name, string message, string friendlyMessage) : base(message)
        {
            this.FriendlyMessage = friendlyMessage;
        }

        public UnvalidSectionIdentifierException(string message, Exception innerException) : base(message, innerException)
        {
            this.FriendlyMessage = message;
        }

        public UnvalidSectionIdentifierException(string message, string friendlyMessage, Exception innerException) : base(message, innerException)
        {
            this.FriendlyMessage = friendlyMessage;
        }

        private UnvalidSectionIdentifierException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }

        public string FriendlyMessage { get; private set; } = "";

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
