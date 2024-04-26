namespace Umeliko.Domain.Learning.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 50;
        public const int MaxUrlLength = 2048;
        public const int Zero = 0;
    }

    public class Creator
    {
        public const int MaxBioLength = 1000;
    }

    public class Banner
    {
        public const int MinTitleLength = 2;
        public const int MaxTitleLength = 50;
        public const int MaxDescriptionLength = 300;
    }

    public class Section
    {
        public const int MinTitleLength = 2;
        public const int MaxTitleLength = 50;
    }

    public class Item
    {
        public const int MinTitleLength = 2;
        public const int MaxTitleLength = 50;
    }
}