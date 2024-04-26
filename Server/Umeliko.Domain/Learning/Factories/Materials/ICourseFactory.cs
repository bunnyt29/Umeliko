namespace Umeliko.Domain.Learning.Factories.Materials;

using Common;
using Models.Materials;

public interface ICourseFactory : IFactory<Course>
{
    ICourseFactory WithContent(string content);

    ICourseFactory WithMaterialId(string materialId);
}
