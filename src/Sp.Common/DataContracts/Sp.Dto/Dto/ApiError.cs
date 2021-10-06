using Newtonsoft.Json;

namespace Sp.Dto.Dto
{
    [JsonObject(MemberSerialization.Fields)]
    public class ApiError
    {
        private readonly int statusCode;
        private readonly string message;

        public int StatusCode => statusCode;
        public string Message => message;

        [JsonConstructor]
        public ApiError() { }

        public ApiError(int statuscode, string message)
            => (this.statusCode, this.message) = (statuscode, message ?? "Internal Server Error");

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}

