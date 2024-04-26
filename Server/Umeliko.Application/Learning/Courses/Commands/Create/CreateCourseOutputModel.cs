namespace Umeliko.Application.Learning.Courses.Commands.Create;

public class CreateCourseOutputModel(string courseId)
{
    public string CourseId { get; } = courseId;
}
