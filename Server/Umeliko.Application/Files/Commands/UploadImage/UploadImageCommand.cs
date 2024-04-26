namespace Umeliko.Application.Files.Commands.UploadImage;

using Common;
using MediatR;
using Microsoft.AspNetCore.Http;

public class UploadImageCommand : IRequest<Result<UploadImageOutputModel>>
{
    public IFormFile Image { get; set; } = default;

    public class UploadImageCommandHandler(IFile file)
        : IRequestHandler<UploadImageCommand, Result<UploadImageOutputModel>>
    {
        public Task<Result<UploadImageOutputModel>> Handle(
            UploadImageCommand request,
            CancellationToken cancellationToken)
            => file.UploadImage(request.Image);
    }
}
