using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace API.Controllers;

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
    public IEnumerable<Folder> Post()
    {
        var folders = new List<Folder>();

        var path  = Request.Form["path"];

        var folder = new Folder
        {
            Name = path,
            Path = path,
            Folders = Directory.GetDirectories(path),
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

}