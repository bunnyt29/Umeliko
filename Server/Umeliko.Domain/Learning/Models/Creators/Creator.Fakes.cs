namespace Umeliko.Domain.Learning.Models.Creators;

using Bogus;
using Common.Models;

public class LearnerFakes
{
    public static class Data
    {
        public static IEnumerable<Creator> GetCreators(int count = 10)
            => Enumerable
                .Range(1, count)
                .Select(GetCreator)
                .ToList();

        public static Creator GetCreator(int totalCategories = 10)
        {
            var creator = new Faker<Creator>()
                .CustomInstantiator(f => new Creator("John", "Doe"))
                .Generate()
                .SetId(Guid.NewGuid().ToString());

            //foreach (var category in GetCategories().Take(totalCategories))
            //{
            //    creator.AddCategory(category);
            //}

            return creator;
        }
    }
}
