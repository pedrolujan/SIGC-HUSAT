namespace selferviceSIGC.Model.Api.Response {
    public abstract class BaseResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}