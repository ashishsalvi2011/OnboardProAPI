using Azure;
using OnboardPro.Models;

namespace OnboardPro.Interface
{
    public interface IResponse
    {       
        ListResponseModel<T> SuccessGetResult<T>(List<T> data);
        SingleResponseModel<T> SuccessGetResult<T>(T data);
        ResponseModel SuccessPostResult();
        ResponseModel FailureResult(string errorMessage);
    }
}
