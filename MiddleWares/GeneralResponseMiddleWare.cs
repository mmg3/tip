using Newtonsoft.Json;
using TIP.Dtos;

namespace TIP.MiddleWares
{
    public class GeneralResponseMiddleWare
    {
        private readonly RequestDelegate _next;

        public GeneralResponseMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            var memoryStreamModified = new MemoryStream();

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                // Call the next delegate/middleware in the pipeline
                await _next(context);

                var response = await FormatResponse(context.Response);

                string resp = JsonConvert.SerializeObject(response);


                var sw = new StreamWriter(memoryStreamModified);
                sw.Write(resp);
                sw.Flush();
                memoryStreamModified.Position = 0;

                await memoryStreamModified.CopyToAsync(originalBodyStream).ConfigureAwait(false);
                context.Response.Body = originalBodyStream;

            }
        }

        private async Task<GeneralResponseDto> FormatResponse(HttpResponse response)
        {
            GeneralResponseDto generalResponseDto = new GeneralResponseDto();

            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            if (response.StatusCode == 200)
            {
                generalResponseDto.Status = true;
                generalResponseDto.ErrorMessage = null;
                generalResponseDto.Exception = null;
                generalResponseDto.Entity = text;
                generalResponseDto.Guid = new Guid().ToString();
            }
            else
            {
                generalResponseDto.Status = false;
                generalResponseDto.ErrorMessage = text;
                generalResponseDto.Exception = text; //context.Features.Get<Exception>().InnerException == null ? context.Features.Get<Exception>().Message : context.Features.Get<Exception>().InnerException.ToString();
                generalResponseDto.Entity = null;
                generalResponseDto.Guid = new Guid().ToString();
            }

            response.Body.Seek(0, SeekOrigin.Begin);
            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return generalResponseDto;
        }
    }
}
