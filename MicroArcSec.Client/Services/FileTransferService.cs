using Grpc.Core;
using Grpc.Core.Utils;
using GrpcFileService;

namespace MicroArcSec.Client.Services
{
    public class FileTransferService : FileTransfer.FileTransferBase
    {
        public override async Task<SendStatus> SendFile(IAsyncStreamReader<SendFileRequest> requestStream, ServerCallContext context)
        {
            string filename = "";
            MemoryStream memoryStream = new MemoryStream();

            // Read the file name and data from the request stream
            await requestStream.ForEachAsync(async request =>
            {
                if (string.IsNullOrEmpty(filename))
                {
                    filename = request.Filename;
                }
                await memoryStream.WriteAsync(request.Data.ToArray());
            });

            // Write the data to a file
            using (FileStream fileStream = new FileStream(".\\Files\\" + filename, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                await memoryStream.CopyToAsync(fileStream);
            }

            // Return a success response
            return new SendStatus { Success = true, Message = "File uploaded successfully" };
        }
    }
}
