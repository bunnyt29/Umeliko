namespace Umeliko.Application.Files.Commands.UploadVideo;

using Common;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UploadVideoCommand : IRequest<Result<UploadVideoOutputModel>>
{
    public IFormFile Video { get; set; } = default;

    public class UploadVideoCommandHandler(IFile file)
        : IRequestHandler<UploadVideoCommand, Result<UploadVideoOutputModel>>
    {
        public Task<Result<UploadVideoOutputModel>> Handle(
            UploadVideoCommand request,
            CancellationToken cancellationToken)
            => file.UploadVideo(request.Video);
    }
}
