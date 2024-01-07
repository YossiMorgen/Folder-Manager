using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Logging;
using API;

[ApiController]
[Route("[controller]")]
public class FolderController : ControllerBase
{
    private readonly ILogger<FolderController> _logger;

    public FolderController(ILogger<FolderController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "GetFolder")]
    public IEnumerable<Folder> Post([FromBody] FolderRequestModel model)
    {
        var folders = new List<Folder>();

        string path = model?.Path ?? "C://";

        var folder = new Folder
        {
            Name = path,
            Path = path,
            FolderNames = Directory.GetDirectories(path).Where(folder => !IsHiddenFolder(folder)).ToArray() ,
            Files = Directory.GetFiles(path).Where(file => !IsHiddenFile(file)).ToArray()
        };

        bool IsHiddenFolder(string folderPath)
        {
            var info = new DirectoryInfo(folderPath);
            return info.Attributes.HasFlag(FileAttributes.Hidden);
        }

        bool IsHiddenFile(string filePath)
        {
            var info = new FileInfo(filePath);
            return info.Attributes.HasFlag(FileAttributes.Hidden);
        }

        folders.Add(folder);
        return folders;
    }

     public class FolderRequestModel
    {
        public string Path { get; set; }
    }

}