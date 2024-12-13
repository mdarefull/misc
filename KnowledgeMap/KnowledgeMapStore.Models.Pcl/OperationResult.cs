
namespace KnowledgeMapStore.Models.Pcl
{
    public struct OperationResult<T>
    {
        private readonly OperationResultType _type;
        public OperationResultType Type { get { return _type; } }

        private readonly string _message;
        public string Message { get { return _message; } }

        private readonly T _returnValue;
        public T ReturnValue { get { return _returnValue; } }

        public OperationResult(OperationResultType type, T returnValue = default(T), string message = null)
        {
            _type = type;
            _message = message;
            _returnValue = returnValue;
        }
    }

    public enum OperationResultType
    {
        NotFound,
        OperationError,
    }
}