using System;
using System.Runtime.Serialization;

namespace CleanArc.Application.Common.Exceptions
{
    [Serializable]
    public sealed class DropdownIsEmptyException : Exception
    {
        public DropdownIsEmptyException(string name, object key, string friendlyMessage = null)
            : base($"Dropdown \"{name}\" ({key}) is epmty.")
        {
            FriendlyMessage = friendlyMessage;
        }

        public DropdownIsEmptyException(string name, object key, Exception innerException, string friendlyMessage = null)
            : base($"Dropdown \"{name}\" ({key}) is epmty.", innerException)
        {
            FriendlyMessage = friendlyMessage;
        }

        private DropdownIsEmptyException(SerializationInfo info, StreamingContext context)
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
