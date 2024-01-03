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

        string path = model.Path;
        // var body  = Request.Body.ToString();
        // log the request
        // _logger.LogInformation(body);
        // var path = body.Split(":")[1];

        var folder = new Folder
        {
            Name = path,
            Path = path,
            FolderNames = Directory.GetDirectories(path),
            Files = Directory.GetFiles(path)
        };
        folders.Add(folder);
        // var files = Directory.GetFiles(path);
        // foreach (var file in files)
        // {
        //     var fileInfo = new FileInfo(file);
        //     folder.Files.Add(new File
        //     {
        //         Name = fileInfo.Name,
        //         Path = fileInfo.FullName
        //     });
        // }
        // var directories = Directory.GetDirectories(path);
        // foreach (var directory in directories)
        // {
        //     var directoryInfo = new DirectoryInfo(directory);
        //     folder.Folders.Add(new Folder
        //     {
        //         Name = directoryInfo.Name,
        //         Path = directoryInfo.FullName,
        //         Folders = new List<Folder>(),
        //         Files = new List<File>()
        //     });
        // }
        return folders;
    }

     public class FolderRequestModel
    {
        public string Path { get; set; }
    }

}