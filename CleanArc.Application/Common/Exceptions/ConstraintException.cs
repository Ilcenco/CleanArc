using System;
using System.Runtime.Serialization;

namespace CleanArc.Application.Common.Exceptions
{
    [Serializable]
    public sealed class ConstraintException : Exception
    {
        public ConstraintException(string name, object key, string friendlyMessage = null)
            : base($"\"{name}\" ({key}) has a constraint.")
        {
            FriendlyMessage = friendlyMessage;
        }

        public ConstraintException(string name, object key, Exception innerException, string friendlyMessage = null)
            : base($"\"{name}\" ({key}) has a constraint.", innerException)
        {
            FriendlyMessage = friendlyMessage;
        }

        private ConstraintException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }

        public string FriendlyMessage { get; private set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
