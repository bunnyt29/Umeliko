namespace Umeliko.Domain.Learning.Factories.Materials;

using Models.Materials;

internal class CourseFactory : ICourseFactory
{
    private string courseContent = default!;
    private string courseMaterialId = default!;

    public ICourseFactory WithContent(string content)
    {
        this.courseContent = content;
        return this;
    }

    public ICourseFactory WithMaterialId(string materialId)
    {
        this.courseMaterialId = materialId;
        return this;
    }

    public Course Build()
        => new Course(this.courseContent, this.courseMaterialId);
}
