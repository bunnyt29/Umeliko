namespace Umeliko.Application.Learning.Lessons.Commands.Create;

public class CreateLessonOutputModel(string lessonId)
{
    public string LessonId { get; } = lessonId;
}
