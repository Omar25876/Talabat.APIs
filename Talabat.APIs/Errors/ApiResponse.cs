
namespace Talabat.APIs.Errors
{
	public class ApiResponse
	{
		public int? StatusCode { get; set; }
		public string? Message { get; set; }

		public ApiResponse(int? statusCode,string? message = null) {
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessage(StatusCode);
		}

		private string? GetDefaultMessage(int? statusCode)
		{
			return StatusCode switch
			{
				400 => "A bad request, you have made",
				401 => "Authorized, you are not",
				403 => "Forbidden, access denied",
				404 => "Resource found, it was not",
				500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
				_ => null
			};
		}
	}
}
