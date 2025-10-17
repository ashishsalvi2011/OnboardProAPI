namespace OnboardPro.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }     
        public string Error { get; set; }
    }

    public class SingleResponseModel<T>: ResponseModel
    {
        public T Data { get; set; }
    }

    public class ListResponseModel<T> : ResponseModel
    {
        public List<T> Data { get; set; }
    }

}
