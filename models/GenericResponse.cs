namespace MyAngularApp.models.response
{
    public class GenericResponse
    {
        public int StatusCode { get; set; }
        public String Description { get; set; } = String.Empty;
        public Object? Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;


        public GenericResponse(int statusCode, string description, object? data)
        {
            StatusCode = statusCode;
            Description = description;
            Data = data;
        }

        public GenericResponse(int statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
        }
    }

}