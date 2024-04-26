namespace Umeliko.Domain.Learning.Models.Materials;

using Umeliko.Domain.Common;
using Umeliko.Domain.Common.Models;
using Umeliko.Domain.Learning.Exceptions;

using static ModelConstants.Item;

public class Item : Entity<int>, IAggregateRoot
{
    private Item()
    {

    }

    public Item(
        string title,
        CourseContentType courseContentType,
        int sectionId)
        : this()
    {
        this.ValidateTitle(title);

        this.Title = title;
        this.CourseContentType = courseContentType;
        this.SectionId = sectionId;
    }

    public string Title { get; set; } = default!;

    public CourseContentType CourseContentType { get; } = default!;

    //public Article Article { get; set; } = default!;

    public Lesson Lesson { get; set; } = default!;

    public int SectionId { get; set; }

    private void ValidateTitle(string title)
        => Guard.ForStringLength<InvalidBannerException>(
            title,
            MinTitleLength,
            MaxTitleLength,
            nameof(this.Title));
}
