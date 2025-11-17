

namespace Backend_Geo_Incidencia.Application.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Code { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
        public T? Data { get; set; }
        public List<T>? DataList { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Consulta ejecutada correctamente", int code = 0)
            => new ApiResponse<T> { Success = true, Message = message, Code = code, Data = data };

        public static ApiResponse<T> OkLista(List<T> data, string message = "Consulta ejecutada correctamente", int code = 0)
            => new ApiResponse<T> { Success = true, Message = message, Code = code, DataList = data };

        public static ApiResponse<T> Fail(string message, int code = 400, IDictionary<string, string[]>? errors = null)
            => new ApiResponse<T> { Success = false, Message = message, Code = code, Errors = errors };
    }
}
