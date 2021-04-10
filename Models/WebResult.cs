namespace GiphyWebApi.Models
{
    public class WebResult
    {
        public string Result { get; set; }
        public bool IsSuccess { get; set; }

        public WebResult(bool isSuccess, string result = "")
        {
            Result = result;
            IsSuccess = IsSuccess;
        }
    }
}