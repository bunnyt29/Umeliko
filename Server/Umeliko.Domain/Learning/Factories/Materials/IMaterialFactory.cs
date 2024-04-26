namespace Umeliko.Domain.Learning.Factories.Materials;

using Common;
using Models.Materials;

public interface IMaterialFactory : IFactory<Material>
{
    IMaterialFactory WithContentType(ContentType contentType);

    IMaterialFactory WithStateType(StateType stateType);
}
