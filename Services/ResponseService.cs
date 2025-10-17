using Azure;
using OnboardPro.Interface;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class ResponseService: IResponse
    {
        public ResponseModel SuccessPostResult()
        {
            return new ResponseModel
            {
                Success = true,
                Message = "Record created successfully.",
                Error = ""
            };
        }
        public ListResponseModel<T> SuccessGetResult<T>(List<T> data)
        {
            return new ListResponseModel<T>
            {
                Success = true,
                Message = "",
                Data = data,
                Error = ""
            };
        }
        public  SingleResponseModel<T> SuccessGetResult<T>(T data)
        {
            return new SingleResponseModel<T>
            {
                Success = true,
                Message = "",
                Data = data,
                Error = ""
            };
        }
        public ResponseModel FailureResult(string errorMessage)
        {
            return new ResponseModel
            {
                Success = false,
                Message = errorMessage,
                Error = errorMessage
            };
        }
    }
}
