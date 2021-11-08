namespace Application.Common
{
    public class ResponseModel<T>
    {
        public string ErrorMessage { get; set; }
        public bool IsError { get; set; }
        public T ResponseValue {get;set;}

        //For pagination
        public int totalItems { get; set; }
        public int totalPages { get; set; }
    }
}
