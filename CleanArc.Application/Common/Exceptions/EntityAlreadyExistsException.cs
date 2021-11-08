using System;
using System.Runtime.Serialization;

namespace CleanArc.Application.Common.Exceptions
{
    [Serializable]
    public sealed class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string name, object key, string friendlyMessage = null)
            : base($"Entity \"{name}\" ({key}) already exists.")
        {
            FriendlyMessage = friendlyMessage;
        }

        public EntityAlreadyExistsException(string name, object key, Exception innerException, string friendlyMessage = null)
            : base($"Entity \"{name}\" ({key}) already exists.", innerException)
        {
            FriendlyMessage = friendlyMessage;
        }

        private EntityAlreadyExistsException(SerializationInfo info, StreamingContext context)
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
