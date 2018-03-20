using  System.ComponentModel.DataAnnotations;

namespace FolderFile {
    public interface INode {
        [Required]
        string Name { get; set; }
    }
}
