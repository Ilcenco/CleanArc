using System;
using System.Runtime.Serialization;

namespace CleanArc.Application.Common.Exceptions
{
    [Serializable]
    public sealed class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, object key, string friendlyMessage = null)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            FriendlyMessage = friendlyMessage;
        }

        public EntityNotFoundException(string name, object key, Exception innerException, string friendlyMessage = null)
            : base($"Entity \"{name}\" ({key}) was not found.", innerException)
        {
            FriendlyMessage = friendlyMessage;
        }

        private EntityNotFoundException(SerializationInfo info, StreamingContext context)
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
