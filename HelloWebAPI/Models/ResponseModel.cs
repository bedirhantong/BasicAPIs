namespace HelloWebAPI.Models
{
    public class ResponseModel
    {
        public ResponseModel(int HttpStatusCode, String Message)
        {
            this.HttpStatusCode = HttpStatusCode;
            this.Message = Message;
        }
        public int HttpStatusCode { get; set; }

        public String Message{ get; set; }
    }
}
