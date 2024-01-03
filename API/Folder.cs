namespace API;

public class Folder
{

    public string Name { get; set; }

    public string Path { get; set; }
    public string[] FolderNames { get; set; }

    // public Folder[] Folders { get; set; } = new Folder[] { };
    public string[] Files { get; set; }

}