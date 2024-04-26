namespace Umeliko.Domain.Learning.Models.Creators;

using Common;
using Common.Models;
using System.ComponentModel.DataAnnotations;

public class Follow : Entity<int>, IAggregateRoot
{
    public Follow(string creatorId, string followerId)
    {
        this.CreatorId = creatorId;
        this.FollowerId = followerId;
    }

    [Required]
    public string CreatorId { get; set; }

    public Creator Creator { get; set; }

    [Required]
    public string FollowerId { get; set; }

    public Creator Follower { get; set; }
}
