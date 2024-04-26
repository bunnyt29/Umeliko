namespace Umeliko.Application.Files.Commands.UploadRaw;

using Common;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UploadRawCommand : IRequest<Result<UploadRawOutputModel>>
{
    public IFormFile Raw { get; set; } = default;

    public class UploadVideoCommandHandler(IFile file)
        : IRequestHandler<UploadRawCommand, Result<UploadRawOutputModel>>
    {
        public Task<Result<UploadRawOutputModel>> Handle(
            UploadRawCommand request,
            CancellationToken cancellationToken)
            => file.UploadRaw(request.Raw);
    }
}
