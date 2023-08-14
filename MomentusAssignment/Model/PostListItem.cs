namespace MomentusAssignment.Model;

public class PostListItem
{
    public int Id { get; set; }

    public bool IsFavorite { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public int Comments { get; set; }
}
